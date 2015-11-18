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
    public partial class FrmDsThuLePhi : Form
    {
        public FrmDsThuLePhi()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FrmDsThuLePhi_Load(object sender, EventArgs e)
        {
            Utils.LoadFullScreen(this);

            dbVeMTDataContext db = new dbVeMTDataContext();
            var db_filter = db.vemts.Where(o => o.lephi == null || o.lephi == false);

            this.reportManager1.DataSources = new PerpetuumSoft.Reporting.Components.ObjectPointerCollection(new string[] {"VeMT"}, new object[] {((object)(db_filter))});
            inlineReportSlot1.RenderDocument();
        }
    }
}
