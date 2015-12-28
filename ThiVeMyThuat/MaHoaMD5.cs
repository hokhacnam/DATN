using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiVeMyThuat
{
    public static class MaHoaMD5
    {
        private static byte[] EncryptData(string data)
        {
            try
            {
                var md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
                var encoder = new System.Text.UTF8Encoding();
                var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
                return hashedBytes;
            }
            catch (Exception ex)
            {
                LogExceptionToFile(ex);
                return null;
            }
        }

        public static string Md5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
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
