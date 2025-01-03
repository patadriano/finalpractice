using Microsoft.Ajax.Utilities;
using PatExam.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace PatExam
{
	public partial class _Default : Page
	{
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                //if (Cache["Team"] == null)
                //{

                //	Cache["Team"] = new List<Team>();
                //}
                
                updateddl();

                
			}
		}

		private void updateddl()
        {

            List<Team> ddlTeamList = new List<Team>();
            String constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString; ;
            string query = "select * from Team";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Team temp = new Team();

                            temp.Name = reader["Name"].ToString();
                            ddlTeamList.Add(temp);
                        }
                    }
                }
            }
            ddlTeam.DataSource = ddlTeamList;
            ddlTeam.DataTextField = "Name";
            ddlTeam.DataValueField = "Name";
            ddlTeam.DataBind();

            List<Department> ddlDeptList = new List<Department>();

            string query2 = "select * from Department";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query2, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department temp2 = new Department();

                            temp2.Name = reader["Name"].ToString();
                            ddlDeptList.Add(temp2);
                        }
                    }
                }
            }

            ddlDept.DataSource = ddlDeptList;
            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "Name";
            ddlDept.DataBind();
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
		{
            Employee deptHead = new Employee();
            deptHead.Name = txtDeptHead.Text; 

            Department dept = new Department();
            dept.Name = txtDeptName.Text;
            dept.DeptHead = deptHead;  



            string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = $"insert into Department (Name) values ('{dept.Name}')";
            //insert
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            updateddl();
            updTeam.Update();
        }

        protected void btnAddTeam_Click(object sender, EventArgs e)
        {
            int selectedIndex = ddlDept.SelectedIndex;
            bindgrid(selectedIndex);
            UpdatePanel4.Update();

            Team team = new Team();
			Employee teamLead = new Employee();
			
			team.Name = txtTeamName.Text;

   //         teamLead.Name = txtTeamLead.Text;

			//string deptname = txtDeptNameTeam.Text;

   //         team.TeamLead = teamLead;

            string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = $"insert into Team (Name, DeptID) values ('{team.Name}', {selectedIndex+1})";
            //insert
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            updateddl();
            UpdatePanel1.Update();


            // ((List<Team>)Cache["Team"]).Add(team);


        }
			
			
        protected void btnAddMember_Click(object sender, EventArgs e)
		{
            int selectedIndex = ddlTeam.SelectedIndex;
            bindgrid2(selectedIndex);
            UpdatePanel6.Update();

            //TextBox3.Text
            Employee emp = new Employee();
			emp.Name = txtName.Text;

            string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = $"insert into Employee (Name, TeamID) values ('{emp.Name}', {selectedIndex + 1})";
            //insert
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
        }
        protected void ddlTeamFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected team ID from DropDownList
            int selectedTeamId = ddlDept.SelectedIndex;

            // Bind the GridView with the selected team data
            bindgrid(selectedTeamId);
            UpdatePanel4.Update();

        }
        protected void ddlTeamFilter_SelectedIndexChanged2(object sender, EventArgs e)
        {
            
             int selectedTeamId = ddlTeam.SelectedIndex;

          
            bindgrid2(selectedTeamId);
            UpdatePanel6.Update();
        }

        private void bindgrid(int selectedIndex)
        {

            List<Team> ddlTeamList = new List<Team>();
            String constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = $"select * from Team where DeptID = {selectedIndex + 1}";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Bind the SqlDataReader to the GridView
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }
                    }
                }
            }

        }
        private void bindgrid2(int selectedIndex) { 
            List<Department> ddlDeptList = new List<Department>();
            String constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString; ;
            string query2 = $"select * from Employee where TeamID = {selectedIndex + 1}"; ;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query2, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Bind the SqlDataReader to the GridView
                            GridView2.DataSource = reader;
                            GridView2.DataBind();
                        }
                    }
                }
            }

        

        }

	}
}