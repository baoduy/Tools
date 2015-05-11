using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Reflection;
using System.Data;
using System.Data.OleDb;

namespace ExcelCompare.Classes
{
    public class DataConverter
    {
        public static void ReleaseCOMObj(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                GC.Collect();
            }
            catch { }
            obj = null;
        }

        #region XSL
        public static String[] GetExcelSheetNames(string excelFile)
        {
            CheckExistFile(excelFile);

            if (excelFile.ToLower().Contains("csv"))
            {
                return new string[] { "Sheet1" };
            }

            string[] excelSheets = null;

            string connString = GetOLEDBConnectionString(excelFile);

            using (OleDbConnection objConn = new OleDbConnection(connString))
            {
                objConn.Open();
                using (DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null))
                {
                    if (dt == null)
                    {
                        return null;
                    }

                    excelSheets = new String[dt.Rows.Count];
                    int i = 0;

                    // Add the sheet name to the string array.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString().Replace("'", "").Replace("$", "");
                        i++;
                    }
                }
            }

            return excelSheets;
        }

        private static string GetOLEDBConnectionString(string excelFile)
        {
            if (excelFile.Contains(".xlsx"))
            {
                return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;" +
                        "Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"", excelFile);
            }
            else
            {
                return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;" +
                        "Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"", excelFile);
            }
        }

        public static FileInfo CheckExistFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                    return file;
            }
            throw new System.IO.FileNotFoundException(string.Format("The file path Can't found: {0}", filePath));
        }

        public static void CheckExistFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
                throw new ArgumentNullException();
            else if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outputFolder">output folder. If null is the same input file.</param>
        public static void CSVtoXSL(string filePath, string outputFolder)
        {
            FileInfo file = CheckExistFile(filePath);

            if (string.IsNullOrEmpty(outputFolder))
            {
                outputFolder = file.Directory.FullName;
            }
            else CheckExistFolder(outputFolder);

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);

            int rowIndex = 1;
            string line = null;
            char seperateChar = char.MinValue;

            using (StreamReader reader = System.IO.File.OpenText(file.FullName))
            {
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    if (seperateChar == char.MinValue)
                    {
                        foreach (char c in ExcelCompare.Properties.Settings.Default.CSVSeperaterChar)
                            if (line.IndexOf(c) > 0)
                            {
                                seperateChar = c;
                                break;
                            }
                        if (seperateChar == char.MinValue)
                            throw new ArgumentException("Seperate Charater not found");
                    }

                    string[] values = line.Split(seperateChar);
                    if (values == null)
                    { continue; }

                    for (int i = 0; i < values.Length; i++)
                    {
                        workSheet.Cells[rowIndex, i + 1] = values[i];
                    }
                    rowIndex++;
                }
            }

            string outputFile = outputFolder + "\\" + file.Name.Replace(file.Extension, ".xls");
            if (System.IO.File.Exists(outputFile))
            {
                System.IO.File.Delete(outputFile);
            }

            workbook.SaveAs(outputFile,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            workbook.Close(true, Missing.Value, Missing.Value);
            excelApp.Quit();

            ReleaseCOMObj(workSheet);
            ReleaseCOMObj(workbook);
            ReleaseCOMObj(excelApp);
        }
        #endregion

        #region DataTable
        public static System.Data.DataTable CSVtoDataTable(string filePath)
        {
            FileInfo file = CheckExistFile(filePath);
            DataTable dataTable = new DataTable();
            string line = null;
            char seperateChar = char.MinValue;

            using (StreamReader reader = System.IO.File.OpenText(file.FullName))
            {
                if (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    if (seperateChar == char.MinValue)
                    {
                        foreach (char c in ExcelCompare.Properties.Settings.Default.CSVSeperaterChar)
                        {
                            if (line.IndexOf(c) > 0)
                            {
                                seperateChar = c;
                                break;
                            }
                        }

                        if (seperateChar == char.MinValue)
                            throw new ArgumentException("Seperate Charater not found");
                    }

                    string[] values = line.Split(seperateChar);

                    foreach (string c in values)
                    {
                        dataTable.Columns.Add(c);
                    }
                }

                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    string[] values = line.Split(seperateChar);
                    if (values == null)
                    { continue; }

                    dataTable.Rows.Add(values);
                }
            }

            return dataTable;
        }

        public static System.Data.DataTable XSLtoDataTable(string excelFile, string sheetName)
        {
            FileInfo file = CheckExistFile(excelFile);

            string connString = GetOLEDBConnectionString(excelFile);

            System.Data.DataTable dataTable = new System.Data.DataTable();

            using (OleDbConnection objConn = new OleDbConnection(connString))
            {
                objConn.Open();
                OleDbCommand command = objConn.CreateCommand();
                command.CommandText = string.Format("SELECT * FROM [{0}$]", sheetName);
                command.CommandType = CommandType.TableDirect;

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        //public static DataTable XSLtoDataTable(string filePath, string sheetName)
        //{
        //    return XSLtoTable(filePath, sheetName);
        //}

        //public static DataTable XSLtoDataTable(string filePath, short sheetIndex)
        //{
        //    return XSLtoTable(filePath, sheetIndex);
        //}

        //private static DataTable XSLtoTable(string filePath, object sheetIndex)
        //{
        //    var file = CheckExistFile(filePath);
        //    var dataTable = new DataTable();

        //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    var workbook = excelApp.Workbooks.Open(file.FullName);
        //    var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[sheetIndex];
        //    var usedRange = workSheet.UsedRange;

        //    var cols = usedRange.get_Range(usedRange.Cells[1, 1], usedRange.Cells[1, usedRange.Columns.Count]);
        //    for (int i = 1; i <= cols.Columns.Count; i++)
        //    {
        //        var value = (cols[1, i] as Microsoft.Office.Interop.Excel.Range).Value2;
        //        if (value != null)
        //        {
        //            dataTable.Columns.Add(value.ToString());
        //        }
        //        else dataTable.Columns.Add(i.ToString());
        //    }

        //    for (int i = 2; i < usedRange.Rows.Count; i++)
        //    {
        //        var objs = new object[usedRange.Columns.Count];
        //        for (int j = 1; j <= objs.Length; j++)
        //        {
        //            objs[j-1] = (usedRange.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value2;
        //        }

        //        dataTable.Rows.Add(objs);
        //    }
        //    return dataTable;

        //}
        #endregion
    }
}
