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
    public partial class Ketquathi : Form
    {
        public Ketquathi()
        {
            InitializeComponent();
            inlineReportSlot1.RenderCompleted += new EventHandler(inlineReportSlot1_RenderCompleted);
            inlineReportSlot1.GetReportParameter += new PerpetuumSoft.Reporting.Components.GetReportParameterEventHandler(inlineReportSlot1_GetReportParameter);
        }

        private void inlineReportSlot1_RenderCompleted(object sender, EventArgs e)
        {
            PerpetuumSoft.Reporting.Components.IReportSource rs = sender as PerpetuumSoft.Reporting.Components.IReportSource;
            using (PerpetuumSoft.Reporting.View.PreviewForm previewForm = new PerpetuumSoft.Reporting.View.PreviewForm(rs))
            {
                previewForm.WindowState = FormWindowState.Maximized;
                previewForm.ShowDialog(this);
            }

        }

        private void inlineReportSlot1_GetReportParameter(object sender, PerpetuumSoft.Reporting.Components.GetReportParameterEventArgs e)
        {
            e.Parameters["ghichu"].Value = textBox1.Text;
        }

        private void Ketquathi_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DsVeMTTableAdapters.vemtTableAdapter da = new DsVeMTTableAdapters.vemtTableAdapter();

            da.Fill(dsVeMT1.vemt);
            inlineReportSlot1.Prepare();
        }
    }
}
