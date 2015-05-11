namespace ControlLibrary.UserControls
{
    partial class GroupingDataCollection
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
            this.grColumns = new System.Windows.Forms.GroupBox();
            this.tableCompareColumns = new System.Windows.Forms.TableLayoutPanel();
            this.pnButton = new System.Windows.Forms.Panel();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.grColumns.SuspendLayout();
            this.tableCompareColumns.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grColumns
            // 
            this.grColumns.Controls.Add(this.tableCompareColumns);
            this.grColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grColumns.Location = new System.Drawing.Point(0, 0);
            this.grColumns.Name = "grColumns";
            this.grColumns.Size = new System.Drawing.Size(510, 592);
            this.grColumns.TabIndex = 2;
            this.grColumns.TabStop = false;
            this.grColumns.Text = "Grouping Columns";
            // 
            // tableCompareColumns
            // 
            this.tableCompareColumns.AutoScroll = true;
            this.tableCompareColumns.AutoSize = true;
            this.tableCompareColumns.ColumnCount = 3;
            this.tableCompareColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCompareColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableCompareColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableCompareColumns.Controls.Add(this.pnButton, 1, 0);
            this.tableCompareColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCompareColumns.Location = new System.Drawing.Point(3, 16);
            this.tableCompareColumns.Name = "tableCompareColumns";
            this.tableCompareColumns.RowCount = 1;
            this.tableCompareColumns.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableCompareColumns.Size = new System.Drawing.Size(504, 573);
            this.tableCompareColumns.TabIndex = 1;
            this.tableCompareColumns.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.tableCompareColumns_ControlAdded);
            this.tableCompareColumns.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tableCompareColumns_ControlRemoved);
            // 
            // pnButton
            // 
            this.pnButton.Controls.Add(this.btRemove);
            this.pnButton.Controls.Add(this.btAdd);
            this.pnButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnButton.Location = new System.Drawing.Point(421, 3);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(50, 20);
            this.pnButton.TabIndex = 0;
            // 
            // btRemove
            // 
            this.btRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btRemove.Location = new System.Drawing.Point(25, 0);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(25, 20);
            this.btRemove.TabIndex = 5;
            this.btRemove.Text = "-";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btAdd
            // 
            this.btAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btAdd.Location = new System.Drawing.Point(0, 0);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(25, 20);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "+";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // GroupingDataCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grColumns);
            this.Name = "GroupingDataCollection";
            this.Size = new System.Drawing.Size(510, 592);
            this.grColumns.ResumeLayout(false);
            this.grColumns.PerformLayout();
            this.tableCompareColumns.ResumeLayout(false);
            this.pnButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grColumns;
        private System.Windows.Forms.TableLayoutPanel tableCompareColumns;
        private System.Windows.Forms.Panel pnButton;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btAdd;
    }
}
