using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using ExcelCompare.Classes;
using ExcelCompare.Properties;
using ControlLibrary.Classes;
using Schroders.DataUtility;

namespace ExcelCompare
{
    public partial class DataGridComparisionView : UserControl
    {
        DataExporter dataExporter = null;

        public DataGridComparisionView()
        {
            InitializeComponent();
        }

        CompareTable currentCompareTable = null;
        private void btCompare_Click(object sender, EventArgs e)
        {
            this.currentCompareTable = new CompareTable();
            this.currentCompareTable.TableA = this.fileCompareBrowser.ExcelFileA.DataTable;
            this.currentCompareTable.TableB = this.fileCompareBrowser.ExcelFileB.DataTable;
            this.currentCompareTable.PrimaryColumn = this.listColumnComparision.PrimaryColumn;
            this.currentCompareTable.CompareColumns = this.listColumnComparision.CompareColumns;

            this.Enabled = false;

            CompareTablesResult result = DataComparer.Compare(this.currentCompareTable);

            this.chShowDiffRow.Checked = false;
            this.ShowResult(result);

            //CompareTablesResult result = new CompareTablesResult();
            ////Copy Columns
            //result.TableA = this.currentCompareTable.TableA.Clone();
            //result.TableB = this.currentCompareTable.TableB.Clone();

            //result.DifferenceCells = new List<DifferenceCell>();

            //this.tabControl1.SelectedTab = this.tabResult;

            //this.resultDataGrids.DataGridA.DataSource = result.TableA;
            //this.resultDataGrids.DataGridB.DataSource = result.TableB;

            //Thread th = new Thread(new ThreadStart(delegate()
            //{
            //    DataComparer.DoCompare(this.currentCompareTable, result);
            //    this.ChangeBackgroundColors(result);
            //}));

            //th.IsBackground = true;
            //th.Start();

            this.Enabled = true;
        }

        private CompareTablesResult currentResult = null;
        private CompareTablesResult currentOnlyDiffRowResult = null;

        private void ShowResult(CompareTablesResult result)
        {
            this.currentResult = result;

            this.chOnlyCompareCol.Checked = false;
            this.tabControl1.SelectedTab = this.tabResult;

            this.resultDataGrids.DataGridA.DataSource = null;
            this.resultDataGrids.DataGridB.DataSource = null;

            this.resultDataGrids.DataGridA.Name = result.TableA.TableName;
            this.resultDataGrids.DataGridA.DataSource = result.TableA;

            this.resultDataGrids.DataGridB.Name = result.TableB.TableName;
            this.resultDataGrids.DataGridB.DataSource = result.TableB;

            this.SortColumns();

            this.ChangeBackgroundColors(result);

            this.resultDataGrids.Refresh();

            this.groupResultTab.Enabled = true;
            this.chOnlyCompareCol.Checked = true;
        }

        IList<int> c_FormatedCell = new List<int>();
        private void ChangeBackgroundColors(CompareTablesResult result)
        {
            this.c_FormatedCell.Clear();

            foreach (DifferenceCell diff in result.DifferenceCells)
            {
                this.resultDataGrids.DataGridA.Rows[diff.RowIndex].Cells[diff.ColumnA].Style.BackColor = Constant.DifferenceColor;
                this.resultDataGrids.DataGridB.Rows[diff.RowIndex].Cells[diff.ColumnB].Style.BackColor = Constant.DifferenceColor;

                this.c_FormatedCell.Add(diff.RowIndex);
            }

            foreach (int rowAIndex in result.NotFoundTableARowIndex)
            {
                this.resultDataGrids.DataGridA.Rows[rowAIndex].DefaultCellStyle.BackColor = Constant.NotFoundAColor;
                this.resultDataGrids.DataGridB.Rows[rowAIndex].DefaultCellStyle.BackColor = Constant.NotFoundAColor;

                this.c_FormatedCell.Add(rowAIndex);
            }

            foreach (int rowBIndex in result.NotFoundTableBRowIndex)
            {
                this.resultDataGrids.DataGridB.Rows[rowBIndex].DefaultCellStyle.BackColor = Constant.NotFoundBColor;
                this.resultDataGrids.DataGridA.Rows[rowBIndex].DefaultCellStyle.BackColor = Constant.NotFoundBColor;

                this.c_FormatedCell.Add(rowBIndex);
            }
        }

        private void SortColumns()
        {
            if (this.resultDataGrids.DataGridA.Columns.Count <= this.resultDataGrids.DataGridB.Columns.Count)
            {
                if (this.currentCompareTable.PrimaryColumn != null)
                {
                    this.resultDataGrids.SortGridColumnHeader(this.resultDataGrids.DataGridA, this.currentCompareTable.PrimaryColumn.ColumnA);
                }
                else this.resultDataGrids.SortGridColumnHeader(this.resultDataGrids.DataGridA, string.Empty);
            }
            else
            {
                if (this.currentCompareTable.PrimaryColumn != null)
                {
                    this.resultDataGrids.SortGridColumnHeader(this.resultDataGrids.DataGridB, this.currentCompareTable.PrimaryColumn.ColumnA);
                }
                else this.resultDataGrids.SortGridColumnHeader(this.resultDataGrids.DataGridB, string.Empty);
            }

            //Ordering ColumnIndex
            int index = 0;
            CompareColumnName col = null;

            if (this.currentCompareTable.PrimaryColumn != null)
            { col = this.currentCompareTable.PrimaryColumn; }
            else
            { col = this.currentCompareTable.CompareColumns[index++]; }

            do
            {
                if (this.resultDataGrids.DataGridA.Columns.Count <= this.resultDataGrids.DataGridB.Columns.Count)
                {
                    int displayIndex = this.resultDataGrids.DataGridA.Columns[col.ColumnA].DisplayIndex;
                    this.resultDataGrids.DataGridB.Columns[col.ColumnB].DisplayIndex = displayIndex;
                }
                else
                {
                    int displayIndex = this.resultDataGrids.DataGridB.Columns[col.ColumnB].DisplayIndex;
                    this.resultDataGrids.DataGridA.Columns[col.ColumnA].DisplayIndex = displayIndex;
                }

                col = this.currentCompareTable.CompareColumns[index++];
            } while (index < this.currentCompareTable.CompareColumns.Count);
        }

        private void btExportToXLS_Click(object sender, EventArgs e)
        {
            if (this.dataExporter == null)
                this.dataExporter = new DataExporter();

            FileInfo fileInfo = new FileInfo(this.fileCompareBrowser.ExcelFileA.FullFileName);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = Settings.Default.ExcelExtension;
            saveFile.FileName = string.Format(
                ExcelCompare.Properties.Settings.Default.ExportResultFileName
                , fileInfo.Name.Replace(fileInfo.Extension, ""));

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (System.IO.File.Exists(saveFile.FileName))
                    System.IO.File.Delete(saveFile.FileName);

                this.dataExporter.ExportToXLS(this.currentResult, saveFile.FileName);
                //this.dataExporter.ExportToXLS(new DataGridView[] { this.resultDataGrids.DataGridA, this.resultDataGrids.DataGridB }, saveFile.FileName);
                if (MessageBox.Show("Export Sucessful. Do you want open it?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(saveFile.FileName);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExcelToolForm form = new ExcelToolForm();
            form.ShowDialog();
        }

        bool isProgress = false;
        private void resultDataGrids_SelectionChanged(object sender, EventArgs e)
        {
            if (this.isProgress)
                return;

            this.isProgress = true;

            try
            {
                if (this.resultDataGrids.DataGridA.Focused)
                {
                    if (this.resultDataGrids.DataGridA.CurrentCell == null)
                        return;

                    this.resultDataGrids.DataGridB.ClearSelection();

                    foreach (DataGridViewCell cell in this.resultDataGrids.DataGridA.SelectedCells)
                    {
                        string colAName = this.resultDataGrids.DataGridA.Columns[cell.ColumnIndex].Name;
                        string colBName = this.currentCompareTable.CompareColumns.GetColumnB(colAName);

                        if (string.IsNullOrEmpty(colBName))
                        {
                            continue;
                        }
                        else this.resultDataGrids.DataGridB[colBName, cell.RowIndex].Selected = true;
                    }
                }
                else if (this.resultDataGrids.DataGridB.Focused)
                {
                    if (this.resultDataGrids.DataGridB.CurrentCell == null)
                        return;

                    this.resultDataGrids.DataGridA.ClearSelection();

                    foreach (DataGridViewCell cell in this.resultDataGrids.DataGridB.SelectedCells)
                    {
                        string colBName = this.resultDataGrids.DataGridB.Columns[cell.ColumnIndex].Name;
                        string colAName = this.currentCompareTable.CompareColumns.GetColumnA(colBName);
                        if (string.IsNullOrEmpty(colAName))
                        {
                            continue;
                        }
                        else this.resultDataGrids.DataGridA[colAName, cell.RowIndex].Selected = true;
                    }
                }
            }
            catch { }

            this.isProgress = false;
        }

        private string GetBasicCharacters(string value)
        {
            return value.ToLower().Replace(" ", "").Replace("_", "").Replace("//", "").Replace("\\", "");
        }

        private void AutoAddCompareColumns()
        {
            if (this.listColumnComparision.ColumnsA == null
                || this.listColumnComparision.ColumnsB == null)
                return;

            this.groupResultTab.Enabled = false;
            this.listColumnComparision.Enabled = false;
            this.listColumnComparision.Visible = false;

            if (this.listColumnComparision.ColumnsA.Count > 0
                && this.listColumnComparision.ColumnsB.Count > 0)
            {
                this.listColumnComparision.ClearControl();

                foreach (DataColumn colA in this.listColumnComparision.ColumnsA)
                {
                    foreach (DataColumn colB in this.listColumnComparision.ColumnsB)
                    {
                        if (this.GetBasicCharacters(colA.ColumnName) == this.GetBasicCharacters(colB.ColumnName))
                        {
                            this.listColumnComparision.AddControl(colA, colB);
                            break;
                        }
                    }
                }
            }

            this.listColumnComparision.Enabled = true;
            this.listColumnComparision.Visible = false;
        }

        private void chOnlyCompareColumns_CheckedChanged(object sender, EventArgs e)
        {
            this.resultDataGrids.ClearSelection();

            if (this.chOnlyCompareCol.Checked)
            {
                this.chShowOnlyDiffCol.Checked = false;
                this.resultDataGrids.HideAllColumns();

                if (this.currentCompareTable.PrimaryColumn != null)
                {
                    this.resultDataGrids.DataGridA.Columns[this.currentCompareTable.PrimaryColumn.ColumnA].Visible = true;
                    this.resultDataGrids.DataGridB.Columns[this.currentCompareTable.PrimaryColumn.ColumnB].Visible = true;
                }

                foreach (CompareColumnName col in this.currentCompareTable.CompareColumns)
                {
                    this.resultDataGrids.DataGridA.Columns[col.ColumnA].Visible = true;
                    this.resultDataGrids.DataGridB.Columns[col.ColumnB].Visible = true;
                }
            }
            else
            {
                this.resultDataGrids.ShowAllColumns();
            }
        }

        private void chShowOnlyDiffCol_CheckedChanged(object sender, EventArgs e)
        {
            this.resultDataGrids.BeginInit();
            this.resultDataGrids.ClearSelection();

            if (this.chShowOnlyDiffCol.Checked)
            {
                this.chOnlyCompareCol.Checked = false;
                this.resultDataGrids.HideAllColumns();

                //GridA
                foreach (DataGridViewColumn column in this.resultDataGrids.DataGridA.Columns)
                {
                    if (column.Name == this.currentCompareTable.PrimaryColumn.ColumnA)
                    {
                        column.Visible = true;
                        continue;
                    }
                    foreach (DifferenceCell cell in this.currentResult.DifferenceCells)
                    {
                        if (cell.ColumnA == column.Name)
                        {
                            column.Visible = true;
                            break;
                        }
                    }
                }

                //GridB
                foreach (DataGridViewColumn column in this.resultDataGrids.DataGridB.Columns)
                {
                    if (column.Name == this.currentCompareTable.PrimaryColumn.ColumnB)
                    {
                        column.Visible = true;
                        continue;
                    }
                    foreach (DifferenceCell cell in this.currentResult.DifferenceCells)
                    {
                        if (cell.ColumnB == column.Name)
                        {
                            column.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                this.resultDataGrids.ShowAllColumns();
            }

            this.resultDataGrids.EndInit();
        }

        private void chShowDiffRow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chShowDiffRow.Checked)
            {
                if (this.currentOnlyDiffRowResult == null)
                    this.currentOnlyDiffRowResult = this.currentResult.GetOnlyDifferenceRow();

                this.ShowResult(this.currentOnlyDiffRowResult);
            }
            else this.ShowResult(this.currentResult);
        }

        private void lbFileA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == this.lbFileA)
                Process.Start(this.fileCompareBrowser.ExcelFileA.FullFileName);
            else Process.Start(this.fileCompareBrowser.ExcelFileB.FullFileName);
        }

        private void fileCompareBrowser_SelectionChanged(object sender, ExcelCompare.Classes.Events.FileSelectionEventArgs e)
        {
            if (e.FileTypeName == ExcelCompare.Classes.Events.FileTypeName.FileA)
            {
                this.lbFileA.Text = string.Format("{0} : {1}", e.ColumnControl.FileName, e.ColumnControl.SheetName);
                this.toolTip.SetToolTip(this.lbFileA, e.ColumnControl.FullFileName);

                this.listColumnComparision.SheetAName = e.ColumnControl.SheetName;
                this.listColumnComparision.ColumnsA = e.ColumnControl.Columns;
                this.oriDataGrids.DataGridA.DataSource = e.ColumnControl.DataTable;
            }
            else
            {
                this.lbFileB.Text = string.Format("{0} : {1}", e.ColumnControl.FileName, e.ColumnControl.SheetName);
                this.toolTip.SetToolTip(this.lbFileB, e.ColumnControl.FullFileName);

                this.listColumnComparision.SheetBName = e.ColumnControl.SheetName;
                this.listColumnComparision.ColumnsB = e.ColumnControl.Columns;
                this.oriDataGrids.DataGridB.DataSource = e.ColumnControl.DataTable;
            }
            this.AutoAddCompareColumns();
        }
    }
}
