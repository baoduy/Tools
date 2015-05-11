using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Schroders.DataUtility
{
    [Serializable]
    public abstract class CompareTablesBase
    {
        DataTable tableA;
        public DataTable TableA
        {
            get { return tableA; }
            set { tableA = value; }
        }

        DataTable tableB;
        public DataTable TableB
        {
            get { return tableB; }
            set { tableB = value; }
        }
    }
}
