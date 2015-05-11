using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlLibrary.Classes.Events;

namespace ControlLibrary.UserControls
{
    [DefaultEvent("SelectionChanged")]
    public partial class FileComparisionBrowser : UserControl
    {
        public string Hearder
        {
            get { return this.groupBroswer.Text; }
            set { this.groupBroswer.Text = value; }
        }

        public ExcelFileBrowser ExcelFileA
        { get { return this.excelFileA; } }

        public ExcelFileBrowser ExcelFileB
        { get { return this.excelFileB; } }

        public FileComparisionBrowser()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Dock == DockStyle.Bottom || this.Dock == DockStyle.Top||this.Dock== DockStyle.None)
                this.Height = this.excelFileA.Height * 2 + this.label1.Height + 20;
        }

        public event EventHandler<FileSelectionEventArgs> SelectionChanged;
        protected virtual void OnSelectionChanged(FileSelectionEventArgs e)
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, e);
        }

        private void excelFileA_SheetNameSelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged(new FileSelectionEventArgs(this.excelFileA, FileTypeName.FileA));
        }

        private void excelFileB_SheetNameSelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged(new FileSelectionEventArgs(this.excelFileB, FileTypeName.FileB));
        }
    }
}
