using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ThiVeMyThuat
{
    public partial class Suathisinh : Form
    {
        public Suathisinh()
        {
            InitializeComponent();
        }


        String sohs1;
        public String sohs
        {
            set;
            get;
        }

        public string hoten
        {
            set;
            get;
        }

        public String gioitinh
        {
            set;
            get;
        }

        public DateTime ngaysinh
        {
            set;
            get;
        }

        public string noisinh
        {
            set;
            get;
        }

        public string cmnd
        {
            set;
            get;
        }

        public DateTime ngaycap
        {
            set;
            get;
        }

        public string noicap
        {
            set;
            get;
        }

        public string hktt
        {
            set;
            get;
        }

        public string sdt
        {
            set;
            get;
        }

        public string dtcd
        {
            get;
            set;
        }

        public string email
        {
            set;
            get;
        }

        public float namtn
        {
            set;
            get;
        }

        public String lephi
        {
            set;
            get;
        }

        //  public Suathisinh(double sohoso)
        //{
        //    InitializeComponent();
        //    this.sohoso = sohoso;
        //}

        public event EventHandler DataAvailable;

        protected virtual void TransferData(EventArgs e)
        {
            EventHandler eh = DataAvailable;
            if (eh != null)
                eh(this, e);
        }


        public bool IsNumber(string pText)
        {
            String regexString = @"^[-+]?[0-9]*\.?[0-9]+$";
            Regex r = new Regex(regexString);
            if (r.IsMatch(pText))
                return true;
            else
                return false;
        }
        public Suathisinh(String sohs)
        {
            InitializeComponent();
            this.sohs1 = sohs;
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private void Suathisinh_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Insert(0, "---Chọn Năm---");
            comboBox1.SelectedIndex = 0;
            int index = 1;
            for (int i = 2016; i > 1950; i--)
            {
                comboBox1.Items.Insert(index, i.ToString());
                index++;
            }
            txtsohs.Text = sohs + "";
            txthoten.Text = hoten;
            if (gioitinh == "Nam")
            {
                checkBox1.Checked = true;
                chkgioitinh.Checked = false;
            }
            else if (gioitinh == "Nữ") { chkgioitinh.Checked = true; checkBox1.Checked = false; }
            
            dateTimePicker1.Text = ngaysinh + "";
            txtnoisinh.Text = noisinh;
            txtsocm.Text = cmnd;
            dateTimePicker2.Text = ngaycap + "";
            txtnoicap.Text = noicap;
            txthokhau.Text = hktt;
            txtsodienthoai.Text = sdt;
            txtdtcd.Text = dtcd;
            txtemal.Text = email;
            comboBox1.Text = namtn + "";
            if (lephi == "Đã nộp")
            {
                chklephi.Checked = true;
            }
            else { chklephi.Checked = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsohs.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào số hồ sơ");
                }
                else if (txthoten.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào họ tên");
                }
                else if (checkBox1.Checked == false && chkgioitinh.Checked == false)
                {
                    MessageBox.Show("Mời bạn chọn giới tính cho thí sinh");
                }
                else if (txtnoisinh.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào nơi Sinh");
                }
                else if (txtsocm.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào số CMND");
                }
                else if (txtnoicap.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào nơi cấp CMND");
                }
                else if (txthokhau.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào hộ khẩu thường trú");
                }
                else if (txtsodienthoai.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào số điện thoại");
                }
                //else if (txtdtcd.Text == "")
                //{
                //    MessageBox.Show("Bạn phải nhập vào số điện thoại cố định");
                //}
                else if (txtemal.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập vào email ");
                }
                else if (comboBox1.Text == "---Chọn Năm---" || comboBox1.Text == "")
                {
                    MessageBox.Show("Mời bạn chọn năm tốt nghiệp Trung Học Phổ Thông");
                }
                else if (IsNumber(txtsohs.Text) == false)
                {
                    MessageBox.Show("Bạn cần nhập định dạng số cho Số hồ sơ");
                    txtsohs.Focus();
                }
                else if (IsNumber(txtsocm.Text) == false)
                {
                    MessageBox.Show("Bạn cần nhập định dạng số cho Số Chứng minh thư nhân dân");
                    txtsocm.Focus();
                }
                else if (IsNumber(txtsodienthoai.Text) == false)
                {
                    MessageBox.Show("Bạn cần nhập định dạng số cho Số Điện thoại");
                    txtsodienthoai.Focus();
                }
                else if (isValidEmail(txtemal.Text) == false)
                {
                    MessageBox.Show("Bạn cần nhập định dạng mail@abc.com cho email");
                    txtemal.Focus();
                }
                else
                {
                    dbVeMTDataContext db = new dbVeMTDataContext();
                    var ts = (from p in db.vemts
                              where p.sohs == txtsohs.Text
                              select p).Single();
                    ts.hoten = txthoten.Text;
                    if (checkBox1.Checked)
                    {
                        ts.phai = true;
                    }
                    else
                        if (chkgioitinh.Checked)
                        {
                            ts.phai = false;
                        }

                    ts.ngaysinh = DateTime.Parse(dateTimePicker1.Text.ToString());
                    ts.noisinh = txtnoisinh.Text;
                    ts.cmnd = txtsocm.Text;
                    ts.ngcapcmt = DateTime.Parse(dateTimePicker2.Text);
                    ts.noicap = txtnoicap.Text;
                    ts.hktt = txthokhau.Text;
                    ts.phone = txtsodienthoai.Text;
                    ts.phonecodinh = txtdtcd.Text;
                    ts.email = txtemal.Text;
                    ts.namtn = float.Parse(comboBox1.Text);
                    if (chklephi.Checked)
                    {
                        ts.lephi = true;
                    }
                    else ts.lephi = false;

                    DialogResult dia = new DialogResult();
                    dia = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thí sinh này không ?" + "", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dia == DialogResult.Yes)
                    {
                        db.SubmitChanges();
                    }

                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Trùng số hồ sơ");
            }
            TransferData(null);
        }


        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chkgioitinh.Checked = false;
        }

        private void chkgioitinh_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
