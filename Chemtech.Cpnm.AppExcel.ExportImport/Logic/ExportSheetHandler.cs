using System.Diagnostics;
using System.Linq;
using Chemtech.CPNM.Model.Domain;
using Chemtech.CPNM.Data.Repositories;
using Microsoft.Office.Interop.Excel;

namespace Chemtech.Cpnm.AppExcel.ExportImport.Logic
{
    public static class ExportSheetHandler
    {
        private const int PropCol = 1;
        private const int UnitCol = 2;
        private const int ItemColStart = 3;

        private const int HeaderRow = 2;

        public static void FormatExport(Worksheet exportWorksheet, ExportDefinition exportDefinition)
        {
            Debug.Assert(exportDefinition.ItemTypes != null && exportDefinition.Properties != null);

            var j = ItemColStart;
            if (exportDefinition.FetchAllItems)
                exportDefinition.Items.
                    ToList().ForEach(it =>
                                          {
                                              exportWorksheet.Cells[HeaderRow, j].Value = it.Name;
                                              j++;
                                          });
            var k = HeaderRow + 1;
            exportDefinition.Properties.
                ToList().ForEach(prop =>
                                        {
                                            exportWorksheet.Cells[k, PropCol].Value = prop.Name;
                                            if (prop.DefaultUnit != null)
                                                exportWorksheet.Cells[k, UnitCol].Value = prop.DefaultUnit.Name;
                                            k++;
                                        });
        }

        public static void ImportData(Worksheet exportWorksheet)
        {

            var itemRepository = new ItemRepository();
            var propertyRepository = new PropertyRepository();
            var unitRepository = new UnitOfMeasureRepository();

            var j = ItemColStart;
            while (exportWorksheet.Cells[HeaderRow, j].Text != "")
            {
                var itemName = exportWorksheet.Cells[HeaderRow, j].Text;
                Item thisItem = itemRepository.GetByName(itemName);

                if (thisItem != null)
                {
                    var i = HeaderRow + 1;
                    while (exportWorksheet.Cells[i, PropCol].Text != "")
                    {
                        var thisProperty = propertyRepository.GetByName((string)exportWorksheet.Cells[i, PropCol].Value);
                        var thisUnit = unitRepository.GetByName((string)exportWorksheet.Cells[i, UnitCol].Value);
                        var thisPval = thisItem.GetPropValue(thisProperty);

                        if (thisPval != null)
                            exportWorksheet.Cells[i, j].Value = thisPval.FormatedValue(thisUnit, PropValue.FormatType.Value);
                        i++;
                    }
                }
                j++;
            }
        }

        public static void ExportData(Worksheet exportWorksheet)
        {
            // TODO: Tratar casos para a exportacao quando o item nao existe no DB. Como faremos?

            var itemRepository = new ItemRepository();
            var propertyRepository = new PropertyRepository();
            var unitRepository = new UnitOfMeasureRepository();
            var pvalRepository = new PropValueRepository();

            var j = ItemColStart;
            while (exportWorksheet.Cells[HeaderRow, j].Text != "")
            {
                var itemName = exportWorksheet.Cells[HeaderRow, j].Text;
                Item thisItem = itemRepository.GetByName(itemName);

                var i = HeaderRow + 1;
                while (exportWorksheet.Cells[i, PropCol].Text != "")
                {
                    var thisProperty = propertyRepository.GetByName((string)exportWorksheet.Cells[i, PropCol].Value);
                    var thisUnit = unitRepository.GetByName((string)exportWorksheet.Cells[i, UnitCol].Value);
                    var thisPval = thisItem.GetPropValue(thisProperty) ?? thisItem.GetNewPropValue(thisProperty);

                    //TODO: Inserir valor na propvalue em uma dada unidade
                    thisPval.Value = (string)exportWorksheet.Cells[i, j].Text;
                    if(thisPval.Value != "") pvalRepository.Update(thisPval);

                    i++;
                }

                j++;
            }
        }
    }
}