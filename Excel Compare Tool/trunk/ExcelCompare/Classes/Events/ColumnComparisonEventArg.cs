using System;
using System.Collections.Generic;
using System.Text;
using ExcelCompare.UserControls;

namespace ExcelCompare.Classes.Events
{
    public class ColumnComparisonEventArgs : ComparisionEventArgsBase<ColumnComparison>
    {
        public ColumnComparisonEventArgs(ColumnComparison columnControl)
            : base(columnControl)
        {
        }
    }
}
