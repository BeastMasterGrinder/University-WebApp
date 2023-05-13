<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGradeReport.aspx.cs" Inherits="YourNamespace.ViewGradeReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Grade Report</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <h1>Grade Report</h1>

        <div class="grade-report">
            <div class="header">
                <div class="column">Course Name</div>
                <div class="column">Grade</div>
            </div>
            <asp:Repeater ID="gradeRepeater" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="column"><%# Eval("CourseName") %></div>
                        <div class="column"><%# Eval("Grade") %></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="cgpa-container">
                <div class="cgpa-label">CGPA:</div>
                <div class="cgpa-value"><%# Eval("CGPA") %></div>
            </div>

            <div class="semester-comparison">
                <h2>Semester-wise Comparison</h2>
                <asp:Repeater ID="semesterComparisonRepeater" runat="server">
                    <ItemTemplate>
                        <div class="semester-row">
                            <div class="semester-name"><%# Eval("SemesterName") %></div>
                            <div class="semester-gpa"><%# Eval("GPA") %></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="print-button-container">
                <asp:Button ID="printButton" runat="server" Text="Print" OnClick="PrintButton_Click" />
            </div>
        </div>
    </div>
</body>
</html>
