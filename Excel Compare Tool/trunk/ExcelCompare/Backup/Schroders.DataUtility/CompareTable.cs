using System;
using System.Collections.Generic;

using System.Text;

namespace Schroders.DataUtility
{
    public class CompareTable : CompareTablesBase
    {
        CompareColumnName primaryColumn;
        public CompareColumnName PrimaryColumn
        {
            get { return primaryColumn; }
            set { primaryColumn = value; }
        }

        CompareColumnNameCollection compareColumns;
        public CompareColumnNameCollection CompareColumns
        {
            get
            {
                if (compareColumns == null)
                    compareColumns = new CompareColumnNameCollection();
                return compareColumns;
            }
            set { compareColumns = value; }
        }

        private string[] ignoreStrings;
        public string[] IgnoreStrings
        {
            get { return ignoreStrings; }
            set { ignoreStrings = value; }
        }

    }
}
