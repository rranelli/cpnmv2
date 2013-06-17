using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chemtech.CPNM.Presentation;
using Chemtech.CPNM.BR.Rules;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace Chemtech.CPNM.AppWord.Application
{
    public class WordHeimdall
    {
        private const string CpnmCriteria = "CPNM(?:VAL|ADR)";
        private const string CpnmValueDocVarPreffix = "CPNMVAL";
        private const string CpnmRefDocVarPreffix = "CPNMADR";
        private static Regex _isFromCpnmRegex;

        private readonly Document _activeDocument;
        private readonly Range _range;

        public WordHeimdall()
        {
            _activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            _range = Globals.ThisAddIn.Application.ActiveWindow.Selection.Range;
            _isFromCpnmRegex = new Regex("^" + CpnmCriteria + @"(\d*)$");
        }

        public void InsertReference()
        {
            var getReference = new GetReference();
            getReference.ShowDialog();

            if (getReference.DialogResult == DialogResult.OK)
            {
                var handler = new AddressHandler
                                     {
                                         PropValue = getReference.SelectedPropValue,
                                         FormatType = getReference.SelectedFormat,
                                         UnitOfMeasure = getReference.SelectedUnit
                                     };

                var nextIndex = GetNextRefIndex();
                var refDocVarName = CpnmRefDocVarPreffix + nextIndex;
                var valDocVarName = CpnmValueDocVarPreffix + nextIndex;

                _activeDocument.Variables.Add(refDocVarName, handler.Address);
                _activeDocument.Variables.Add(valDocVarName, handler.GetFormatedValue());

                var newField = _range.Fields.Add(_range, WdFieldType.wdFieldDocVariable, valDocVarName, true);
                newField.Update();
            }
        }

        public void FetchAllDocVars()
        {
            (from Variable docVar in _activeDocument.Variables //gotta love linQ s2.
             where IsManagedRefDocVar(docVar)
             select docVar).ToList().ForEach(FetchDocVar);
        }

        public void FetchDocVar(Variable docVar)
        {
            var value = new AddressHandler(docVar.Value).GetFormatedValue();
            var valueDocVarName =
                docVar.Name.Replace(CpnmRefDocVarPreffix,
                                    CpnmValueDocVarPreffix);

            _activeDocument.Variables[valueDocVarName].Value = value;
        }

        public int GetNextRefIndex()
        {
            int i = (from Variable docVar in _activeDocument.Variables 
                     where IsManagedRefDocVar(docVar) 
                     select ExtractIndex(docVar)).Concat(new[] {0}).Max();

            return i + 1;
        }

        public int ExtractIndex(Variable docVar)
        {
            var matches = _isFromCpnmRegex.Matches(docVar.Name);
            return int.Parse(matches[0].Groups[1].Value);
        }

        private static bool IsManagedRefDocVar(Variable thisDocVar)
        {
            return thisDocVar.Name.Contains(CpnmRefDocVarPreffix);
        }
    }
}