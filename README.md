
# MVC_Web_Assignment

A college project where I built an ASP.NET MVC Web Application.

The application was built using Microsoft Visual Studio 2019 The database was built using Microsoft SQL Server Management Studio 18.

The application allows review and administration of the AdventureWorksOBP database.
The application can only be accessed by a registered user, therefore it uses the ASP.NET Identity framework which allows registration and login for users.
Based on their Authorization Role, the user has access to different functionalities.
The user with the Administrator Role can edit all data from different tables in the database.
Users that do not have the Administrator Role can only view data from database tables.
The application uses a variety of elements learnt during the Web Development course.
The elements used are as follows:
- jQuery DataTables for a detailed overview of all data from tables, with sorting
- AJAX Calls which deserialize JSON data fetched from the database (for certain tables only)
- HTML Helper Methods
- Partial Views
- Validation and Custom Validators
- Razor View Engine Mechanism
- Weakly Typed and Strongly Typed Views
- ViewData and ViewBag mechanisms
- Child Actions
- ASP.NET Identity

This repository contains two folders.

The Database folder contains two .sql files containing queries required for the application to work properly. The AWOBP.sql file contains queries used to initilize the database used in the application. The Procedures.sql file contains queries used to create stored procedures required for the application to work properly.

The MVCWebProject folder contains code for the application.
