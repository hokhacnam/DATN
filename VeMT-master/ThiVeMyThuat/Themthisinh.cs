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
    public partial class Themthisinh : Form
    {
        String sohs;
        public Themthisinh()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public event EventHandler DataAvailable;

        protected virtual void TransferData(EventArgs e)
        {
            EventHandler eh = DataAvailable;
            if (eh != null)
                eh(this, e);
        }

        public Themthisinh(String sohs)
        {
            InitializeComponent();
            this.sohs = sohs;
        }


        private void Themthisinh_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Insert(0, "---Chọn Năm---");
            comboBox1.SelectedIndex = 0;
            int index = 1;
            for (int i = 2016; i > 1950; i--)
            {
                comboBox1.Items.Insert(index, i.ToString());
                index++;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (txtsohs.Text == "")
            {
                MessageBox.Show("Bạn phải nhập vào số hồ sơ");
            }
            else if (txthoten.Text == "")
            {
                MessageBox.Show("Bạn phải nhập vào họ tên");
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
                vemt ve = new vemt();

                ve.sohs = txtsohs.Text;
                ve.hoten = txthoten.Text;
                if (checkBox1.Checked)
                {
                    ve.phai = true;
                }
                else
                    if (chkgioitinh.Checked)
                    {
                        ve.phai = false;
                    }

                ve.ngaysinh = DateTime.Parse(dateTimePicker2.Text.ToString());
                ve.noisinh = txtnoisinh.Text;
                ve.cmnd = txtsocm.Text;
                ve.ngcapcmt = DateTime.Parse(dateTimePicker1.Text);
                ve.noicap = txtnoicap.Text;
                ve.hktt = txthokhau.Text;
                ve.phone = txtsodienthoai.Text;
                if (txtdtcd.Text != "")
                {
                    ve.phonecodinh = txtdtcd.Text;
                }
                else
                {
                    ve.phonecodinh = null;
                }
                ve.email = txtemal.Text;
                ve.namtn = float.Parse(comboBox1.Text);
                if (chklephi.Checked)
                {
                    ve.lephi = true;
                }
                else ve.lephi = false;



                db.vemts.InsertOnSubmit(ve);
                db.SubmitChanges();
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TransferData(null);
                this.Close();
                Frmdangky fm = new Frmdangky();
                fm.Show();
            }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Sai Định dạng ngày tháng");
            //}

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
