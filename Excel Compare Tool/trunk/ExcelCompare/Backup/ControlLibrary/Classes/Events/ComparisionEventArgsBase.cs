using System;
using System.Collections.Generic;
using System.Text;

namespace ControlLibrary.Classes.Events
{
    public abstract class ComparisionEventArgsBase<C> : EventArgs
    {
        C columnControl;
        public C ColumnControl
        {
            get { return columnControl; }
            private set { columnControl = value; }
        }

        public ComparisionEventArgsBase(C columnControl)
        {
            this.ColumnControl = columnControl;
        }
    }
}
