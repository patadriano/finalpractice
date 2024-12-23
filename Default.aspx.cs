using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SimpleCRUD.Controllers;

namespace SimpleCRUD
{
    public partial class _Default : Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    List<string> list = new List<string>();
                    string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                    string query = "select Name from Person ";

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
                                list.Add(temp.Name);
                                
                            }
                        }

                        cmd.ExecuteNonQuery();

                        //
                    }
                ddl.DataSource = list;
                ddl.DataBind();
                }
                catch (Exception ex)
                {
                }

                
            }
        }
        protected void btnAddPerson_Click(object sender, EventArgs e)
        {
            Model person = new Model();
            person.Name = txtName.Text;
            person.Age = Convert.ToInt32(txtAge.Text);

            DefaultController defaultController = new DefaultController();
            defaultController.PersonTable(person);
            //display();
            BindGrid();
            UpdatePanel2.Update();
                  
        }
        public void display()
        {
            //string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            //SqlConnection con = new SqlConnection(constring);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ToString();
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from Person";
            //cmd.Connection = con;
            //SqlDataReader rd = cmd.ExecuteReader();
            //table.Append("<table border='1'>");
            //table.Append("<tr><th>Name</th><th>Age</th>");
            //table.Append("</tr>");

            //if (rd.HasRows)
            //{
            //    while (rd.Read())
            //    {
            //        table.Append("<tr>");
            //        table.Append("<td>" + rd[0] + "<td>");
            //        table.Append("<td>" + rd[1] + "<td>");
            //        table.Append("<tr>");
            //    }
            //}
            //table.Append("</table>");
            //PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
            //rd.Close();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Name, Age FROM Person"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void btnReader(object sender, EventArgs e)
        {
            try
            {
                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = "select ID, Name, Age from Person ";
                List<string> list = new List<string>();
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
                            temp.Age = Convert.ToInt32(reader["Age"]);

                            list.Add(temp.Name);
                            
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