using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.Classes.Events
{
    public class TreeViewScrollEventArgs : EventArgs
    {
        // Scroll event argument
        private TreeNode mTop;
        private bool mTracking;
        
        public TreeViewScrollEventArgs(TreeNode top, bool tracking)
        {
            mTop = top;
            mTracking = tracking;
        }

        public TreeNode Top
        {
            get { return mTop; }
        }

        public bool Tracking
        {
            get { return mTracking; }
        }

    }
}
