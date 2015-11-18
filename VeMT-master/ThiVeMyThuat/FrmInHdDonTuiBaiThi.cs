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
    public partial class FrmInHDDonTuiBaiThi : Form
    {
        public FrmInHDDonTuiBaiThi()
        {
            InitializeComponent();
        }

        private void FrmDonTuiBaiThi_Load(object sender, EventArgs e)
        {
            Utils.LoadFullScreen(this);

            DsVeMTTableAdapters.vemtTableAdapter da = new DsVeMTTableAdapters.vemtTableAdapter();
            da.Fill(dsVeMT1.vemt);
            

            //dbVeMTDataContext db = new dbVeMTDataContext();
            //var db_filter = db.vemts.OrderBy(o => o.sobaodanh).OrderBy(o => o.phongthi).OrderBy(o => o.tui);

            ////dataGridView1.DataSource = db_filter;

            //this.reportManager1.DataSources = new PerpetuumSoft.Reporting.Components.ObjectPointerCollection(new string[] { "VeMT" }, new object[] { ((object)(db_filter)) });

            inlineReportSlot1.RenderDocument();
        }
    }
}
