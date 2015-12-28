using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ThiVeMyThuat
{
    public partial class PhoDiemThi : Form
    {
        public PhoDiemThi()
        {
            InitializeComponent();
        }

        private void phodiemthi_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dbVeMTDataContext db = new dbVeMTDataContext();
            dataGridView1.Rows.Clear();
            var results = from p in db.vemts
                          group p by p.diem into g
                          select new { diem = g.Key , soluong = g.Count() };
            dataGridView1.DataSource = results;
            db.SubmitChanges();
            //Tìm và đặt giá trị MAX cho trục Y
            int max = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            for (int i = 1; i <= dataGridView1.SelectedRows.Count; i++)
                if (max < Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value))
                    max = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            if (chart1.ChartAreas[0].AxisY.Maximum < max) chart1.ChartAreas[0].AxisY.Maximum = max;

            chart1.Series.Clear();

            Series s = new Series();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                s.ChartType = SeriesChartType.Line;
                DataPoint p = new DataPoint();
                p.XValue = i;
                p.SetValueY(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));
                //p.AxisLabel = "Điểm " + dataGridView1.Rows[i].Cells[0].Value.ToString() +"";
                p.AxisLabel = "điểm" + i.ToString(); ;
                s.Points.Add(p);
            }
            chart1.Series.Add(s);
        }

        private void phodiemthi_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            chart1.Titles.Add("ChartTitle1");
            chart1.Titles[0].Text = "PHỔ ĐIỂM";
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            for (int i = 1; i <= dataGridView1.SelectedRows.Count; i++)
                if (max < Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value))
                    max = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            if (chart1.ChartAreas[0].AxisY.Maximum < max) chart1.ChartAreas[0].AxisY.Maximum = max;

            chart1.Series.Clear();

            Series s = new Series();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                s.ChartType = SeriesChartType.Line;
                DataPoint p = new DataPoint();
                p.XValue = i;
                p.SetValueY(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));
                p.AxisLabel =  dataGridView1.Rows[i].Cells[0].Value.ToString();
                //p.AxisLabel = dataGridView1.Rows[i].Cells[0].Value.ToString();
                s.Points.Add(p);
            }
            chart1.Series.Add(s);
        }
    }
}
