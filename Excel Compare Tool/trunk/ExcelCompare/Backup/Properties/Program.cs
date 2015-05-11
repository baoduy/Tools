using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace ExcelCompare
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG == false
            try
            {
#endif
                Application.Run(new MainForm());
                //Application.Run(new MainForm());
#if DEBUG ==false
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
#endif
        }
    }
}
