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
    public partial class danhsachduthi : Form
    {
        public danhsachduthi()
        {
            InitializeComponent();
            //Loaded += new RoutedEventHandler(MainPage_Loaded);
            //reportViewer.PageLoaded += new EventHandler<PerpetuumSoft.ReportingServices.Viewer.Client.PageLoadedEventArgs>(reportViewer_PageLoaded);
            //reportViewer.ParameterVisibilityChanging += new EventHandler<PerpetuumSoft.ReportingServices.Viewer.Client.ParameterVisibilityChangingEventArgs>(reportViewer_ParameterVisibilityChanging); 
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
            TimeSpan result = DateTime.Today.Subtract(dateTimePicker2.Value);
            e.Parameters["gio"].Value = numericUpDown1.Text;
            e.Parameters["phut"].Value = numericUpDown2.Text;
            e.Parameters["ngay"].Value = dateTimePicker2.Value.ToString("dd");
            e.Parameters["thang"].Value = dateTimePicker2.Value.ToString("MM");
            e.Parameters["phongthi"].Value = textBox5.Text;
            e.Parameters["ghichu"].Value = textBox6.Text;
           // e.Parameters["test"].Value = textBox7.Text;
        }


        public string GC { 
            get;
            set;
        }

        private void danhsachduthi_Load(object sender, EventArgs e)
        {
        //    Utils.LoadFullScreen(this);
        //    DsVeMTTableAdapters.vemtTableAdapter da = new DsVeMTTableAdapters.vemtTableAdapter();

        //    da.Fill(dsVeMT1.vemt);

        //    inlineReportSlot1.RenderDocument();
           
        }

        //protected override void OnUnprocessableParametersDetected()
        //{
        //    List<PerpetuumSoft.Reporting.DOM.Parameter> problemParameters,
        //   `List<Parame>
        //}

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //PerpetuumSoft.Reporting.Components.InlineReportSlot rp = new PerpetuumSoft.Reporting.Components.InlineReportSlot();
            //PerpetuumSoft.Reporting.DOM.Document template = new PerpetuumSoft.Reporting.DOM.Document();
            //template.Parameters.Add(new PerpetuumSoft.Reporting.DOM.Parameter());
            //rp.SaveReport(template);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DsVeMTTableAdapters.vemtTableAdapter da = new DsVeMTTableAdapters.vemtTableAdapter();

             da.Fill(dsVeMT1.vemt);
            inlineReportSlot1.Prepare();
        }
    }
}
