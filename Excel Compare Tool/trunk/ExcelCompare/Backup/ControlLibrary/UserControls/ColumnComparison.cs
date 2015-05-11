using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.UserControls
{
    public partial class ColumnComparison : UserControl
    {
        [DefaultValue(null)]
        public IList<DataColumn> ColumnsA
        {
            get { return this.comboBoxA.DataSource as IList<DataColumn>; }
            set
            {
                this.comboBoxA.DataSource = value;
            }
        }

        [DefaultValue(null)]
        public IList<DataColumn> ColumnsB
        {
            get { return this.comboBoxB.DataSource as IList<DataColumn>; }
            set
            {
                this.comboBoxB.DataSource = value;
            }
        }

        [DefaultValue(null)]
        public DataColumn SelectedColumnA
        {
            get { return this.comboBoxA.SelectedItem as DataColumn; }
            set { this.comboBoxA.SelectedItem = value; }
        }

        [DefaultValue(null)]
        public DataColumn SelectedColumnB
        {
            get { return this.comboBoxB.SelectedItem as DataColumn; }
            set { this.comboBoxB.SelectedItem = value; }
        }

        [DefaultValue(null)]
        public int SelectedIndexColumnA
        {
            get { return this.comboBoxA.SelectedIndex; }
            set { this.comboBoxA.SelectedIndex = value; }
        }

        [DefaultValue(null)]
        public int SelectedIndexColumnB
        {
            get { return this.comboBoxB.SelectedIndex; }
            set { this.comboBoxB.SelectedIndex = value; }
        }

        [DefaultValue(false)]
        public bool ShowCheckBoxEnable
        {
            get { return this.chEnable.Visible; }
            set { this.chEnable.Visible = value; }
        }

        public new bool Enabled
        {
            get { return this.comboBoxA.Enabled; }
            set 
            {
                if (value != this.comboBoxA.Enabled)
                {
                    this.comboBoxA.Enabled = value;
                    this.comboBoxB.Enabled = value;

                    this.chEnable.Checked = value;

                    if (!this.DesignMode)
                        this.OnEnabledChanged(EventArgs.Empty);
                }
            }
        }

        public ColumnComparison()
        {
            InitializeComponent();
        }

        private void chEnable_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxA.Enabled = this.comboBoxB.Enabled = this.chEnable.Checked;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            this.Height = this.comboBoxA.Height + 5;
        }
    }
}
