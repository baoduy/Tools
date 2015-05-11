using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExcelCompare
{
    public partial class TestControls : Form
    {
        public TestControls()
        {
            InitializeComponent();
        }

        private void TestControls_Load(object sender, EventArgs e)
        {
            this.groupingDataCollection1.Add(null);
        }
    }
}