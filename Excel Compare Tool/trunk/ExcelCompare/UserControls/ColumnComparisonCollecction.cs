using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ExcelCompare.UserControls
{
    public partial class ColumnComparisonCollecction : UserControl
    {
        public string SheetAName
        {
            get { return this.lbSheetA.Text; }
            set { this.lbSheetA.Text = value; }
        }

        public string SheetBName
        {
            get { return this.lbSheetB.Text; }
            set { this.lbSheetB.Text = value; }
        }

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

        /// <summary>
        /// Add compare column
        /// </summary>
        /// <param name="columnA"></param>
        /// <param name="columnB"></param>
        public void Add(DataColumn columnA, DataColumn columnB)
        {
            ColumnComparison colCP = new ColumnComparison();
            colCP.Dock = DockStyle.Top;
            colCP.ColumnsA = this.ColumnsA;
            colCP.ColumnsB = this.ColumnsB;
            colCP.SelectedColumnA = columnA;
            colCP.SelectedColumnB = columnB;

            if (this.listCC == null)
                this.listCC = new List<ColumnComparison>();

            if (columnA == null && columnB == null && this.listCC.Count > 0)
            {
                colCP.SelectedColumnA = this.listCC[this.listCC.Count - 1].SelectedColumnA;
                colCP.SelectedColumnB = this.listCC[this.listCC.Count - 1].SelectedColumnB;
            }

            this.listCC.Add(colCP);

            if (this.tableCompareColumns.Controls.Count > 1)
            {
                int newIndex = this.tableCompareColumns.GetRow(this.pnButton) + 1;

                this.tableCompareColumns.Controls.Add(colCP, 0, newIndex);

                this.tableCompareColumns.SetRow(this.pnButton, newIndex);

                this.tableCompareColumns.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            else
            {
                this.tableCompareColumns.Controls.Add(colCP, 0, this.tableCompareColumns.GetRow(this.pnButton));

                this.tableCompareColumns.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            //this.SetEnabledButton();
            this.dataSpceialColumn.Checked = true;
        }

        /// <summary>
        /// Clear all compare columns
        /// </summary>
        public void Clear()
        {
            if (this.listCC != null)
            {
                foreach (ColumnComparison c in this.listCC)
                {
                    this.tableCompareColumns.Controls.Remove(c);
                    c.Dispose();
                }

                this.tableCompareColumns.SetRow(this.pnButton, this.tableCompareColumns.GetRow(this.pnButton) - this.listCC.Count + 1);
                this.listCC.Clear();

                this.SetEnabledButton();
            }
        }

        IList<ColumnComparison> listCC = null;
        private void btAdd_Click(object sender, EventArgs e)
        {
            this.Add(null, null);
        }

        private void SetEnabledButton()
        {
            if (this.listCC != null)
            {
                this.btRemove.Enabled = this.listCC.Count > 1;

                if (this.ColumnsA != null && this.ColumnsB != null)
                {
                    this.btAdd.Enabled = !(this.listCC.Count == this.ColumnsA.Count || this.listCC.Count == this.ColumnsB.Count);
                }
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (this.listCC.Count > 0)
            {
                ColumnComparison colCC = this.listCC[this.listCC.Count - 1];

                this.listCC.RemoveAt(this.listCC.Count - 1);

                this.tableCompareColumns.Controls.Remove(colCC);
                colCC.Dispose();

                this.tableCompareColumns.SetRow(this.pnButton, this.tableCompareColumns.GetRow(this.pnButton) - 1);

                //this.SetEnabledButton();
            }
        }

        private void SetColumnsToControls()
        {
            if (this.ColumnsA == null || this.ColumnsB == null)
            {
                this.tableCompareColumns.Enabled = false;
                return;
            }

            if (this.tableCompareColumns.Enabled == false)
            {
                this.tableCompareColumns.Enabled = true;
                if (this.listCC == null ? true : this.listCC.Count <= 0)
                {
                    this.btAdd_Click(this, EventArgs.Empty);
                }
            }

            #region Set Column
            if (this.listCC != null)
            {
                foreach (ColumnComparison item in this.listCC)
                {
                    item.ColumnsA = this.ColumnsA;
                    item.ColumnsB = this.ColumnsB;
                }
            }
            #endregion
        }

       

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            this.lbSheetA.Width = this.primaryCC.Width / 2;
        }

        public ColumnComparisonCollecction()
        {
            InitializeComponent();
        }
    }
}
