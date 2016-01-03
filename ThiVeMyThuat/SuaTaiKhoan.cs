using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiVeMyThuat
{
    public partial class SuaTaiKhoan : Form
    {
        public SuaTaiKhoan()
        {
           InitializeComponent();
           // this.user = user;
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
            if (textBox1.Text.Length - 1 < 5)
                MessageBox.Show("Tên tài khoản quá ngắn");
            else
                if (textBox1.Text.Length - 1 > 30)
                    MessageBox.Show("Tên tài khoản quá dài");
                else
                    if (textBox2.Text.Length - 1 < 5)
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
                                    var ts = (from p in db.nhanviens
                                              where p.username == textBox1.Text
                                              select p).Single();
                                    

                                    
                                    Tennd = textBox4.Text;
                                    username = textBox1.Text;
                                    pass = textBox2.Text;
                                    
                                    db.SubmitChanges();
                                    MessageBox.Show("Sửa tài khoản thành công");
                                }
                                catch 
                                {

                                    MessageBox.Show("Không thể tạo tài khoản");
                                }
                            }
            TransferData(null);
            this.Close();
            
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

        private void SuaTaiKhoan_Load(object sender, EventArgs e)
        {
            textBox4.Text = Tennd;
            textBox1.Text = username;
            textBox2.Text = pass;
            textBox3.Text = pass;
            textBox4.Focus();
        }

    }
}
