using Microsoft.ReportingServices.DataProcessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ThiVeMyThuat
{
    public class Connect
    {
        private string _conString;
        private static string _sv;
        public string Database;
        private static string _user;
        private static string _pass;
        // Phương thức kết nối sql
        public SqlConnection GetConnect()
        {
            try
            {
                var xmlread = new XmlDocument();
                xmlread.Load("Connection.xml");
                var xmlelement = xmlread.DocumentElement;
                if (xmlelement != null)
                {
                    var serverNode = xmlelement.SelectSingleNode("server");
                    if (serverNode != null)
                        _sv = serverNode.InnerText;

                    var databaseNode = xmlelement.SelectSingleNode("database");
                    if (databaseNode != null)
                        Database = databaseNode.InnerText;

                    var usernameNode = xmlelement.SelectSingleNode("username");
                    if (usernameNode != null)
                        _user = usernameNode.InnerText;

                    var passwordNode = xmlelement.SelectSingleNode("password");
                    if (passwordNode != null)
                        _pass = passwordNode.InnerText;
                }
                if (_user == "")
                    _conString = @"Data Source = " + _sv + ";Initial Catalog = " + Database + ";Integrated Security=SSPI";
                else
                    _conString = @"Data Source=" + _sv + ";Initial Catalog=" + Database + ";User Id=" + _user + ";Password=" +
                                 _pass + "";
                return new SqlConnection(_conString);
                //---Win xp
                //const string conString = @"Data Source=.\SQLEXPRESS; AttachDbFilename=DataDirectory|\QLSV_TEST.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True;";
                //---Win 7
                //const string conString = @"Server=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\QLSV_TEST.mdf; Database=QLSV_TEST;Trusted_Connection=Yes;";
                //return new SqlConnection(conString);
            }
            catch (Exception ex)
            {
              LogExceptionToFile(ex);
                return null;
            }
        }

        public DataTable GetTable(String sql)
        {
            var dt = new DataTable();
            try
            {
                if (string.IsNullOrEmpty(sql)) return dt;
                var connect = GetConnect();
                var ad = new SqlDataAdapter(sql, connect);
                ad.Fill(dt);

            }
            catch (Exception ex)
            {
                LogExceptionToFile(ex);
            }
            return dt;
        }

        // Phương thức thực hiện thêm sửa ...
        public void ExcuteQuerySql(string sql)
        {
            try
            {
                var connect = GetConnect();
                connect.Open();
                var cmd = new SqlCommand(sql, connect);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connect.Close();
            }
            catch (Exception ex)
            {
                LogExceptionToFile(ex);
            }
        }

  
        public static void LogExceptionToFile(Exception ex)
        {
            var logPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            var logDirectory = logPath + @"\EXCEPTION";
            var filePath = "";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
                filePath = logDirectory + @"\EXCEPTION.0.log";
            }
            else
            {
                var filePaths = Directory.GetFiles(logDirectory, "*.log");
                if (filePaths.Length == 0)
                {
                    filePath = logDirectory + @"\EXCEPTION.0.log";
                }
                else
                {
                    var fPath = filePaths[filePaths.Length - 1];
                    if (File.Exists(fPath))
                    {
                        var lastestFile = new FileInfo(fPath);
                        // > 2 MB
                        if (((lastestFile.Length / 1024f) / 1024f) > 2)
                        {
                            var file = new FileInfo(fPath);
                            var fileName = file.Name.Split('.');
                            filePath = logDirectory + @"\EXCEPTION." + (int.Parse(fileName[1]) + 1) + @".log";
                        }
                        else
                        {
                            filePath = fPath;
                        }
                    }
                }
            }

            var a = Environment.NewLine;
            var logMessage = string.Concat(new object[]
            {
                ex.Message,
                Environment.NewLine,
                ex.Source, 
                Environment.NewLine,
                ex.StackTrace,
                Environment.NewLine,
                ex.TargetSite,
                Environment.NewLine,
                ex.InnerException
            });
            logMessage = DateTime.Now.ToString("HH:mm:ss") + " " + logMessage;
            var listener = new TextWriterTraceListener(filePath);
            listener.WriteLine(logMessage);
            listener.Flush();
            listener.Close();
        }
    }
}
