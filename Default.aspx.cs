using SimpleCRUD.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace SimpleCRUD
{
    public partial class _Default : Page
    {
        protected void updateddl()
        {
            List<Group> ddlGroupList = new List<Group>();
                            String constring = "Data Source =.\\sqlexpress; Initial Catalog = Practice; Integrated Security = True; Encrypt = False";
                            string query = "select * from [Group]";
                            using (SqlConnection con = new SqlConnection(constring))
                            {
                                con.Open();
                                using (SqlCommand cmd = new SqlCommand(query,con))
                                {
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            Group temp = new Group();
                                            temp.ID = Convert.ToInt32(reader["ID"]);
                                            temp.Name = reader["Name"].ToString();
                                            ddlGroupList.Add(temp);
                                        }
                                    }
                                }  
                            }
                            ddlGroup.DataSource = ddlGroupList;
                            ddlGroup.DataTextField = "Name";
                            ddlGroup.DataValueField = "ID";
                            ddlGroup.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                updateddl();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = ddlGroup.SelectedIndex;
            Person person = new Person();
            person.Name = TextBox1.Text;
            

            //DefaultController defaultController = new DefaultController();
            //defaultController.PersonTable(person);

            String constring = "Data Source =.\\sqlexpress; Initial Catalog = Practice; Integrated Security = True; Encrypt = False";
            String query = $"insert into Person (Name, GroupID) values ('{person.Name}',{selectedIndex+1})";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Group grp = new Group();
            grp.Name = TextBox3.Text;
            //DefaultController defaultController = new DefaultController();
            //defaultController.PersonTable(person);
            String constring = "Data Source =.\\sqlexpress; Initial Catalog = Practice; Integrated Security = True; Encrypt = False";
            string query = $"INSERT INTO [Group] (Name) VALUES ('{grp.Name}')";

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            updateddl();
            UpdatePanel2.Update();
        }
    }
}