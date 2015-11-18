using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiVeMyThuat
{
    class CPhongThi
    {
        public List<vemt> Lst_baithi_theophong = new List<vemt>();
        public int sobaithi_con_theophong { get; set; }
    }

    class CTui
    {
        public List<vemt> Lst_baithi_theotui = new List<vemt>();
        public int sobaithi_con_theotui { get; set; }
    }
    class Utils
    {
        //Khởi tạo list phòng thi
        public static List<CPhongThi> lst_phongthi = new List<CPhongThi>();
        //Khởi tạo list túi
        public static List<CTui> lst_tui = new List<CTui>();
        //khởi tạo biến đếm số túi bài thi
        public static int sotuibaithi { get; set; }
        //khởi tạo biến chứa số bài thi / túi
        public static int sobaithi_theotui { get; set; }

        public static void LoadFullScreen(Form f)
        {
            f.WindowState = FormWindowState.Maximized;
        }        

        public static void Show_Exception_Msg(Exception ex)
        {
            if (MessageBox.Show(Constants.Msg_Exception_Error, Constants.Msg_Caption_Error, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                MessageBox.Show(ex.ToString(), Constants.Msg_Caption_Exception_Error_Detail, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
