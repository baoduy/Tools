using System;
using System.Collections.Generic;

using System.Text;
using System.Reflection;
using System.Data;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ControlLibrary.Classes
{
    public class DataExporter
    {
        public DataExporter()
        {
            ResetProcessingInfo();
        }

        private void ResetProcessingInfo()
        {
            this.ProcessingTable = ProcessTable.None;
            this.ProcessingRowIndex = -1;
        }

        public enum ProcessTable
        { None = 0, TableA = 1, TableB = 2 }

        ProcessTable processingTable;

        public ProcessTable ProcessingTable
        {
            get { return processingTable; }
            private set { processingTable = value; }
        }

        int processingRowIndex;
        public int ProcessingRowIndex
        {
            get { return processingRowIndex; }
            private set { processingRowIndex = value; }
        }

        #region Data Table
        public void ExportToXLS(CompareTablesResult result, string fullNameFile)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add(Missing.Value);

            #region TableA
            this.ProcessingTable = DataExporter.ProcessTable.TableA;
            Worksheet workSheetA = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);
            PlushDataToSheet(result.TableA, workSheetA);
            #endregion

            #region Table B
            this.ProcessingTable = DataExporter.ProcessTable.TableB;
            Worksheet workSheetB = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(2);
            PlushDataToSheet(result.TableB, workSheetB);
            #endregion

            #region Format Back Color
            foreach (DifferenceCell cell in result.DifferenceCells)
            {
                int rIndex = cell.RowIndex + 2;
                int colAIndex = result.TableA.Columns.IndexOf(cell.ColumnA) + 1;
                int colBIndex = result.TableB.Columns.IndexOf(cell.ColumnB) + 1;

                ((Range)workSheetA.Cells[rIndex, colAIndex]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                ((Range)workSheetB.Cells[rIndex, colBIndex]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            }
            #endregion

            workbook.SaveAs(fullNameFile, XlFileFormat.xlExcel8, null, null, null, false, XlSaveAsAccessMode.xlExclusive, null, null, null, null, null);
            workbook.Close(true, fullNameFile, workbook);
            excelApp.Quit();

            DataConverter.ReleaseCOMObj(workSheetA);
            DataConverter.ReleaseCOMObj(workSheetB);
            DataConverter.ReleaseCOMObj(workbook);
            DataConverter.ReleaseCOMObj(excelApp);

            this.ResetProcessingInfo();
        }

        private void PlushDataToSheet(System.Data.DataTable table, Worksheet workSheet)
        {
            this.ProcessingRowIndex = 1;
            int colunmIndex = 1;
            workSheet.Name = table.TableName;

            // Plush columns
            foreach (DataColumn col in table.Columns)
            {
                workSheet.Cells[this.ProcessingRowIndex, colunmIndex] = col.ColumnName;
                ((Range)workSheet.Cells[this.ProcessingRowIndex, colunmIndex]).Font.Bold = true;
                ((Range)workSheet.Cells[this.ProcessingRowIndex, colunmIndex]).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); ;

                colunmIndex++;
            }

            //Plush Data
            this.ProcessingRowIndex++;
            colunmIndex = 1;

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    workSheet.Cells[this.ProcessingRowIndex, colunmIndex++] = row[col];
                }
                this.ProcessingRowIndex++;
                colunmIndex = 1;
            }
        }
        #endregion

        #region DataGridView
        public void ExportToXLS(DataGridView[] dataGrids, string fullNameFile)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add(Missing.Value);

            int sheetCount = 1;
            foreach (DataGridView grid in dataGrids)
            {
                this.ProcessingTable = (ProcessTable)sheetCount;
                Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(sheetCount++);
                PlushDataToSheet(grid, workSheet);
            }

            try
            {
                workbook.SaveAs(fullNameFile, XlFileFormat.xlExcel8, null, null, null, false, XlSaveAsAccessMode.xlExclusive, null, null, null, null, null);
                workbook.Close(true, fullNameFile, workbook);
            }
            catch { }

            excelApp.Quit();

            DataConverter.ReleaseCOMObj(workbook);
            DataConverter.ReleaseCOMObj(excelApp);

            this.ResetProcessingInfo();
        }

        private void PlushDataToSheet(DataGridView dataGrid, Worksheet workSheet)
        {
            this.ProcessingRowIndex = 1;
            int colunmIndex = 1;

            try
            {
                workSheet.Name = dataGrid.Name;
            }
            catch { }

            // Plush columns
            DataGridViewColumn col = dataGrid.Columns.GetFirstColumn(DataGridViewElementStates.None);
            do
            {
                if (col.Visible)
                {
                    workSheet.Cells[this.ProcessingRowIndex, colunmIndex] = col.HeaderText;
                    ((Range)workSheet.Cells[this.ProcessingRowIndex, colunmIndex]).Font.Bold = true;
                    ((Range)workSheet.Cells[this.ProcessingRowIndex, colunmIndex]).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue); ;

                    colunmIndex++;
                }

                col = dataGrid.Columns.GetNextColumn(col, DataGridViewElementStates.None, DataGridViewElementStates.None);

            } while (col != null);

            //Plush Data
            this.ProcessingRowIndex++;
            colunmIndex = 1;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                col = dataGrid.Columns.GetFirstColumn(DataGridViewElementStates.None);
                do
                {
                    if (col.Visible)
                    {
                        DataGridViewCell cell = row.Cells[col.Name];
                        workSheet.Cells[this.ProcessingRowIndex, colunmIndex] = cell.Value;
                        if (!cell.Style.BackColor.IsEmpty)
                        {
                            ((Range)workSheet.Cells[this.ProcessingRowIndex, colunmIndex]).Interior.Color = System.Drawing.ColorTranslator.ToOle(cell.Style.BackColor);
                        }
                        else if (!cell.OwningRow.DefaultCellStyle.BackColor.IsEmpty)
                        {
                            ((Range)workSheet.Cells[this.ProcessingRowIndex, colunmIndex]).Interior.Color = System.Drawing.ColorTranslator.ToOle(cell.OwningRow.DefaultCellStyle.BackColor);
                        }

                        colunmIndex++;
                    }
                    col = dataGrid.Columns.GetNextColumn(col, DataGridViewElementStates.None, DataGridViewElementStates.None);

                } while (col != null);

                this.ProcessingRowIndex++;
                colunmIndex = 1;
            }
        }
        #endregion
    }
}
