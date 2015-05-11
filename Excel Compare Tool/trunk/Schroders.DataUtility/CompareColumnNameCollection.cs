using System;
using System.Collections.Generic;
using System.Text;

namespace Schroders.DataUtility
{
    public class CompareColumnNameCollection : List<CompareColumnName>
    {
        public CompareColumnName GetColumn(string columnA, string columnB)
        {
            if (string.IsNullOrEmpty(columnA) && string.IsNullOrEmpty(columnB))
                throw new ArgumentException("one of parameter not be null");

            foreach (CompareColumnName col in this)
            {
                if (!string.IsNullOrEmpty(columnA) && !string.IsNullOrEmpty(columnB))
                {
                    if (col.ColumnA == columnA && col.ColumnB == columnB)
                        return col;
                }
                else if (!string.IsNullOrEmpty(columnA))
                {
                    if (col.ColumnA == columnA)
                        return col;
                }
                else if (col.ColumnB == columnB)
                    return col;
            }

            return null;
        }

        public string GetColumnA(string columnB)
        {
            CompareColumnName col = GetColumn(null, columnB);
            if (col != null)
                return col.ColumnA;

            return null;
        }

        public string GetColumnB(string columnA)
        {
            CompareColumnName col = GetColumn(columnA, null);
            if (col != null)
                return col.ColumnA;

            return null;
        }


    }
}
