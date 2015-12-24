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
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain f = new FrmMain();
            if (IsvalidUser(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Đăng nhập thành công");
                
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }

        private bool IsvalidUser(string userName, string password)
        {

            dbVeMTDataContext context = new dbVeMTDataContext();
            var q = from p in context.nhanviens
                    where p.username == textBox1.Text
                    && p.pass == textBox2.Text
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

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
