using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ViewGradeReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Call a method to populate the grade report data
            PopulateGradeReportData();
            PopulateSemesterComparisonData();
        }
    }

    protected void PopulateGradeReportData()
    {
        // Retrieve the student's grade report from the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Assuming you have a table named "GradeReport" with the required columns
                string query = "SELECT CourseName, Grade FROM GradeReport WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set the parameter value to the current student's ID
                    command.Parameters.AddWithValue("@StudentID", GetCurrentStudentID());

                    // Execute the query and retrieve the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the data to the repeater control for displaying the grade report
                        gradeRepeater.DataSource = dataTable;
                        gradeRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during database retrieval
                // Display an error message or log the exception
            }
        }
    }

    protected void PopulateSemesterComparisonData()
    {
        // Retrieve the student's semester-wise comparison data from the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Assuming you have a table named "SemesterComparison" with the required columns
                string query = "SELECT SemesterName, GPA FROM SemesterComparison WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set the parameter value to the current student's ID
                    command.Parameters.AddWithValue("@StudentID", GetCurrentStudentID());

                    // Execute the query and retrieve the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the data to the repeater control for displaying the semester-wise comparison
                        semesterComparisonRepeater.DataSource = dataTable;
                        semesterComparisonRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during database retrieval
                // Display an error message or log the exception
            }
        }
    }

    protected int GetCurrentStudentID()
    {
        // Implement your logic to get the current student's ID
        // You can retrieve it from a session variable or any other source
        // For example:
        return Convert.ToInt32(Session["StudentID"]);
    }

    protected void PrintButton_Click(object sender, EventArgs e)
    {
        // Implement the logic to generate and print the grade report
        // You can use libraries or frameworks to generate a PDF or print-friendly version of the report
        // You can also provide a print button that invokes the browser's print functionality
        // For example:
        ClientScript.RegisterStartupScript(this.GetType(), "print", "<script type='text/javascript'>window.print();</script>");
    }
}
