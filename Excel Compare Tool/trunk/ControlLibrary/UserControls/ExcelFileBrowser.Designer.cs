namespace ControlLibrary.UserControls
{
    partial class ExcelFileBrowser
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSheetName = new System.Windows.Forms.ComboBox();
            this.fileBrowserDialog = new UserControls.FileBrowserDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.dataSheetName, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.fileBrowserDialog, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(444, 42);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(225, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(60, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sheet:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataSheetName
            // 
            this.dataSheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataSheetName.FormattingEnabled = true;
            this.dataSheetName.Location = new System.Drawing.Point(291, 3);
            this.dataSheetName.Name = "dataSheetName";
            this.dataSheetName.Size = new System.Drawing.Size(150, 21);
            this.dataSheetName.TabIndex = 3;
            this.dataSheetName.SelectedIndexChanged += new System.EventHandler(this.dataSheetName_SelectedIndexChanged);
            // 
            // fileBrowserDialog
            // 
            this.fileBrowserDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowserDialog.Filter = null;
            this.fileBrowserDialog.FullFileName = "";
            this.fileBrowserDialog.Location = new System.Drawing.Point(3, 3);
            this.fileBrowserDialog.Multiselect = false;
            this.fileBrowserDialog.Name = "fileBrowserDialog";
            this.fileBrowserDialog.Size = new System.Drawing.Size(216, 36);
            this.fileBrowserDialog.TabIndex = 4;
            // 
            // OpenExcelFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "OpenExcelFile";
            this.Size = new System.Drawing.Size(444, 42);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dataSheetName;
        private FileBrowserDialog fileBrowserDialog;

    }
}
