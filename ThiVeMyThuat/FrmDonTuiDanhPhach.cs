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
    public partial class FrmDonTuiDanhPhach : Form
    {
        public FrmDonTuiDanhPhach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //sap xep theo phong thi
                dbVeMTDataContext db = new dbVeMTDataContext();
                var qry = db.vemts.OrderBy(a => a.phongthi);
                List<vemt> list = new List<vemt>();
                list = qry.ToList();
                //danh stt
                int n = list.Count;
                for (int i = 0; i < n; i++)
                {
                    list[i].stt = i + 1;
                }
                
                //don tui bai thi
                for (int i = 0; i < n; i++)
                {
                    decimal? stt = list[i].stt;
                    list[i].tui = Convert.ToDouble((int)((stt - 1) / numericUpDown1.Value)) + 1;
                }
              //  db.SubmitChanges();
                //danh phach theo tung tui, cac phach trong mot tui la lien tuc
                //phac giua cac tui cach nhau la 1 so nguyen tu 1 den 10
                //sinh ra so ngau nhien
                Random rd = new Random(1);
                int rn = rd.Next(1, 100);
                //lay ra danh sach cac tui
                var qryDstui = (from x in db.vemts
                               orderby x.tui
                               select x.tui).Distinct();
                List<double?> dstui = new List<double?>();
                dstui = qryDstui.ToList();

                //duyet tung tui bai thi
                foreach (float item in dstui)
                {
                    //MesageBox.Show(item.ToString());
                    progressBar1.Value = progressBar1.Value + 1;
                    List<vemt> dsSbd = new List<vemt>();
                    //lay ra ca bai thi trong 1 tui
                    dsSbd = (from x in db.vemts
                             where x.tui == item
                             select x).ToList();
                    //duyet tung bai thi va danh phach cho bai thi
                    for (int i = 0; i < dsSbd.Count; i++)
                    {
                        
                        dsSbd[i].phach = rn;//so phach la tang lien tuc
                        rn = rn + 1;
                    }
                    //tui tiep theo co so phach bat dau bang so phach tui cu  + 1 so ngau nhien
                    rn = rn + new Random().Next(1,10);
                    
                }
                db.SubmitChanges();
                MessageBox.Show("Đã thực hiện xong");
            }
            catch (Exception ex)
            {
                Utils.Show_Exception_Msg(ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDonTuiDanhPhach_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = (from x in new dbVeMTDataContext().vemts
                                    select x.tui).Distinct().ToList().Count();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
