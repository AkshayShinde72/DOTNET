using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace customer_adiodotnet
{
    internal class Productlayer
    {
        private string _connecstionString;

        public Productlayer(IConfiguration iconfiguration)
        {
            _connecstionString = iconfiguration.GetConnectionString("Default");
        }



        public void Products()
        {
            using (SqlConnection con = new SqlConnection(_connecstionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Customer", con);
                con.Open();
                Console.WriteLine("Connected");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", reader["Id"], reader["Name"], reader["Address"], reader["Mobile_No"]);
                    }
                }
            }
        }


            public void product_insert()
            {
                using (SqlConnection con = new SqlConnection(_connecstionString))
                {
                    try
                    {
                        //Create an instance of SqlCommand class, specifying the T-SQL command 
                        //that we want to execute, and the connection object.
                        SqlCommand cmd = new SqlCommand("insert into Customer values ( 'Yash','Nagpur','1718569856')", con);
                        con.Open();
                        //Since we are performing an insert operation, use ExecuteNonQuery() 
                        //method of the command object. ExecuteNonQuery() method returns an 
                        //integer, which specifies the number of rows inserted
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Inserted Rows = " + rowsAffected);

                        //Set to CommandText to the update query. We are reusing the command object, 
                        //instead of creating a new command object
                        cmd.CommandText = "update Customer set Name= 'Shubham Gaikwad' where Id = 1";
                        //use ExecuteNonQuery() method to execute the update statement on the database
                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Updated Rows = " + rowsAffected);

                        //Set to CommandText to the delete query. We are reusing the command object, 
                        //instead of creating a new command object
                        cmd.CommandText = "Delete from Customer where Id = 3";
                        //use ExecuteNonQuery() method to delete the row from the database
                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("Deleted Rows = " + rowsAffected);
                    }
                    catch (Exception ex)
                    {
                        // Handle Exceptions, if any
                        Console.WriteLine(ex.Message);
                    }
                }

            }



        }


    }

