namespace ExcelTest
{
  using ClosedXML.Excel;

  class HelloWorld
  {
    public HelloWorld()
    {
      var workbook = new XLWorkbook();
      var worksheet = workbook.Worksheets.Add("Sample Sheet");
      worksheet.Cell("A1").Value = "Hello World!";
      workbook.SaveAs("HelloWorld.xlsx");
    }
  }
}
