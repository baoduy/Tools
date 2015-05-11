using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlLibrary.Classes;
using Schroders.DataUtility;

namespace ControlLibrary.UserControls
{
    public partial class CompareDataGrids : UserControl
    {
        public CDataGridView DataGridA
        {
            get { return this.dataGridA; }
        }

        public CDataGridView DataGridB
        {
            get { return this.dataGridB; }
        }

        public CompareDataGrids()
        {
            InitializeComponent();
        }

        public void ClearSelection()
        {
            this.dataGridA.ClearSelection();
            this.dataGridB.ClearSelection();
        }

        public void ShowAllColumns()
        {
            this.ShowGridAllColumns(this.dataGridA);
            this.ShowGridAllColumns(this.dataGridB);
        }

        public void HideAllColumns()
        {
            this.HideGridAllColumns(this.dataGridA);
            this.HideGridAllColumns(this.dataGridB);
        }

        private void ShowGridAllColumns(DataGridView dataGrid)
        {
            dataGrid.ClearSelection();
            foreach (DataGridViewColumn col in dataGrid.Columns)
                col.Visible = true;
        }

        private void HideGridAllColumns(DataGridView dataGrid)
        {
            dataGrid.ClearSelection();
            foreach (DataGridViewColumn col in dataGrid.Columns)
                col.Visible = false;
        }

        public void ShowAllRows()
        {
            this.ClearSelection();
            for (int i = 0; i < this.DataGridA.RowCount; i++)
            {
                this.DataGridA.Rows[i].Visible = true;
                this.DataGridB.Rows[i].Visible = true;
            }
        }

        public void BeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this.dataGridA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridB)).BeginInit();
        }

        public void EndInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this.dataGridA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridB)).EndInit();
        }

        public void SuspendBinding()
        {
            ((CurrencyManager)BindingContext[this.DataGridA.DataSource]).SuspendBinding();
            ((CurrencyManager)BindingContext[this.DataGridB.DataSource]).SuspendBinding();
        }

        public void ResumeBinding()
        {
            ((CurrencyManager)BindingContext[this.DataGridA.DataSource]).ResumeBinding();
            ((CurrencyManager)BindingContext[this.DataGridB.DataSource]).ResumeBinding();
        }

        public void HideAllRows()
        {
            this.ClearSelection();
            for (int i = 0; i < this.DataGridA.RowCount; i++)
            {
                this.DataGridA.Rows[i].Visible = false;
                this.DataGridB.Rows[i].Visible = false;
            }
        }

       

        public void HidEmptyFormatRows()
        {
            this.DataGridA.HideEmptyFormatRow();
            this.DataGridB.HideEmptyFormatRow();
        }

        public void SortColumnHeader()
        {
            this.SortGridColumnHeader(this.dataGridA, string.Empty);
            this.SortGridColumnHeader(this.dataGridB, string.Empty);
        }

        public void SortColumnHeader(CompareColumnName excludeColumn)
        {
            if (excludeColumn != null)
            {
                this.SortGridColumnHeader(this.dataGridA, excludeColumn.ColumnA);
                this.SortGridColumnHeader(this.dataGridB, excludeColumn.ColumnB);
            }
            else this.SortColumnHeader();
        }


        public void SortGridColumnHeader(DataGridView dataGrid, string excludeColumn)
        {
            for (int i = 0; i < dataGrid.ColumnCount - 1; i++)
            {
                if (!string.IsNullOrEmpty(excludeColumn) &&
                      dataGrid.Columns[i].HeaderText == excludeColumn)
                    continue;

                for (int j = i + 1; j < dataGrid.ColumnCount; j++)
                {
                    if (dataGrid.Columns[i].HeaderText.Trim().ToLower().CompareTo(dataGrid.Columns[j].HeaderText.Trim().ToLower()) > 0)
                    {
                        int tmp = dataGrid.Columns[i].DisplayIndex;
                        dataGrid.Columns[i].DisplayIndex = dataGrid.Columns[j].DisplayIndex;
                        dataGrid.Columns[j].DisplayIndex = tmp;
                    }
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        public override void Refresh()
        {
            this.dataGridA.Refresh();
            this.dataGridB.Refresh();

            base.Refresh();
        }

        private void dataGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (sender == this.dataGridA)
                {
                    this.dataGridB.FirstDisplayedScrollingRowIndex = this.dataGridA.FirstDisplayedScrollingRowIndex;
                    this.dataGridB.FirstDisplayedScrollingColumnIndex = this.dataGridA.FirstDisplayedScrollingColumnIndex;
                }
                else
                {
                    this.dataGridA.FirstDisplayedScrollingRowIndex = this.dataGridB.FirstDisplayedScrollingRowIndex;
                    this.dataGridA.FirstDisplayedScrollingColumnIndex = this.dataGridB.FirstDisplayedScrollingColumnIndex;
                }
            }
            catch { }
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged(e);
        }

        //private void dataGridB_Sorted(object sender, EventArgs e)
        //{
        //    this.OnSorted(sender, e);
        //}

        public event System.EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged(this, e);
            }
            else try
                {
                    if (this.dataGridA.Focused)
                    {
                        this.dataGridB.CurrentCell = this.dataGridB.Rows[this.dataGridA.CurrentCell.RowIndex].Cells[this.dataGridA.CurrentCell.ColumnIndex];
                    }
                    else this.dataGridA.CurrentCell = this.dataGridA.Rows[this.dataGridB.CurrentCell.RowIndex].Cells[this.dataGridA.CurrentCell.ColumnIndex];
                }
                catch { }
        }

        private void dataGridA_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        //public event System.EventHandler Sorted;
        //protected virtual void OnSorted(object sender, EventArgs e)
        //{
        //    if (this.Sorted != null)
        //    {
        //        this.Sorted(sender, e);
        //    }
        //}
    }
}
