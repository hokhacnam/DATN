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
    public partial class FrmQuanLyDangNhap : Form
    {
        public FrmQuanLyDangNhap()
        {
            InitializeComponent();
        }

        private void loadgrv()
        {



            dbVeMTDataContext db = new dbVeMTDataContext();
            dgv_nguoidung.Rows.Clear();
            var list = from t in db.nhanviens orderby t.username select new { t.username,t.pass,t.tennguoidung};
            dgv_nguoidung.DataSource = list;



            

            dgv_nguoidung.Columns[0].HeaderText = "Tài khoản";
            dgv_nguoidung.Columns[1].HeaderText = "Mật khẩu";
            dgv_nguoidung.Columns[2].HeaderText = "Họ và Tên người dùng";
            dgv_nguoidung.Columns[0].Width = 200;
            dgv_nguoidung.Columns[1].Width = 200;
            dgv_nguoidung.Columns[2].Width = 300;
            

        }

        public void load_datagridview()
        {
            dbVeMTDataContext db = new dbVeMTDataContext();
            dgv_nguoidung.Rows.Clear();
            var list = from t in db.nhanviens orderby t.username select new { t.username, t.pass, t.tennguoidung };
            

            dgv_nguoidung.Columns[0].HeaderText = "Tài khoản";
            dgv_nguoidung.Columns[1].HeaderText = "Mật khẩu";
            dgv_nguoidung.Columns[2].HeaderText = "Họ và Tên người dùng";
            dgv_nguoidung.Columns[0].Width = 200;
            dgv_nguoidung.Columns[1].Width = 200;
            dgv_nguoidung.Columns[2].Width = 300;
           // dgv_nguoidung.DataSource = null;
            dgv_nguoidung.DataSource = list;
            dgv_nguoidung.Refresh();
        }


        private void FrmQuanLyDangNhap_Load(object sender, EventArgs e)
        {
            loadgrv();
            dgv_nguoidung.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = dgv_nguoidung.CurrentRow.Cells[0].ToString();
            TaoTaiKhoan f = new TaoTaiKhoan(user);
            f.DataAvailable += new EventHandler(child_DataAvaiable);
            f.Show();
        }

        private void child_DataAvaiable(object sender, EventArgs e)
        {
            TaoTaiKhoan s = sender as TaoTaiKhoan ;
            if (s != null)
            {
                foreach (DataGridViewRow item in dgv_nguoidung.Rows)
                {
                    if (item.Cells[0].Value.ToString().Trim() == s.username)
                    {
                        item.Cells[1].Value = s.pass;
                        item.Cells[2].Value = s.Tennd;
                        
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuaTaiKhoan f = new SuaTaiKhoan();
            f.username = dgv_nguoidung.CurrentRow.Cells[0].Value.ToString();
            f.pass = dgv_nguoidung.CurrentRow.Cells[1].Value.ToString();
            f.Tennd = dgv_nguoidung.CurrentRow.Cells[2].Value.ToString();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbVeMTDataContext db = new dbVeMTDataContext();
            var del = db.nhanviens.SingleOrDefault(d => d.username == dgv_nguoidung.CurrentRow.Cells[0].Value.ToString());
            db.nhanviens.DeleteOnSubmit(del);
            DialogResult dia = new DialogResult();
            dia = MessageBox.Show("Bạn có chắc muốn xóa người dùng này?" + "", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.Yes) db.SubmitChanges();

            loadgrv();
        }
    }
} 
