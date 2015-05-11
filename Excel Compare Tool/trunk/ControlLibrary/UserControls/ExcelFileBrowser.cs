using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ControlLibrary.Classes;

namespace ControlLibrary.UserControls
{
    public partial class ExcelFileBrowser : UserControl
    {
        public string Title
        {
            get { return this.fileBrowserDialog.Title; }
            set { this.fileBrowserDialog.Title = value; }
        }

        public string FullFileName
        {
            get { return this.fileBrowserDialog.FullFileName; }
            set { this.fileBrowserDialog.FullFileName = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName
        {
            get { return this.fileBrowserDialog.FileName; }
        }

        public string SheetName
        {
            get { return this.dataSheetName.Text; }
            set { this.dataSheetName.SelectedValue = value; }
        }

        public ExcelFileBrowser()
        {
            InitializeComponent();

            this.fileBrowserDialog.FilePathChanged += new EventHandler(fileBrowserDialog_FilePathChanged);
            this.fileBrowserDialog.Filter = Properties.Settings.Default.ExcelExtension;
            this.fileBrowserDialog.Multiselect = false;
        }


        DataTable data;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DataTable
        {
            get
            {
                if (this.data == null)
                    this.GetData();
                else if (this.data.TableName != this.dataSheetName.Text)
                    this.GetData();

                return this.data;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<DataColumn> Columns
        {
            get
            {
                IList<DataColumn> list = new List<DataColumn>();
                if (this.DataTable != null)
                {
                    foreach (DataColumn col in this.DataTable.Columns)
                        list.Add(col);
                }

                return list;
            }
        }

        private void GetData()
        {
            if (string.IsNullOrEmpty(this.fileBrowserDialog.FullFileName))
            { return; }

            if (this.fileBrowserDialog.FullFileName.Contains("csv"))
                this.data = DataConverter.CSVtoDataTable(this.fileBrowserDialog.FullFileName);
            else this.data = DataConverter.XSLtoDataTable(this.fileBrowserDialog.FullFileName, this.dataSheetName.Text);

            if (this.data != null)
                this.data.TableName = this.dataSheetName.Text;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Height = this.dataSheetName.Height + 10;
        }

        private void fileBrowserDialog_FilePathChanged(object sender, EventArgs e)
        {
            this.dataSheetName.Items.Clear();

            if (!string.IsNullOrEmpty(this.fileBrowserDialog.FullFileName))
            {
                string[] sheetNames = DataConverter.GetExcelSheetNames(this.fileBrowserDialog.FullFileName);
                if (sheetNames != null)
                {
                    foreach (string s in sheetNames)
                        this.dataSheetName.Items.Add(s);

                    this.dataSheetName.SelectedIndex = 0;
                }
            }
        }

        private void dataSheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnSheetNameSelectionChanged(e);
        }

        public event System.EventHandler SheetNameSelectionChanged;
        protected virtual void OnSheetNameSelectionChanged(EventArgs e)
        {
            this.data = null;
            if (this.SheetNameSelectionChanged != null)
                this.SheetNameSelectionChanged(this, e);
        }
    }
}
