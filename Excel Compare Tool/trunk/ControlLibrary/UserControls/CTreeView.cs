using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ControlLibrary.Classes;
using System.Runtime.InteropServices;
using System.Drawing;
using ControlLibrary.Classes.Events;

namespace ControlLibrary.UserControls
{
    public partial class CTreeView : TreeView
    {
        private List<CTreeView> linkedTreeViews = new List<CTreeView>();
        /// <summary>     /// Links the specified tree view to this tree view.  
        /// Whenever either treeview     /// scrolls, the other will scroll too.     
        /// </summary>     
        /// <param name="treeView">The TreeView to link.</param>     
        public void AddLinkedTreeView(CTreeView treeView)
        {
            if (treeView == this)
                throw new ArgumentException("Cannot link a TreeView to itself!", "treeView");

            if (!linkedTreeViews.Contains(treeView))
            {
                //add the treeview to our list of linked treeviews
                linkedTreeViews.Add(treeView);
                //add this to the treeview's list of linked treeviews
                treeView.AddLinkedTreeView(this);
                //make sure the TreeView is linked to all of the other TreeViews that this TreeView is linked to
                for (int i = 0; i < linkedTreeViews.Count; i++)
                {
                    //get the linked treeview   
                    CTreeView linkedTreeView = linkedTreeViews[i];
                    //link the treeviews together           
                    if (linkedTreeView != treeView)
                        linkedTreeView.AddLinkedTreeView(treeView);
                }
            }
        }
        /// <summary>     
        /// Sets the destination's scroll positions to that of the source.  
        /// </summary>    
        /// <param name="source">The source of the scroll positions.</param>  
        /// <param name="dest">The destinations to set the scroll positions for.</param>  
        private void SetScrollPositions(CTreeView source, CTreeView dest)
        {
            //get the scroll positions of the source 
            int horizontal = User32.GetScrollPos(source.Handle, Orientation.Horizontal);
            int vertical = User32.GetScrollPos(source.Handle, Orientation.Vertical);
            //set the scroll positions of the destination    
            User32.SetScrollPos(dest.Handle, Orientation.Horizontal, horizontal, true);
            User32.SetScrollPos(dest.Handle, Orientation.Vertical, vertical, true);
        }

        protected override void WndProc(ref Message m)
        {   
            //process the message         
            base.WndProc(ref m);  
            //pass scroll messages onto any linked views      
            if (m.Msg == User32.WM_VSCROLL || m.Msg == User32.WM_MOUSEWHEEL)
            {
                foreach (CTreeView linkedTreeView in linkedTreeViews)
                {
                    //set the scroll positions of the linked tree view   
                    SetScrollPositions(this, linkedTreeView);
                    //copy the windows message               
                    Message copy = new Message();
                    copy.HWnd = linkedTreeView.Handle;
                    copy.LParam = m.LParam;
                    copy.Msg = m.Msg;
                    copy.Result = m.Result;
                    copy.WParam = m.WParam;
                    //pass the message onto the linked tree view     
                    linkedTreeView.RecieveWndProc(ref copy);
                }
            }
        }
        /// <summary>     
        /// Recieves a WndProc message without passing it onto any linked treeviews. 
        /// This is useful to avoid infinite loops. 
        /// /// </summary>     
        /// <param name="m">The windows message.</param> 
        private void RecieveWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
        /// <summary>  
        /// /// Imported functions from the User32.dll   
        /// /// </summary>     
        private class User32
        {
            public const int WM_VSCROLL = 0x115;
            public const int WM_MOUSEWHEEL = 0x020A;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int GetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar);
            [DllImport("user32.dll")]
            public static extern int SetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar, int nPos, bool bRedraw);
        }

        /// <summary>
        /// Copy all node and subnode in tree.
        /// </summary>
        /// <param name="desTree"></param>
        public void CloneNodes(TreeView desTree)
        {
            desTree.Nodes.Clear();
            foreach (TreeNode node in this.Nodes)
                desTree.Nodes.Add(node.Clone() as TreeNode);
        }

        DataTable cr_Date;
        GroupColumnCollection cr_Grouping;
        public void BindingData(DataTable data, GroupColumnCollection groups)
        {
            this.cr_Date = data;
            this.cr_Grouping = groups;

            if (this.cr_Date == null && this.cr_Grouping == null)
                return;

            this.Nodes.Clear();

            foreach (DataRow row in this.cr_Date.Rows)
            {
                TreeNode currentNode = null;
                foreach (string gr in this.cr_Grouping)
                {
                    if (row[gr] == null)
                    {
                        continue;
                    }

                    string value = row[gr].ToString();
                    if (currentNode == null)
                    {
                        TreeNode[] findNodes = this.Nodes.Find(value, false);
                        if (findNodes == null || findNodes.Length <= 0)
                        {
                            currentNode = new TreeNode(value);
                            currentNode.Name = value;
                            this.Nodes.Add(currentNode);
                        }
                        else currentNode = findNodes[0];
                    }
                    else
                    {
                        TreeNode[] findNodes = currentNode.Nodes.Find(value, false);
                        if (findNodes == null || findNodes.Length <= 0)
                        {
                            TreeNode newNode = new TreeNode(value);
                            newNode.Name = value;
                            currentNode.Nodes.Add(newNode);
                            currentNode = newNode;
                        }
                        else currentNode = findNodes[0];
                    }
                }
            }
        }

        public CTreeView()
        {
            InitializeComponent();
        }

        public CTreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
