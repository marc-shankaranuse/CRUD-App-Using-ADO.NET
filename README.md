# CRUD-App-Using-ADO.NET
This is a CRUD (Create, Read, Update, Delete) Web API Application built using ADO.NET and SQL Server.
📌 Description

This is a CRUD (Create, Read, Update, Delete) Web API Application built using ADO.NET and SQL Server. The application allows users to manage student or employee records through RESTful API endpoints. The backend is developed using ASP.NET Core, where ADO.NET is used to interact with the database via stored procedures. The frontend (if applicable) includes a table-based UI where users can view, edit, and delete records.

🚀 Features
Create a new student/employee using POST method.
Retrieve all students/employees using GET method.
Retrieve a particular student/employee by ID.
Update an existing student/employee using PUT method.
Delete a student/employee using DELETE method.
Database integration using ADO.NET and SQL Server Stored Procedures.
DbContext-based implementation for efficient database management.

🏗️ Technologies Used
C# (ASP.NET Core)
ADO.NET (for database connectivity)
SQL Server (with stored procedures)
Entity Framework Core (DbContext)
Swagger UI (for API testing)
---============================================================================================================================================
📂 Project Structure
CRUD-ADO.NET-API/
│── Controllers/
│   ├── HomeController.cs
│── DataAccess/
│   ├── DatabaseHelper.cs
│── Models/
│   ├── Employees.cs
│   ├── ErrorViewModel.cs
│── Views/
│   ├── Create.cshtml
│   ├── Delete.cshtml
│   ├── Details.cshtml
│   ├── Edit.cshtml
│   ├── Index.cshtml
│   ├── Privacy.cshtml
│── StoredProcedures.sql
│── ConnectionString.cs
│   ├── ConnectionString
│       ├── cs : string
│       ├── dbcs : string
│── EmployeeDataAccessLayer.cs
│   ├── EmployeeDataAccessLayer
│       ├── cs : string
│       ├── getAllEmployees() : List<Employees>
│       ├── getEmployeeByID(int? id) : Employees
│       ├── AddEmployee(Employees emp) : void
│       ├── UpdateEmployee(Employees emp) : void
│       ├── DeleteEmployee(int? id) : void
│── Program.cs
│── appsettings.json
│── README.md
![image](https://github.com/user-attachments/assets/042cf201-6141-4dde-886b-f0eea9e126c9)
--============================================================================================================================================================

2️⃣ Setup SQL Server Database
Create a SQL Server Database (e.g., CrudADODB)
Execute the StoredProcedures.sql file to create tables and stored procedures.

Update the connection string in appsettings.json.

"ConnectionStrings": {
  "dbcs": "Server=MARCUS-LAPTOP\\SQLEXPRESS; Database=CrudADOdb; Trusted_Connection=True; TrustServerCertificate=True;"
}

3️⃣ Run the Application
dotnet run
--=======================================================================================================================================================
📌 API Endpoints
🔹 Create a New Student (POST)
POST /api/student
Request Body:
{
  "Name": "John Doe",
  "Age": 22,
  "Course": "Computer Science"
}

🔹 Get All Students (GET)
GET /api/student

🔹 Get a Student by ID (GET)
GET /api/student/{id}

🔹 Update Student (PUT)
PUT /api/student/{id}
Request Body:
{
  "Name": "John Doe Updated",
  "Age": 23,
  "Course": "Data Science"
}

🔹 Delete Student (DELETE)
DELETE /api/student/{id}
--====================================================================================================================================================
--creating database for CRUD APP
CREATE DATABASE CrudADOdb;
use CrudADOdb;
--creating table name Employees
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Gender VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	Designation VARCHAR(50) NOT NULL,
	City VARCHAR(50) NOT NULL
);

--===================================
📊 Database: Stored Procedures
CREATE PROCEDURE GetAllStudents
AS
BEGIN
    SELECT * FROM Students
END
CREATE PROCEDURE InsertStudent
    @Name NVARCHAR(100),
    @Age INT,
    @Course NVARCHAR(100)
AS
BEGIN
    INSERT INTO Students (Name, Age, Course) VALUES (@Name, @Age, @Course)
END
--=============
GO  --use to write or executes stored procedures in separate or alone execution batch
					-- Stored Procedures  for CRUD Operations ---
-- creating a procedure to add new employee (HttpPost method )
CREATE PROCEDURE spAddEmployee
(
	@Name VARCHAR(50),
	@Gender VARCHAR(50),
	@Age INT,
	@Designation VARCHAR(50),
	@City VARCHAR(50)
)
AS
BEGIN
	INSERT INTO Employees (Name, Gender, Age, Designation, City)
	VALUES (@Name, @Gender, @Age, @Designation, @City)
END


GO  
-- updating a  existing data or procedure, making some changes in employee (HttpPut method )
CREATE PROCEDURE spUpdateEmployee
(
	@Id INT,
	@Name VARCHAR(50),
	@Gender VARCHAR(50),
	@Age INT,
	@Designation VARCHAR(50),
	@City VARCHAR(50)
)
AS
BEGIN
	UPDATE Employees 
	SET
		Name = @Name,
		Gender = @Gender,
		Age =  @Age,
		Designation = @Designation, 
		City = @City
	WHERE Id = @Id
END


GO
-- Deleting a existing data or procedure or employee (HttpDelete method )
CREATE PROCEDURE spDeleteEmployee
(
	@Id INT
)
AS
BEGIN
	DELETE FROM Employees 
	WHERE Id = @Id
END



GO  
-- gets all students details and shows/displays on view or table (HttpGet method )
CREATE PROCEDURE spGetAllEmployee
AS
BEGIN
	SELECT * FROM Employees 
	ORDER BY Id
END

--================================================================================================================================
📌 Frontend Functionality 
Display a table with student/employee records.
Edit button: Opens a form to update details.
Delete button: Removes a record.
Add new button: Opens a form to add a new student.
