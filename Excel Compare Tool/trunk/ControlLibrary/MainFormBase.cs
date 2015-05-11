using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class MainFormBase : Form
    {
        public MainFormBase()
        {
            InitializeComponent();
        }

        protected void ShowForm(Form form)
        {
            this.ShowForm(form, false);
        }

        protected void ShowForm(Form form, bool maximun)
        {
            foreach (Form fr in this.MdiChildren)
                if (fr.GetType() == form.GetType())
                {
                    fr.BringToFront();
                    return;
                }

            form.TopLevel = false;
            form.MdiParent = this;
            form.StartPosition = FormStartPosition.CenterParent;

            if (maximun)
            {
                form.WindowState = FormWindowState.Maximized;
            }

            form.Show();
        }
    }
}