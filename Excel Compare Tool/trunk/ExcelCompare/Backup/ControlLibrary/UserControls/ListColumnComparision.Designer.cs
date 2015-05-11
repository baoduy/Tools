namespace ControlLibrary.UserControls
{
    partial class ListColumnComparision
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
            this.grPrimary = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSheetB = new System.Windows.Forms.Label();
            this.lbSheetA = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataColumnByColumn = new System.Windows.Forms.RadioButton();
            this.dataSpceialColumn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataRowByRow = new System.Windows.Forms.RadioButton();
            this.dataPrimaryKey = new System.Windows.Forms.RadioButton();
            this.primaryCC = new ControlLibrary.UserControls.ColumnComparison();
            this.columnCollection = new ControlLibrary.UserControls.ComparisionCollection();
            this.grPrimary.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grPrimary
            // 
            this.grPrimary.Controls.Add(this.tableLayoutPanel1);
            this.grPrimary.Controls.Add(this.primaryCC);
            this.grPrimary.Dock = System.Windows.Forms.DockStyle.Top;
            this.grPrimary.Enabled = false;
            this.grPrimary.Location = new System.Drawing.Point(0, 80);
            this.grPrimary.Name = "grPrimary";
            this.grPrimary.Size = new System.Drawing.Size(510, 69);
            this.grPrimary.TabIndex = 1;
            this.grPrimary.TabStop = false;
            this.grPrimary.Text = "Primary Key Column";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbSheetB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbSheetA, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 27);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbSheetB
            // 
            this.lbSheetB.AutoSize = true;
            this.lbSheetB.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSheetB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSheetB.ForeColor = System.Drawing.Color.Blue;
            this.lbSheetB.Location = new System.Drawing.Point(255, 0);
            this.lbSheetB.Name = "lbSheetB";
            this.lbSheetB.Size = new System.Drawing.Size(246, 13);
            this.lbSheetB.TabIndex = 4;
            this.lbSheetB.Text = "Sheet B";
            this.lbSheetB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSheetA
            // 
            this.lbSheetA.AutoSize = true;
            this.lbSheetA.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSheetA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSheetA.ForeColor = System.Drawing.Color.Blue;
            this.lbSheetA.Location = new System.Drawing.Point(3, 0);
            this.lbSheetA.Name = "lbSheetA";
            this.lbSheetA.Size = new System.Drawing.Size(246, 13);
            this.lbSheetA.TabIndex = 0;
            this.lbSheetA.Text = "Sheet A";
            this.lbSheetA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataColumnByColumn);
            this.groupBox4.Controls.Add(this.dataSpceialColumn);
            this.groupBox4.Location = new System.Drawing.Point(298, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(124, 62);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Column Type";
            // 
            // dataColumnByColumn
            // 
            this.dataColumnByColumn.AutoSize = true;
            this.dataColumnByColumn.Checked = true;
            this.dataColumnByColumn.Location = new System.Drawing.Point(6, 18);
            this.dataColumnByColumn.Name = "dataColumnByColumn";
            this.dataColumnByColumn.Size = new System.Drawing.Size(112, 17);
            this.dataColumnByColumn.TabIndex = 2;
            this.dataColumnByColumn.TabStop = true;
            this.dataColumnByColumn.Text = "Column by Column";
            this.dataColumnByColumn.UseVisualStyleBackColor = true;
            // 
            // dataSpceialColumn
            // 
            this.dataSpceialColumn.AutoSize = true;
            this.dataSpceialColumn.Location = new System.Drawing.Point(6, 41);
            this.dataSpceialColumn.Name = "dataSpceialColumn";
            this.dataSpceialColumn.Size = new System.Drawing.Size(103, 17);
            this.dataSpceialColumn.TabIndex = 3;
            this.dataSpceialColumn.Text = "Special Columns";
            this.dataSpceialColumn.UseVisualStyleBackColor = true;
            this.dataSpceialColumn.CheckedChanged += new System.EventHandler(this.dataSpceialColumn_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataRowByRow);
            this.groupBox3.Controls.Add(this.dataPrimaryKey);
            this.groupBox3.Location = new System.Drawing.Point(57, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 64);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Row Type";
            // 
            // dataRowByRow
            // 
            this.dataRowByRow.AutoSize = true;
            this.dataRowByRow.Checked = true;
            this.dataRowByRow.Location = new System.Drawing.Point(6, 19);
            this.dataRowByRow.Name = "dataRowByRow";
            this.dataRowByRow.Size = new System.Drawing.Size(86, 17);
            this.dataRowByRow.TabIndex = 0;
            this.dataRowByRow.TabStop = true;
            this.dataRowByRow.Text = "Row by Row";
            this.dataRowByRow.UseVisualStyleBackColor = true;
            // 
            // dataPrimaryKey
            // 
            this.dataPrimaryKey.AutoSize = true;
            this.dataPrimaryKey.Location = new System.Drawing.Point(6, 42);
            this.dataPrimaryKey.Name = "dataPrimaryKey";
            this.dataPrimaryKey.Size = new System.Drawing.Size(80, 17);
            this.dataPrimaryKey.TabIndex = 1;
            this.dataPrimaryKey.Text = "Primary Key";
            this.dataPrimaryKey.UseVisualStyleBackColor = true;
            this.dataPrimaryKey.CheckedChanged += new System.EventHandler(this.dataPrimaryKey_CheckedChanged);
            // 
            // primaryCC
            // 
            this.primaryCC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.primaryCC.Location = new System.Drawing.Point(3, 40);
            this.primaryCC.Name = "primaryCC";
            this.primaryCC.SelectedIndexColumnA = -1;
            this.primaryCC.SelectedIndexColumnB = -1;
            this.primaryCC.ShowCheckBoxEnable = false;
            this.primaryCC.Size = new System.Drawing.Size(504, 26);
            this.primaryCC.TabIndex = 3;
            // 
            // columnCollection
            // 
            this.columnCollection.ColumnsA = null;
            this.columnCollection.ColumnsB = null;
            this.columnCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnCollection.Header = "Compare Columns";
            this.columnCollection.Location = new System.Drawing.Point(0, 149);
            this.columnCollection.Name = "columnCollection";
            this.columnCollection.SheetAName = "Sheet A";
            this.columnCollection.SheetBName = "Sheet B";
            this.columnCollection.Size = new System.Drawing.Size(510, 443);
            this.columnCollection.TabIndex = 4;
            // 
            // ListColumnComparision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.columnCollection);
            this.Controls.Add(this.grPrimary);
            this.Controls.Add(this.groupBox2);
            this.Name = "ListColumnComparision";
            this.Size = new System.Drawing.Size(510, 592);
            this.grPrimary.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grPrimary;
        private System.Windows.Forms.Label lbSheetA;
        private ColumnComparison primaryCC;
        private System.Windows.Forms.Label lbSheetB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton dataColumnByColumn;
        private System.Windows.Forms.RadioButton dataSpceialColumn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton dataRowByRow;
        private System.Windows.Forms.RadioButton dataPrimaryKey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComparisionCollection columnCollection;
    }
}
