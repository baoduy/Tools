namespace ExcelCompare
{
    partial class TestControls
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
            this.groupingDataCollection1 = new ControlLibrary.UserControls.GroupingDataCollection();
            this.SuspendLayout();
            // 
            // groupingDataCollection1
            // 
            this.groupingDataCollection1.Columns = null;
            this.groupingDataCollection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupingDataCollection1.Header = "Compare Columns";
            this.groupingDataCollection1.Location = new System.Drawing.Point(0, 0);
            this.groupingDataCollection1.Name = "groupingDataCollection1";
            this.groupingDataCollection1.Size = new System.Drawing.Size(527, 449);
            this.groupingDataCollection1.TabIndex = 0;
            // 
            // TestControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 449);
            this.Controls.Add(this.groupingDataCollection1);
            this.Name = "TestControls";
            this.Text = "TestControls";
            this.Load += new System.EventHandler(this.TestControls_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.UserControls.GroupingDataCollection groupingDataCollection1;

    }
}