using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TradeMessageGenerator
{
    public static class ExcelFileGenerator
    {

        //This method will create a excel file with the messages generated and store it in /TradeWeb folder
        //with it's session ID.

        #region Public Static Methods

        public static bool CreateExcel(DataSet ds,string fullFileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet excelWorksheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                excelApp = new Excel.Application();

                // for making Excel visible
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                // Creation a new Workbook
                excelWorkbook = excelApp.Workbooks.Add(Type.Missing);

                //excelWorkbook = excelApp.Workbooks.Open(AppSettings.ExcelFilePath);

                foreach (DataTable table in ds.Tables)
                {
                    excelWorksheet = excelWorkbook.Sheets.Add();
                    excelWorksheet.Name = table.TableName;

                    for (int i = 1; i < table.Columns.Count + 1; i++)
                    {
                        excelWorksheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    }

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0; k < table.Columns.Count; k++)
                        {
                            excelWorksheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }

                    // To resize columns
                    excelCellrange = excelWorksheet.Range[excelWorksheet.Cells[1, 1], excelWorksheet.Cells[table.Rows.Count, table.Columns.Count]];
                    excelCellrange.EntireColumn.AutoFit();

                    //To format column headers
                    excelCellrange = excelWorksheet.Range[excelWorksheet.Cells[1, 1], excelWorksheet.Cells[1, table.Columns.Count]];
                    FormattingExcelCells(excelCellrange, true);

                }

                //excelWorkbook.Save();
                excelWorkbook.SaveAs(fullFileName);
                excelWorkbook.Close();
                excelApp.Quit();
                return true;
            }
            catch (Exception ex)
            {
                //handle exception
                return false;
            }
            finally
            {
                excelWorksheet = null;
                excelCellrange = null;
                excelWorkbook = null;
            }

        }

        #endregion

        #region Private Static Methods

        private static void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, bool IsFontbold)
        {
            if (IsFontbold == true)
            {
                range.Font.Bold = IsFontbold;
            }
        }

        #endregion

    }
}
