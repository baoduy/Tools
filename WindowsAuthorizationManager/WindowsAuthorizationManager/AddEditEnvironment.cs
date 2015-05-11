using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using WindowsAuthorizationManager.Properties;
using WindowsAuthorizationManager.Common;
using WindowsAuthorizationManager.Entities;

namespace WindowsAuthorizationManager
{
    public partial class AddEditEnvironment : Form
    {
        public EnvironmentCollection DataSource { get; set; }

        public AddEditEnvironment()
        {
            InitializeComponent();
        }

        private void AddEditEnvironment_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }

        private void DataBind()
        {
            if (this.DataSource == null)
                this.DataSource = Helper.GetConfigurationFromFile(Settings.Default.ConfigurationFile);

            if (this.DataSource.Count <= 0)
                this.DataSource.Add(new EnvironmentEntity());

            this.dataGridView1.ClearSelection();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.DataSource.ReportItems;
        }

        public bool ValidateData()
        {
            this.dataGridView1.EndEdit();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                DataGridViewCell currentCell = null;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (string.IsNullOrEmpty(cell.Value as string))
                    {
                        MessageBox.Show(string.Format("The {0} of row {1} can not empty", this.dataGridView1.Columns[cell.ColumnIndex].HeaderText, row.Index));
                        currentCell = cell;
                    }
                }

                if (currentCell != null)
                {
                    this.dataGridView1.CurrentCell = currentCell;
                    this.dataGridView1.BeginEdit(true);
                    return false;
                }
            }

            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private bool SaveConfiguration()
        {
            var collection = new StringCollection();
            if (this.ValidateData())
            {
                Helper.SaveConfigurationToFile(this.DataSource, Settings.Default.ConfigurationFile);
                MessageBox.Show("Configuration is saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void btn_NewItem_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
                this.DataSource = new EnvironmentCollection();
            this.DataSource.Add(new EnvironmentEntity());

            this.DataBind();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete Environment configuration?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (this.dataGridView1.SelectedRows.Count <= 0)
                {
                    this.DataSource.Remove(this.dataGridView1.CurrentCell.OwningRow.DataBoundItem as EnvironmentEntity);
                }
                else foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        this.DataSource.Remove(row.DataBoundItem as EnvironmentEntity);
                    }

                this.DataBind();
            }
        }

        private void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            if (this.SaveConfiguration())
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
