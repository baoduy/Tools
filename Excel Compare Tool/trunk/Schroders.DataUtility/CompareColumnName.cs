using System;
using System.Collections.Generic;

using System.Text;

namespace Schroders.DataUtility
{
    public class CompareColumnName
    {
        private string columnA;
        public string ColumnA
        {
            get { return columnA; }
            set { columnA = value; }
        }

        private string columnB;
        public string ColumnB
        {
            get { return columnB; }
            set { columnB = value; }
        }


        public CompareColumnName(string colmnA,string columnB)
        {
            this.ColumnA = colmnA;
            this.ColumnB = columnB;
        }
    }
}
