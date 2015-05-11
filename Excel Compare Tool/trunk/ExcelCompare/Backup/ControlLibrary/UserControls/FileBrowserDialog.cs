using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.UserControls
{
    [DefaultEvent("FilePathChanged")]
    public partial class FileBrowserDialog : UserControl
    {
        public string Title
        {
            get { return this.lbTitle.Text; }
            set { this.lbTitle.Text = value; }
        }

        string filter;
        public string Filter
        {
            get { return filter; }
            set { filter = value; }
        }

        bool multiselect;
        public bool Multiselect
        {
            get { return multiselect; }
            set { multiselect = value; }
        }

        [Browsable(false)]
        public string FullFileName
        {
            get { return this.dataFilePath.Text; }
            set { this.dataFilePath.Text = value; }
        }

        [Browsable(false)]
        public string FileName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.dataFilePath.Text)
                    && this.dataFilePath.Text.Contains("\\"))
                    return this.dataFilePath.Text.Substring(this.dataFilePath.Text.LastIndexOf("\\") + 1);

                return this.dataFilePath.Text;
            }
        }

        public FileBrowserDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Dock == DockStyle.Bottom || this.Dock == DockStyle.Top || this.Dock == DockStyle.None)
                this.Height = this.btOpen.Height + 10;
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = this.Multiselect;
            openFile.Filter = this.Filter;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.dataFilePath.Text = openFile.FileName;
            }
        }

        private void dataFilePath_TextChanged(object sender, EventArgs e)
        {
            this.OnFilePathChanged(e);
        }

        public event System.EventHandler FilePathChanged;
        protected virtual void OnFilePathChanged(EventArgs e)
        {
            if (this.FilePathChanged != null)
                this.FilePathChanged(this, e);
        }

        private void dataFilePath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.btOpen_Click(sender, e);
        }

        private void lbTitle_TextChanged(object sender, EventArgs e)
        {
            this.lbTitle.Visible = !string.IsNullOrEmpty(this.lbTitle.Text);
        }
    }
}
