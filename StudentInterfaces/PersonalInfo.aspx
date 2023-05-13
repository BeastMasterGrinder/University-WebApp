<!DOCTYPE html>
<html>
<head>
    <title>View Personal Information</title>
    <style>
        /* Add some basic styling */
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        input[type="text"],
        input[type="email"] {
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>View Personal Information</h2>
        <form method="post" action="UpdatePersonalInfo.aspx">
            <label for="txtName">Name:</label>
            <input type="text" id="txtName" name="txtName" readonly />

            <label for="txtRegNumber">Registration Number:</label>
            <input type="text" id="txtRegNumber" name="txtRegNumber" readonly />

            <label for="txtBatch">Batch:</label>
            <input type="text" id="txtBatch" name="txtBatch" readonly />

            <label for="txtCurrentSemester">Current Semester:</label>
            <input type="text" id="txtCurrentSemester" name="txtCurrentSemester" readonly />

            <label for="txtContact">Contact:</label>
            <input type="text" id="txtContact" name="txtContact" />

            <input type="submit" value="Update" />
        </form>
    </div>
</body>
</html>
