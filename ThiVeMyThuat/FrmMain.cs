using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ThiVeMyThuat
{
    public delegate void SendMessage(String value);
    public partial class FrmMain : Form
        {
        public FrmMain()
        {
            InitializeComponent();
        }
        String taikhoan;
        private void Setvalue(String value)
        {
            this.taikhoan = value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmDsAnh f = new FrmDsAnh();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDsPhongThi f = new FrmDsPhongThi();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmDsDinhChinh f = new FrmDsDinhChinh();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmDsThuLePhi f = new FrmDsThuLePhi();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DanhSachDuThi f = new DanhSachDuThi();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmInTheDuThi FrmTheduthi = new FrmInTheDuThi();
            FrmTheduthi.Show();
        }

        private void btnDonTuiBaiThi_Click(object sender, EventArgs e)
        {
            FrmDonTuiDanhPhach f = new FrmDonTuiDanhPhach();
            f.Show();
        }

        private void btnInHdDonTuiBT_Click(object sender, EventArgs e)
        {
            FrmInHDDonTuiBaiThi f = new FrmInHDDonTuiBaiThi();
            f.Show();
        }

        private void btnInHdDanhPhach_Click(object sender, EventArgs e)
        {
            FrmInHDDanhPhach f = new FrmInHDDanhPhach();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmDonTuiRand f = new FrmDonTuiRand();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmInThongTinTuiPhach f = new FrmInThongTinTuiPhach();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmDangKy f = new FrmDangKy();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DanhSachDuTru f = new DanhSachDuTru();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmDonTuiDanhPhach f = new FrmDonTuiDanhPhach();
            f.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            DanhSBD f = new DanhSBD();
            f.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Chiaphongthi f = new Chiaphongthi();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dbVeMTDataContext db = new dbVeMTDataContext();
                    var qry1 = db.vemts.OrderBy(bn => bn.phach);
                    List<vemt> list1 = new List<vemt>();
                    list1 = qry1.ToList();
                    string[] a = new string[20];
                    DataSet ds = new DataSet();
                    ds = GetDataExcel(openFileDialog1.FileName, "Sheet1");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //Dong
                    {
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
                        {
                            a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();

                        };

                        for (int ba = 0; ba < list1.Count; ba++)
                        {
                            if (list1[ba].phach == Convert.ToDouble(a[0]))
                            {
                                list1[ba].diem = Convert.ToDouble(a[1]);
                                db.SubmitChanges();
                            }
                        }

                        //MessageBox.Show(a[1].ToString());
                        //Bat dau import du lieu vao
                        //  mh.Insert(a[0], a[1], byte.Parse(a[2]));
                    }
                    //loadData();
                    MessageBox.Show("Import thành công.");
                }
                catch
                {
                    MessageBox.Show("Lỗi! Import thất bại. Vui lòng kiểm tra lại file Excel.");
                };
            }  
            ImPortDiem f = new ImPortDiem();
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PhoDiemThi f = new PhoDiemThi();
            f.Show();
        }

        public static string OpenExcelFile(string fPath)
        {
            string connectionstring = String.Empty;
            string[] splitdot = fPath.Split(new char[1] { '.' });
            string dot = splitdot[splitdot.Length - 1].ToLower();
            if (dot == "xls")
            {
                //tao chuoi ket noi voi Excel 2003
                connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (dot == "xlsx")
            {
                //tao chuoi ket noi voi Excel 2007
                connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            }
            return connectionstring;
        }

        public static DataSet GetDataExcel(string fPath, string sheetname)
        {
            DataSet ds = new DataSet();
            string connectionstring = OpenExcelFile(fPath);
            string query = "SELECT * FROM [" + sheetname + "$]";
            using (OleDbConnection cnn = new OleDbConnection(connectionstring))
            {
                cnn.Open();
                OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, cnn);
                oleAdapter.Fill(ds, sheetname);
                oleAdapter.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return ds;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            chuẩnBịToolStripMenuItem.Enabled = false;
            bắtĐầuToolStripMenuItem.Enabled = false;
            chấmThiVàKếQuảToolStripMenuItem.Enabled = false;
            tạoTàiKhoảnToolStripMenuItem.Enabled = false;
            
            var f = new DangNhap(Setvalue);
            f.ShowDialog();
            try
            {
                if (taikhoan.ToString() == "admin")
                {
                    chuẩnBịToolStripMenuItem.Enabled = true;
                    bắtĐầuToolStripMenuItem.Enabled = true;
                    chấmThiVàKếQuảToolStripMenuItem.Enabled = true;
                    đăngNhậpToolStripMenuItem.Enabled = false;
                    tạoTàiKhoảnToolStripMenuItem.Enabled = true;
                }
                else
                {
                    chuẩnBịToolStripMenuItem.Enabled = true;
                    bắtĐầuToolStripMenuItem.Enabled = true;
                    chấmThiVàKếQuảToolStripMenuItem.Enabled = true;
                    đăngNhậpToolStripMenuItem.Enabled = false;
                    tạoTàiKhoảnToolStripMenuItem.Enabled = false;
                }
            }
            catch 
            {
                chuẩnBịToolStripMenuItem.Enabled = false;
                bắtĐầuToolStripMenuItem.Enabled = false;
                chấmThiVàKếQuảToolStripMenuItem.Enabled = false;
                tạoTàiKhoảnToolStripMenuItem.Enabled = false;
            }
           
           
        }

        private bool CheckExitsFrom(String name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        /*Phương thức tiếp theo là ActiveChildForm dùng để “Kích hoạt”  
         * – hiển thị lên trên cùng các trong số các Form Con nếu nó đã hiện mà không phải tạo thể hiện mới */
        private void ActiveChildForm(String name)
        {
            // bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
            // return check;
        }

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

        private void cậpNhậtThíSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("Frmdangky"))
            {
                FrmDangKy fm = new FrmDangKy();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("Frmdangky");
        }

        private void đánhSốBáoDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("DanhSBD"))
            {
                DanhSBD fm = new DanhSBD();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("DanhSBD");
        }

        private void chiaPhòngThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("Chiaphongthi"))
            {
                Chiaphongthi fm = new Chiaphongthi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("Chiaphongthi");
        }

        private void inGiấyBáoDựThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("danhsachduthi"))
            {
                DanhSachDuThi fm = new DanhSachDuThi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("danhsachduthi");
        }

        private void inThẻDựThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmInTheDuThi"))
            {
                FrmInTheDuThi fm = new FrmInTheDuThi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmInTheDuThi");
        }

        private void inDanhSáchẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmDsAnh"))
            {
                FrmDsAnh fm = new FrmDsAnh();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmDsAnh");
        }

        private void inDanhSáchPhòngThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmDsPhongThi"))
            {
                FrmDsPhongThi fm = new FrmDsPhongThi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmDsPhongThi");
        }

        private void inDanhSáchĐínhChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmDsDinhChinh"))
            {
                FrmDsDinhChinh fm = new FrmDsDinhChinh();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmDsDinhChinh");
        }

        private void inDanhSáchThuLệPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmDsThuLePhi"))
            {
                FrmDsThuLePhi fm = new FrmDsThuLePhi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmDsThuLePhi");
        }

        private void dồnTúiBàiThiVàĐánhPháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmDonTuiRand"))
            {
                FrmDonTuiRand fm = new FrmDonTuiRand();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmDonTuiRand");
        }

        private void inHướngDẫnDồnTúiBàiThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmInHDDonTuiBaiThi"))
            {
                FrmInHDDonTuiBaiThi fm = new FrmInHDDonTuiBaiThi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmInHDDonTuiBaiThi");
        }

        private void inHướngDẫnĐánhPháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmInHDDanhPhach"))
            {
                FrmInHDDanhPhach fm = new FrmInHDDanhPhach();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmInHDDanhPhach");
        }

        private void inThôngTinTúiPháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("FrmInThongTinTuiPhach"))
            {
                FrmInThongTinTuiPhach fm = new FrmInThongTinTuiPhach();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmInThongTinTuiPhach");
        }

        private void importĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!CheckExitsFrom("Importdiem"))
            //{
            //    Importdiem fm = new Importdiem();
            //    fm.MdiParent = this;
            //    fm.Show();

            //}
            //else ActiveChildForm("Importdiem");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dbVeMTDataContext db = new dbVeMTDataContext();
                    var qry1 = db.vemts.OrderBy(bn => bn.phach);
                    List<vemt> list1 = new List<vemt>();
                    list1 = qry1.ToList();
                    string[] a = new string[20];
                    DataSet ds = new DataSet();
                    ds = GetDataExcel(openFileDialog1.FileName, "Sheet1");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //Dong
                    {
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
                        {
                            a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();

                        };

                        for (int ba = 0; ba < list1.Count; ba++)
                        {
                            if (list1[ba].phach == Convert.ToDouble(a[0]))
                            {
                                list1[ba].diem = Convert.ToDouble(a[1]);
                                db.SubmitChanges();
                            }
                        }

                        //MessageBox.Show(a[1].ToString());
                        //Bat dau import du lieu vao
                        //  mh.Insert(a[0], a[1], byte.Parse(a[2]));
                    }
                    //loadData();
                    MessageBox.Show("Import thành công.");
                }
                catch
                {
                    MessageBox.Show("Lỗi! Import thất bại. Vui lòng kiểm tra lại file Excel.");
                };
            }
            ImPortDiem f = new ImPortDiem();
            f.Show();
        }

        private void biểuĐồPhổĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExitsFrom("phodiemthi"))
            {
                PhoDiemThi fm = new PhoDiemThi();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("phodiemthi");
        }

        private void dồnTúiPháchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!CheckExitsFrom("FrmDonTuiDanhPhach"))
            {
                FrmDonTuiDanhPhach fm = new FrmDonTuiDanhPhach();
                fm.MdiParent = this;
                fm.Show();

            }
            else ActiveChildForm("FrmDonTuiDanhPhach");
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!CheckExitsFrom("Dangnhap"))
            //{
                var f = new DangNhap(Setvalue);
                f.ShowDialog();
               // f.MdiParent = this;
               

            //}
            //else ActiveChildForm("Dangnhap");
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    if (IsvalidUser(textBox1.Text, textBox2.Text))
        //    {
        //        MessageBox.Show("Đăng nhập thành công");
        //        //textBox1.Text = "";
        //        //textBox2.Text = "";
        //        chuẩnBịToolStripMenuItem.Enabled = true;
        //        bắtĐầuToolStripMenuItem.Enabled = true;
        //        chấmThiVàKếQuảToolStripMenuItem.Enabled = true;
                
        //        groupBox2.Hide();
        //        if(textBox1.Text == "khacnam")
        //        {
        //            hệThốngToolStripMenuItem.Enabled = true;
        //        }

        //    }
        //    else
        //    {
        //        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
        //        textBox1.Text = "";
        //        textBox2.Text = "";
        //        textBox1.Focus();
                
        //    }

            
        //}

        private void bắtĐầuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoTaiKhoan f = new TaoTaiKhoan();
            f.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void đánhSốBáoDanhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DanhSachSBD f = new DanhSachSBD();
            f.Show();
        }

        private void chiaPhòngThiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Chiaphongthi f = new Chiaphongthi();
        }
    }
}
