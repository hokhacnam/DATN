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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDsAnh f = new FrmDsAnh();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDsPhongThi f = new FrmDsPhongThi();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmDsDinhChinh f = new FrmDsDinhChinh();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmDsThuLePhi f = new FrmDsThuLePhi();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            danhsachduthi f = new danhsachduthi();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmInTheDuThi FrmTheduthi = new FrmInTheDuThi();
            FrmTheduthi.Show();
        }

        private void btnDonTuiBaiThi_Click(object sender, EventArgs e)
        {
            FrmDonTuiDanhPhach f = new FrmDonTuiDanhPhach();
            f.Show();
        }

        private void btnInHdDonTuiBT_Click(object sender, EventArgs e)
        {
            FrmInHDDonTuiBaiThi f = new FrmInHDDonTuiBaiThi();
            f.Show();
        }

        private void btnInHdDanhPhach_Click(object sender, EventArgs e)
        {
            FrmInHDDanhPhach f = new FrmInHDDanhPhach();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmDonTuiRand f = new FrmDonTuiRand();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmInThongTinTuiPhach f = new FrmInThongTinTuiPhach();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Frmdangky f = new Frmdangky();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Danhsachdutru f = new Danhsachdutru();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmDonTuiDanhPhach f = new FrmDonTuiDanhPhach();
            f.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            DanhSBD f = new DanhSBD();
            f.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Chiaphongthi f = new Chiaphongthi();
            f.Show();
        }
    }
}
