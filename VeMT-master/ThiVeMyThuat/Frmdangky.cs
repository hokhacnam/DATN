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
    public partial class Frmdangky : Form
    {
        public Frmdangky()
        {
            InitializeComponent();
        }

        //private void child_DataAvaiable(object sender, EventArgs e)
        //{
        //    Themthisinh s = sender as Themthisinh;
        //    if (s != null)
        //    {
        //        foreach (DataGridViewRow item in dgv_thisinh.Rows)
        //        {
        //            if (item.Cells[13].Value.ToString().Trim() == s)
        //            {
        //                item.Cells[1].Value = s.Hosv;
        //                item.Cells[2].Value = s.Tensv;
        //                item.Cells[3].Value = s.Ngaysinh;
        //                item.Cells[4].Value = s.idLop;
        //                break;
        //            }
        //        }
        //    }
        //}

        private void loadgrv()
        {
            dbVeMTDataContext db = new dbVeMTDataContext();
            dgv_thisinh.Rows.Clear();
            var list = from t in db.vemts  orderby t.sohs select new { t.sohs, t.hoten, Type = t.phai == true ? "Nam" : "Nữ", t.ngaysinh, t.noisinh, t.cmnd, t.ngcapcmt, t.noicap, t.hktt, t.phone, t.phonecodinh, t.email, t.namtn, Type1 = t.lephi == true ? "Đã nộp" : "Chưa nộp" };
            dgv_thisinh.DataSource = list;

            dgv_thisinh.Columns[0].HeaderText = "Số HS";
            dgv_thisinh.Columns[1].HeaderText = "Họ và tên";
            dgv_thisinh.Columns[2].HeaderText = "Giới tính";
            dgv_thisinh.Columns[3].HeaderText = "Ngày sinh";
            dgv_thisinh.Columns[4].HeaderText = "Nơi Sinh";
            dgv_thisinh.Columns[5].HeaderText = "Số CMND";
            dgv_thisinh.Columns[6].HeaderText = "Ngày cấp CMND";
            dgv_thisinh.Columns[7].HeaderText = "Nơi cấp CMND";
            dgv_thisinh.Columns[8].HeaderText = "Hộ khẩu thường trú";
            dgv_thisinh.Columns[9].HeaderText = "Số điện thoại";
            dgv_thisinh.Columns[10].HeaderText = "Điện thoại cố định";
            dgv_thisinh.Columns[11].HeaderText = "Email";
            dgv_thisinh.Columns[12].HeaderText = "Năm tốt nghiệp";
            dgv_thisinh.Columns[13].HeaderText = "Lệ phí";

            this.dgv_thisinh.Columns[3].DefaultCellStyle.Format = ("dd/MM/yyyy");
            this.dgv_thisinh.Columns[6].DefaultCellStyle.Format = ("dd/MM/yyyy");
            //    if (dgv_thisinh.CurrentRow.Cells[2].Value.ToString() == "True")
            //    {
            //        dgv_thisinh.CurrentRow.Cells[2].Value = "name";
            //    }

            //    else { dgv_thisinh.CurrentRow.Cells[2].Value = "nữ"; }
        }

        private void Frmdangky_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            // TODO: This line of code loads data into the 'dsVeMT.vemt' table. You can move, or remove it, as needed.
            loadgrv();

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            String sohs = dgv_thisinh.CurrentRow.Cells[0].ToString();
            Themthisinh them = new Themthisinh(sohs);
            them.DataAvailable += new EventHandler(child_DataAvaiable);
            them.Show();
        }

        private void child_DataAvaiable(object sender, EventArgs e)
        {
            Suathisinh s = sender as Suathisinh;
            if (s != null)
            {
                foreach (DataGridViewRow item in dgv_thisinh.Rows)
                {
                    if (item.Cells[0].Value.ToString().Trim() == s.sohs)
                    {
                        item.Cells[1].Value = s.hoten;
                        item.Cells[2].Value = s.gioitinh;
                        item.Cells[3].Value = s.ngaysinh;
                        item.Cells[4].Value = s.noisinh;
                        item.Cells[5].Value = s.cmnd;
                        item.Cells[6].Value = s.ngaycap;
                        item.Cells[7].Value = s.noicap;
                        item.Cells[8].Value = s.hktt;
                        item.Cells[9].Value = s.sdt;
                        item.Cells[10].Value = s.dtcd;
                        item.Cells[11].Value = s.email;
                        item.Cells[12].Value = s.namtn;
                        item.Cells[13].Value = s.lephi;
                        break;
                    }
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            //int ExampleId;
            //int RowId;
            //if (MessageBox.Show("Bạn có chắc xoá mẫu tin này không?",

            //   "Delete Warning", MessageBoxButtons.YesNo,

            //   MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)

            //   == DialogResult.Yes)
            //{

            //    for (int i = 0; i < dgv_thisinh.SelectedRows.Count; i++)
            //    {

            //        RowId = dgv_thisinh.SelectedRows[i].Index;

            //        ExampleId = Convert.ToInt32(dgv_thisinh[0, RowId].Value);

            //    }

            //    using (var db = new dbVeMTDataContext())
            //    {

            //        if (ExampleId != 0)
            //        {

            //            var getData = (from example in db.vemts

            //                           where example.sohs == ExampleId

            //                           select example).Single();

            //            db.vemts.DeleteOnSubmit(getData);

            //            db.SubmitChanges();

            //            MessageBox.Show("Đã xoá thành công!");

            //            loadgrv();

            //        }

            //    }

            //}

            dbVeMTDataContext db = new dbVeMTDataContext();
            var del = db.vemts.SingleOrDefault(d => d.sohs == dgv_thisinh.CurrentRow.Cells[0].Value.ToString());
            db.vemts.DeleteOnSubmit(del);
            DialogResult dia = new DialogResult();
            dia = MessageBox.Show("Bạn có chắc muốn xóa thí sinh này?" + "", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dia == DialogResult.Yes) db.SubmitChanges();

            loadgrv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbVeMTDataContext db = new dbVeMTDataContext();
            dgv_thisinh.Rows.Clear();
            if (comboBox1.Text == "Số hồ sơ")
            {
                var list = from t in db.vemts
                           where t.sohs.ToString().Contains(textBox1.Text)
                           select new { t.sohs, t.hoten, Type = t.phai == true ? "Nam" : "Nữ", t.ngaysinh, t.noisinh, t.cmnd, t.ngcapcmt, t.noicap, t.hktt, t.phone, t.phonecodinh, t.email, t.namtn, Type1 = t.lephi == true ? "Đã nộp" : "Chưa nộp" };
                dgv_thisinh.DataSource = list;
            }

            else if (comboBox1.Text == "Họ tên")
            {
                var list = from t in db.vemts
                           where t.hoten.ToString().Contains(textBox1.Text)
                           select new { t.sohs, t.hoten, Type = t.phai == true ? "Nam" : "Nữ", t.ngaysinh, t.noisinh, t.cmnd, t.ngcapcmt, t.noicap, t.hktt, t.phone, t.phonecodinh, t.email, t.namtn, Type1 = t.lephi == true ? "Đã nộp" : "Chưa nộp" };
                dgv_thisinh.DataSource = list;
            }

            else if (comboBox1.Text == "Năm tốt nghiệp")
            {
                var list = from t in db.vemts
                           where t.namtn.ToString().Contains(textBox1.Text)
                           select new { t.sohs, t.hoten, Type = t.phai == true ? "Nam" : "Nữ", t.ngaysinh, t.noisinh, t.cmnd, t.ngcapcmt, t.noicap, t.hktt, t.phone, t.phonecodinh, t.email, t.namtn, Type1 = t.lephi == true ? "Đã nộp" : "Chưa nộp" };
                dgv_thisinh.DataSource = list;
            }
            else
            {
                loadgrv();
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            //double sohs = double.Parse( dgv_thisinh.CurrentRow.Cells[0].Value.ToString());
            //MessageBox.Show(sohs.ToString());
            //Suathisinh sua = new Suathisinh(sohs);
            //sua.DataAvailable += new EventHandler(child_DataAvaiable);
            //sua.Show();

            //Suathisinh sua = new Suathisinh();
            //sua.sohs = dgv_thisinh.CurrentRow.Cells[0].Value.ToString();
            //sua.hoten = dgv_thisinh.CurrentRow.Cells[1].Value.ToString();
            //sua.gioitinh = dgv_thisinh.CurrentRow.Cells[2].Value.ToString();
            //sua.ngaysinh = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[3].Value.ToString());

            //sua.noisinh = dgv_thisinh.CurrentRow.Cells[4].Value.ToString();
            //sua.cmnd = dgv_thisinh.CurrentRow.Cells[5].Value.ToString();
            //sua.ngaycap = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[6].Value.ToString());
            //sua.noicap = dgv_thisinh.CurrentRow.Cells[7].Value.ToString();
            //sua.hktt = dgv_thisinh.CurrentRow.Cells[8].Value.ToString();
            //sua.sdt = dgv_thisinh.CurrentRow.Cells[9].Value.ToString();
            //if (dgv_thisinh.CurrentRow.Cells[10].Value != null)
            //{
            //    sua.dtcd = dgv_thisinh.CurrentRow.Cells[10].Value.ToString();
            //}
            //else
            //{
            //    sua.dtcd = "";
            //}
            //sua.email = dgv_thisinh.CurrentRow.Cells[11].Value.ToString();
            //sua.namtn = float.Parse(dgv_thisinh.CurrentRow.Cells[12].Value.ToString());
            //sua.lephi = dgv_thisinh.CurrentRow.Cells[13].Value.ToString();
            //sua.Show();
            String masv = dgv_thisinh.CurrentRow.Cells[0].Value.ToString();
            Suathisinh up = new Suathisinh(masv);
            up.DataAvailable += new EventHandler(child_DataAvaiable);
            up.Show();

        }

        //private void child_DataAvaiable(object sender, EventArgs e)
        //{
        //    Suathisinh s = sender as Suathisinh;
        //    if (s != null)
        //    {
        //        foreach (DataGridViewRow item in dgv_thisinh.Rows)
        //        {
        //            if (double.Parse(item.Cells[0].Value.ToString().Trim()) == s.sohs)
        //            {
        //                item.Cells[1].Value = s.hoten;
        //                item.Cells[2].Value = s.gioitinh;
        //                item.Cells[3].Value = s.ngaysinh;
        //                item.Cells[4].Value = s.noisinh;
        //                item.Cells[5].Value = s.cmnd;
        //                item.Cells[6].Value = s.ngaycap;
        //                item.Cells[7].Value = s.noicap;
        //                item.Cells[8].Value = s.hktt;
        //                item.Cells[9].Value = s.sdt;
        //                item.Cells[10].Value = s.email;
        //                item.Cells[11].Value = s.namtn;
        //                item.Cells[12].Value = s.lephi ;
        //                break;
        //            }
        //        }
        //    }
        //}

        //protected void dgv_thisinh_RowDataBound(object sender, DataGridViewRowEventArgs e)
        //  {
        //     DataGridViewRow r = e.Row;
        //     if ( bool.Parse( r.Cells[2].Value.ToString()) == true )
        //             r.Cells[2].Value = "Nam";
        //     else
        //             r.Cells[2].Value = "Nữ";

        //  }

        private void dgv_thisinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Suathisinh sua = new Suathisinh();
            //sua.sohs = dgv_thisinh.CurrentRow.Cells[0].Value.ToString();
            //sua.hoten = dgv_thisinh.CurrentRow.Cells[1].Value.ToString();
            //sua.gioitinh = dgv_thisinh.CurrentRow.Cells[2].Value.ToString();
            //sua.ngaysinh = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[3].Value.ToString());

            //sua.noisinh = dgv_thisinh.CurrentRow.Cells[4].Value.ToString();
            //sua.cmnd = dgv_thisinh.CurrentRow.Cells[5].Value.ToString();
            //sua.ngaycap = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[6].Value.ToString());
            //sua.noicap = dgv_thisinh.CurrentRow.Cells[7].Value.ToString();
            //sua.hktt = dgv_thisinh.CurrentRow.Cells[8].Value.ToString();
            //sua.sdt = dgv_thisinh.CurrentRow.Cells[9].Value.ToString();
            //if (dgv_thisinh.CurrentRow.Cells[10].Value.ToString() != null)
            //{
            //    sua.dtcd = dgv_thisinh.CurrentRow.Cells[10].Value.ToString();
            //}
            //else
            //{
            //    sua.dtcd = "";
            //}
            //sua.email = dgv_thisinh.CurrentRow.Cells[11].Value.ToString();
            //sua.namtn = float.Parse(dgv_thisinh.CurrentRow.Cells[12].Value.ToString());
            //sua.lephi = dgv_thisinh.CurrentRow.Cells[13].Value.ToString();
            //sua.Show();
        }

        private void btndanhsach_Click(object sender, EventArgs e)
        {
            Danhsachdutru ds = new Danhsachdutru ();
            ds.Show();
        }

        //private void dgv_thisinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    Suathisinh sua = new Suathisinh();
        //    sua.sohs = dgv_thisinh.CurrentRow.Cells[0].Value.ToString();
        //    sua.hoten = dgv_thisinh.CurrentRow.Cells[1].Value.ToString();
        //    sua.gioitinh = dgv_thisinh.CurrentRow.Cells[2].Value.ToString();
        //    sua.ngaysinh = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[3].Value.ToString());

        //    sua.noisinh = dgv_thisinh.CurrentRow.Cells[4].Value.ToString();
        //    sua.cmnd = dgv_thisinh.CurrentRow.Cells[5].Value.ToString();
        //    sua.ngaycap = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[6].Value.ToString());
        //    sua.noicap = dgv_thisinh.CurrentRow.Cells[7].Value.ToString();
        //    sua.hktt = dgv_thisinh.CurrentRow.Cells[8].Value.ToString();
        //    sua.sdt = dgv_thisinh.CurrentRow.Cells[9].Value.ToString();
        //    if (dgv_thisinh.CurrentRow.Cells[10].Value != null)
        //    {
        //        sua.dtcd = dgv_thisinh.CurrentRow.Cells[10].Value.ToString();
        //    }
        //    else
        //    {
        //        sua.dtcd = "";
        //    }
        //    sua.email = dgv_thisinh.CurrentRow.Cells[11].Value.ToString();
        //    sua.namtn = float.Parse(dgv_thisinh.CurrentRow.Cells[12].Value.ToString());
        //    sua.lephi = dgv_thisinh.CurrentRow.Cells[13].Value.ToString();
        //    sua.Show();
        //}

        private void dgv_thisinh_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Suathisinh sua = new Suathisinh();
            sua.sohs = dgv_thisinh.CurrentRow.Cells[0].Value.ToString();
            sua.hoten = dgv_thisinh.CurrentRow.Cells[1].Value.ToString();
            sua.gioitinh = dgv_thisinh.CurrentRow.Cells[2].Value.ToString();
            sua.ngaysinh = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[3].Value.ToString());

            sua.noisinh = dgv_thisinh.CurrentRow.Cells[4].Value.ToString();
            sua.cmnd = dgv_thisinh.CurrentRow.Cells[5].Value.ToString();
            sua.ngaycap = DateTime.Parse(dgv_thisinh.CurrentRow.Cells[6].Value.ToString());
            sua.noicap = dgv_thisinh.CurrentRow.Cells[7].Value.ToString();
            sua.hktt = dgv_thisinh.CurrentRow.Cells[8].Value.ToString();
            sua.sdt = dgv_thisinh.CurrentRow.Cells[9].Value.ToString();
            if (dgv_thisinh.CurrentRow.Cells[10].Value != null)
            {
                sua.dtcd = dgv_thisinh.CurrentRow.Cells[10].Value.ToString();
            }
            else
            {
                sua.dtcd = "";
            }
            sua.email = dgv_thisinh.CurrentRow.Cells[11].Value.ToString();
            sua.namtn = float.Parse(dgv_thisinh.CurrentRow.Cells[12].Value.ToString());
            sua.lephi = dgv_thisinh.CurrentRow.Cells[13].Value.ToString();
            sua.Show();
        }

       
    }
}
