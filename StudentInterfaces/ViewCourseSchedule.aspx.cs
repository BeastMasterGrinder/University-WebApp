using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewCourseSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Load the course schedule for the logged-in student
            LoadCourseSchedule();
        }
    }

    protected void LoadCourseSchedule()
    {
        // Retrieve the student's enrolled courses and section details from the database
        string studentID = GetLoggedInStudentID(); // Retrieve the student's ID based on the current user session or authentication

        // Establish the database connection
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // SQL query to retrieve the course schedule for the student
            string query = "SELECT c.CourseName, s.SectionName, s.Timings, f.InstructorName " +
                           "FROM Courses c " +
                           "INNER JOIN Sections s ON c.CourseID = s.CourseID " +
                           "INNER JOIN CourseInstructors ci ON s.SectionID = ci.SectionID " +
                           "INNER JOIN Faculty f ON ci.FacultyID = f.FacultyID " +
                           "INNER JOIN StudentsSections ss ON s.SectionID = ss.SectionID " +
                           "WHERE ss.StudentID = @StudentID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);

                // Open the database connection
                connection.Open();

                // Execute the SQL query and retrieve the results
                SqlDataReader reader = command.ExecuteReader();

                // Iterate over the result set and populate the course schedule
                while (reader.Read())
                {
                    string courseName = reader["CourseName"].ToString();
                    string sectionName = reader["SectionName"].ToString();
                    string timings = reader["Timings"].ToString();
                    string instructorName = reader["InstructorName"].ToString();

                    // Create HTML elements dynamically and add them to the page
                    CreateCourseInfoElement(courseName, sectionName, timings, instructorName);
                }

                // Close the reader and the database connection
                reader.Close();
                connection.Close();
            }
        }
    }

    protected void CreateCourseInfoElement(string courseName, string sectionName, string timings, string instructorName)
    {
        // Create the HTML elements dynamically using Literal controls
        Literal courseInfoLiteral = new Literal();
        courseInfoLiteral.Text = "<div class='course-info'>" +
                                    "<h3>" + courseName + "</h3>" +
                                  "</div>";

        Literal sectionInfoLiteral = new Literal();
        sectionInfoLiteral.Text = "<div class='section-info'>" +
                                      "<h4>" + sectionName + "</h4>" +
                                      "<p>Timings: " + timings + "</p>" +
                                      "<p>Instructor: " + instructorName + "</p>" +
                                  "</div>";

        // Add the created elements to the appropriate container on the page
        courseInfoContainer.Controls.Add(courseInfoLiteral);
        sectionInfoContainer.Controls.Add(sectionInfoLiteral);
    }

    protected string GetLoggedInStudentID()
    {
        // Replace this with your own logic to retrieve the student's ID based on the current user session or authentication
        // For demonstration purposes, return a static student ID
        return "123456789";
    }
}
