using System;
using System.Collections.Generic;
using System.Text;
using ControlLibrary.UserControls;

namespace ControlLibrary.Classes.Events
{
    public class ColumnComparisonEventArgs : ComparisionEventArgsBase<ColumnComparison>
    {
        public ColumnComparisonEventArgs(ColumnComparison columnControl)
            : base(columnControl)
        {
        }
    }
}
