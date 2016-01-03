using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Xml.Linq;

namespace ThiVeMyThuat
{
    public partial class DangNhapServer : Form
    {
        public DangNhapServer()
        {
            InitializeComponent();
        }

        public SqlConnection getcon(string server, string db, string user, string pass)
        {
            return new SqlConnection("Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pass + ";");
        } 

        private void Dangnhapserver_Load(object sender, EventArgs e)
        {

            try
            {
                var logPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
                var filename = logPath + @"\Connection.xml";
                if (!File.Exists(filename)) return;
                var xmlread = new XmlDocument();
                xmlread.Load("Connection.xml");
                var xmlelement = xmlread.DocumentElement;
                if (xmlelement == null) return;
                var serverNode = xmlelement.SelectSingleNode("server");
                if (serverNode != null)
                    txtserver.Text = serverNode.InnerText;

                var databaseNode = xmlelement.SelectSingleNode("database");
                if (databaseNode != null)
                    txtdatabase.Text = databaseNode.InnerText;

                var usernameNode = xmlelement.SelectSingleNode("username");
                if (usernameNode != null)
                    txtusername.Text = usernameNode.InnerText;

                var passwordNode = xmlelement.SelectSingleNode("password");
                if (passwordNode != null)
                    txtpassword.Text = passwordNode.InnerText;
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtserver.Text))
                {
                    txtserver.Focus();
                }
                else if (string.IsNullOrEmpty(txtdatabase.Text))
                {
                    txtdatabase.Focus();
                }
                else
                {
                    var xdoc = new XDocument(
                        new XElement("config",
                            new XElement("server", txtserver.Text),
                            new XElement("database", txtdatabase.Text),
                            new XElement("username", txtusername.Text),
                            new XElement("password", txtpassword.Text)
                            )
                        );
                    xdoc.Save("Connection.xml");
                    MessageBox.Show(@"Lưu lại thành công", @"Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Log2File.LogExceptionToFile(ex);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string conString;
                if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
                    conString = @"Data Source = " + txtserver.Text + ";Initial Catalog = " + txtdatabase.Text + ";Integrated Security=SSPI";
                else
                    conString = @"Data Source=" + txtserver.Text + ";Initial Catalog=" + txtdatabase.Text + ";User Id=" + txtusername.Text + ";Password=" + txtpassword.Text + "";
                var conn = new SqlConnection(conString);
                if (CheckConn(conn))
                    MessageBox.Show(@"Kết nối CSDL thành công.", @"Thông báo");
                else
                    MessageBox.Show(@"Không thể kết nối CSDL.", @"Thông báo");
            }
            catch (Exception ex)
            {
                LogExceptionToFile(ex);
            }
        }
       

        private static bool CheckConn(SqlConnection conn)
        {
            try
            {
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    SqlConnection con = getcon(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        //    try
        //    {
        //        con.Open();
        //        string path = Environment.CurrentDirectory + "/" + "connect.txt";
        //        if (!File.Exists(path))
        //        {
        //            File.CreateText(path);
        //            using (StreamWriter sw = new StreamWriter(path))
        //            {
        //                sw.WriteLine("Máy chủ : " + textBox1.Text);
        //                sw.WriteLine("Cơ sở dữ liệu : " + textBox2.Text);
        //                sw.WriteLine("Người dùng : " + textBox3.Text);
        //                sw.WriteLine("Mật khẩu : " + textBox4.Text);
        //            }

        //        }
        //        else
        //        {
        //            using (StreamWriter sw = new StreamWriter(path))
        //            {
        //                sw.WriteLine("Máy chủ : " + textBox1.Text);
        //                sw.WriteLine("Cơ sở dữ liệu : " + textBox2.Text);
        //                sw.WriteLine("Người dùng : " + textBox3.Text);
        //                sw.WriteLine("Mật khẩu : " + textBox4.Text);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Kết nối thất bại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    MessageBox.Show("Kết nối thành công tới server" + textBox1.Text, "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        //    FrmMain f = new FrmMain();
        //    f.Show();
        //   this.Hide();
        //    //Application.Exit();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    Close();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
