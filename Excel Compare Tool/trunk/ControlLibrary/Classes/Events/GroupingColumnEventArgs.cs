using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.Classes.Events
{
    public class GroupingColumnEventArgs : ComparisionEventArgsBase<ComboBox>
    {
        public GroupingColumnEventArgs(ComboBox control)
            : base(control)
        {
        }
    }
}
