using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Xml.Linq;
using OfficeOpenXml;
using System.Data.Common;
using System.Web.UI.WebControls.WebParts;




namespace CRUD
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!IsPostBack)
            {
                BindGrid();

            }
        }
        protected void ButtonOne(object sender, EventArgs e)
        {
            try
            {
                Person person = new Person();
                person.Name = TextBox1.Text.ToString();
                person.Age = int.Parse(TextBox2.Text);
                person.Address = TextBox3.Text.ToString();
                person.Email = TextBox4.Text.ToString();

                string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                string query = $"insert into Person (Name, Age,Address,Email) values (@Name,@Age,@Address,@Email)";
                //insert
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;
                
                    cmd.Parameters.AddWithValue("@Name", TextBox1.Text.ToString());
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(TextBox2.Text));
                    cmd.Parameters.AddWithValue("@Address", TextBox3.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", TextBox4.Text.ToString());
                    cmd.ExecuteNonQuery();
                }
                
                BindGrid();
                UpdatePanel1.Update();
                appear.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
   

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row to edit mode
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid(); // Rebind the GridView data
            UpdatePanel1.Update();


        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            GridViewRow row = GridView1.Rows[e.RowIndex];
          
            TextBox txtName = (TextBox)row.FindControl("TextBoxName");
            TextBox txtAge = (TextBox)row.FindControl("TextBoxAge");
            TextBox txtAddress = (TextBox)row.FindControl("TextBoxAddress");
            TextBox txtEmail = (TextBox)row.FindControl("TextBoxEmail");

            string updatedName = txtName.Text;
            string updatedAge = txtAge.Text;
            string updatedAddress = txtAddress.Text;
            string updatedEmail = txtEmail.Text;

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            
            string constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = "UPDATE Person SET Name = @Name, Age = @Age, Address = @Address, Email = @Email WHERE ID = @ID";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", updatedName);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Age", updatedAge);
                cmd.Parameters.AddWithValue("@Address", updatedAddress);
                cmd.Parameters.AddWithValue("@Email", updatedEmail);
                cmd.ExecuteNonQuery();

            }
            // Reset edit mode
            GridView1.EditIndex = -1;
            BindGrid(); // Rebind the GridView to refresh data
            UpdatePanel1.Update();


        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            GridView1.EditIndex = -1;
            BindGrid(); // Rebind the GridView data
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            String constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = $"DELETE FROM Person WHERE ID = @ID";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
            BindGrid();
            UpdatePanel1.Update();

            BindGrid();
        }

        private void BindGrid()
        {
            String constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Person"))
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
        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    // Bind the GridView to data before exporting
        //    BindGrid();

        //    // Create a StringWriter to hold the CSV data
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
            
        //    // Render GridView to HtmlTextWriter (for easy export)
        //    GridView1.RenderControl(htw);

        //    // Get the rendered HTML content of GridView
        //    string gridHtml = sw.ToString();

        //    // Convert the HTML table to CSV format
        //    string csvData = ConvertHtmlToCsv(gridHtml);

        //    // Set the response headers for CSV download
        //    Response.Clear();
        //    Response.ContentType = "text/csv";
        //    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv");

        //    // Write CSV data to the response
        //    Response.Write(csvData);

        //    // Flush the response and end the request without causing lifecycle issues
        //    Response.Flush();
        //    Response.SuppressContent = true;  // To prevent the rest of the page from being sent

        //    // Ensure that no further processing is done on the page.
        //    Context.ApplicationInstance.CompleteRequest();
        //}


        // Override the VerifyRenderingInServerForm method
        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    // Required for GridView rendering during export
        //    if (control is GridView)
        //    {
        //        // Allow the GridView to be rendered for export
        //    }
        //}




        //private string ConvertHtmlToCsv(string html)
        //{
        //    string csv = string.Empty;

            
        //    var rows = html.Split(new string[] { "<tr>" }, StringSplitOptions.None);
        //    foreach (var row in rows)
        //    {
        //        if (row.Contains("<td>"))
        //        {
        //            var cells = row.Split(new string[] { "<td>" }, StringSplitOptions.None);
        //            foreach (var cell in cells)
        //            {
        //                if (cell.Contains("</td>"))
        //                {
        //                    var cellValue = cell.Split(new string[] { "</td>" }, StringSplitOptions.None)[0];
        //                    csv += cellValue.Replace("&nbsp;", "").Trim() + ",";
        //                }
        //            }
        //            csv = csv.TrimEnd(',') + Environment.NewLine;
        //        }
        //    }

        //    return csv;
        //}

        // Method to get data from the database and bind to the GridView
        private DataTable GetDatabaseData()


        {
            String constring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            DataTable dt = new DataTable();


            string query = "SELECT [Name] FROM Person";

            // Use SqlConnection to connect to the database
            using (SqlConnection connection = new SqlConnection(constring))
            {
                // Create a SqlDataAdapter to execute the query and fill the DataTable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                try
                {
                    // Open the connection (optional, as SqlDataAdapter opens automatically when needed)
                    connection.Open();

                    // Fill the DataTable with the data from the query
                    dataAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., connection issues, SQL errors)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            // Return the populated DataTable
            return dt;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Update the GridView's PageIndex to the new page
            GridView1.PageIndex = e.NewPageIndex;

            // Rebind the data to the GridView to reflect the new page
            BindGrid();
        }
        protected void add_Click(object sender, EventArgs e)
        {
            appear.Visible = true;
            UpdatePanel2.Update();
        }


        protected void ExportData_Click(object sender, EventArgs e)
        {

            #region comment
            //String sql = "SELECT * FROM TABLE";
            //SqlCommand command = new SqlCommand(sql, dbConnection);
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet);
            //DataTable dt = dataSet.Tables[0];

            //// Loop through rows
            //foreach (DataRow row in dt.Rows)
            //{
            //    // Loop through columns
            //    foreach (DataColumn column in dt.Columns)
            //    {

            //    }
            #endregion

            var dt = GetDatabaseData();
          

            string timestamp = DateTime.Now.ToString("MM-dd-yyyy HH-mm");
            string filename = $"Sample_Export_{timestamp}.xlsx";

            using (ExcelPackage pack = new ExcelPackage())
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.Add("ExportedData");
                ws.Cells["A1"].LoadFromDataTable(dt, true);

                //using (var range = ws.Cells[1, 1, 1, dt.Columns.Count])
                //{
                //    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#244494"));
                //    range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                //}


                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                //Response.Clear();
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("content-disposition", $"attachment;filename={filename}");
                //Response.BinaryWrite(pack.GetAsByteArray());
                //Response.End();


                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                string filePath = Path.Combine(downloadsPath, filename);
                FileInfo fileInfo = new FileInfo(filePath);
                pack.SaveAs(fileInfo);
            }
        }

        // Override the Render method for GridView

    }
}