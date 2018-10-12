using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace YouCom.Service.Configuracion
{
    public class Excel
    {
        /// <summary>
        /// Convierte LIST en Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static System.Data.DataTable ListToDataTable<T>(IList<T> data)
        {
            System.Data.DataTable table = new System.Data.DataTable();


            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }


        /// <summary>
        /// Convierte LIST en Datatable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static System.Data.DataTable ConvertListToDataTable(List<string[]> list)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }


        /// <summary>
        /// Transforam Hoja Excel en Datable
        /// </summary>
        /// <param name="arch"></param>
        /// <param name="hoja"></param>
        /// <returns></returns>
        public static System.Data.DataTable CargaExcel(string arch)
        {
            IWorkbook workbook;
            using (FileStream fileStream = File.OpenRead(arch))
            {
                workbook = WorkbookFactory.Create(fileStream);


            }
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                OleDbConnection conex = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + arch + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1\"");
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conex;
                conex.Open();


                comand.CommandType = CommandType.Text;
                comand.CommandText = "SELECT * FROM [" + workbook.GetSheetName(0).ToString() + "$" + "]";
                OleDbDataAdapter adaptador = new OleDbDataAdapter(comand.CommandText, conex);
                System.Data.DataTable dt1 = new System.Data.DataTable();

                adaptador.Fill(dt1);
                return dt1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Funcion para buscar Hoja dentro de documento Excel
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns></returns>
        public static String[] GetExcelSheetNames(string excelFile)
        {
            System.Data.DataTable dt = null;
            String[] excelSheets = null;
            try
            {
                OleDbConnection conex = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conex;
                conex.Open();

                // Get the data table containg the schema guid.
                dt = conex.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                }


            }
            catch (Exception ex)
            {

            }
            return excelSheets;
        }
    }
}
