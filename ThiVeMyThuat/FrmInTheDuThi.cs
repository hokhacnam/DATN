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
using System.Configuration;
namespace ThiVeMyThuat
{
    public partial class FrmInTheDuThi : Form
    {
        public FrmInTheDuThi()
        {
            InitializeComponent();
        }

        private void FrmInTheDuThi_Load(object sender, EventArgs e)
        {
            //string conStr = ConfigurationManager.ConnectionStrings["ThiVeMyThuat.Properties.Settings.XDAConnectionString"].ToString();
            //SqlConnection conn = new SqlConnection(conStr);
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM VeMT", conn);
            //SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    int ns = row[5].ToString().Length;
            //    String ns2;
            //    if (ns == 5)
            //    {
            //        ns2 = row[5].ToString();
            //        //    MessageBox.Show(ns2);
            //        string ns3 = ns2.Substring(1, 2) + "/" + "0" + ns2.Substring(0, 1) + "/" + ns2.Substring(3, 2);
            //        row[6] = DateTime.Parse(ns3);
            //        // da.Update(item);
            //        //   MessageBox.Show(item[6].ToString());

            //        // MessageBox.Show(ns2.Substring(3, 2) + "/" + ns2.Substring(1, 2) + "/" + "0" + ns2.Substring(0, 1));
            //    }
            //    else if (ns == 6)
            //    {
            //        ns2 = row[5].ToString();
            //        //MessageBox.Show(ns2);
            //        string ns3 = ns2.Substring(2, 2) + "/" + ns2.Substring(0, 2) + "/" + ns2.Substring(4, 2);
            //        row[6] = DateTime.Parse(ns3);
            //        // da.Update(item);
            //        //MessageBox.Show(item[6].ToString());
            //        //MessageBox.Show(ns2.Substring(4, 2) + "/" + ns2.Substring(2, 2) + "/" + ns2.Substring(0, 2));
            //    }
            //}
            //sda.UpdateCommand = cmb.GetUpdateCommand();
            //sda.Update(ds);
            DsVeMTTableAdapters.vemtTableAdapter da = new DsVeMTTableAdapters.vemtTableAdapter();
            
            da.Fill(dsVeMT1.vemt);
            
            inlineReportSlot1.RenderDocument();
        }
    }
}
