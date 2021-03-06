﻿namespace ExcelTest
{
  using System;

  using ClosedXML.Excel;

  public class BasicTable
  {
    public BasicTable()
    {
      var wb = new XLWorkbook();
      var ws = wb.Worksheets.Add("Contacts");

      // Title
      ws.Cell("B2").Value = "Contacts";

      // First Names
      ws.Cell("B3").Value = "FName";
      ws.Cell("B4").Value = "John";
      ws.Cell("B5").Value = "Hank";
      ws.Cell("B6").Value = "Dagny";

      // Last Names
      ws.Cell("C3").Value = "LName";
      ws.Cell("C4").Value = "Galt";
      ws.Cell("C5").Value = "Rearden";
      ws.Cell("C6").Value = "Taggart";

      // Boolean
      ws.Cell("D3").Value = "Outcast";
      ws.Cell("D4").Value = true;
      ws.Cell("D5").Value = false;
      ws.Cell("D6").Value = false;

      // DateTime
      ws.Cell("E3").Value = "DOB";
      ws.Cell("E4").Value = new DateTime(1919, 1, 21);
      ws.Cell("E5").Value = new DateTime(1907, 3, 4);
      ws.Cell("E6").Value = new DateTime(1921, 12, 15);

      // Numeric
      ws.Cell("F3").Value = "Income";
      ws.Cell("F4").Value = 2000;
      ws.Cell("F5").Value = 40000;
      ws.Cell("F6").Value = 10000;

      // From worksheet
      var rngTable = ws.Range("B2:F6");

      // From another range
      var rngDates = rngTable.Range("D3:D5"); // The address is relative to rngTable (NOT the worksheet)
      var rngNumbers = rngTable.Range("E3:E5"); // The address is relative to rngTable (NOT the worksheet)

      // Using OpenXML's predefined formats
      rngDates.Style.NumberFormat.NumberFormatId = 15;

      // Using a custom format
      rngNumbers.Style.NumberFormat.Format = "$ #,##0";

      var rngHeaders = rngTable.Range("A2:E2"); // The address is relative to rngTable (NOT the worksheet)
      rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
      rngHeaders.Style.Font.Bold = true;
      rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

      rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;

      rngTable.Cell(1, 1).Style.Font.Bold = true;
      rngTable.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
      rngTable.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

      rngTable.Row(1).Merge(); // We could've also used: rngTable.Range("A1:E1").Merge()

      //Add a thick outside border
      rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

      // You can also specify the border for each side with:
      // rngTable.FirstColumn().Style.Border.LeftBorder = XLBorderStyleValues.Thick;
      // rngTable.LastColumn().Style.Border.RightBorder = XLBorderStyleValues.Thick;
      // rngTable.FirstRow().Style.Border.TopBorder = XLBorderStyleValues.Thick;
      // rngTable.LastRow().Style.Border.BottomBorder = XLBorderStyleValues.Thick;

      ws.Columns(2, 6).AdjustToContents();

      wb.SaveAs("BasicTable.xlsx");
    }
  }
}
