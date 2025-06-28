-- Drop tables if they already exist
IF OBJECT_ID('dbo.employees', 'U') IS NOT NULL DROP TABLE dbo.employees;
GO

-- Create Employees Table
CREATE TABLE employees (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL
);
GO

SET IDENTITY_INSERT employees ON;

INSERT INTO employees (id, name, username, password, role)
VALUES
(1, 'Admin', 'admin', 'admin123', 'Manager'),
(2, 'Nhân viên A', 'nva', 'password1', 'Staff'),
(3, 'Nhân viên B', 'nvb', 'password2', 'Staff');

SET IDENTITY_INSERT employees OFF;