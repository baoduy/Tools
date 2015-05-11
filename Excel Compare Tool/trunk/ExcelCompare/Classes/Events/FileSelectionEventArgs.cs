using System;
using System.Collections.Generic;
using System.Text;
using ExcelCompare.UserControls;
using ControlLibrary.Classes.Events;

namespace ExcelCompare.Classes.Events
{
    public enum FileTypeName
    { FileA, FileB }

    public class FileSelectionEventArgs : ComparisionEventArgsBase<ExcelFileBrowser>
    {
        FileTypeName fileTypeName;
        public FileTypeName FileTypeName
        {
            get { return fileTypeName; }
            private set { fileTypeName = value; }
        }

        public FileSelectionEventArgs(ExcelFileBrowser control, FileTypeName fileTypeName)
            : base(control)
        {
            this.FileTypeName = fileTypeName;
        }
    }
}
