namespace AppPoolController
{
    partial class FrEnvironment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrEnvironment));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerList = new System.Windows.Forms.TextBox();
            this.cboEnvName = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnSaveClose, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtUserName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtServerList, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboEnvName, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 309);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(256, 285);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(82, 22);
            this.btnSaveClose.TabIndex = 14;
            this.btnSaveClose.Text = "Save && Close";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Admin Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Environment Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Admin User:";
            this.toolTip1.SetToolTip(this.label2, "User Name is Domain\\UserName");
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(259, 255);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 22);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(103, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 20);
            this.txtUserName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtUserName, "User Name is Domain\\UserName");
            this.txtUserName.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(103, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 119);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Servers:";
            // 
            // txtServerList
            // 
            this.txtServerList.Location = new System.Drawing.Point(103, 117);
            this.txtServerList.Multiline = true;
            this.txtServerList.Name = "txtServerList";
            this.tableLayoutPanel1.SetRowSpan(this.txtServerList, 2);
            this.txtServerList.Size = new System.Drawing.Size(150, 200);
            this.txtServerList.TabIndex = 3;
            // 
            // cboEnvName
            // 
            this.cboEnvName.DisplayMember = "Name";
            this.cboEnvName.FormattingEnabled = true;
            this.cboEnvName.Location = new System.Drawing.Point(103, 38);
            this.cboEnvName.Name = "cboEnvName";
            this.cboEnvName.Size = new System.Drawing.Size(150, 21);
            this.cboEnvName.TabIndex = 0;
            this.cboEnvName.SelectedIndexChanged += new System.EventHandler(this.cboEnvName_SelectedIndexChanged);
            this.cboEnvName.Leave += new System.EventHandler(this.cboEnvName_Leave);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // FrEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 309);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrEnvironment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Environment Management";
            this.Load += new System.EventHandler(this.FrEnvironment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerList;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cboEnvName;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}