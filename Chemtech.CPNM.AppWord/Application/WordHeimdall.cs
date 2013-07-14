// WordHeimdall.cs
// Projeto: Chemtech.CPNM.AppWord
// Solution: Chemtech.CPNM
// Implementado por: Renan
// Criado em: 16/06/2013
// Modificado em: 18/06/2013 : 1:52 AM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Chemtech.CPNM.BR.Logic;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Presentation.Forms;
using Chemtech.Cpnm.Data.Addresses;
using Microsoft.Office.Interop.Word;

namespace Chemtech.CPNM.AppWord.Application
{
    public class WordHeimdall // essa classe funciona como um controller para a "view" do Word.
    {
        private const string CpnmCriteria = "CPNM(?:VAL|ADR)";
        private const string CpnmValueDocVarPreffix = "CPNMVAL";
        private const string CpnmRefDocVarPreffix = "CPNMADR";

        private static readonly Regex IsFromCpnmRegex = new Regex("^" + CpnmCriteria + @"(\d*)$");
        private readonly Document _activeDocument;
        private readonly Range _range;

        private IAddressFactory addressFactory;

        public WordHeimdall()
        {
            _activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            _range = Globals.ThisAddIn.Application.ActiveWindow.Selection.Range;
        }

        // Metodos que operam sobre o _activeDocument
        public void InsertReference()
        {
            var getReference = new GetReference();
            getReference.ShowDialog();

            if (getReference.DialogResult != DialogResult.OK) return;
            var handler = new AddressHandler
                              {
                                  Item = getReference.SelectedItem,
                                  PropValue = getReference.SelectedPropValue,
                                  FormatType = getReference.SelectedFormat,
                                  UnitOfMeasure = getReference.SelectedUnit
                              };

            if (getReference.IsMetaDataSelected)
                handler.ThisAddressType =
                    (AddressHandler.AddressType) Enum.Parse(typeof (AddressHandler.AddressType), getReference.SelectedMetaData);

            int nextIndex = GetNextRefIndex();
            string refDocVarName = CpnmRefDocVarPreffix + nextIndex;
            string valDocVarName = CpnmValueDocVarPreffix + nextIndex;

            _activeDocument.Variables.Add(refDocVarName, handler.Address);
            _activeDocument.Variables.Add(valDocVarName, handler.GetFormatedValue());

            Field newField = _range.Fields.Add(_range, WdFieldType.wdFieldDocVariable, valDocVarName, true);
            newField.Update();
        }

        public void ReuseReferences()
        {
            IEnumerable<AddressHandler> allHandlers = GetAllAddressHandlers();

            List<Item> existantItems = (from handler in allHandlers select handler.Item).ToList();
            var reuseForm = new SetUpReuse(existantItems);
            reuseForm.ShowDialog();

            if (reuseForm.DialogResult == DialogResult.OK)
            {
                var reuseHandler = new ReuseHandler
                                       {
                                           ReusePairs = reuseForm.ReusePairs,
                                           IsSelectionRestricted = reuseForm.IsSelectionOnly
                                       };

                ExecuteReuse(reuseHandler);
                _activeDocument.Fields.Update();
            }
        }

        public void FetchAllDocVars()
        {
            (from Variable docVar in _activeDocument.Variables
             //gotta love linQ s2.
             where IsManagedRefDocVar(docVar)
             select docVar).ToList().ForEach(FetchDocVar);
        }

        // ########
        // Helpers

        private IEnumerable<AddressHandler> GetAllAddressHandlers()
        {
            return (from Variable docVar in _activeDocument.Variables
                    where IsManagedRefDocVar(docVar)
                    select docVar)
                .Select(refdocvar => new AddressHandler(refdocvar.Value))
                .ToList();
        }

        private void FetchDocVar(Variable refDocVar)
        {
            string value = new AddressHandler(refDocVar.Value).GetFormatedValue();
            string valueDocVarName =
                refDocVar.Name.Replace(CpnmRefDocVarPreffix,
                                       CpnmValueDocVarPreffix);

            Variable valueDocVar = _activeDocument.Variables[valueDocVarName];
            valueDocVar.Value = value;
        }

        private void ExecuteReuse(ReuseHandler reuseHandler)
        {
            //TODO: Implementar a troca de campos apenas na regiao selecionada.
            List<Variable> docVarsToMap = (from Variable docvar in _activeDocument.Variables
                                           where IsManagedRefDocVar(docvar)
                                           select docvar).ToList();

            docVarsToMap.ForEach(refDocVar =>
                                     {
                                         refDocVar.Value = reuseHandler.SwapAddress(refDocVar.Value);
                                         FetchDocVar(refDocVar);
                                     });
        }

        private int GetNextRefIndex()
        {
            int i = (from Variable docVar in _activeDocument.Variables
                     where IsManagedRefDocVar(docVar)
                     select ExtractIndex(docVar)).Concat(new[] {0}).Max();

            return i + 1;
        }

        private static int ExtractIndex(Variable docVar)
        {
            MatchCollection matches = IsFromCpnmRegex.Matches(docVar.Name);
            return int.Parse(matches[0].Groups[1].Value);
        }

        private static bool IsManagedRefDocVar(Variable thisDocVar)
        {
            return thisDocVar.Name.Contains(CpnmRefDocVarPreffix);
        }
    }
}