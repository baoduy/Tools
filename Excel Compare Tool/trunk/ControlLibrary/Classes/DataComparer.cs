using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Drawing;

namespace ControlLibrary.Classes
{
    public class DataComparer
    {
        public static bool IsEquals(object objA, object objB)
        {
            if (objA != null && objB != null)
            {
                return objA.ToString().Trim().ToLower() == objB.ToString().Trim().ToLower();
            }
            else if (objA != null || objB != null)
                return false;

            return true;
        }

        public static ReadOnlyCollection<CompareColumnName> Diffrence(DataRow rowA, DataRow rowB, IList<CompareColumnName> Columns)
        {
            IList<CompareColumnName> list = new List<CompareColumnName>();

            foreach (CompareColumnName col in Columns)
            {
                object valA = rowA[col.ColumnA];
                object valB = rowB[col.ColumnB];
                if (!IsEquals(valA, valB))
                {
                    list.Add(col);
                }
            }

            return new ReadOnlyCollection<CompareColumnName>(list);
        }

        private static KeyValuePair<DataRow, ReadOnlyCollection<CompareColumnName>> FindLessDifference(DataRow rowA, DataRow[] rowArray, CompareColumnNameCollection columnCompares)
        {
            ReadOnlyCollection<CompareColumnName> currentCells = null;
            DataRow currentRow = null;

            foreach (DataRow rowB in rowArray)
            {
                ReadOnlyCollection<CompareColumnName> cells = DataComparer.Diffrence(rowA, rowB, columnCompares);
                if (cells != null)
                {
                    if (currentCells == null || cells.Count < currentCells.Count)
                    {
                        currentCells = cells;
                        currentRow = rowB;
                    }
                }
            }

            return new KeyValuePair<DataRow, ReadOnlyCollection<CompareColumnName>>(currentRow, currentCells);
        }

        private static DataRow[] SearchData(DataTable sourceTable, string PrimaryKey, object primaryValue)
        {
            DataRow[] foundRows = null;
            try
            {
                foundRows = sourceTable.Select(string.Format("[{0}] = '{1}'", PrimaryKey, primaryValue));
            }
            catch (EvaluateException)
            {
                foundRows = sourceTable.Select(string.Format("[{0}] = {1}", PrimaryKey, primaryValue));
            }

            return foundRows;
        }

        public static CompareTablesResult Compare(CompareTable compareInfo)
        {
            CompareTablesResult result = new CompareTablesResult();
            //Copy Columns
            result.TableA = compareInfo.TableA.Clone();
            result.TableB = compareInfo.TableB.Clone();

            result.DifferenceCells = new List<DifferenceCell>();

            DoCompare(compareInfo, result);

            return result;
        }
        
       public static void DoCompare(CompareTable compareInfo, CompareTablesResult result)
        {
            DataTable tableA = compareInfo.TableA;
            DataTable tableB = compareInfo.TableB;

            IList<DataRow> notFoundTableA = new List<DataRow>();
            IList<DataRow> notFoundTableB = new List<DataRow>();

            IList<string> comparedKeys = new List<string>();

            if (compareInfo.PrimaryColumn != null)
            {
                #region Compare with Primary key

                foreach (DataRow rowA in tableA.Rows)
                {
                    object priAval = rowA[compareInfo.PrimaryColumn.ColumnA];

                    if (priAval == null)
                        continue;
                    //Collect compared keys for not found rows below
                    if (!comparedKeys.Contains(priAval.ToString().Trim().ToLower()))
                        comparedKeys.Add(priAval.ToString().Trim().ToLower());

                    #region Find each rowA in TableB
                    DataRow[] rowsB = SearchData(tableB, compareInfo.PrimaryColumn.ColumnB, priAval);

                    //Found Row
                    if (rowsB != null && rowsB.Length > 0)
                    {
                        KeyValuePair<DataRow, ReadOnlyCollection<CompareColumnName>> dataRowCell = DataComparer.FindLessDifference(rowA, rowsB, compareInfo.CompareColumns);

                        if (dataRowCell.Key != null)
                        {
                            result.TableA.Rows.Add(rowA.ItemArray);
                            result.TableB.Rows.Add(dataRowCell.Key.ItemArray);

                            foreach (CompareColumnName cell in dataRowCell.Value)
                            {
                                DifferenceCell diff = new DifferenceCell();
                                diff.RowIndex = result.TableA.Rows.Count - 1;
                                diff.ColumnA = cell.ColumnA;
                                diff.ColumnB = cell.ColumnB;
                                result.DifferenceCells.Add(diff);
                            }
                        }
                    }
                    //Not Found Row
                    else notFoundTableA.Add(rowA);
                    #endregion
                }

                #region Find each rowB in TableA to collect NotFoundRowB.
                foreach (DataRow rowB in tableB.Rows)
                {
                    object priBval = rowB[compareInfo.PrimaryColumn.ColumnB];

                    if (priBval == null)
                        continue;

                    if (comparedKeys.Contains(priBval.ToString().Trim().ToLower()))
                        continue;

                    notFoundTableB.Add(rowB);
                }
                #endregion
                #endregion
            }
            else
            {
                #region Comare Row by Row
                int rowsCount = tableA.Rows.Count > tableB.Rows.Count ?
                    tableB.Rows.Count : tableA.Rows.Count;

                for (int i = 0; i < rowsCount; i++)
                {
                    DataRow rowA = tableA.Rows[i];
                    DataRow rowB = tableB.Rows[i];

                    ReadOnlyCollection<CompareColumnName> cells = Diffrence(rowA, rowB, compareInfo.CompareColumns);
                    if (cells != null)
                    {
                        result.TableA.Rows.Add(rowA.ItemArray);
                        result.TableB.Rows.Add(rowB.ItemArray);

                        foreach (CompareColumnName cell in cells)
                        {
                            DifferenceCell diff = new DifferenceCell();
                            diff.RowIndex = result.TableA.Rows.Count - 1;
                            diff.ColumnA = cell.ColumnA;
                            diff.ColumnB = cell.ColumnB;

                            result.DifferenceCells.Add(diff);
                        }
                    }
                }
                #endregion
            }

            #region Add NotFoundRows
            result.NotFoundTableARowIndex = new List<int>();
            result.NotFoundTableBRowIndex = new List<int>();

            foreach (DataRow row in notFoundTableA)
            {
                result.NotFoundTableARowIndex.Add(result.TableA.Rows.Count);
                result.TableA.Rows.Add(row.ItemArray);
                result.TableB.Rows.Add();

            }

            foreach (DataRow row in notFoundTableB)
            {
                result.NotFoundTableBRowIndex.Add(result.TableB.Rows.Count);
                result.TableB.Rows.Add(row.ItemArray);
                result.TableA.Rows.Add();
            }
            #endregion
        }

        private static void SetDifferentColorParrent(TreeNode node)
        {
            while (node.Parent != null)
            {
                node.Parent.BackColor = Constant.DifferenceColor;
                node = node.Parent;
            }
        }

        private static void SetNotFoundColorIndex(TreeNode node)
        {
            node.BackColor = Constant.NotFoundBColor;
        }

        public static bool Compare(TreeNodeCollection treeNodesA, TreeNodeCollection treeNodesB)
        {
            bool diff = false;
            int i = 0;
            int end = treeNodesA.Count;

            while (i < end)
            {
                TreeNode nodeA = treeNodesA[i];
                TreeNode[] nodesB = treeNodesB.Find(nodeA.Name, false);

                if (nodesB.Length <= 0)
                {
                    treeNodesA.Remove(nodeA);
                    DataComparer.SetNotFoundColorIndex(nodeA);
                    treeNodesA.Add(nodeA);

                    TreeNode node = nodeA.Clone() as TreeNode;
                    node.Text = string.Empty;
                    DataComparer.SetNotFoundColorIndex(node);
                    treeNodesB.Add(node);

                    DataComparer.SetDifferentColorParrent(nodeA);
                    DataComparer.SetDifferentColorParrent(node);

                    end--;
                }
                else
                {
                    TreeNode nodeB = nodesB[0];
                    treeNodesB.Remove(nodeB);
                    treeNodesB.Insert(nodeA.Index, nodeB);

                    if (!IsEquals(nodeA.Text, nodeB.Text))
                    {
                        DataComparer.SetNotFoundColorIndex(nodeA);
                        DataComparer.SetNotFoundColorIndex(nodeB);
                        diff = true;

                        DataComparer.Compare(nodeA.Nodes, nodeB.Nodes);
                    }
                    else diff = DataComparer.Compare(nodeA.Nodes, nodeB.Nodes);

                    if (!diff)
                    {
                        treeNodesA.Remove(nodeA);
                        treeNodesB.Remove(nodeB);
                        end--;
                    }
                    else i++;
                }
            }

            for (i = end; i < treeNodesB.Count; i++)
            {
                TreeNode tmpNode = treeNodesB[i];
                if (string.IsNullOrEmpty(tmpNode.Text))
                    continue;

                DataComparer.SetNotFoundColorIndex(tmpNode);

                TreeNode node = tmpNode.Clone() as TreeNode;
                node.Text = string.Empty;
                DataComparer.SetNotFoundColorIndex(node);
                treeNodesA.Insert(tmpNode.Index, node);

                DataComparer.SetDifferentColorParrent(tmpNode);
                DataComparer.SetDifferentColorParrent(node);
                diff = true;
            }
            return diff;
        }
    }
}
