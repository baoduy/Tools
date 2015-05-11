﻿using System;
using System.Collections.Generic;

using System.Text;

namespace Schroders.DataUtility
{
    [Serializable]
    public class DifferenceCell
    {
        int rowIndex;
        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        string columnA;
        public string ColumnA
        {
            get { return columnA; }
            set { columnA = value; }
        }

        string columnB;
        public string ColumnB
        {
            get { return columnB; }
            set { columnB = value; }
        }
    }
}
