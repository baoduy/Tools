namespace WindowsAuthorizationManager
{
    partial class AddEditEnvironment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_NewItem = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_SaveAndClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SaveAndClose);
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_NewItem);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Delete.Location = new System.Drawing.Point(78, 16);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 28);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_NewItem
            // 
            this.btn_NewItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_NewItem.Location = new System.Drawing.Point(3, 16);
            this.btn_NewItem.Name = "btn_NewItem";
            this.btn_NewItem.Size = new System.Drawing.Size(75, 28);
            this.btn_NewItem.TabIndex = 1;
            this.btn_NewItem.Text = "New";
            this.btn_NewItem.UseVisualStyleBackColor = true;
            this.btn_NewItem.Click += new System.EventHandler(this.btn_NewItem_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Location = new System.Drawing.Point(553, 16);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 28);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(631, 292);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_SaveAndClose
            // 
            this.btn_SaveAndClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_SaveAndClose.Location = new System.Drawing.Point(455, 16);
            this.btn_SaveAndClose.Name = "btn_SaveAndClose";
            this.btn_SaveAndClose.Size = new System.Drawing.Size(98, 28);
            this.btn_SaveAndClose.TabIndex = 3;
            this.btn_SaveAndClose.Text = "Save And Close";
            this.btn_SaveAndClose.UseVisualStyleBackColor = true;
            this.btn_SaveAndClose.Click += new System.EventHandler(this.btn_SaveAndClose_Click);
            // 
            // AddEditEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 339);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditEnvironment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditEnvironment";
            this.Load += new System.EventHandler(this.AddEditEnvironment_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_NewItem;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_SaveAndClose;
    }
}