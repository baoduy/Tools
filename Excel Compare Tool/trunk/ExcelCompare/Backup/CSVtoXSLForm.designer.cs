namespace ExcelCompare
{
    partial class ExcelToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelToolForm));
            this.btOpen = new System.Windows.Forms.Button();
            this.btConvert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsInputFile = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chTheSameInput = new System.Windows.Forms.CheckBox();
            this.btChooseFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.chDeleteSourceFiles = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(210, 12);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Add Files";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(210, 244);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(75, 23);
            this.btConvert.TabIndex = 1;
            this.btConvert.Text = "Convert";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chDeleteSourceFiles);
            this.groupBox1.Controls.Add(this.lsInputFile);
            this.groupBox1.Controls.Add(this.btOpen);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input File";
            // 
            // lsInputFile
            // 
            this.lsInputFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lsInputFile.FormattingEnabled = true;
            this.lsInputFile.Location = new System.Drawing.Point(3, 16);
            this.lsInputFile.Name = "lsInputFile";
            this.lsInputFile.Size = new System.Drawing.Size(201, 147);
            this.lsInputFile.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chTheSameInput);
            this.groupBox2.Controls.Add(this.btChooseFolder);
            this.groupBox2.Controls.Add(this.txtOutputFolder);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 67);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output File";
            // 
            // chTheSameInput
            // 
            this.chTheSameInput.AutoSize = true;
            this.chTheSameInput.Location = new System.Drawing.Point(12, 19);
            this.chTheSameInput.Name = "chTheSameInput";
            this.chTheSameInput.Size = new System.Drawing.Size(115, 17);
            this.chTheSameInput.TabIndex = 2;
            this.chTheSameInput.Text = "The same input file";
            this.chTheSameInput.UseVisualStyleBackColor = true;
            this.chTheSameInput.CheckedChanged += new System.EventHandler(this.chTheSameInput_CheckedChanged);
            // 
            // btChooseFolder
            // 
            this.btChooseFolder.Location = new System.Drawing.Point(210, 40);
            this.btChooseFolder.Name = "btChooseFolder";
            this.btChooseFolder.Size = new System.Drawing.Size(75, 23);
            this.btChooseFolder.TabIndex = 1;
            this.btChooseFolder.Text = "Save";
            this.btChooseFolder.UseVisualStyleBackColor = true;
            this.btChooseFolder.Click += new System.EventHandler(this.btChooseFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(12, 42);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(192, 20);
            this.txtOutputFolder.TabIndex = 0;
            this.txtOutputFolder.Text = "C:\\Output";
            // 
            // chDeleteSourceFiles
            // 
            this.chDeleteSourceFiles.AutoSize = true;
            this.chDeleteSourceFiles.Location = new System.Drawing.Point(210, 146);
            this.chDeleteSourceFiles.Name = "chDeleteSourceFiles";
            this.chDeleteSourceFiles.Size = new System.Drawing.Size(118, 17);
            this.chDeleteSourceFiles.TabIndex = 2;
            this.chDeleteSourceFiles.Text = "Delete Source Files";
            this.chDeleteSourceFiles.UseVisualStyleBackColor = true;
            // 
            // ExcelToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 269);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btConvert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelToolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV to XSL";
            this.Load += new System.EventHandler(this.ExcelToolForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lsInputFile;
        private System.Windows.Forms.Button btChooseFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.CheckBox chTheSameInput;
        private System.Windows.Forms.CheckBox chDeleteSourceFiles;

    }
}

