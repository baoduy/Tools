using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace ExcelCompare.Classes
{
    public class CompareTablesResult : CompareTablesBase
    {
        IList<DifferenceCell> differenceCells;
        public IList<DifferenceCell> DifferenceCells
        {
            get { return differenceCells; }
            set { differenceCells = value; }
        }

        IList<int> notFoundTableARowIndex;
        public IList<int> NotFoundTableARowIndex
        {
            get { return notFoundTableARowIndex; }
            set { notFoundTableARowIndex = value; }
        }

        IList<int> notFoundTableBRowIndex;
        public IList<int> NotFoundTableBRowIndex
        {
            get { return notFoundTableBRowIndex; }
            set { notFoundTableBRowIndex = value; }
        }

        public CompareTablesResult GetOnlyDifferenceRow()
        {
            CompareTablesResult result = new CompareTablesResult();
            result.DifferenceCells = new List<DifferenceCell>();
            result.NotFoundTableARowIndex = new List<int>();
            result.NotFoundTableBRowIndex = new List<int>();
            
            result.TableA =this.TableA.Clone();
            result.TableB =this.TableB.Clone();

            result.TableA.Rows.Clear();
            result.TableB.Rows.Clear();

            foreach (DifferenceCell cell in this.DifferenceCells)
            { 
                result.TableA.Rows.Add(this.TableA.Rows[cell.RowIndex].ItemArray);
                result.TableB.Rows.Add(this.TableB.Rows[cell.RowIndex].ItemArray);

                DifferenceCell newCell= new DifferenceCell();
                newCell.ColumnA = cell.ColumnA;
                newCell.ColumnB = cell.ColumnB;
                newCell.RowIndex =  result.TableA.Rows.Count - 1;

                result.DifferenceCells.Add(newCell);
            }

            foreach (int i in this.NotFoundTableARowIndex)
            {
                result.TableA.Rows.Add(this.TableA.Rows[i].ItemArray);
                result.TableB.Rows.Add(this.TableB.Rows[i].ItemArray);

                result.NotFoundTableARowIndex.Add(result.TableA.Rows.Count - 1);
            }

            foreach (int i in this.notFoundTableBRowIndex)
            {
                result.TableA.Rows.Add(this.TableA.Rows[i].ItemArray);
                result.TableB.Rows.Add(this.TableB.Rows[i].ItemArray);

                result.NotFoundTableARowIndex.Add(result.TableA.Rows.Count - 1);
            }

            return result;
        }
    }
}
