using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ViewEvaluationMarks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Call a method to populate the evaluation marks data
            PopulateEvaluationMarksData();
        }
    }

    protected void PopulateEvaluationMarksData()
    {
        // Retrieve the student's evaluation marks from the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Assuming you have a table named "EvaluationMarks" with the required columns
                string query = "SELECT EvaluationID, CourseName, EvaluationType, MarksObtained FROM EvaluationMarks WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set the parameter value to the current student's ID
                    command.Parameters.AddWithValue("@StudentID", GetCurrentStudentID());

                    // Execute the query and retrieve the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the data to the repeater control for displaying the evaluation marks
                        evaluationRepeater.DataSource = dataTable;
                        evaluationRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during database access
                // Display an error message to the user or log the error
            }
        }
    }

    protected void SubmitMarks(object sender, CommandEventArgs e)
    {
        // Get the EvaluationID and marks entered by the student
        int evaluationID = Convert.ToInt32(e.CommandArgument);
        TextBox marksTextBox = (TextBox)((Button)sender).Parent.FindControl("marksTextBox");
        int marksObtained = Convert.ToInt32(marksTextBox.Text);

        // Update the marks in the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Assuming you have a table named "EvaluationMarks" with a primary key column "EvaluationID" and a column "MarksObtained"
                string query = "UPDATE EvaluationMarks SET MarksObtained = @MarksObtained WHERE EvaluationID = @EvaluationID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MarksObtained", marksObtained);
                    command.Parameters.AddWithValue("@EvaluationID", evaluationID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during database access
                // Display an error message to the user or log the error
            }
        }
    }

    protected int GetCurrentStudentID()
    {
        // Implement the logic to retrieve the current student's ID
        // This can be based on the user's authentication or session information
        // Return the student ID
    }
}
