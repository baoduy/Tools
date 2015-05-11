using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ExcelCompare.Classes;
using ControlLibrary.Classes;
using Schroders.DataUtility;

namespace ExcelCompare.Views
{
    public partial class TreeComparisonView : UserControl
    {
        public TreeComparisonView()
        {
            InitializeComponent();
        }

        private void fileComparisionBrowser_SelectionChanged(object sender, ExcelCompare.Classes.Events.FileSelectionEventArgs e)
        {
            this.groupingDataCollection.Columns = e.ColumnControl.Columns;
        }

        private void btCompare_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            this.TreeOriginal.TreeViewA.BindingData(
                this.fileComparisionBrowser.ExcelFileA.DataTable, this.groupingDataCollection.GroupColumns);

            this.TreeOriginal.TreeViewB.BindingData(
               this.fileComparisionBrowser.ExcelFileB.DataTable, this.groupingDataCollection.GroupColumns);

            this.TreeOriginal.TreeViewA.CloneNodes(this.compareTree.TreeViewA);
            this.TreeOriginal.TreeViewB.CloneNodes(this.compareTree.TreeViewB);

            DataComparer.Compare(this.compareTree.TreeViewA.Nodes, this.compareTree.TreeViewB.Nodes, Constant.DifferenceColor, Constant.NotFoundAColor);

            this.tabControl.SelectedTab = this.tabResult;

            this.Enabled = true;
        }
    }
}
