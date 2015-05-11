using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.DirectoryServices;
using AppPoolController.Properties;
using AppPoolController.Class;

namespace AppPoolController
{
    public partial class FrMain : Form
    {
        public FrMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataBind();
            this.listAppPools.Focus();
        }

        private void DataBind()
        {
            this.cboEnvironment.DataSource = Functions.ReadEnvironment();
        }

        IList<DirectoryEntry> appPools = null;
        DirectoryEntry currentSelected = null;

        private void listAppPools_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listAppPools.SelectedItem != null)
            {
                this.currentSelected = this.appPools[this.listAppPools.SelectedIndex];

                this.SetButtonStatus();

                this.btnRecycle.Enabled = true;
            }
            else
            {
                this.btnRecycle.Enabled = false;
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = false;
                this.currentSelected = null;
            }
        }

        private void SetButtonStatus()
        {
            if (AppPool.GetAppPoolStatus(this.currentSelected) == AppPool.AppPoolStatus.Start)
            {
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
            }
            else
            {
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AppPool.StopAppPool(this.currentSelected);
            this.SetButtonStatus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AppPool.StartAppPool(this.currentSelected);
            this.SetButtonStatus();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            AppPool.RecycleAppPool(this.currentSelected);
            MessageBox.Show(this.currentSelected.Name + " has been recycled successfully");
        }

        private void btnEditEnv_Click(object sender, EventArgs e)
        {
            FrEnvironment fr = new FrEnvironment();
            fr.ShowDialog();
            this.DataBind();
        }

        private void cboEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboEnvironment.SelectedItem != null)
                this.cboServerList.DataSource = (this.cboEnvironment.SelectedItem as EnvironmentEntry).GetServerList();
            else this.cboServerList.DataSource = null;
        }

        private void cboServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboServerList_Leave(sender, e);
        }

        private void cboServerList_Leave(object sender, EventArgs e)
        {
            try
            {
                EnvironmentEntry env = (EnvironmentEntry)this.cboEnvironment.SelectedItem;
                if (env != null)
                {
                    this.appPools = AppPool.GetAllAppPool(this.cboServerList.Text, env.UserName, env.Password);

                    this.listAppPools.Items.Clear();
                    foreach (DirectoryEntry a in this.appPools)
                    {
                        this.listAppPools.Items.Add(a.Name);
                    }

                    if (this.listAppPools.Items.Count > 0
                        && !env.ServerList.Contains(this.cboServerList.Text))
                    {
                        env.ServerList += "\n" + this.cboServerList.Text;
                        Functions.SaveEnvironment(this.cboEnvironment.DataSource as IList<EnvironmentEntry>);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}