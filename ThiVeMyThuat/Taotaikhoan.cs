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
    public partial class TaoTaiKhoan : Form
    {
        public TaoTaiKhoan()
        {
            InitializeComponent();
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
                                    //var p = from t in db.nhanviens
                                            //where t.username =db;

                                    nhanvien n = new nhanvien();
                                    n.username = textBox1.Text;
                                    n.pass = textBox2.Text;
                                    db.nhanviens.InsertOnSubmit(n);
                                    db.SubmitChanges();
                                    MessageBox.Show("Tạo tài khoản thành công");
                                }
                                catch 
                                {

                                    MessageBox.Show("Không thể tạo tài khoản");
                                }
                            }
            
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

    }
}
