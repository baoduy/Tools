using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ExcelCompare.Classes;
using ExcelCompare.Classes.Events;

namespace ExcelCompare.UserControls
{
    public partial class GroupingDataCollection : UserControl
    {
        [DefaultValue(null)]
        IList<DataColumn> columns;
        public IList<DataColumn> Columns
        {
            get { return this.columns; }
            set
            {
                this.columns = value;
                this.SetColumnsToControls();
            }
        }

        [DefaultValue(null)]
        GroupColumnCollection groupColumns;
        public GroupColumnCollection GroupColumns
        {
            get
            {
                if (this.groupColumns == null)
                    this.groupColumns = new GroupColumnCollection();

                if (this.groupColumns.Count <= 0)
                {
                    if (this.listCC != null)
                    {
                        foreach (ComboBox col in this.listCC)
                        {
                            if (col.SelectedItem != null)
                                this.groupColumns.Add(col.Text);
                        }
                    }
                }
                return this.groupColumns;
            }
        }

        [DefaultValue(null)]
        public string Header
        {
            get { return this.grColumns.Text; }
            set { this.grColumns.Text = value; }
        }

        public GroupingDataCollection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add compare column
        /// </summary>
        /// <param name="columnA"></param>
        /// <param name="columnB"></param>
        public void Add(DataColumn selectedColumn)
        {
            if (this.listCC == null)
                this.listCC = new List<ComboBox>();

            if (selectedColumn == null && this.listCC.Count > 0)
            {
                selectedColumn = this.Columns[this.listCC[this.listCC.Count - 1].SelectedIndex + 1];
            }

            ComboBox colCP = new ComboBox();
            colCP.Dock = DockStyle.Top;
            colCP.DisplayMember = "ColumnName";
            colCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            colCP.Size = new System.Drawing.Size(200, 21);
            colCP.DataSource = new BindingSource(this.Columns, null);

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

            colCP.SelectedItem = selectedColumn;
            colCP.Focus();

            this.OnColumnAdded(new GroupingColumnEventArgs(colCP));
        }

        /// <summary>
        /// Clear all compare columns
        /// </summary>
        public void Clear()
        {
            if (this.listCC != null)
            {
                foreach (ComboBox c in this.listCC)
                {
                    this.tableCompareColumns.Controls.Remove(c);
                    c.Dispose();
                }

                this.tableCompareColumns.SetRow(this.pnButton, this.tableCompareColumns.GetRow(this.pnButton) - this.listCC.Count + 1);
                this.listCC.Clear();

                this.SetEnabledButton();
            }
        }

        IList<ComboBox> listCC = null;
        public IList<ComboBox> ListColumnControl
        {
            get { return listCC; }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            this.Add(null);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (this.listCC.Count > 0)
            {
                ComboBox colCC = this.listCC[this.listCC.Count - 1];

                this.listCC.RemoveAt(this.listCC.Count - 1);

                this.tableCompareColumns.Controls.Remove(colCC);
                colCC.Dispose();

                this.tableCompareColumns.SetRow(this.pnButton, this.tableCompareColumns.GetRow(this.pnButton) - 1);

                this.OnColumnRemoved(new GroupingColumnEventArgs(colCC));
            }
        }

        private void SetEnabledButton()
        {
            if (this.listCC != null)
            {
                this.btRemove.Enabled = this.listCC.Count > 1;

                if (this.Columns != null)
                {
                    this.btAdd.Enabled = !(this.listCC.Count == this.Columns.Count);
                }
            }
        }

        private void SetColumnsToControls()
        {
            if (this.Columns == null)
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
                foreach (ComboBox item in this.listCC)
                {
                    item.DataSource = this.Columns;
                }
            }
            #endregion
        }

        private void tableCompareColumns_ControlAdded(object sender, ControlEventArgs e)
        {
            if (this.groupColumns != null)
                this.groupColumns.Clear();

            this.SetEnabledButton();
        }

        private void tableCompareColumns_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.groupColumns != null)
                this.groupColumns.Clear();

            this.SetEnabledButton();
        }

        public event System.EventHandler<GroupingColumnEventArgs> ColumnAdded;
        protected virtual void OnColumnAdded(GroupingColumnEventArgs e)
        {
            if (this.ColumnAdded != null)
                this.ColumnAdded(this, e);
        }

        public event System.EventHandler<GroupingColumnEventArgs> ColumnRemoved;
        protected virtual void OnColumnRemoved(GroupingColumnEventArgs e)
        {
            if (this.ColumnRemoved != null)
                this.ColumnRemoved(this, e);
        }
    }
}
