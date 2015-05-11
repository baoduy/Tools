using System;
using System.Collections.Generic;

using System.Text;

namespace ExcelCompare.Classes
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
            get { return compareColumns; }
            set { compareColumns = value; }
        }
    }
}
