using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiVeMyThuat
{
    public static class UpdateData
    {
        private static readonly Connect Conn = new Connect();
        public class Taikhoan
        {
            public virtual string TaiKhoan { get; set; }
            public virtual string MatKhau { get; set; }
            public virtual string HoTen { get; set; }
          
        }

        public static void UpdateMatKhau(string taikhoan, string matkhau)
        {
            try
            {
                Conn.ExcuteQuerySql("Update nhanvien set username = N'" + matkhau + "' where pass = N'" + taikhoan +
                                    "'");
            }
            catch (Exception ex)
            {
               LogExceptionToFile(ex);
            }
        }

        private static void UpdateMatKhau(Taikhoan item)
        {
            try
            {
                Conn.ExcuteQuerySql("Update nhanvien set tennguoidung = N'" + item.HoTen +
                                     "' where username = " + item.TaiKhoan + "");
            }
            catch (Exception ex)
            {
                LogExceptionToFile(ex);
            }
        }

        /// <summary>
        /// Update mật khẩu cho nhiều tk
        /// </summary>
        /// <param name="list"></param>
        /// <returns>true</returns>
        public static void UpdateMatKhau(IEnumerable<Taikhoan> list)
        {
            try
            {
                foreach (var item in list)
                {
                    UpdateMatKhau(item);
                }
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
