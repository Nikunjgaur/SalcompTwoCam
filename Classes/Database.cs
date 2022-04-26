using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace SalcompTwoCam
{

    public class Database
    {
        // Process process = new Process();

        public void InsertRecord(DateTime date, DateTime time, string modelnum, string serialnum,
                               string defcode, string camCode,int result)
        {

           

            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.chargerdatabase (_date, _time, modelnum, srnum, 
                                code, camcode,_result)
                                values(@date, @time, @modelnumum, @srnum, @defcode, @camcode, @result)";

                NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@modelnumum", modelnum);
                cmd.Parameters.AddWithValue("@srnum", serialnum);
                cmd.Parameters.AddWithValue("@defcode", defcode);
                cmd.Parameters.AddWithValue("@camcode", camCode);
                cmd.Parameters.AddWithValue("@result", result);
                
                con.Open();
                int n = cmd.ExecuteNonQuery();
            }
        }
       

        public void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State != ConnectionState.Open)
                {
                    MessageBox.Show("Can not connect to Database");
                }
                else
                {
                    Console.WriteLine("Connected to database.");
                }
            }
        }

        public NpgsqlConnection GetConnection()
        {

            return new NpgsqlConnection(@"Server=localhost; Port = 5432; user Id = postgres; password = 1234; Database = postgres;");
        }
    }


}