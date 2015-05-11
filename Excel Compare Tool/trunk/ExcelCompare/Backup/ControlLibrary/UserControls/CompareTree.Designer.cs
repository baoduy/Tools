using ControlLibrary.Classes.Events;
namespace ControlLibrary.UserControls
{
    partial class CompareTree
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewA = new ControlLibrary.UserControls.CTreeView(this.components);
            this.treeViewB = new ControlLibrary.UserControls.CTreeView(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewA);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeViewB);
            this.splitContainer1.Size = new System.Drawing.Size(600, 600);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewA
            // 
            this.treeViewA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewA.Location = new System.Drawing.Point(0, 0);
            this.treeViewA.Name = "treeViewA";
            this.treeViewA.Size = new System.Drawing.Size(300, 600);
            this.treeViewA.TabIndex = 0;
            this.treeViewA.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            // 
            // treeViewB
            // 
            this.treeViewB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewB.Location = new System.Drawing.Point(0, 0);
            this.treeViewB.Name = "treeViewB";
            this.treeViewB.Size = new System.Drawing.Size(296, 600);
            this.treeViewB.TabIndex = 0;
            this.treeViewB.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            // 
            // CompareTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CompareTree";
            this.Size = new System.Drawing.Size(600, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CTreeView treeViewA;
        private CTreeView treeViewB;
    }
}
