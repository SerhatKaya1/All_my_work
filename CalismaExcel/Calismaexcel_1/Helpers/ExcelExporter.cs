using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.IO;
using System.Linq;

public static class ExcelHelper
{
    public static byte[] GenerateExcelFile(DataTable dataTable)
    {
        using (MemoryStream memStream = new MemoryStream())
        {
            // OpenXML ile Excel dosyası oluştur
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(memStream, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);
            }

            // DataTable'daki verileri Excel dosyasına ekle
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(memStream, true))
            {
                WorksheetPart worksheetPart = document.WorkbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Row excelRow = new Row();
                    foreach (var cellValue in row.ItemArray)
                    {
                        Cell excelCell = new Cell(new CellValue(cellValue.ToString()));
                        excelRow.Append(excelCell);
                    }
                    sheetData.AppendChild(excelRow);
                }
            }

            // MemoryStream'dan byte dizisine çevir
            return memStream.ToArray();
        }
    }
}
