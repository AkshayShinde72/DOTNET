using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace company_adiodotnet
{
    internal class Productlayer
    {

        private string _connectionString;
        public Productlayer(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public void Products()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee", con);
                con.Open();
                Console.WriteLine("connected");
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Console.WriteLine("{0} {1} {2}", rdr["Id"], rdr["Name"], rdr["Salary"]);
                    }

                }
            }

        }
    }
}
