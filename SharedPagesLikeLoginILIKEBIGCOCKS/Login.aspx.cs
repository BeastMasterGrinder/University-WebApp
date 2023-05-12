using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string role = ddlRole.SelectedValue;

        // Assuming you have a connection string named "ConnectionString" in your web.config file
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Perform the login validation
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Role", role);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                // Login successful
                Response.Redirect("Welcome.aspx"); // Redirect to the welcome page
            }
            else
            {
                // Invalid login
                lblMessage.Text = "Invalid username, password, or role.";
                lblMessage.Visible = true;
            }
        }
    }
}
