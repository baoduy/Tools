namespace AppPoolController
{
    partial class FrMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboEnvironment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboServerList = new System.Windows.Forms.ComboBox();
            this.listAppPools = new System.Windows.Forms.ListBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.btnEditEnv = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cboEnvironment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboServerList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listAppPools, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnRecycle, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnEditEnv, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 2, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 303);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cboEnvironment
            // 
            this.cboEnvironment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboEnvironment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEnvironment.DisplayMember = "Name";
            this.cboEnvironment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnvironment.FormattingEnabled = true;
            this.cboEnvironment.Location = new System.Drawing.Point(103, 33);
            this.cboEnvironment.Name = "cboEnvironment";
            this.cboEnvironment.Size = new System.Drawing.Size(174, 21);
            this.cboEnvironment.TabIndex = 1;
            this.cboEnvironment.SelectedIndexChanged += new System.EventHandler(this.cboEnvironment_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Environment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "AppPools:";
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
            this.label1.Size = new System.Drawing.Size(365, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "AppPool Controller";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server:";
            // 
            // cboServerList
            // 
            this.cboServerList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboServerList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServerList.FormattingEnabled = true;
            this.cboServerList.Location = new System.Drawing.Point(103, 61);
            this.cboServerList.Name = "cboServerList";
            this.cboServerList.Size = new System.Drawing.Size(174, 21);
            this.cboServerList.TabIndex = 2;
            this.cboServerList.SelectedIndexChanged += new System.EventHandler(this.cboServerList_SelectedIndexChanged);
            this.cboServerList.Leave += new System.EventHandler(this.cboServerList_Leave);
            // 
            // listAppPools
            // 
            this.listAppPools.FormattingEnabled = true;
            this.listAppPools.Location = new System.Drawing.Point(103, 88);
            this.listAppPools.Name = "listAppPools";
            this.tableLayoutPanel1.SetRowSpan(this.listAppPools, 4);
            this.listAppPools.Size = new System.Drawing.Size(174, 212);
            this.listAppPools.TabIndex = 0;
            this.listAppPools.SelectedIndexChanged += new System.EventHandler(this.listAppPools_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(283, 88);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(85, 22);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(283, 116);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 22);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRecycle
            // 
            this.btnRecycle.Enabled = false;
            this.btnRecycle.Location = new System.Drawing.Point(283, 144);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(85, 22);
            this.btnRecycle.TabIndex = 5;
            this.btnRecycle.Text = "Recycle";
            this.btnRecycle.UseVisualStyleBackColor = true;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // btnEditEnv
            // 
            this.btnEditEnv.Location = new System.Drawing.Point(283, 33);
            this.btnEditEnv.Name = "btnEditEnv";
            this.btnEditEnv.Size = new System.Drawing.Size(85, 22);
            this.btnEditEnv.TabIndex = 7;
            this.btnEditEnv.Text = "...";
            this.btnEditEnv.UseVisualStyleBackColor = true;
            this.btnEditEnv.Click += new System.EventHandler(this.btnEditEnv_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(283, 277);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppPool Controller";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboServerList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listAppPools;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRecycle;
        private System.Windows.Forms.ComboBox cboEnvironment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditEnv;
        private System.Windows.Forms.Button btnClose;
    }
}

