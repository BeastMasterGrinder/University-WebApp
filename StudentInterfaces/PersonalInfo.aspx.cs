using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class UpdatePersonalInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Populate the form fields with the student's information
            PopulateStudentInfo();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Get the updated contact information from the form
        string contact = txtContact.Text.Trim();

        // Get the student's registration number from the query string
        string regNumber = Request.QueryString["regNumber"];

        // Update the contact information in the database
        UpdateContactInfo(regNumber, contact);

        // Redirect the user back to the view page
        Response.Redirect("ViewPersonalInfo.aspx");
    }

    private void PopulateStudentInfo()
    {
        // Get the student's registration number from the query string
        string regNumber = Request.QueryString["regNumber"];

        // Fetch the student's information from the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Name, Batch, CurrentSemester, Contact FROM Students WHERE RegistrationNumber = @RegNumber";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RegNumber", regNumber);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Populate the form fields with the student's information
                    txtName.Text = reader["Name"].ToString();
                    txtBatch.Text = reader["Batch"].ToString();
                    txtCurrentSemester.Text = reader["CurrentSemester"].ToString();
                    txtContact.Text = reader["Contact"].ToString();
                }
                reader.Close();
            }
        }
    }

    private void UpdateContactInfo(string regNumber, string contact)
    {
        // Update the contact information in the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Students SET Contact = @Contact WHERE RegistrationNumber = @RegNumber";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Contact", contact);
                command.Parameters.AddWithValue("@RegNumber", regNumber);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
/*
In this backend file, we have a Page_Load event handler that is executed when the page is loaded. Inside this event handler, we call the PopulateStudentInfo method to retrieve the student's information from the database and populate the form fields with the fetched values.

The btnUpdate_Click event handler is executed when the user clicks the "Update" button. Inside this event handler, we get the updated contact information from the form and the student's registration number from the query string. We then call the UpdateContactInfo method to update the contact information in the database.

Make sure to replace "YourConnectionString" with the actual connection string to your database. Also, adjust the table and column names in the SQL queries to match your database schema.

Note: This is a basic example, and you may need to implement additional error handling, input validation, and security measures based on your specific requirements.
 */