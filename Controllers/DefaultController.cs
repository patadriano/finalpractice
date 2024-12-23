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
        public void PersonTable(Model person)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = $"insert into Person (Name, Age) values (@Name, @Age)";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Name", person.Name);
                    cmd.Parameters.AddWithValue("@Age", person.Age);

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
        public void ReadPersonTable(Model person)
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
                            Model temp = new Model();
                            temp.Name = reader["Name"].ToString();
                            temp.Age = (int)reader["Age"];
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