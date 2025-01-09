using System.Text;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;

namespace ReadExcelAndParseToScript;

public static class CategoryExcelHelper
{

    public static List<Category> FillCategoryFromExcel(ISheet worksheet)
    {
        var result = new List<Category>(worksheet.LastRowNum);
        
        var nameTable = -1;
        var idTable = -1;
        var orderTable = -1;
        var descriptionTable = -1;
        var sysnameTable = -1;
        var testSampleTable = -1;
        var complaintCategoryTable = -1;
        var sb = new StringBuilder();

        for (var rowIndex = 0; rowIndex <= worksheet.LastRowNum; rowIndex++)
        {
            var row = worksheet.GetRow(rowIndex);
            if (rowIndex == 0)
            {
                nameTable = row.Cells.First(x => x.StringCellValue == "Name").ColumnIndex;
                //orderTable = row.Cells.First(x => x.StringCellValue == "Order").ColumnIndex;
                //complaintCategoryTable = row.Cells.First(x => x.StringCellValue == "ComplaintCategoryId").ColumnIndex;
                idTable = row.Cells.First(x => x.StringCellValue == "Id").ColumnIndex;
                descriptionTable = row.Cells.First(x => x.StringCellValue == "Description").ColumnIndex;
                //sysnameTable = row.Cells.First(x => x.StringCellValue == "Sysname").ColumnIndex;
                //testSampleTable = row.Cells.First(x => x.StringCellValue == "TestSample").ColumnIndex;
                continue;
            }

            if (row == null || row.Cells == null || !row.Cells.Any())
            {
                break;
            }
            var name = row.Cells[nameTable].StringCellValue ?? "_EMPTY_NAME_";
            var description = row.Cells[descriptionTable].StringCellValue ?? "_EMPTY_NAME_";
            //var order = (int)row.Cells[orderTable].NumericCellValue;
            var complaintCategory = (int)row.Cells[idTable].NumericCellValue;
            //var sysname = row.Cells[sysnameTable].StringCellValue.Trim() ?? "_EMPTY_SYSNAME_";
            //var testSample = row.Cells[testSampleTable].StringCellValue ?? "_EMPTY_TEST_SAMPLE_";
            result.Add(new Category()
            {
                Description = description.Trim(),
                Id = complaintCategory,
                Name = name.Trim()
            });
        }

        return result;

    }
    
    
    
}