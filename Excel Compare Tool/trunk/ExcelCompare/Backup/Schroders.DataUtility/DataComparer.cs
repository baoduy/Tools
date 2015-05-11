using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Drawing;

namespace Schroders.DataUtility
{
    public class DataComparer
    {
        public static string Replace(string value, string[] oldValues, string newValue)
        {
            if (oldValues != null && oldValues.Length > 0 && !string.IsNullOrEmpty(value))
            {
                int originalLength = value.Length;
                foreach (string s in oldValues)
                    value = value.Replace(s, newValue);
            }
            return value;
        }

        public static bool IsEquals(object objA, object objB)
        { return IsEquals(objA, objB, null); }

        public static bool IsEquals(object objA, object objB, string[] ignoreStrings)
        {
            if (objA != null && objB != null)
            {
                if (ignoreStrings == null || ignoreStrings.Length <= 0)
                    return objA.ToString().Trim().ToLower() == objB.ToString().Trim().ToLower();
                else
                {
                    string strA = Replace(objA.ToString(), ignoreStrings, string.Empty);
                    string strB = Replace(objB.ToString(), ignoreStrings, string.Empty);

                    return strA.Trim().ToLower() == strB.Trim().ToLower();
                }
            }
            else if (objA != null || objB != null)
                return false;

            return true;
        }

        public static ReadOnlyCollection<CompareColumnName> Diffrence(DataRow rowA, DataRow rowB, IList<CompareColumnName> Columns)
        { return Diffrence(rowA, rowB, Columns, null); }

        public static ReadOnlyCollection<CompareColumnName> Diffrence(DataRow rowA, DataRow rowB, IList<CompareColumnName> Columns, string[] ignoreStrings)
        {
            IList<CompareColumnName> list = new List<CompareColumnName>();

            foreach (CompareColumnName col in Columns)
            {
                object valA = rowA[col.ColumnA];
                object valB = rowB[col.ColumnB];
                if (!IsEquals(valA, valB, ignoreStrings))
                {
                    list.Add(col);
                }
            }

            return new ReadOnlyCollection<CompareColumnName>(list);
        }

        private static KeyValuePair<DataRow, ReadOnlyCollection<CompareColumnName>> FindLessDifference(DataRow rowA, DataRow[] rowArray, CompareColumnNameCollection columnCompares, string[] ignoreStrings)
        {
            ReadOnlyCollection<CompareColumnName> currentCells = null;
            DataRow currentRow = null;

            foreach (DataRow rowB in rowArray)
            {
                ReadOnlyCollection<CompareColumnName> cells = DataComparer.Diffrence(rowA, rowB, columnCompares);
                if (cells != null && cells.Count > 0)
                {
                    if (currentCells == null || cells.Count < currentCells.Count)
                    {
                        currentCells = cells;
                        currentRow = rowB;
                    }
                }//Found a row the same with rowA
                else
                {
                    currentCells = null;
                    currentRow = null;
                    break;
                }
            }

            return new KeyValuePair<DataRow, ReadOnlyCollection<CompareColumnName>>(currentRow, currentCells);
        }

        private static DataRow[] SearchData(DataTable sourceTable, string PrimaryKey, object primaryValue, string[] ignoreStrings)
        {
            if (sourceTable.Columns[PrimaryKey].DataType != typeof(string))
                return sourceTable.Select(string.Format("[{0}] = {1}", PrimaryKey, primaryValue));

            StringBuilder filterExpression = new StringBuilder();

            if (ignoreStrings != null && ignoreStrings.Length > 0 && primaryValue != null)
            {
                string priValue = Replace(primaryValue.ToString(), ignoreStrings, "%");
                priValue = priValue.Replace("'", "''");

                int index = priValue.IndexOf("%");
                if (index > 0 && index < priValue.Length - 1)
                {
                    foreach (string val in priValue.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (filterExpression.Length > 0)
                            filterExpression.Append(" AND ");

                        filterExpression.AppendFormat("{0} LIKE '%{1}%'", PrimaryKey, val.Trim());
                    }
                }
                else if (index != -1)
                    filterExpression.AppendFormat("[{0}] LIKE '{1}'", PrimaryKey, priValue.Trim());
                else filterExpression.AppendFormat("[{0}] = '{1}'", PrimaryKey, priValue.Trim());
            }
            else
            { filterExpression.AppendFormat("[{0}] = '{1}'", PrimaryKey, primaryValue.ToString().Replace("'", "''")); }

            return sourceTable.Select(filterExpression.ToString());
        }

        public static CompareTablesResult Compare(CompareTable compareInfo)
        {
            CompareTablesResult result = new CompareTablesResult();
            result.OriginalTableA = compareInfo.TableA;
            result.OriginalTableB = compareInfo.TableB;
            //Copy Columns
            result.TableA = compareInfo.TableA.Clone();
            result.TableB = compareInfo.TableB.Clone();

            if (string.IsNullOrEmpty(result.TableA.TableName))
                result.TableA.TableName = "Table";
            if (string.IsNullOrEmpty(result.TableB.TableName))
                result.TableB.TableName = "Table";

            if (result.TableA.TableName == result.TableB.TableName)
            {
                result.TableA.TableName += "_A";
                result.TableB.TableName += "_B";
            }

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

                    string priStr = Replace(priAval.ToString(), compareInfo.IgnoreStrings, string.Empty);
                    if (!string.IsNullOrEmpty(priStr))
                        priStr = priStr.Trim().ToLower();

                    //Collect compared keys for not found rows below
                    if (!comparedKeys.Contains(priStr))
                        comparedKeys.Add(priStr);

                    #region Find each rowA in TableB
                    DataRow[] rowsB = SearchData(tableB, compareInfo.PrimaryColumn.ColumnB, priAval, compareInfo.IgnoreStrings);

                    //Found Row
                    if (rowsB != null && rowsB.Length > 0)
                    {
                        KeyValuePair<DataRow, ReadOnlyCollection<CompareColumnName>> dataRowCell = DataComparer.FindLessDifference(rowA, rowsB, compareInfo.CompareColumns, compareInfo.IgnoreStrings);

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

                    string priBStr = Replace(priBval.ToString(), compareInfo.IgnoreStrings, string.Empty);
                    if (!string.IsNullOrEmpty(priBStr))
                        priBStr = priBStr.Trim().ToLower();

                    if (comparedKeys.Contains(priBStr))
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

        private static void SetDifferentColorParrent(TreeNode node, Color DifferenceColor)
        {
            while (node.Parent != null)
            {
                node.Parent.BackColor = DifferenceColor;
                node = node.Parent;
            }
        }

        private static void SetNotFoundColorIndex(TreeNode node, Color NotFoundColor)
        {
            node.BackColor = NotFoundColor;
        }

        public static bool Compare(TreeNodeCollection treeNodesA, TreeNodeCollection treeNodesB, Color DifferenceColor, Color NotFoundColor)
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
                    DataComparer.SetNotFoundColorIndex(nodeA, NotFoundColor);
                    treeNodesA.Add(nodeA);

                    TreeNode node = nodeA.Clone() as TreeNode;
                    node.Text = string.Empty;
                    DataComparer.SetNotFoundColorIndex(node, NotFoundColor);
                    treeNodesB.Add(node);

                    DataComparer.SetDifferentColorParrent(nodeA, DifferenceColor);
                    DataComparer.SetDifferentColorParrent(node, DifferenceColor);

                    end--;
                }
                else
                {
                    TreeNode nodeB = nodesB[0];
                    treeNodesB.Remove(nodeB);
                    treeNodesB.Insert(nodeA.Index, nodeB);

                    if (!IsEquals(nodeA.Text, nodeB.Text))
                    {
                        DataComparer.SetNotFoundColorIndex(nodeA, NotFoundColor);
                        DataComparer.SetNotFoundColorIndex(nodeB, NotFoundColor);
                        diff = true;

                        DataComparer.Compare(nodeA.Nodes, nodeB.Nodes, DifferenceColor, NotFoundColor);
                    }
                    else diff = DataComparer.Compare(nodeA.Nodes, nodeB.Nodes, DifferenceColor, NotFoundColor);

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

                DataComparer.SetNotFoundColorIndex(tmpNode, NotFoundColor);

                TreeNode node = tmpNode.Clone() as TreeNode;
                node.Text = string.Empty;
                DataComparer.SetNotFoundColorIndex(node, NotFoundColor);
                treeNodesA.Insert(tmpNode.Index, node);

                DataComparer.SetDifferentColorParrent(tmpNode, DifferenceColor);
                DataComparer.SetDifferentColorParrent(node, DifferenceColor);
                diff = true;
            }
            return diff;
        }
    }
}
