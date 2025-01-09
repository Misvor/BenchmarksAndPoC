// See https://aka.ms/new-console-template for more information

using System.Text;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Tls;
using ReadExcelAndParseToScript;

Console.OutputEncoding = System.Text.Encoding.Unicode;
var fileStream = new FileStream(@"C:\Users\misvor\Downloads\CategoryData.xlsx", FileMode.Open);

var workBook = WorkbookFactory.Create(fileStream);
var worksheetCategory = workBook.GetSheetAt((int)Sheets.Category);

var categories = CategoryExcelHelper.FillCategoryFromExcel(worksheetCategory);
var worksheet = workBook.GetSheetAt((int)Sheets.Complaints); 

var nameTable = -1;
var idTable = -1;
var orderTable = -1;
var descriptionTable = -1;
var sysnameTable = -1;
var testSampleTable = -1;
var complaintCategoryTable = -1;
var sb = new StringBuilder();

foreach (var category in categories)
{
    sb.Append(
        $"""
         DECLARE @{category.Name} INT;
                 select @{category.Name} = Id from ComplaintCategories where Name = '{category.Name}'
         """);
    sb.AppendLine(Environment.NewLine);
}


for (var rowIndex = 0; rowIndex <= worksheet.LastRowNum; rowIndex++)
{
    var row = worksheet.GetRow(rowIndex);
    if (rowIndex == 0)
    {
        nameTable = row.Cells.First(x => x.StringCellValue == "Name").ColumnIndex;
        orderTable = row.Cells.First(x => x.StringCellValue == "Order").ColumnIndex;
        complaintCategoryTable = row.Cells.First(x => x.StringCellValue == "ComplaintCategoryId").ColumnIndex;
        //descriptionTable = row.Cells.First(x => x.StringCellValue == "Description").ColumnIndex;
        sysnameTable = row.Cells.First(x => x.StringCellValue == "Sysname").ColumnIndex;
        testSampleTable = row.Cells.First(x => x.StringCellValue == "TestSample").ColumnIndex;
        continue;
    }

    if (row == null || row.Cells == null || !row.Cells.Any())
    {
        break;
    }
    var name = row.Cells[nameTable].StringCellValue ?? "_EMPTY_NAME_";
    //var description = row.Cells[descriptionTable].StringCellValue ?? "_EMPTY_NAME_";
    var order = (int)row.Cells[orderTable].NumericCellValue;
    var complaintCategory = (int)row.Cells[complaintCategoryTable].NumericCellValue;
    var sysname = row.Cells[sysnameTable].StringCellValue.Trim() ?? "_EMPTY_SYSNAME_";
    var testSample = row.Cells[testSampleTable].StringCellValue ?? "_EMPTY_TEST_SAMPLE_";

    //sb.FormComplaintCategoryString(name.Trim(), description.Trim(), order, testSample.Trim());
    sb.FormComplaintString(name.Trim(), order, categories.First(x=> x.Id == complaintCategory).Name, sysname.Trim(), testSample.Trim());
    sb.AppendLine(Environment.NewLine);
}


File.WriteAllText("ComplaintScript.txt", sb.ToString());
Console.WriteLine(sb.ToString());
Console.ReadKey();

enum Sheets
{
    Category = 0,
    Complaints = 1
}