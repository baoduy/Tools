using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppPoolController.Class;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AppPoolController
{
    public partial class FrEnvironment : Form
    {
        IList<EnvironmentEntry> listEnv = null;

        public FrEnvironment()
        {
            InitializeComponent();
        }

        private void FrEnvironment_Load(object sender, EventArgs e)
        {
            this.Read();
            this.DataBind();
        }

        public override bool ValidateChildren()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(this.cboEnvName.Text))
            {
                this.errorProvider.SetError(this.cboEnvName, "Not Empty");
                valid = false;
            }
            else this.errorProvider.SetError(this.cboEnvName, string.Empty);

            if (string.IsNullOrEmpty(this.txtUserName.Text))
            {
                this.errorProvider.SetError(this.txtUserName, "Not Empty");
                valid = false;
            }
            else this.errorProvider.SetError(this.txtPassword, string.Empty);

            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                this.errorProvider.SetError(this.txtPassword, "Not Empty");
                valid = false;
            }
            else this.errorProvider.SetError(this.txtPassword, string.Empty);

            return valid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            EnvironmentEntry currentEnv = null;
            if (this.cboEnvName.SelectedItem != null)
            {
                currentEnv = this.cboEnvName.SelectedItem as EnvironmentEntry;
            }
            else
            {
                currentEnv = new EnvironmentEntry(this.cboEnvName.Text);
                this.listEnv.Add(currentEnv);
            }


            currentEnv.Password = this.txtPassword.Text;
            currentEnv.UserName = this.txtUserName.Text;
            currentEnv.ServerList = this.txtServerList.Text;

            this.Save();

            this.cboEnvName.DataSource = this.listEnv;
        }

        private void Save()
        {
            Functions.SaveEnvironment(this.listEnv);

            this.DataBind();
        }

        protected void DataBind()
        { this.cboEnvName.DataSource = this.listEnv; }

        private void Read()
        {
            this.listEnv = Functions.ReadEnvironment();
        }

        private void cboEnvName_Leave(object sender, EventArgs e)
        {
            if (this.cboEnvName.SelectedItem != null)
            {
                EnvironmentEntry currentEnv = this.cboEnvName.SelectedItem as EnvironmentEntry;
                this.txtUserName.Text = currentEnv.UserName;
                this.txtPassword.Text = currentEnv.Password;
                this.txtServerList.Text = currentEnv.ServerList;
            }
            else
            {
                this.txtUserName.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.txtServerList.Text = string.Empty;
            }
        }

        private void cboEnvName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboEnvName_Leave(sender, e);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            this.btnSave_Click(sender, e);
            this.Close();
        }
    }
}