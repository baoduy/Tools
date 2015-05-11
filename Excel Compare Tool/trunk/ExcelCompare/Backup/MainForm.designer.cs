using ExcelCompare.UserControls;
namespace ExcelCompare
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsCSVtoXLS = new System.Windows.Forms.ToolStripButton();
            this.tsDataGridComparer = new System.Windows.Forms.ToolStripButton();
            this.tsDataTreeCompare = new System.Windows.Forms.ToolStripButton();
            this.tsVersion = new System.Windows.Forms.ToolStripLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCSVtoXLS,
            this.tsDataGridComparer,
            this.tsDataTreeCompare,
            this.tsVersion});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(792, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsCSVtoXLS
            // 
            this.tsCSVtoXLS.Image = ((System.Drawing.Image)(resources.GetObject("tsCSVtoXLS.Image")));
            this.tsCSVtoXLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCSVtoXLS.Name = "tsCSVtoXLS";
            this.tsCSVtoXLS.Size = new System.Drawing.Size(79, 22);
            this.tsCSVtoXLS.Text = "CSV to XLS";
            this.tsCSVtoXLS.ToolTipText = "Convert CSV to Excel";
            this.tsCSVtoXLS.Click += new System.EventHandler(this.tsCSVtoXLS_Click);
            // 
            // tsDataGridComparer
            // 
            this.tsDataGridComparer.Image = ((System.Drawing.Image)(resources.GetObject("tsDataGridComparer.Image")));
            this.tsDataGridComparer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDataGridComparer.Name = "tsDataGridComparer";
            this.tsDataGridComparer.Size = new System.Drawing.Size(118, 22);
            this.tsDataGridComparer.Text = "Data Grid Compare";
            this.tsDataGridComparer.Click += new System.EventHandler(this.tsDataGridComparer_Click);
            // 
            // tsDataTreeCompare
            // 
            this.tsDataTreeCompare.Image = ((System.Drawing.Image)(resources.GetObject("tsDataTreeCompare.Image")));
            this.tsDataTreeCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDataTreeCompare.Name = "tsDataTreeCompare";
            this.tsDataTreeCompare.Size = new System.Drawing.Size(125, 22);
            this.tsDataTreeCompare.Text = "Data Tree Comparer";
            this.tsDataTreeCompare.Click += new System.EventHandler(this.tsDataTreeCompare_Click);
            // 
            // tsVersion
            // 
            this.tsVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsVersion.IsLink = true;
            this.tsVersion.LinkVisited = true;
            this.tsVersion.Name = "tsVersion";
            this.tsVersion.Size = new System.Drawing.Size(42, 22);
            this.tsVersion.Text = "Version";
            this.tsVersion.ToolTipText = "Excel comparer develop by Hoang Bao Duy";
            this.tsVersion.Click += new System.EventHandler(this.tsVersion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 780);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Excel Comparer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsCSVtoXLS;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton tsDataGridComparer;
        private System.Windows.Forms.ToolStripButton tsDataTreeCompare;
        private System.Windows.Forms.ToolStripLabel tsVersion;
    }
}