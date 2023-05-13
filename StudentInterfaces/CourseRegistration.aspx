<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="CourseRegistration" %>

<!DOCTYPE html>
<html>
<head>
    <title>Course Registration</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        h2 {
            color: #333;
        }

        .container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input[type="text"],
        .form-group input[type="submit"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-group input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            cursor: pointer;
        }

        #courseDetails,
        #sectionSelection {
            margin-top: 20px;
        }

        .course-info,
        .section-info {
            margin-bottom: 10px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .course-info h3,
        .section-info h3 {
            margin-top: 0;
            margin-bottom: 10px;
            color: #333;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>Course Registration</h2>
        <div class="form-group">
            <label for="txtSearch">Search Course:</label>
            <input type="text" id="txtSearch" runat="server" />
            <input type="submit" id="btnSearch" runat="server" value="Search" onclick="SearchCourse()" />
        </div>
        <div id="courseDetails" runat="server">
            <!-- Course details will be dynamically populated here -->
        </div>
        <div id="sectionSelection" runat="server">
            <!-- Section selection will be dynamically populated here -->
        </div>
        <div>
            <input type="submit" id="btnRegister" runat="server" value="Register" onclick="RegisterCourses()" />
            <input type="submit" id="btnDrop" runat="server" value="Drop" onclick="DropCourses()" />
        </div>
    </div>
    <script src="scripts.js"></script>
</body>
</html>
