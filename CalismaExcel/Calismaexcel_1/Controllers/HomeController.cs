using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
using System.Data;
using System.Linq;

public class HomeController : Controller
{
    // Hafızada tutulan veriler
    private static DataTable personDataTable;

    // Ana sayfa
    public IActionResult Index()
    {
        return View();
    }

    // Excel dosyası oluştur.
    /*
    * CreateExcel Metodu:
    * Bu metod, kullanıcı tarafından sağlanan kişi bilgilerini hafızada bir DataTable'a ekler
    * ve bu bilgileri içeren bir Excel dosyasını oluşturarak kullanıcıya indirme imkanı sunar.
    */
    public IActionResult CreateExcel(string name, string surname, string address, string email)
    {
        // Verileri hafızada tutulan DataTable'a ekle
        AddPersonToDataTable(name, surname, address, email);

        // Excel dosyasını oluştur ve kullanıcıya indirme
        byte[] fileContents = GenerateExcelFile();
        return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "persons.xlsx");
    }

    // DataTable'a kişi ekleyen yardımcı metot.
    /*
    * AddPersonToDataTable Metodu:
    * Bu metod, DataTable'a yeni bir kişiyi eklemek için kullanılır.
    * DataTable henüz oluşturulmamışsa, önce DataTable oluşturulur.
    */
    private void AddPersonToDataTable(string name, string surname, string address, string email)
    {
        // DataTable henüz oluşturulmamışsa oluştur
        if (personDataTable == null)
        {
            personDataTable = new DataTable();
            personDataTable.Columns.Add("Name");
            personDataTable.Columns.Add("Surname");
            personDataTable.Columns.Add("Address");
            personDataTable.Columns.Add("Email");
        }

        // Yeni bir DataRow oluştur ve DataTable'a ekle
        DataRow newRow = personDataTable.NewRow();
        newRow["Name"] = name;
        newRow["Surname"] = surname;
        newRow["Address"] = address;
        newRow["Email"] = email;
        personDataTable.Rows.Add(newRow);
    }

    // Excel dosyasını oluşturan yardımcı metot
    /*
    * GenerateExcelFile Metodu:
    * Bu metod, DataTable'daki kişi bilgilerini içeren bir Excel dosyasını oluşturur.
    */
    private byte[] GenerateExcelFile()
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

                foreach (DataRow row in personDataTable.Rows)
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
