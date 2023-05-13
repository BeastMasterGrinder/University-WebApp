<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCourseSchedule.aspx.cs" Inherits="ViewCourseSchedule" %>

<!DOCTYPE html>
<html>
<head>
    <title>View Course Schedule</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        h2 {
            color: #333;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }

        .course-info {
            margin-bottom: 20px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .course-info h3 {
            margin-top: 0;
            margin-bottom: 10px;
            color: #333;
        }

        .section-info {
            margin-bottom: 10px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .section-info h4 {
            margin-top: 0;
            margin-bottom: 5px;
            color: #333;
        }

        .section-info p {
            margin: 0;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>View Course Schedule</h2>
        <div>
            <!-- Course schedule will be dynamically populated here -->
            <div class="course-info">
                <h3>Course 1</h3>
                <div class="section-info">
                    <h4>Section A</h4>
                    <p>Timings: Monday, 9:00 AM - 11:00 AM</p>
                    <p>Instructor: John Doe</p>
                </div>
                <div class="section-info">
                    <h4>Section B</h4>
                    <p>Timings: Wednesday, 1:00 PM - 3:00 PM</p>
                    <p>Instructor: Jane Smith</p>
                </div>
            </div>
            <div class="course-info">
                <h3>Course 2</h3>
                <div class="section-info">
                    <h4>Section C</h4>
                    <p>Timings: Tuesday, 10:00 AM - 12:00 PM</p>
                    <p>Instructor: Bob Johnson</p>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
