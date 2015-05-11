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
    public partial class ListColumnComparision : UserControl
    {
        IList<DataColumn> columnsA;
        public IList<DataColumn> ColumnsA
        {
            get { return this.columnsA; }
            set
            {
                this.columnsA = value;
                this.SetColumnsToControls();
            }
        }

        IList<DataColumn> columnsB;
        public IList<DataColumn> ColumnsB
        {
            get { return this.columnsB; }
            set
            {
                this.columnsB = value;
                this.SetColumnsToControls();
            }
        }

        public CompareColumnName PrimaryColumn
        {
            get
            {
                if (this.grPrimary.Enabled &&
                    this.primaryCC.SelectedColumnA != null && this.primaryCC.SelectedColumnB != null)
                {
                    return new CompareColumnName(
                        this.primaryCC.SelectedColumnA.ColumnName,
                        this.primaryCC.SelectedColumnB.ColumnName);
                }
                return null;
            }
        }

        CompareColumnNameCollection compareColumns;
        public CompareColumnNameCollection CompareColumns
        {
            get
            {
                CompareColumnNameCollection columns = this.columnCollection.CompareColumns;
                
                if (this.columnsA == null || this.columnsB == null)
                    return columns;

                if (columns.Count <= 0)
                {
                    if (this.compareColumns == null)
                    {
                        this.compareColumns = new CompareColumnNameCollection();

                        int columnCount = this.ColumnsA.Count > this.ColumnsB.Count ? this.ColumnsB.Count : this.ColumnsA.Count;
                        for (int i = 0; i < columnCount; i++)
                        {
                            this.compareColumns.Add(new CompareColumnName(this.ColumnsA[i].ColumnName, this.ColumnsB[i].ColumnName));
                        }
                    }

                    columns = this.compareColumns;
                }

                return columns;
            }
        }

        public string SheetAName
        {
            get { return this.lbSheetA.Text; }
            set
            {
                this.lbSheetA.Text = value;
                this.columnCollection.SheetAName = value;
            }
        }

        public string SheetBName
        {
            get { return this.lbSheetB.Text; }
            set
            {
                this.lbSheetB.Text = value;
                this.columnCollection.SheetBName = value;
            }
        }

        public ListColumnComparision()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add compare column
        /// </summary>
        /// <param name="columnA"></param>
        /// <param name="columnB"></param>
        public void AddControl(DataColumn columnA, DataColumn columnB)
        {
            this.columnCollection.Add(columnA, columnB);
        }

        /// <summary>
        /// Clear all compare columns
        /// </summary>
        public void ClearControl()
        {
            this.columnCollection.Clear();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dataSpceialColumn_CheckedChanged(this, e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            this.lbSheetA.Width = this.primaryCC.Width / 2;
        }

        //IList<ColumnComparison> listCC = null;
        //private void btAdd_Click(object sender, EventArgs e)
        //{
        //    this.Add(null, null);
        //}

        //private void SetEnabledButton()
        //{
        //    if (this.listCC != null)
        //    {
        //        this.btRemove.Enabled = this.listCC.Count > 1;

        //        if (this.ColumnsA != null && this.ColumnsB != null)
        //        {
        //            this.btAdd.Enabled = !(this.listCC.Count == this.ColumnsA.Count || this.listCC.Count == this.ColumnsB.Count);
        //        }
        //    }
        //}

        //private void btRemove_Click(object sender, EventArgs e)
        //{
        //    if (this.listCC.Count > 0)
        //    {
        //        ColumnComparison colCC = this.listCC[this.listCC.Count - 1];

        //        this.listCC.RemoveAt(this.listCC.Count - 1);

        //        this.tableCompareColumns.Controls.Remove(colCC);
        //        colCC.Dispose();

        //        this.tableCompareColumns.SetRow(this.pnButton, this.tableCompareColumns.GetRow(this.pnButton) - 1);

        //        //this.SetEnabledButton();
        //    }
        //}

        private void SetColumnsToControls()
        {
            #region Set Column
            this.primaryCC.ColumnsA = this.ColumnsA;
            this.primaryCC.ColumnsB = this.ColumnsB;

            this.columnCollection.ColumnsA = this.ColumnsA;
            this.columnCollection.ColumnsB = this.ColumnsB;
            #endregion
        }

        private void dataSpceialColumn_CheckedChanged(object sender, EventArgs e)
        {
            this.columnCollection.Enabled = this.dataSpceialColumn.Checked;
            this.columnCollection.BringToFront();
        }

        private void dataPrimaryKey_CheckedChanged(object sender, EventArgs e)
        {
            this.grPrimary.Enabled = this.dataPrimaryKey.Checked;
        }


        //private void tableCompareColumns_ControlAdded(object sender, ControlEventArgs e)
        //{
        //    if (this.compareColumns != null)
        //        this.compareColumns.Clear();

        //    this.SetEnabledButton();
        //}

        //private void tableCompareColumns_ControlRemoved(object sender, ControlEventArgs e)
        //{
        //    if (this.compareColumns != null)
        //        this.compareColumns.Clear();

        //    this.SetEnabledButton();
        //}
    }
}
