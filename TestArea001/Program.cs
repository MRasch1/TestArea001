using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestArea001
{
    public class TestDB
    {
        private SqlConnection _con = new SqlConnection();
        private SqlCommand _sql_command = new SqlCommand();
        string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Visual Studio\TestArea001\TestArea001\TestDatabase.mdf;Integrated Security=True";

        public TestDB()
        {
            _con.ConnectionString = _connectionString;
        }


        public void Mathias(DatoKlasse dato)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    //conn.ConnectionString = _connectionString;
                    conn.Open();
                    string sql = "INSERT INTO TestData (Dato) VALUES(@Dato)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Dato", dato.Dato);

                        var antalgemteRækker = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public int CreatePersonInDatoKlasse(DatoKlasse dato)
        {
            int result = -1;
            try
            {
                // Open the connection.
                using (_con = new SqlConnection(_connectionString))
                {
                    _con.Open();
                    string sql = "INSERT INTO TestData (Dato) VALUES(@Dato)";

                    using (_sql_command = new SqlCommand(sql, _con))
                    {
                        _sql_command.Parameters.AddWithValue("@Dato", dato.Dato);
                        //sql_command.Parameters.AddWithValue("@Navn", dato.Navn);
                        var antalgemteRækker = _sql_command.ExecuteNonQuery();
                        result = antalgemteRækker;
                        _con.Close();
                    }

                }

                

                   

                ////SqlCommand cmd = new SqlCommand("dbo.TestData", conn);
                //// Set the command type.
                //sql_command.CommandType = System.Data.CommandType.StoredProcedure;

                //    rdr = sql_command.ExecuteReader();

                //    // Add the parameter.
                //    SqlParameter parameter = sql_command.Parameters.Add("@dt", System.Data.SqlDbType.DateTime);

                //    // Set the value.
                //    parameter.Value = dato.Dato;

                //    sql_command.Connection = con;
                //    //set the sql statement to execute at the data source
                //    //sql_command.CommandText = sql;
                //    //execute the data.
                //    result = sql_command.ExecuteNonQuery();

                //    // Make the call.
                //    //sql_command.ExecuteNonQuery();

                //    if (conn != null)
                //    {
                //        conn.Close();
                //    }
                //    if (rdr != null)
                //    {
                //        rdr.Close();
                //    }



                //    if (result > 0)
                //    {
                //        MessageBox.Show("Data has been saved in the SQL database");
                //    }
                //    else
                //    {
                //        MessageBox.Show("SQL QUERY ERROR");
                //    }
                //    //closing connection
                //    con.Close();

                
            }
            catch (Exception ex)//catch exeption
            {
                _con.Close();
                //displaying errors message.
                MessageBox.Show(ex.Message);
            }

            return result;
        }


    }





    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }


    }
}
