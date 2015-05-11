namespace Sharepoint_Verification
{
    partial class Form1
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
            this.layoutURL = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FarmInfo = new System.Windows.Forms.TextBox();
            this.btn_Go = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.layoutURL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutURL
            // 
            this.layoutURL.ColumnCount = 4;
            this.layoutURL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutURL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutURL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.layoutURL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutURL.Controls.Add(this.label1, 0, 0);
            this.layoutURL.Controls.Add(this.txt_FarmInfo, 1, 0);
            this.layoutURL.Controls.Add(this.btn_Go, 3, 0);
            this.layoutURL.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutURL.Location = new System.Drawing.Point(0, 0);
            this.layoutURL.Name = "layoutURL";
            this.layoutURL.RowCount = 1;
            this.layoutURL.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutURL.Size = new System.Drawing.Size(646, 30);
            this.layoutURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_FarmInfo
            // 
            this.txt_FarmInfo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_FarmInfo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.txt_FarmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_FarmInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FarmInfo.Location = new System.Drawing.Point(41, 3);
            this.txt_FarmInfo.Name = "txt_FarmInfo";
            this.txt_FarmInfo.ReadOnly = true;
            this.txt_FarmInfo.Size = new System.Drawing.Size(531, 23);
            this.txt_FarmInfo.TabIndex = 1;
            this.txt_FarmInfo.TextChanged += new System.EventHandler(this.data_URL_TextChanged);
            // 
            // btn_Go
            // 
            this.btn_Go.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Go.Enabled = false;
            this.btn_Go.Location = new System.Drawing.Point(588, 3);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(55, 24);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 409);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(646, 40);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(568, 13);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 24);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save to File";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Result
            // 
            this.txt_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Result.Location = new System.Drawing.Point(0, 30);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ReadOnly = true;
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Result.Size = new System.Drawing.Size(646, 379);
            this.txt_Result.TabIndex = 2;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt|*.txt";
            this.saveFileDialog.FileName = "SP2010 Verification Result";
            this.saveFileDialog.Filter = "txt|*.txt";
            this.saveFileDialog.Title = "Save Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 449);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.layoutURL);
            this.Name = "Form1";
            this.Text = "Sharepoint 2010 Verification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.layoutURL.ResumeLayout(false);
            this.layoutURL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FarmInfo;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

