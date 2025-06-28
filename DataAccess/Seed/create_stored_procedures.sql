-- Drop procedures if they already exist
IF OBJECT_ID('dbo.AddEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.AddEmployee;
IF OBJECT_ID('dbo.UpdateEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.UpdateEmployee;
IF OBJECT_ID('dbo.DeleteEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.DeleteEmployee;
IF OBJECT_ID('dbo.GetAllEmployees', 'P') IS NOT NULL DROP PROCEDURE dbo.GetAllEmployees;
IF OBJECT_ID('dbo.AuthenticateUser', 'P') IS NOT NULL DROP PROCEDURE dbo.AuthenticateUser;

-- Stored Procedure: Add Employee
CREATE PROCEDURE AddEmployee
    @name VARCHAR(100),
    @username VARCHAR(50),
    @password VARCHAR(255),
    @role VARCHAR(50)
AS
BEGIN
    INSERT INTO employees (name, username, password, role)
    VALUES (@name, @username, @password, @role);
END;
GO

-- Stored Procedure: Update Employee
CREATE PROCEDURE UpdateEmployee
    @id INT,
    @name VARCHAR(100),
    @username VARCHAR(50),
    @password VARCHAR(255),
    @role VARCHAR(50)
AS
BEGIN
    UPDATE employees
    SET name = @name, username = @username, password = @password, role = @role
    WHERE id = @id;
END;
GO

-- Stored Procedure: Delete Employee
CREATE PROCEDURE DeleteEmployee
    @id INT
AS
BEGIN
    DELETE FROM employees WHERE id = @id;
END;
GO

-- Stored Procedure: Get All Employees
CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT id, name, username, role FROM employees;
END;
GO

-- Stored Procedure: Get authenticated user
CREATE PROCEDURE AuthenticateUser
    @username VARCHAR(50),
    @password VARCHAR(255)
AS
BEGIN
    SELECT id, name, username, role
    FROM employees
    WHERE username = @username AND password = @password;
END;
GO
