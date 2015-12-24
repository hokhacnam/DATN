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
    public partial class Ingiaybao : Form
    {

        //Định nghĩa delegate
        public delegate void DelSendMsg(string msg);

        //khạ báo biến kiểu delegate
        public DelSendMsg SendMsg;
        public Ingiaybao()
        {
            InitializeComponent();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            danhsachduthi re = new danhsachduthi();
          
            if (SendMsg != null)
            {
                SendMsg.Invoke(txtghichu.Text);
            }
            danhsachduthi ds = new danhsachduthi();
            ds.Show();
        }

        private void Ingiaybao_Load(object sender, EventArgs e)
        {

        }
    }
}
