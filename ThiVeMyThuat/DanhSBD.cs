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
    public partial class DanhSBD : Form
    {
        public DanhSBD()
        {
            InitializeComponent();
        }

        //private void loadgrv()
        //{
        //    dbVeMTDataContext db = new dbVeMTDataContext();
        //    dgv_thisinh.Rows.Clear();
        //    var list = from t in db.vemts select new { t.sohs, t.hoten, Type = t.phai == true ? "Nam" : "Nữ",t.sobaodanh };
        //    dgv_thisinh.DataSource = list;

        //    dgv_thisinh.Columns[0].HeaderText = "Số HS";
        //    dgv_thisinh.Columns[1].HeaderText = "Họ và tên";
        //    dgv_thisinh.Columns[2].HeaderText = "Giới tính";
           
        //    dgv_thisinh.Columns[3].HeaderText = "Số báo danh";
            

        //    //this.dgv_thisinh.Columns[3].DefaultCellStyle.Format = ("dd/MM/yyyy");
        //    //this.dgv_thisinh.Columns[6].DefaultCellStyle.Format = ("dd/MM/yyyy");
        //    //    if (dgv_thisinh.CurrentRow.Cells[2].Value.ToString() == "True")
        //    //    {
        //    //        dgv_thisinh.CurrentRow.Cells[2].Value = "name";
        //    //    }

        //    //    else { dgv_thisinh.CurrentRow.Cells[2].Value = "nữ"; }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //Random rd = new Random(1);
            //int rn = rd.Next(1, 100);
            if (comboBox1.Text == "anphabe Tên")
            {
                int rn = 1;
                dbVeMTDataContext db = new dbVeMTDataContext();
                //db.layTen();
                //var sort = from s in db.vemts
                //           orderby db.layTen(s.hoten)
                //           select s.hoten;
                var qry1 = db.vemts.OrderBy(a => db.layTen(a.hoten)).Select(b => b.hoten);
                List<String> list1 = new List<String>();
                list1 = qry1.ToList();
              //  var qry = db.vemts.OrderBy(a => db.layTen(a.phongthi));
                //private ArrayList al = new ArrayList();
                List<String> ds = new List<String>();
              //  ds = sort.ToList();
                // MessageBox.Show(ds.ToString());
                foreach (String item in list1)
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
                    if (dsSbd1.Count() < 10)
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            string s = rn.ToString().PadLeft(1, '0') ;

                            dsSbd[i].sobaodanh = textBox1.Text + s;//so phach la tang lien tuc
                            // MessageBox.Show(dsSbd[i].phach.ToString());
                            rn = rn + 1;
                        }
                    }
                    else if (dsSbd1.Count() < 100)
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            //string s = i.ToString().PadLeft(2, '0') +rn.ToString();
                            string s = rn.ToString().PadLeft(2, '0');
                            dsSbd[i].sobaodanh = textBox1.Text + s;//so phach la tang lien tuc
                            // MessageBox.Show(dsSbd[i].phach.ToString());
                            rn = rn + 1;
                        }
                    }
                    else if (dsSbd1.Count() < 1000)
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            //string s = i.ToString().PadLeft(2, '0') +rn.ToString();
                            string s = rn.ToString().PadLeft(3, '0');
                            dsSbd[i].sobaodanh = textBox1.Text + s;//so phach la tang lien tuc
                           // MessageBox.Show(dsSbd[i].sobaodanh.ToString());
                            rn = rn + 1;
                        }
                        
                       
                    }
                    else
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            string s = rn.ToString().PadLeft(4, '0');

                            dsSbd[i].sobaodanh = textBox1.Text + s;//so phach la tang lien tuc
                            // MessageBox.Show(dsSbd[i].phach.ToString());
                            rn = rn + 1;
                        }
                    }

                }

                db.SubmitChanges();

                MessageBox.Show("Đã thực hiện xong");

               // loadgrv();
            }
            else
            {
                int rn = 1;
                dbVeMTDataContext db = new dbVeMTDataContext();
                //db.layTen();
                var sort = from s in db.vemts
                           orderby s.sohs
                           select (s.sohs);
                //private ArrayList al = new ArrayList();
                List<String> ds = new List<String>();
                ds = sort.ToList();
                // MessageBox.Show(ds.ToString());
                foreach (String item in sort)
                {
                    List<vemt> dsSbd = new List<vemt>();
                    List<vemt> dsSbd1 = new List<vemt>();
                    dsSbd = (from purchase in db.vemts
                             where purchase.sohs == item
                             select purchase).ToList();

                    dsSbd1 = (from r in db.vemts
                              orderby r.sohs
                              select r).ToList();
                    // dsSbd.Count();
                   // MessageBox.Show(dsSbd1.Count().ToString());
                    if (dsSbd1.Count() < 10)
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            string a = rn.ToString().PadLeft(1, '0');

                            dsSbd[i].sobaodanh = textBox1.Text + a;//so phach la tang lien tuc
                            // MessageBox.Show(dsSbd[i].phach.ToString());
                            rn = rn + 1;
                        }
                    }
                    else if (dsSbd1.Count() < 100)
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            string a = rn.ToString().PadLeft(2, '0');

                            dsSbd[i].sobaodanh = textBox1.Text + a;//so phach la tang lien tuc
                            // MessageBox.Show(dsSbd[i].phach.ToString());
                            rn = rn + 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dsSbd.Count(); i++)
                        {
                            string a = rn.ToString().PadLeft(3, '0');

                            dsSbd[i].sobaodanh = textBox1.Text + a;//so phach la tang lien tuc
                            // MessageBox.Show(dsSbd[i].phach.ToString());
                            rn = rn + 1;
                        }
                    }

                }

                db.SubmitChanges();
                MessageBox.Show("Đã thực hiện xong");

              //  loadgrv();
            }
        }

        private void DanhSBD_Load(object sender, EventArgs e)
        {
           // loadgrv();
            comboBox1.Text = "anphabe Tên";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DanhSachSBD f = new DanhSachSBD();
            f.Show();
        }
    }
}
