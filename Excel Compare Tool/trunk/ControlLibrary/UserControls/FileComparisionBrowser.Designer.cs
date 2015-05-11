namespace ControlLibrary.UserControls
{
    partial class FileComparisionBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBroswer = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.excelFileB = new ControlLibrary.UserControls.ExcelFileBrowser();
            this.excelFileA = new ControlLibrary.UserControls.ExcelFileBrowser();
            this.groupBroswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBroswer
            // 
            this.groupBroswer.Controls.Add(this.excelFileB);
            this.groupBroswer.Controls.Add(this.label1);
            this.groupBroswer.Controls.Add(this.excelFileA);
            this.groupBroswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBroswer.Location = new System.Drawing.Point(0, 0);
            this.groupBroswer.Name = "groupBroswer";
            this.groupBroswer.Size = new System.Drawing.Size(720, 95);
            this.groupBroswer.TabIndex = 4;
            this.groupBroswer.TabStop = false;
            this.groupBroswer.Text = "Files Comparison";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "   - Compare With:";
            // 
            // excelFileB
            // 
            this.excelFileB.Dock = System.Windows.Forms.DockStyle.Top;
            this.excelFileB.FullFileName = "";
            this.excelFileB.Location = new System.Drawing.Point(3, 60);
            this.excelFileB.Name = "excelFileB";
            this.excelFileB.SheetName = "";
            this.excelFileB.Size = new System.Drawing.Size(714, 31);
            this.excelFileB.TabIndex = 2;
            this.excelFileB.Title = "File B:";
            this.excelFileB.SheetNameSelectionChanged += new System.EventHandler(this.excelFileB_SheetNameSelectionChanged);
            // 
            // excelFileA
            // 
            this.excelFileA.Dock = System.Windows.Forms.DockStyle.Top;
            this.excelFileA.FullFileName = "";
            this.excelFileA.Location = new System.Drawing.Point(3, 16);
            this.excelFileA.Name = "excelFileA";
            this.excelFileA.SheetName = "";
            this.excelFileA.Size = new System.Drawing.Size(714, 31);
            this.excelFileA.TabIndex = 0;
            this.excelFileA.Title = "File A:";
            this.excelFileA.SheetNameSelectionChanged += new System.EventHandler(this.excelFileA_SheetNameSelectionChanged);
            // 
            // FileComparisionBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBroswer);
            this.Name = "FileComparisionBrowser";
            this.Size = new System.Drawing.Size(720, 95);
            this.groupBroswer.ResumeLayout(false);
            this.groupBroswer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBroswer;
        private ExcelFileBrowser excelFileB;
        private System.Windows.Forms.Label label1;
        private ExcelFileBrowser excelFileA;
    }
}
