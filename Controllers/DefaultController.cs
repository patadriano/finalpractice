using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;



namespace SimpleCRUD.Controllers
{
    public class DefaultController
    {
        public void AddPersonTable(Person person)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = $"insert into Person (Name) values (@Name)";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    

                    cmd.ExecuteNonQuery();

                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        Model temp = new Model();
                    //        temp.Name = reader["Name"].ToString();
                    //        temp.Age = (int)reader["Age"];

                    //        ldata.Add(temp);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void AddTeamTable(Team team)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = $"insert into Team (Name, DeptID) values (@Name, @DeptID)";

                

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", team.Name);

                    //cmd.Parameters.AddWithValue("@DeptID", team.DeptID);

                    cmd.ExecuteNonQuery();

                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        Model temp = new Model();
                    //        temp.Name = reader["Name"].ToString();
                    //        temp.Age = (int)reader["Age"];

                    //        ldata.Add(temp);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void AddDeptTable(Dept dept)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = $"insert into Department (Name) values (@Name)";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", dept.Name);

                  

                    cmd.ExecuteNonQuery();

                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    while (reader.Read())
                    //    {
                    //        Model temp = new Model();
                    //        temp.Name = reader["Name"].ToString();
                    //        temp.Age = (int)reader["Age"];

                    //        ldata.Add(temp);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void ReadPersonTable(Person person)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = "select ID, Name, Age from Person ";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Person temp = new Person();
                            temp.Name = reader["Name"].ToString();
                         
                        }
                    }

                    cmd.ExecuteNonQuery();

                    //
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
        
}