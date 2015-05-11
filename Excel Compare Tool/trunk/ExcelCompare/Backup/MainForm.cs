using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using ExcelCompare.Classes;
using ExcelCompare.Properties;
using System.Reflection;
using ControlLibrary;

namespace ExcelCompare
{
    public partial class MainForm : MainFormBase
    {
        public MainForm()
        {
            InitializeComponent();

            if (this.WindowState == FormWindowState.Normal)
                this.Height = SystemInformation.WorkingArea.Height - 10;
        }

        //private void ShowForm(Form form)
        //{
        //    this.ShowForm(form, false);
        //}

        //private void ShowForm(Form form, bool maximun)
        //{
        //    foreach (Form fr in this.MdiChildren)
        //        if (fr.GetType() == form.GetType())
        //        {
        //            fr.BringToFront();
        //            return;
        //        }

        //    form.TopLevel = false;
        //    form.MdiParent = this;
        //    form.StartPosition = FormStartPosition.CenterParent;

        //    if (maximun)
        //    {
        //        form.WindowState = FormWindowState.Maximized;
        //    }

        //    form.Show();
        //}

        private void tsCSVtoXLS_Click(object sender, EventArgs e)
        {
            this.ShowForm(new ExcelToolForm());
        }

        private void tsDataGridComparer_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FrDataGridCompare(), true);
        }

        private void tsDataTreeCompare_Click(object sender, EventArgs e)
        {
            this.ShowForm(new FrTreeDataCompare(), true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.tsVersion.Text = "Version: " + this.ProductVersion;
        }

        private void tsVersion_Click(object sender, EventArgs e)
        {
            Process.Start("Release Note.txt");
        }
    }
}
