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
    public partial class DoiMatKhau : Form
    {
        private readonly string _taikhoan;
        private readonly string _matkhau;
        public delegate void SendMessage(String value);

        private void Setvalue(String value)
        {
            this.textBox1.Text = value;
        }
        public bool CheckUpdate;
        public DoiMatKhau()
        {
            InitializeComponent();
            //_taikhoan = tk;
            //_matkhau = mk;
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            textBox1.Text = f.txtTaiKhoan.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMK1.Text))
            {
                txtMK1.Focus();
                errorcu.SetError(txtMK1, @"Chưa nhập mật khẩu cũ");
            }
            else if (string.IsNullOrEmpty(txtMK2.Text))
            {
                txtMK2.Focus();
                errorcu.Dispose();
                errormoi.SetError(txtMK2, @"Chưa nhập mật khẩu mới");
            }
            else if (string.IsNullOrEmpty(txtMK3.Text))
            {
                txtMK3.Focus();
                errormoi.Dispose(); 
                errornhaplai.SetError(txtMK3, @"Nhập lại mật khẩu mới");
            }
            else if (txtMK2.Text != txtMK3.Text)
            {
                txtMK3.Focus();
                errornhaplai.Dispose();
                MessageBox.Show(@"Mật khẩu nhập lại không khớp", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            //else if (_matkhau != MaHoaMD5.Md5(txtMK1.Text))
            //{
            //    txtMK1.Focus();
            //    MessageBox.Show(@"Sai Mật khẩu cũ", @"Thông báo", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //}
            else
            {
                //UpdateData.UpdateMatKhau(_taikhoan, MaHoaMD5.Md5(txtMK3.Text));
                //CheckUpdate = true;
                dbVeMTDataContext db = new dbVeMTDataContext();
                var ts = (from p in db.nhanviens
                          where p.username == textBox1.Text
                          select p).Single();
                if(ts.pass == txtMK1.Text.ToMD5())
                {
                    ts.pass = txtMK2.Text.ToMD5();
                    db.SubmitChanges();
                    MessageBox.Show(@"Mật khẩu đã được thay đổi", @"Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    txtMK1.Focus();
                    MessageBox.Show(@"Sai Mật khẩu cũ", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
               // ts.tennguoidung = textBox4.Text;
               // ts.username = textBox1.Text;
               
            }
        }
    }
}
