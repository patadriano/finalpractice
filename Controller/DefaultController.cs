using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleCRUD.Controller
{
    public class DefaultController
    {
        public void PersonTable(Person person)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Practice"].ConnectionString;
                //string query = $"insert into Person (Name, Age) values (@Name, @Age)";
                string query = $"insert into Person (Name, Age) values ({person.Name},{person.Age} )";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    //cmd.Parameters.AddWithValue("@Name", person.Name);
                    //cmd.Parameters.AddWithValue("@Age", person.Age);

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
    }
}