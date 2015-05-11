using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using ExcelCompare.Classes.Events;

namespace ExcelCompare.Classes
{
    public class BackgroundWorkerComparer : BackgroundWorker
    {
        public event EventHandler<ProgressDataChangedEventArgs> ProgressDataChanged;
        protected virtual void OnProgressDataChanged(ProgressDataChangedEventArgs e)
        {
            if (this.ProgressDataChanged != null)
                this.ProgressDataChanged(this, e);
        }

        public void ReportProgressData(object data)
        { }
        public void ReportProgress(object data, object userState)
        { }
    }
}
