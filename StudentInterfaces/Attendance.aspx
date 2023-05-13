<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAttendance.aspx.cs" Inherits="ViewAttendance" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View and Update Attendance</title>
    <style>
        /* Add your CSS styling here */
        body {
            font-family: Arial, sans-serif;
        }
        
        h2 {
            color: #333;
        }
        
        .attendance-table {
            width: 100%;
            border-collapse: collapse;
        }
        
        .attendance-table th, .attendance-table td {
            padding: 10px;
            text-align: center;
            border-bottom: 1px solid #ccc;
        }
        
        .attendance-table th {
            background-color: #f2f2f2;
            font-weight: bold;
        }
        
        .attendance-table tr:hover {
            background-color: #f9f9f9;
        }
        
        .attendance-table .present {
            color: green;
            font-weight: bold;
        }
        
        .attendance-table .absent {
            color: red;
            font-weight: bold;
        }
        
        .update-btn {
            padding: 5px 10px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        
        .update-btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>View and Update Attendance</h2>
            <table class="attendance-table">
                <tr>
                    <th>Course Name</th>
                    <th>Date</th>
                    <th>Status</th>
                    <th>Action</th>
                </tr>
                <asp:Repeater ID="attendanceRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("CourseName") %></td>
                            <td><%# Eval("AttendanceDate", "{0:MM/dd/yyyy}") %></td>
                            <td>
                                <%# Eval("Status") == "Present" ? "<span class='present'>Present</span>" : "<span class='absent'>Absent</span>" %>
                            </td>
                            <td>
                                <asp:Button ID="updateButton" runat="server" CssClass="update-btn" Text="Update" CommandArgument='<%# Eval("AttendanceID") %>' OnClick="UpdateAttendance" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
