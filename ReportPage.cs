using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace SalcompTwoCam
{
    public partial class ReportPage : Form
    {
        Database db = new Database();
        public ReportPage()
        {
            InitializeComponent();
        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {
            ShowDateWise();
        }


        public void ShowDateWise()
        {
            using (NpgsqlConnection con = db.GetConnection())
            {
                con.Open();
                string query = @"select _date as ""Date"", _time as ""Time"", modelnum as ""Model Number"", srnum as ""Serial Number"",
                                    code as ""Defect Code"", _result as ""Final Result"" from public.chargerdatabase where 
                                    _date between @date1 and @date2 group by _date, _time, modelnum, srnum, code, _result";

                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@date1", Convert.ToDateTime(datePickerStart.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.AddWithValue("@date2", Convert.ToDateTime(datePickerEnd.Value.ToString("yyyy-MM-dd")));
                NpgsqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                if (reader.HasRows)
                {
                    dt.Clear();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
                reader.Close();

            }
        }

        private void ReportPage_Load(object sender, EventArgs e)
        {
            db.TestConnection();

        }

        private void ReportPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.reportPage = null;
        }
    }
}
