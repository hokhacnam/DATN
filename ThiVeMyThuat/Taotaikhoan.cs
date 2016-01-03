using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiVeMyThuat
{
    public partial class TaoTaiKhoan : Form
    {
   
        public TaoTaiKhoan(String user)
        {
           InitializeComponent();
            this.user = user;
        }
        private string user;

        public string username
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string pass
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Tennd
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public event EventHandler DataAvailable;

        protected virtual void TransferData(EventArgs e)
        {
            EventHandler eh = DataAvailable;
            if (eh != null)
                eh(this, e);
        }

       
  
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length - 1 < 4)
                MessageBox.Show("Tên tài khoản quá ngắn");
            else
                if (textBox1.Text.Length - 1 > 30)
                    MessageBox.Show("Tên tài khoản quá dài");
                else
                    if (textBox2.Text.Length - 1 < 4)
                        MessageBox.Show("Mật khẩu quá ngắn");
                    else
                        if (textBox3.Text.Length - 1 > 30)
                            MessageBox.Show("Mật khẩu quá dài");
                        else
                            if (textBox2.Text != textBox3.Text)
                                MessageBox.Show("Password không trùng nhau");
                            else
                            {
                                try
                                {
                                    dbVeMTDataContext db = new dbVeMTDataContext();
                                    //var p = from t in db.nhanviens
                                            //where t.username =db;

                                    nhanvien n = new nhanvien();
                                    n.tennguoidung = textBox4.Text;
                                    n.username = textBox1.Text;
                                    n.pass = textBox2.Text.ToMD5();
                                    db.nhanviens.InsertOnSubmit(n);
                                    db.SubmitChanges();
                                    MessageBox.Show("Tạo tài khoản thành công");
                                    this.Close();
                                }
                                catch 
                                {

                                    MessageBox.Show("Không thể tạo tài khoản");
                                }
                            }
            foreach (var item in Application.OpenForms)
            {
                Form f = (Form)item;
                if (f.Name == "FrmQuanLyDangNhap")
                {
                    FrmQuanLyDangNhap f1 = (FrmQuanLyDangNhap)f;
                    
                    f1.load_datagridview();
                }
                
            }
            TransferData(null);
          
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

    }
    public static class HL
    {
        public static string ToMD5(this string str)
        {
            string result = "";
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                result += buffer[i].ToString("X2");
            }
            return result;
        }
    }
}
