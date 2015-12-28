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
    public partial class InGiayBao : Form
    {

        //Định nghĩa delegate
        public delegate void DelSendMsg(string msg);

        //khạ báo biến kiểu delegate
        public DelSendMsg SendMsg;
        public InGiayBao()
        {
            InitializeComponent();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            DanhSachDuThi re = new DanhSachDuThi();
          
            if (SendMsg != null)
            {
                SendMsg.Invoke(txtghichu.Text);
            }
            DanhSachDuThi ds = new DanhSachDuThi();
            ds.Show();
        }

        private void Ingiaybao_Load(object sender, EventArgs e)
        {

        }
    }
}
