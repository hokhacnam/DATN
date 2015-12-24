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

namespace ThiVeMyThuat
{
    public partial class Dangnhapserver : Form
    {
        public Dangnhapserver()
        {
            InitializeComponent();
        }

        public SqlConnection getcon(string server, string db, string user, string pass)
        {
            return new SqlConnection("Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pass + ";");
        } 

        private void Dangnhapserver_Load(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = getcon(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            try
            {
                con.Open();
                string path = Environment.CurrentDirectory + "/" + "connect.txt";
                if (!File.Exists(path))
                {
                    File.CreateText(path);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("Máy chủ : " + textBox1.Text);
                        sw.WriteLine("Cơ sở dữ liệu : " + textBox2.Text);
                        sw.WriteLine("Người dùng : " + textBox3.Text);
                        sw.WriteLine("Mật khẩu : " + textBox4.Text);
                    }

                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("Máy chủ : " + textBox1.Text);
                        sw.WriteLine("Cơ sở dữ liệu : " + textBox2.Text);
                        sw.WriteLine("Người dùng : " + textBox3.Text);
                        sw.WriteLine("Mật khẩu : " + textBox4.Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Kết nối thành công tới server" + textBox1.Text, "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            FrmMain f = new FrmMain();
            f.Show();
           this.Hide();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
