-- Drop tables if they already exist
IF OBJECT_ID('dbo.invoices', 'U') IS NOT NULL DROP TABLE dbo.invoices;
IF OBJECT_ID('dbo.water_consumption', 'U') IS NOT NULL DROP TABLE dbo.water_consumption;
IF OBJECT_ID('dbo.customers', 'U') IS NOT NULL DROP TABLE dbo.customers;
IF OBJECT_ID('dbo.employees', 'U') IS NOT NULL DROP TABLE dbo.employees;

-- Create Employees Table
CREATE TABLE employees (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL
);
GO

-- Create Customers Table
CREATE TABLE customers (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    water_meter_code VARCHAR(50) UNIQUE NOT NULL,
    created_by INT NOT NULL,
    FOREIGN KEY (created_by) REFERENCES employees(id) ON DELETE SET NULL
);
GO

-- Create Water Consumption Table
CREATE TABLE water_consumption (
    id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT NOT NULL,
    recorded_month INT CHECK (recorded_month BETWEEN 1 AND 12),
    recorded_year INT,
    value DECIMAL(10,2) NOT NULL,
    recorded_by INT NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(id) ON DELETE CASCADE,
    FOREIGN KEY (recorded_by) REFERENCES employees(id) ON DELETE SET NULL
);
GO

-- Create Invoices Table
CREATE TABLE invoices (
    id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT NOT NULL,
    collect_month INT CHECK (collect_month BETWEEN 1 AND 12),
    collect_year INT,
    consumption_amount DECIMAL(10,2) NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    status VARCHAR(20) CHECK (status IN ('Pending', 'Paid')) DEFAULT 'Pending',
    created_by INT NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(id) ON DELETE CASCADE,
    FOREIGN KEY (created_by) REFERENCES employees(id) ON DELETE SET NULL
);
GO
