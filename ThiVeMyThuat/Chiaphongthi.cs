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
    public partial class Chiaphongthi : Form
    {
        public Chiaphongthi()
        {
            InitializeComponent();
        }

       // private void loadgrv()
        //{
        //    dbVeMTDataContext db = new dbVeMTDataContext();
        //    dgv_thisinh.Rows.Clear();
        //    var list = from t in db.vemts select new { t.sohs, t.hoten, Type = t.phai == true ? "Nam" : "Nữ", t.phongthi };
        //    dgv_thisinh.DataSource = list;

        //    dgv_thisinh.Columns[0].HeaderText = "Số HS";
        //    dgv_thisinh.Columns[1].HeaderText = "Họ và tên";
        //    dgv_thisinh.Columns[2].HeaderText = "Giới tính";

        //    dgv_thisinh.Columns[3].HeaderText = "Phòng thi";


        //    //this.dgv_thisinh.Columns[3].DefaultCellStyle.Format = ("dd/MM/yyyy");
        //    //this.dgv_thisinh.Columns[6].DefaultCellStyle.Format = ("dd/MM/yyyy");
        //    //    if (dgv_thisinh.CurrentRow.Cells[2].Value.ToString() == "True")
        //    //    {
        //    //        dgv_thisinh.CurrentRow.Cells[2].Value = "name";
        //    //    }

        //    //    else { dgv_thisinh.CurrentRow.Cells[2].Value = "nữ"; }
        //}

        private void Chiaphongthi_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "anphabe Tên";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "anphabe Tên")
            {
                int rn = 1;
                //dbVeMTDataContext db = new dbVeMTDataContext();
                
                //var b = from s in db.vemts
                //        orderby db.layTen(s.hoten)
                //        select (s.hoten);
                //List<String> list1 = new List<String>();
                //list1 = b.ToList();
                ////MessageBox.Show(b.ToString());
                ////danh stt
                //foreach (String item1 in b)
                //{
                //    List<vemt> dsSbd2 = new List<vemt>();
                //   // List<vemt> dsSbd3 = new List<vemt>();
                //    dsSbd2 = (from purchase in db.vemts
                //              where purchase.hoten == item1
                //              select purchase).ToList();


                //    // dsSbd.Count();
                //    //MessageBox.Show(dsSbd1.Count().ToString());

                //    for (int i = 0; i < dsSbd2.Count(); i++)
                //    {
                //        dsSbd2[i].stt = rn;
                //        rn = rn + 1;
                //        //MessageBox.Show(rn.ToString());
                //    }

                //}

                dbVeMTDataContext db = new dbVeMTDataContext();
                var qry1 = db.vemts.OrderBy(a => a.hoten);
                List<vemt> list1 = new List<vemt>();
                list1 = qry1.ToList();
                //danh stt
                int n = list1.Count;
                for (int i = 0; i < n; i++)
                {
                    list1[i].stt = i + 1;
                }

                    var qry = from s in db.vemts
                              orderby db.layTen(s.hoten)
                              select (s.hoten);


                    List<String> list = new List<String>();


                    foreach (String item in qry)
                    {
                        List<vemt> dsSbd = new List<vemt>();
                        List<vemt> dsSbd1 = new List<vemt>();
                        dsSbd = (from purchase in db.vemts
                                 where purchase.hoten == item
                                 select purchase).ToList();

                        dsSbd1 = (from r in db.vemts
                                  orderby r.hoten
                                  select r).ToList();
                        // dsSbd.Count();
                        //MessageBox.Show(dsSbd1.Count().ToString());
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {

                            decimal? stt = dsSbd[i].stt;
                            dsSbd[i].phongthi = Convert.ToDouble((int)((stt - 1) / numericUpDown1.Value ) + 1);
                           // MessageBox.Show(stt.ToString());
                           // rn = rn + 1;
                        }
                       // int sl = dsSbd.Count();
                        
                    }
                   
                    db.SubmitChanges();
                   // MessageBox.Show("Đã thực hiện xong");
                    double d = (int)(list1.Count() / numericUpDown1.Value) + 1;
                    var qry3 = from s in db.vemts
                               where s.phongthi == d
                               select (s.hoten);
                    int sl = qry3.Count();
                  //  MessageBox.Show(sl.ToString());
                if (numericUpDown2.Value.ToString()=="")
                {
                    MessageBox.Show("Mời nhập vào số thí sinh cần gộp");
                }
                else if (sl<= numericUpDown2.Value)
                {
                    List<vemt> upt = new List<vemt>();
                    upt = (from v in db.vemts
                           where v.phongthi == d
                           select v).ToList();
                    //for (int i = 0; i < upt.Count(); i++)
                    //{

                        
                    //    upt[i].phongthi = Convert.ToDouble((int)((stt - 1) / numericUpDown1.Value) + 1);
                    //    // MessageBox.Show(stt.ToString());
                    //    // rn = rn + 1;
                    //}

                    foreach (vemt v in upt)
                    {
                        v.phongthi = d - 1;
                    }
                    //upt.phongthi = (d - 1.0);
                   
                    db.SubmitChanges();
                }
                //a = số lượng người ở phòng d
                // nếu d < số người quy định*
                //{
                // update pt=d-1 cua where pt = d
            //}
                    MessageBox.Show("Chia thành công");
                    //MessageBox.Show(list.Count.ToString());

                
                  //  loadgrv();
                }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            InDanhSachPhongThi f = new InDanhSachPhongThi();
            f.Show();
        }
        }
    }