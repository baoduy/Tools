using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ExcelCompare.Classes;
using Schroders.DataUtility;

namespace ExcelCompare
{
    public partial class ExcelToolForm : Form
    {
        public ExcelToolForm()
        {
            InitializeComponent();
        }

        string[] inputFiles = null;

        private void btOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = Properties.Settings.Default.CSVExtension;

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.inputFiles = open.FileNames;

                this.lsInputFile.Items.Clear();
                foreach (string f in this.inputFiles)
                {
                    FileInfo fi = new FileInfo(f);
                    this.lsInputFile.Items.Add(fi.Name);
                    this.txtOutputFolder.Text = fi.Directory.FullName;
                }
            }
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            foreach (string f in this.inputFiles)
            {
                if (this.chTheSameInput.Checked)
                {
                    ExcelConverter.CSVtoXSL(f, null);
                }
                else ExcelConverter.CSVtoXSL(f, this.txtOutputFolder.Text);

                if (chDeleteSourceFiles.Checked)
                {
                    try { System.IO.File.Delete(f); }
                    catch { }
                }
            }

            MessageBox.Show("Convert Success!", "CSV to XLS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Enabled = true;
        }

        private void btChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderChoise = new FolderBrowserDialog();
            if (folderChoise.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtOutputFolder.Text = folderChoise.SelectedPath;
            }
        }

        private void chTheSameInput_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOutputFolder.Enabled = !this.chTheSameInput.Checked;
            this.btChooseFolder.Enabled = !this.chTheSameInput.Checked;
        }

        private void ExcelToolForm_Load(object sender, EventArgs e)
        {
            this.chTheSameInput.Checked = true;
        }
    }
}
