<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEvaluationMarks.aspx.cs" Inherits="YourNamespace.ViewEvaluationMarks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>View and Submit Evaluation Marks</title>
    <style>
        /* CSS styles for the page */
        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        th, td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        th {
            background-color: #f2f2f2;
        }

        .submit-btn {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            cursor: pointer;
        }

        .submit-btn:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>View and Submit Evaluation Marks</h2>

        <table>
            <tr>
                <th>Course</th>
                <th>Evaluation Type</th>
                <th>Marks Obtained</th>
                <th>Submit Marks</th>
            </tr>
            <asp:Repeater ID="evaluationRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CourseName") %></td>
                        <td><%# Eval("EvaluationType") %></td>
                        <td><%# Eval("MarksObtained") %></td>
                        <td>
                            <asp:TextBox ID="marksTextBox" runat="server"></asp:TextBox>
                            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="submit-btn"
                                CommandName="SubmitMarks" CommandArgument='<%# Eval("EvaluationID") %>' OnCommand="SubmitMarks" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</body>
</html>
