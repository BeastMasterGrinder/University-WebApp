using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class CourseRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Clear any previous course registration selections
            ClearCourseSelection();
        }
    }

    protected void SearchCourse()
    {
        string courseCode = txtSearch.Value.Trim();

        // Fetch the course details from the database
        DataTable dtCourseDetails = GetCourseDetails(courseCode);

        // Populate the course details section
        PopulateCourseDetails(dtCourseDetails);

        // Fetch the available sections for the course
        DataTable dtSections = GetAvailableSections(courseCode);

        // Populate the section selection
        PopulateSectionSelection(dtSections);
    }

    protected void RegisterCourses()
    {
        // Retrieve the selected course and section information
        string courseCode = txtCourseCode.Value.Trim();
        int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
        // Additional code to handle course registration
    }

    protected void DropCourses()
    {
        // Retrieve the selected course and section information
        string courseCode = txtCourseCode.Value.Trim();
        int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
        // Additional code to handle course dropping
    }

    private DataTable GetCourseDetails(string courseCode)
    {
        // Fetch the course
