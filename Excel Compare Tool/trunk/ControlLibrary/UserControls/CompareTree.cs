using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlLibrary.Classes.Events;

namespace ControlLibrary.UserControls
{
    public partial class CompareTree : UserControl
    {
        public CompareTree()
        {
            InitializeComponent();

            this.treeViewA.AddLinkedTreeView(this.treeViewB);
            this.treeViewB.AddLinkedTreeView(this.treeViewA);
        }

        public CTreeView TreeViewA
        { get { return this.treeViewA; } }

        public CTreeView TreeViewB
        { get { return this.treeViewB; } }

        //
        // Summary:
        //     Gets or sets the System.Windows.Forms.ImageList that contains the System.Drawing.Image
        //     objects used by the tree nodes.
        //
        // Returns:
        //     The System.Windows.Forms.ImageList that contains the System.Drawing.Image
        //     objects used by the tree nodes. The default value is null.
        [DefaultValue("")]
        public ImageList ImageList
        {
            get { return this.TreeViewA.ImageList; }
            set
            {
                this.TreeViewA.ImageList = value;
                this.TreeViewB.ImageList = value;
            }
        }

        //TreeNode cr_NodeA;
        //TreeNode cr_NodeB;
        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode cr_Node = e.Node;
            TreeView cr_Tree = sender == this.treeViewA ? this.treeViewB : this.treeViewA;

            Stack<int> stack = new Stack<int>();

            while (cr_Node != null)
            {
                stack.Push(cr_Node.Index);
                cr_Node = cr_Node.Parent;
            }

            cr_Node = null;
            while (stack.Count > 0)
            {
                int index = stack.Pop();
                if (cr_Node == null)
                {
                    if (cr_Tree.Nodes.Count > index)
                        cr_Node = cr_Tree.Nodes[index];
                }
                else if (cr_Node.Nodes.Count > index)
                    cr_Node = cr_Node.Nodes[index];

                cr_Node.Expand();
            }
        }
    }
}
