using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Assignment_day14_disconnected
{
    internal class EmpDAL {

        private static string _connectionString;
        SqlDataAdapter dataAdapter;
        DataSet dataset=new DataSet();
        SqlConnection connection;
        public EmpDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
            connection = new SqlConnection(_connectionString);
        }

        public DataTable GetList()
        {
            dataAdapter = new SqlDataAdapter("select * from Employee2", connection);
            dataAdapter.FillSchema(dataset, SchemaType.Source, "Employee2");
            dataAdapter.Fill(dataset, "Employee2");
            Console.WriteLine(dataset.GetXml());

            dataset.Tables[0].TableName = "Employee2";
            DataTable dt = dataset.Tables["Employee2"];
           
            return dt;
        }

       public void addindataset()
        {
            DataRow drCurrent = dataset.Tables["Employee2"].NewRow();
            drCurrent["Id"] = 9;
            drCurrent["Name"] = "Akshita";
            drCurrent["Salary"] = 7000000;

            dataset.Tables["Employee2"].Rows.Add(drCurrent);
            Console.WriteLine("Add was successful, Click any key to continue!!");

            SqlCommandBuilder co = new SqlCommandBuilder(dataAdapter);
            Console.WriteLine(co.GetInsertCommand().CommandText);
            dataAdapter.Update(dataset, "Employee2");

        }

        public void deletebyid(int id)
        {
            DataRow dd = dataset.Tables[0].Rows.Find(id);
            dd.Delete();
            SqlCommandBuilder co = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataset, "Employee2");
            Console.WriteLine(co.GetDeleteCommand().CommandText);
        }
    }
}
