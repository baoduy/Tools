using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.UserControls
{
    [DefaultEvent("SelectedPathChanged")]
    public partial class FolderBrowserDialog : UserControl
    {
        public string Title
        {
            get { return this.lbTitle.Text; }
            set { this.lbTitle.Text = value; }
        }

        //string filter;
        //public string Filter
        //{
        //    get { return filter; }
        //    set { filter = value; }
        //}

        //bool multiselect;
        //public bool Multiselect
        //{
        //    get { return multiselect; }
        //    set { multiselect = value; }
        //}

        [Browsable(false)]
        public string SelectedPath
        {
            get { return this.dataFolderPath.Text; }
            set { this.dataFolderPath.Text = value; }
        }

        //[Browsable(false)]
        //public string FileName
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(this.dataFilePath.Text)
        //            && this.dataFilePath.Text.Contains("\\"))
        //            return this.dataFilePath.Text.Substring(this.dataFilePath.Text.LastIndexOf("\\") + 1);

        //        return this.dataFilePath.Text;
        //    }
        //}

        public FolderBrowserDialog()
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
            System.Windows.Forms.FolderBrowserDialog openFolder = new System.Windows.Forms.FolderBrowserDialog();
            openFolder.SelectedPath = this.dataFolderPath.Text;

            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                this.dataFolderPath.Text = openFolder.SelectedPath;
            }
        }

        private void dataFilePath_TextChanged(object sender, EventArgs e)
        {
            this.OnSelectedPathChanged(e);
        }

        public event System.EventHandler SelectedPathChanged;
        protected virtual void OnSelectedPathChanged(EventArgs e)
        {
            if (this.SelectedPathChanged != null)
                this.SelectedPathChanged(this, e);
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
