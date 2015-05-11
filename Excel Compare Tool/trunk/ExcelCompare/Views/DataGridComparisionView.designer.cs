using ExcelCompare.UserControls;
namespace ExcelCompare
{
    partial class DataGridComparisionView
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInputData = new System.Windows.Forms.TabPage();
            this.listColumnComparision = new ControlLibrary.UserControls.ListColumnComparision();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btCompare = new System.Windows.Forms.Button();
            this.fileCompareBrowser = new ExcelCompare.UserControls.FileComparisionBrowser();
            this.tabOriginal = new System.Windows.Forms.TabPage();
            this.oriDataGrids = new ControlLibrary.UserControls.CompareDataGrids();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.resultDataGrids = new ControlLibrary.UserControls.CompareDataGrids();
            this.groupResultTab = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbFileB = new System.Windows.Forms.LinkLabel();
            this.btExportToXLS = new System.Windows.Forms.Button();
            this.lbFileA = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chShowDiffRow = new System.Windows.Forms.CheckBox();
            this.chShowOnlyDiffCol = new System.Windows.Forms.CheckBox();
            this.chOnlyCompareCol = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabInputData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabOriginal.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.groupResultTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInputData);
            this.tabControl1.Controls.Add(this.tabOriginal);
            this.tabControl1.Controls.Add(this.tabResult);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 780);
            this.tabControl1.TabIndex = 0;
            // 
            // tabInputData
            // 
            this.tabInputData.Controls.Add(this.listColumnComparision);
            this.tabInputData.Controls.Add(this.groupBox2);
            this.tabInputData.Controls.Add(this.fileCompareBrowser);
            this.tabInputData.Location = new System.Drawing.Point(4, 22);
            this.tabInputData.Name = "tabInputData";
            this.tabInputData.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputData.Size = new System.Drawing.Size(784, 754);
            this.tabInputData.TabIndex = 0;
            this.tabInputData.Text = "Input Data";
            this.tabInputData.UseVisualStyleBackColor = true;
            // 
            // listColumnComparision
            // 
            this.listColumnComparision.ColumnsA = null;
            this.listColumnComparision.ColumnsB = null;
            this.listColumnComparision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listColumnComparision.Location = new System.Drawing.Point(3, 98);
            this.listColumnComparision.Name = "listColumnComparision";
            this.listColumnComparision.SheetAName = "Sheet A";
            this.listColumnComparision.SheetBName = "Sheet B";
            this.listColumnComparision.Size = new System.Drawing.Size(778, 605);
            this.listColumnComparision.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btCompare);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 703);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btCompare
            // 
            this.btCompare.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCompare.Location = new System.Drawing.Point(625, 16);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(150, 29);
            this.btCompare.TabIndex = 4;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            this.btCompare.Click += new System.EventHandler(this.btCompare_Click);
            // 
            // fileCompareBrowser
            // 
            this.fileCompareBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileCompareBrowser.Hearder = "Files Comparison";
            this.fileCompareBrowser.Location = new System.Drawing.Point(3, 3);
            this.fileCompareBrowser.Name = "fileCompareBrowser";
            this.fileCompareBrowser.Size = new System.Drawing.Size(778, 95);
            this.fileCompareBrowser.TabIndex = 3;
            this.fileCompareBrowser.TabStop = false;
            this.fileCompareBrowser.SelectionChanged += new System.EventHandler<ExcelCompare.Classes.Events.FileSelectionEventArgs>(this.fileCompareBrowser_SelectionChanged);
            // 
            // tabOriginal
            // 
            this.tabOriginal.Controls.Add(this.oriDataGrids);
            this.tabOriginal.Location = new System.Drawing.Point(4, 22);
            this.tabOriginal.Name = "tabOriginal";
            this.tabOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tabOriginal.Size = new System.Drawing.Size(784, 754);
            this.tabOriginal.TabIndex = 1;
            this.tabOriginal.Text = "Original Data";
            this.tabOriginal.UseVisualStyleBackColor = true;
            // 
            // oriDataGrids
            // 
            this.oriDataGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oriDataGrids.Location = new System.Drawing.Point(3, 3);
            this.oriDataGrids.Name = "oriDataGrids";
            this.oriDataGrids.Size = new System.Drawing.Size(778, 748);
            this.oriDataGrids.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.resultDataGrids);
            this.tabResult.Controls.Add(this.groupResultTab);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Size = new System.Drawing.Size(784, 754);
            this.tabResult.TabIndex = 2;
            this.tabResult.Text = "Compare Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // resultDataGrids
            // 
            this.resultDataGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGrids.Location = new System.Drawing.Point(0, 80);
            this.resultDataGrids.Name = "resultDataGrids";
            this.resultDataGrids.Size = new System.Drawing.Size(784, 674);
            this.resultDataGrids.TabIndex = 0;
            this.resultDataGrids.SelectionChanged += new System.EventHandler(this.resultDataGrids_SelectionChanged);
            // 
            // groupResultTab
            // 
            this.groupResultTab.Controls.Add(this.tableLayoutPanel1);
            this.groupResultTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupResultTab.Location = new System.Drawing.Point(0, 0);
            this.groupResultTab.Name = "groupResultTab";
            this.groupResultTab.Size = new System.Drawing.Size(784, 80);
            this.groupResultTab.TabIndex = 1;
            this.groupResultTab.TabStop = false;
            this.groupResultTab.Text = "Export";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbFileB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btExportToXLS, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbFileA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 61);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbFileB
            // 
            this.lbFileB.AutoSize = true;
            this.lbFileB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFileB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileB.Location = new System.Drawing.Point(392, 30);
            this.lbFileB.Name = "lbFileB";
            this.lbFileB.Size = new System.Drawing.Size(383, 31);
            this.lbFileB.TabIndex = 3;
            this.lbFileB.TabStop = true;
            this.lbFileB.Text = "Excel File A : Sheet A";
            this.lbFileB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFileB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbFileA_LinkClicked);
            // 
            // btExportToXLS
            // 
            this.btExportToXLS.Dock = System.Windows.Forms.DockStyle.Right;
            this.btExportToXLS.Location = new System.Drawing.Point(678, 3);
            this.btExportToXLS.Name = "btExportToXLS";
            this.btExportToXLS.Size = new System.Drawing.Size(97, 24);
            this.btExportToXLS.TabIndex = 0;
            this.btExportToXLS.Text = "Export to Excel";
            this.btExportToXLS.UseVisualStyleBackColor = true;
            this.btExportToXLS.Click += new System.EventHandler(this.btExportToXLS_Click);
            // 
            // lbFileA
            // 
            this.lbFileA.AutoSize = true;
            this.lbFileA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFileA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFileA.Location = new System.Drawing.Point(3, 30);
            this.lbFileA.Name = "lbFileA";
            this.lbFileA.Size = new System.Drawing.Size(383, 31);
            this.lbFileA.TabIndex = 2;
            this.lbFileA.TabStop = true;
            this.lbFileA.Text = "Excel File A : Sheet A";
            this.lbFileA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbFileA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbFileA_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chShowDiffRow);
            this.panel1.Controls.Add(this.chShowOnlyDiffCol);
            this.panel1.Controls.Add(this.chOnlyCompareCol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 24);
            this.panel1.TabIndex = 4;
            // 
            // chShowDiffRow
            // 
            this.chShowDiffRow.AutoSize = true;
            this.chShowDiffRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.chShowDiffRow.Location = new System.Drawing.Point(326, 0);
            this.chShowDiffRow.Name = "chShowDiffRow";
            this.chShowDiffRow.Size = new System.Drawing.Size(145, 24);
            this.chShowDiffRow.TabIndex = 4;
            this.chShowDiffRow.Text = "Show only difference row";
            this.chShowDiffRow.UseVisualStyleBackColor = true;
            this.chShowDiffRow.CheckedChanged += new System.EventHandler(this.chShowDiffRow_CheckedChanged);
            // 
            // chShowOnlyDiffCol
            // 
            this.chShowOnlyDiffCol.AutoSize = true;
            this.chShowOnlyDiffCol.Dock = System.Windows.Forms.DockStyle.Left;
            this.chShowOnlyDiffCol.Location = new System.Drawing.Point(164, 0);
            this.chShowOnlyDiffCol.Name = "chShowOnlyDiffCol";
            this.chShowOnlyDiffCol.Size = new System.Drawing.Size(162, 24);
            this.chShowOnlyDiffCol.TabIndex = 3;
            this.chShowOnlyDiffCol.Text = "Show only difference column";
            this.chShowOnlyDiffCol.UseVisualStyleBackColor = true;
            this.chShowOnlyDiffCol.CheckedChanged += new System.EventHandler(this.chShowOnlyDiffCol_CheckedChanged);
            // 
            // chOnlyCompareCol
            // 
            this.chOnlyCompareCol.AutoSize = true;
            this.chOnlyCompareCol.Dock = System.Windows.Forms.DockStyle.Left;
            this.chOnlyCompareCol.Location = new System.Drawing.Point(0, 0);
            this.chOnlyCompareCol.Name = "chOnlyCompareCol";
            this.chOnlyCompareCol.Size = new System.Drawing.Size(164, 24);
            this.chOnlyCompareCol.TabIndex = 2;
            this.chOnlyCompareCol.Text = "Show only comparing column";
            this.chOnlyCompareCol.UseVisualStyleBackColor = true;
            this.chOnlyCompareCol.CheckedChanged += new System.EventHandler(this.chOnlyCompareColumns_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // DataGridComparisionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "DataGridComparisionView";
            this.Size = new System.Drawing.Size(792, 780);
            this.tabControl1.ResumeLayout(false);
            this.tabInputData.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabOriginal.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.groupResultTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInputData;
        private ControlLibrary.UserControls.ListColumnComparision listColumnComparision;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btCompare;
        private FileComparisionBrowser fileCompareBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TabPage tabOriginal;
        private ControlLibrary.UserControls.CompareDataGrids oriDataGrids;
        private ControlLibrary.UserControls.CompareDataGrids resultDataGrids;
        private System.Windows.Forms.GroupBox groupResultTab;
        private System.Windows.Forms.Button btExportToXLS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel lbFileB;
        private System.Windows.Forms.LinkLabel lbFileA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chShowOnlyDiffCol;
        private System.Windows.Forms.CheckBox chOnlyCompareCol;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chShowDiffRow;
    }
}