using PerpetuumSoft.Reporting.DOM;
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
    public partial class FrmInThongTinTuiPhach : Form
    {
        public FrmInThongTinTuiPhach()
        {
            InitializeComponent();
        }

        List<ThongTinTuiPhach> lst_TT_TuiPhach = new List<ThongTinTuiPhach>();

        private void FrmInThongTinTuiPhach_Load(object sender, EventArgs e)
        {
            Utils.LoadFullScreen(this);                      

            //Chuẩn bị dữ liệu cho lst_TT_TuiPhach
            LoadData_lstTui();

            //Gán datasource cho reportManager1
            this.reportManager1.DataSources = new PerpetuumSoft.Reporting.Components.ObjectPointerCollection(new string[] { "TTTuiPhach" }, new object[] { ((object)(lst_TT_TuiPhach)) });
                        
            inlineReportSlot1.RenderDocument();                       
        }

        public void LoadData_lstTui()
        {
            //lấy về dữ liệu
            dbVeMTDataContext db = new dbVeMTDataContext();
            
            //lấy về số túi bài thi trong CSDL
            var query = db.vemts.Select(o => o.tui).Distinct(); // (from x in db.vemts select x.tui).Distinct();


            for (int i = 0; i < query.Count(); i++)
            {
                //get list bài thi theo túi, sort by phach.
                var qr = db.vemts.Where(o => o.tui == i + 1).OrderBy(o => o.phach).ToList();
                
                //Khởi tạo đối tượng Thông tin phách
                ThongTinTuiPhach tt = new ThongTinTuiPhach();
                tt.tuiso = i + 1;
                tt.tuphach = (int) qr[0].phach;
                tt.denphach = (int)qr[qr.Count() - 1].phach;

                //Add đối tượng vừa tạo vào lst_tt_tuiphach
                lst_TT_TuiPhach.Add(tt);

            }
        }

    }

    class ThongTinTuiPhach
    {
        public int tuiso { get; set; }
        public int tuphach { get; set; }
        public int denphach { get; set; }
    }
}
