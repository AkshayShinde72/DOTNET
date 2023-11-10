using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Assignment_Ado_dotnet
{
    internal class DataLayer
    {
        private string _connectionString;
        public DataLayer(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = _connectionString;
            return sqlconn;
        }

        public int InsertData(Employee_poco e)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            int record = 0;

            try
            {
                sqlconn = getconnection();
                sqlcmd = new SqlCommand("storedata", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = e.Name;
                sqlcmd.Parameters.Add("@psalary", SqlDbType.Float).Value = e.Salary;
                sqlcmd.Parameters.Add("@pgender", SqlDbType.Char).Value = e.Gender;
                sqlcmd.Parameters.Add("@paddress", SqlDbType.NVarChar).Value = e.Address;

                sqlconn.Open();
                record = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Insert Data succesfully");
            }
            catch (SqlException se)
            { Console.WriteLine(se.Message); }

            finally
            {
                sqlconn.Close();
            }
            return record;


        }

        public List<Employee_poco> GetList()
        {
            var listEmployee = new List<Employee_poco>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetProductsByName", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@ProductName",SqlDbType.NVarChar).Value=
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listEmployee.Add(new Employee_poco
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Name = rdr["Name"].ToString(),
                            Salary = Convert.ToSingle(rdr["Salary"]),
                            Address = rdr["Address"].ToString(),
                            Gender = rdr["Gender"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listEmployee;
        }

        public void Update_Employee(Employee_poco e, int id)
        {
            try
            {
                SqlConnection con = getconnection();
                SqlCommand cmd = new SqlCommand("@Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = e.Id;
                cmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = e.Name;
                cmd.Parameters.Add("@psalary", SqlDbType.Float).Value = e.Salary;
                cmd.Parameters.Add("@pgender", SqlDbType.Char).Value = e.Gender;
                cmd.Parameters.Add("@paddress", SqlDbType.NVarChar).Value = e.Address;
                cmd.Parameters.Add("@PCID", SqlDbType.Int).Value = id;
                con.Open();
                Console.WriteLine("Connected");
                int record = cmd.ExecuteNonQuery();
                Console.WriteLine("Rows Affected = " + record);
                con.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void Delete(int id)
        {
            try
            {
                SqlConnection con = getconnection();
                SqlCommand cmd = new SqlCommand("@Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = id;
                con.Open();
                Console.WriteLine("Connected");
                int record = cmd.ExecuteNonQuery();
                Console.WriteLine(" Delete Command executed and Affected Rows = " + record);
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //_____________________________________________________________________________________________________________

        public Employee_poco search(int id)
        {
            SqlConnection con = null;
            Employee_poco c = null;
            try
            {
              con = getconnection();
                SqlCommand cmd = new SqlCommand("@Search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = id;

                c= new Employee_poco();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        c = new Employee_poco();
                        c.Id = Convert.ToInt32(reader["Id"]);
                        c.Name = Convert.ToString(reader["Name"]);
                        c.Address = Convert.ToString(reader["Address"]);
                        c.Salary = Convert.ToSingle(reader["Salary"]);
                        c.Gender = Convert.ToString(reader["Gender"]);

                        break;
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return c;
        }
    }
}
    
