namespace ControlLibrary.UserControls
{
    partial class FileBrowserDialog
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
            this.dataFilePath = new System.Windows.Forms.TextBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.dataFilePath, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btOpen, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.lbTitle, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(764, 150);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // dataFilePath
            // 
            this.dataFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataFilePath.Location = new System.Drawing.Point(35, 3);
            this.dataFilePath.Name = "dataFilePath";
            this.dataFilePath.Size = new System.Drawing.Size(645, 20);
            this.dataFilePath.TabIndex = 0;
            this.dataFilePath.TextChanged += new System.EventHandler(this.dataFilePath_TextChanged);
            this.dataFilePath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataFilePath_MouseDoubleClick);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(686, 3);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 21);
            this.btOpen.TabIndex = 1;
            this.btOpen.Text = "Browse";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Location = new System.Drawing.Point(3, 7);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(26, 13);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "File:";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.TextChanged += new System.EventHandler(this.lbTitle_TextChanged);
            // 
            // FileBrowserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FileBrowserDialog";
            this.Size = new System.Drawing.Size(764, 150);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox dataFilePath;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Label lbTitle;
    }
}
