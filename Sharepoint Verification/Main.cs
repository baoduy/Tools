using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Sharepoint_Verification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void data_URL_TextChanged(object sender, EventArgs e)
        {
            this.btn_Go.Enabled = this.txt_FarmInfo.Text.Length > 0;
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            this.txt_Result.Text = string.Empty;

            this.btn_Go.Enabled = false;
            this.btn_Save.Enabled = false;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                try
                {
                    var builder = new StringBuilder();
                    builder.Append(this.txt_FarmInfo.Text);
                    builder.Append(Environment.NewLine);
                    builder.Append("=================================================");
                    builder.Append(Environment.NewLine);

                    foreach (SPWebApplication webApp in this.webServices.WebApplications)
                    {
                        builder.Append(this.GetWebAppInfo(webApp));
                        builder.Append("=================================================");
                        builder.Append(Environment.NewLine);
                    }

                    this.txt_Result.Text = builder.ToString();
                }
                catch (Exception ex)
                { this.errorProvider1.SetError(this.txt_FarmInfo, ex.Message); }
            });

            this.btn_Go.Enabled = true;
            this.btn_Save.Enabled = true;
        }

        private string GetWebAppInfo(SPWebApplication webApp)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("WebApp: {0}, SiteCollection: {1}",
                    webApp.Name, webApp.Sites.Count);
            builder.Append(Environment.NewLine);

            if (webApp.Sites.Count > 0)
            {
                foreach (SPSite site in webApp.Sites)
                {
                    builder.Append(this.GetWebInfo(site.RootWeb));
                    builder.Append(Environment.NewLine);
                }
            }

            return builder.ToString();
        }

        private string GetWebInfo(SPWeb web)
        {
            var builder = new StringBuilder();

            builder.AppendFormat("========================{0}", Environment.NewLine);
            builder.AppendFormat("Site: {0}, Lists: {1}, Subsite: {2}, Size: {3}MB",
                       web.Url, web.Lists.Count, web.Webs.Count, ((decimal)web.Site.Usage.Storage / 1024M / 1024M).ToString("F1"));

            builder.AppendFormat("{0}- List:", Environment.NewLine);
            foreach (SPList list in web.Lists)
            {
                builder.AppendFormat("{0}\t- {1}, Items: {2}",
                    Environment.NewLine, list.Title, list.ItemCount);
            }
            builder.Append(Environment.NewLine);

            if (web.Webs.Count > 0)
            {
                builder.AppendFormat("{0}- Subsite of :{1} {0}", Environment.NewLine, web.Url);
                foreach (SPWeb w in web.Webs)
                {
                    builder.Append(this.GetWebInfo(w));
                    builder.Append(Environment.NewLine);
                }
            }
            builder.AppendFormat("========================{0}", Environment.NewLine);
            return builder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.FileName = string.Format("SP2010 Verification Result_{0:yyyy.mm.dd hhmm}", DateTime.Now);
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, this.txt_Result.Text);
                    MessageBox.Show("Flie has been saved successful.", "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadFarmInfo();
        }

        SPWebService webServices;
        private void LoadFarmInfo()
        {
            if (SPFarm.Local != null)
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
            {
                this.webServices = SPFarm.Local.Services.GetValue<SPWebService>();
                if (this.webServices != null)
                {
                    this.txt_FarmInfo.Text = string.Format("SPFarm 2010: {0} has {1} website",
                       SPFarm.Local.BuildVersion, this.webServices.WebApplications.Count);
                    this.btn_Go.Enabled = true;
                }
            });
            }
            else
            {
                this.txt_FarmInfo.Text = "SPFarm not found.";
                this.btn_Go.Enabled = false;
            }
        }
    }
}
