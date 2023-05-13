using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Call a method to populate the attendance data
            PopulateAttendanceData();
        }
    }

    protected void PopulateAttendanceData()
    {
        // Retrieve the student's attendance records from the database
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Assuming you have a table named "Attendance" with the required columns
                string query = "SELECT CourseName, AttendanceDate, Status, AttendanceID FROM Attendance WHERE StudentID = @StudentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set the parameter value to the current student's ID
                    command.Parameters.AddWithValue("@StudentID", GetCurrentStudentID());

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable attendanceTable = new DataTable();
                        adapter.Fill(attendanceTable);

                        // Bind the attendance data to the repeater control
                        attendanceRepeater.DataSource = attendanceTable;
                        attendanceRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                // Display an error message or perform error logging
            }
        }
    }

    protected void UpdateAttendance(object sender, EventArgs e)
    {
        // Retrieve the AttendanceID from the clicked button's CommandArgument
        Button updateButton = (Button)sender;
        int attendanceID = Convert.ToInt32(updateButton.CommandArgument);

        // Perform the logic to update the attendance record in the database
        // You can retrieve the student's ID, update the attendance status, etc.

        // Refresh the attendance data after updating
        PopulateAttendanceData();
    }

    protected int GetCurrentStudentID()
    {
        // Retrieve the current student's ID based on the logged-in user or session
        // Replace this with your actual logic to get the student ID
        int studentID = 123; // Example value, replace with your own implementation

        return studentID;
    }
}
