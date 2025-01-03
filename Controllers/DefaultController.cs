using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace PatExam.Controllers
{
    public class DefaultController
    {
        public void Basic(Employee emp)
        {
            try
            {


                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                // string query = "SELECT * FROM Employee ";
                string query = $"insert into Employee (Name, Address) values ('{emp.Name}','{emp.Address}')";


                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    //cmd.ExecuteNonQuery(); for insert


                    cmd.ExecuteNonQuery();




                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        Employee temp = new Employee();
                    //        temp.Name = reader["Name"].ToString();
                    //        temp.Address = reader["Address"].ToString();

                    //        ldata.Add(temp);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Team(Team team, string deptname)
        {

            string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

            //
            string query =  $"Select ID from Person where deptname = '{deptname}'";

            // string query = "SELECT * FROM Employee ";


            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = Convert.ToInt32(rdr["ID"]);
                }
                
            }
            
            //

            string query2 = $"insert into Team (Name, Leader, DeptID) values ('{team.Name}','{team.TeamLead}','')";


            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
        }
        public void Dept(Department dept)
        {

            string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = $"insert into Department (Name, Head) values ('{dept.Name}','{dept.DeptHead})";
            //insert
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            //--------------
        }
    }
}