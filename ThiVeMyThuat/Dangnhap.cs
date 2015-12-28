using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ThiVeMyThuat
{
    public partial class DangNhap : Form
    {
      //  public delegate void CustomHandler(object sender, bool checkState, Taikhoan hs);
        //public event CustomHandler CheckDangNhap;
        public SendMessage send;
        public class Taikhoan
        {
           // public virtual int ID { get; set; }

            public virtual string TaiKhoan { get; set; }

            //public virtual string HoTen { get; set; }

            public virtual string MatKhau { get; set; }

           // public virtual string Quyen { get; set; }
        }
        public DangNhap()
        {
            InitializeComponent();
           
        }
        public DangNhap( SendMessage sender)
        {
            InitializeComponent();
            this.send = sender;

        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FrmMain f = new FrmMain();
        //    if (IsvalidUser(textBox1.Text, textBox2.Text))
        //    {
        //        MessageBox.Show("Đăng nhập thành công");
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
        //        textBox1.Text = "";
        //        textBox2.Text = "";
        //        textBox1.Focus();
        //    }
        //}

        //private bool IsvalidUser(string userName, string password)
        //{

        //    dbVeMTDataContext context = new dbVeMTDataContext();
        //    var q = from p in context.nhanviens
        //            where p.username == textBox1.Text
        //            && p.pass == textBox2.Text
        //            select p;

        //    if (q.Any())
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private void Dangnhap_Load(object sender, EventArgs e)
        {
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void label3_Click(object sender, EventArgs e)
        //{

        //}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new DangNhapServer();
            f.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Application.Exit();
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

        private void label3_Click(object sender, EventArgs e)
        {
        }
        private bool IsvalidUser(string userName, string password)
        {

            dbVeMTDataContext context = new dbVeMTDataContext();
            var q = from p in context.nhanviens
                    where p.username == txtTaiKhoan.Text
                    && p.pass == txtMatKhau.Text
                    select p;

            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show(@"Vui lòng nhập tên tài khoản", @"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
            }
            else if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show(@"Vui lòng nhập mật khâu", @"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
            }
            else
            {
                try
                {
                    if (IsvalidUser(txtTaiKhoan.Text, txtMatKhau.Text))
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        //textBox1.Text = "";
                        //textBox2.Text = "";
                        
                        this.send(this.txtTaiKhoan.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");


                    }
                }
                catch (Exception ex)
                {

                    LogExceptionToFile(ex);
                }
         
            }
        }

        private void Dangnhap()
        {
            try
            {
                if (IsvalidUser(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công");
                    //textBox1.Text = "";
                    //textBox2.Text = "";


                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");


                }
            }
            catch
            {

                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
         
        }
    }
}
