namespace ExcelCompare
{
    partial class FrDataGridCompare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrDataGridCompare));
            this.dataGridComparisionView1 = new ExcelCompare.DataGridComparisionView();
            this.SuspendLayout();
            // 
            // dataGridComparisionView1
            // 
            this.dataGridComparisionView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridComparisionView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridComparisionView1.Name = "dataGridComparisionView1";
            this.dataGridComparisionView1.Size = new System.Drawing.Size(792, 566);
            this.dataGridComparisionView1.TabIndex = 0;
            // 
            // FrDataGridCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dataGridComparisionView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrDataGridCompare";
            this.Text = "FrDataGridCompare";
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridComparisionView dataGridComparisionView1;
    }
}