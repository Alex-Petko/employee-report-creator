using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfTest
{
    /// <inheritdoc />
    internal class ExcelPrintProvider : IPrintProvider
    {
        private const string WorksheetName = "Employees";
        private const string StartCellAddress = "A1";
        private const string OutputFileExtension = "xlsx";

        private readonly IConfigurations _configurations;

        public ExcelPrintProvider(IConfigurations configurations)
        {
            _configurations = configurations;
        }

        public void Print<T>(IEnumerable<T> items)
        {
            if (!items.Any())
            {
                return;
            }

            using (var excelPackage = new ExcelPackage())
            {
                var workSheet = excelPackage.Workbook.Worksheets.Add(WorksheetName);
                workSheet.Cells[StartCellAddress].LoadFromCollection(items);

                var path = Path.Combine(_configurations.ExcelOutputPath, $"{_configurations.ExcelOutputFileName}.{OutputFileExtension}");
                excelPackage.SaveAs(path);
            }
        }
    }
}
