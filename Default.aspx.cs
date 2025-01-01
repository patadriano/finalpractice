using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealCrud.Controller;

namespace RealCrud
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGrid();
                
            }


        }
        //protected void EditButton_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    GridViewRow row = (GridViewRow)btn.NamingContainer;
        //    int rowIndex = row.RowIndex;
        //    // Use rowIndex to identify the clicked row and proceed with logic
        //    Edit(rowIndex);

        //}
        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    GridViewRow row = (GridViewRow)btn.NamingContainer;
        //    int rowIndex = row.RowIndex;
        //    // Use rowIndex to identify the clicked row and proceed with logic
        //    Delete(rowIndex);
        //}

        //private void Edit(int rowIndex){

            
        //}
        private void Delete(int rowIndex)
        {
            String constring = "Data Source =.\\sqlexpress; Initial Catalog = Practice; Integrated Security = True; Encrypt = False";
            string query = $"DELETE FROM Person WHERE ID = {rowIndex+1}";

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row to edit mode
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid(); // Rebind the GridView data
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the row that is being edited
            GridViewRow row = GridView1.Rows[e.RowIndex];

            // Find the TextBox control inside the row
            TextBox txtName = (TextBox)row.FindControl("TextBox1");

            // Check if the TextBox was found
            
                // Get the updated name from the TextBox
                string updatedName = txtName.Text;

                // Get the ID from the DataKey (make sure DataKeyNames is set in your GridView)
                int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                // Proceed with your update logic
                string constring = "Data Source =.\\sqlexpress; Initial Catalog = Practice; Integrated Security = True; Encrypt = False";
                string query = "UPDATE Person SET Name = @Name WHERE ID = @ID";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", updatedName);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }

                // Reset edit mode
                GridView1.EditIndex = -1;
                BindGrid(); // Rebind the GridView to refresh data
            
          
        }



        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            GridView1.EditIndex = -1;
            BindGrid(); // Rebind the GridView data
        }



        private void BindGrid()
        {
            String constring = "Data Source =.\\sqlexpress; Initial Catalog = Practice; Integrated Security = True; Encrypt = False";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Person"))
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

    }
}