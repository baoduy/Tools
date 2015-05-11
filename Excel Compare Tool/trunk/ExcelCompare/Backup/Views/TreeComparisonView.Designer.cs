namespace ExcelCompare.Views
{
    partial class TreeComparisonView
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInputData = new System.Windows.Forms.TabPage();
            this.groupBt = new System.Windows.Forms.GroupBox();
            this.btCompare = new System.Windows.Forms.Button();
            this.tabOrgData = new System.Windows.Forms.TabPage();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.groupExport = new System.Windows.Forms.GroupBox();
            this.groupingDataCollection = new ControlLibrary.UserControls.GroupingDataCollection();
            this.fileComparisionBrowser = new ExcelCompare.UserControls.FileComparisionBrowser();
            this.TreeOriginal = new ControlLibrary.UserControls.CompareTree();
            this.compareTree = new ControlLibrary.UserControls.CompareTree();
            this.tabControl.SuspendLayout();
            this.tabInputData.SuspendLayout();
            this.groupBt.SuspendLayout();
            this.tabOrgData.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInputData);
            this.tabControl.Controls.Add(this.tabOrgData);
            this.tabControl.Controls.Add(this.tabResult);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(688, 764);
            this.tabControl.TabIndex = 0;
            // 
            // tabInputData
            // 
            this.tabInputData.Controls.Add(this.groupingDataCollection);
            this.tabInputData.Controls.Add(this.groupBt);
            this.tabInputData.Controls.Add(this.fileComparisionBrowser);
            this.tabInputData.Location = new System.Drawing.Point(4, 22);
            this.tabInputData.Name = "tabInputData";
            this.tabInputData.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputData.Size = new System.Drawing.Size(680, 738);
            this.tabInputData.TabIndex = 0;
            this.tabInputData.Text = "Input Data";
            this.tabInputData.UseVisualStyleBackColor = true;
            // 
            // groupBt
            // 
            this.groupBt.Controls.Add(this.btCompare);
            this.groupBt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBt.Location = new System.Drawing.Point(3, 690);
            this.groupBt.Name = "groupBt";
            this.groupBt.Size = new System.Drawing.Size(674, 45);
            this.groupBt.TabIndex = 5;
            this.groupBt.TabStop = false;
            // 
            // btCompare
            // 
            this.btCompare.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCompare.Location = new System.Drawing.Point(521, 16);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(150, 26);
            this.btCompare.TabIndex = 4;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            this.btCompare.Click += new System.EventHandler(this.btCompare_Click);
            // 
            // tabOrgData
            // 
            this.tabOrgData.Controls.Add(this.TreeOriginal);
            this.tabOrgData.Location = new System.Drawing.Point(4, 22);
            this.tabOrgData.Name = "tabOrgData";
            this.tabOrgData.Size = new System.Drawing.Size(680, 738);
            this.tabOrgData.TabIndex = 2;
            this.tabOrgData.Text = "Original Data";
            this.tabOrgData.UseVisualStyleBackColor = true;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.compareTree);
            this.tabResult.Controls.Add(this.groupExport);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(680, 738);
            this.tabResult.TabIndex = 1;
            this.tabResult.Text = "Compare Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // groupExport
            // 
            this.groupExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupExport.Location = new System.Drawing.Point(3, 3);
            this.groupExport.Name = "groupExport";
            this.groupExport.Size = new System.Drawing.Size(674, 56);
            this.groupExport.TabIndex = 0;
            this.groupExport.TabStop = false;
            this.groupExport.Text = "Export";
            // 
            // groupingDataCollection
            // 
            this.groupingDataCollection.Columns = null;
            this.groupingDataCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupingDataCollection.Header = "Grouping Columns";
            this.groupingDataCollection.Location = new System.Drawing.Point(3, 98);
            this.groupingDataCollection.Name = "groupingDataCollection";
            this.groupingDataCollection.Size = new System.Drawing.Size(674, 592);
            this.groupingDataCollection.TabIndex = 1;
            // 
            // fileComparisionBrowser
            // 
            this.fileComparisionBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileComparisionBrowser.Hearder = "Files Comparison";
            this.fileComparisionBrowser.Location = new System.Drawing.Point(3, 3);
            this.fileComparisionBrowser.Name = "fileComparisionBrowser";
            this.fileComparisionBrowser.Size = new System.Drawing.Size(674, 95);
            this.fileComparisionBrowser.TabIndex = 0;
            this.fileComparisionBrowser.SelectionChanged += new System.EventHandler<ExcelCompare.Classes.Events.FileSelectionEventArgs>(this.fileComparisionBrowser_SelectionChanged);
            // 
            // TreeOriginal
            // 
            this.TreeOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeOriginal.ImageList = null;
            this.TreeOriginal.Location = new System.Drawing.Point(0, 0);
            this.TreeOriginal.Name = "TreeOriginal";
            this.TreeOriginal.Size = new System.Drawing.Size(680, 738);
            this.TreeOriginal.TabIndex = 2;
            // 
            // compareTree
            // 
            this.compareTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compareTree.ImageList = null;
            this.compareTree.Location = new System.Drawing.Point(3, 59);
            this.compareTree.Name = "compareTree";
            this.compareTree.Size = new System.Drawing.Size(674, 676);
            this.compareTree.TabIndex = 1;
            // 
            // TreeComparisonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "TreeComparisonView";
            this.Size = new System.Drawing.Size(688, 764);
            this.tabControl.ResumeLayout(false);
            this.tabInputData.ResumeLayout(false);
            this.groupBt.ResumeLayout(false);
            this.tabOrgData.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInputData;
        private System.Windows.Forms.TabPage tabResult;
        private ExcelCompare.UserControls.FileComparisionBrowser fileComparisionBrowser;
        private ControlLibrary.UserControls.GroupingDataCollection groupingDataCollection;
        private System.Windows.Forms.GroupBox groupBt;
        private System.Windows.Forms.Button btCompare;
        private ControlLibrary.UserControls.CompareTree compareTree;
        private System.Windows.Forms.GroupBox groupExport;
        private System.Windows.Forms.TabPage tabOrgData;
        private ControlLibrary.UserControls.CompareTree TreeOriginal;
    }
}
