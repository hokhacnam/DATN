using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ThiVeMyThuat
{
    public partial class ImPortDiem : Form
    {
        public ImPortDiem()
        {
            InitializeComponent();
        }


        DsVeMTTableAdapters.vemtTableAdapter mh = new DsVeMTTableAdapters.vemtTableAdapter();

        void loadData()
        {
            dataGridView1.DataSource = mh.GetData();
        }

        public static string OpenExcelFile(string fPath)
        {
            string connectionstring = String.Empty;
            string[] splitdot = fPath.Split(new char[1] { '.' });
            string dot = splitdot[splitdot.Length - 1].ToLower();
            if (dot == "xls")
            {
                //tao chuoi ket noi voi Excel 2003
                connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            }
            else if (dot == "xlsx")
            {
                //tao chuoi ket noi voi Excel 2007
                connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fPath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            }
            return connectionstring;
        }

        public static DataSet GetDataExcel(string fPath, string sheetname)
        {
            DataSet ds = new DataSet();
            string connectionstring = OpenExcelFile(fPath);
            string query = "SELECT * FROM [" + sheetname + "$]";
            using (OleDbConnection cnn = new OleDbConnection(connectionstring))
            {
                cnn.Open();
                OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, cnn);
                oleAdapter.Fill(ds, sheetname);
                oleAdapter.Dispose();
                cnn.Close();
                cnn.Dispose();
            }
            return ds;
        }


        private void btnimport_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        dbVeMTDataContext db = new dbVeMTDataContext();
            //        var qry1 = db.vemts.OrderBy(bn => bn.phach);
            //        List<vemt> list1 = new List<vemt>();
            //        list1 = qry1.ToList();
            //        string[] a = new string[20];
            //        DataSet ds = new DataSet();
            //        ds = GetDataExcel(openFileDialog1.FileName, "Sheet1");// Goi chuong trinh GetDataExcel phia tren luu vao Dataset ds        
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++) //Dong
            //        {
            //            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)//Cot 
            //            {
            //                a[j] = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                            
            //            };

            //            for (int ba = 0; ba < list1.Count; ba++)
            //            {
            //                if (list1[ba].phach ==Convert.ToDouble(a[0]))
            //                {
            //                    list1[ba].diem = Convert.ToDouble(a[1]);
            //                    db.SubmitChanges();
            //                }
            //            }
                        
            //            //MessageBox.Show(a[1].ToString());
            //            //Bat dau import du lieu vao
            //          //  mh.Insert(a[0], a[1], byte.Parse(a[2]));
            //        }
            //        loadData();
            //        MessageBox.Show("Import thành công.");
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Lỗi! Import thất bại. Vui lòng kiểm tra lại file Excel.");
            //    };
            //}  
        }

        private void Importdiem_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KetQua f = new KetQua();
            f.Show();
        }
    }
}
