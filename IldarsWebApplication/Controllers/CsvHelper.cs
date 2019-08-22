using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace IldarsWebApplication.Controllers
{
    public static class CsvHelper
    {
        private static FileStreamResult Export(DataTable dt, int codepage = 1251, string delimiter = ";", string fileName = "Export")
        {
            var output = new MemoryStream();
            var writer = new StreamWriter(output, Encoding.GetEncoding(codepage));

            foreach (var column in dt.Columns)
            {
                writer.Write(column);
                writer.Write(delimiter);
            }
            writer.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    var s = item.ToString().Replace("\t", " ");
                    while (s.IndexOf("  ", StringComparison.Ordinal) >= 0)
                    {
                        s = s.Replace("  ", " ");
                    }
                    s = s.Trim();

                    if (s.Contains(delimiter) || s.Contains("\"") || s.Contains((char)10) || s.Contains((char)13))
                    {
                        writer.Write("\"");
                        writer.Write(s.Replace("\"", "\"\""));
                        writer.Write("\"");
                    }
                    else
                    {
                        writer.Write(s);
                    }
                    writer.Write(delimiter);
                }
                writer.WriteLine();
            }

            writer.Flush();
            output.Position = 0;

            //return output;
            return new FileStreamResult(output, "text/comma-separated-values")
            {
                FileDownloadName = fileName + "_" + DateTime.Now.ToString("ddMMyy-HHmm") + ".csv"
            };
        }

        public static FileStreamResult Export(string sqlText, string fileName = "Export")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter() { SelectCommand = sqlCommand })
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            sqlDataAdapter.Fill(dataTable);
                            return Export(dataTable, fileName: fileName);
                        }
                    }
                }
            }
        }
    }
}