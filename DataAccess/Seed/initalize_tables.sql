-- Drop tables if they already exist
IF OBJECT_ID('dbo.invoices', 'U') IS NOT NULL DROP TABLE dbo.invoices;
IF OBJECT_ID('dbo.water_consumption', 'U') IS NOT NULL DROP TABLE dbo.water_consumption;
IF OBJECT_ID('dbo.customers', 'U') IS NOT NULL DROP TABLE dbo.customers;
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
    collect_month TINYINT CHECK (collect_month BETWEEN 1 AND 12) NOT NULL,
    collect_year SMALLINT NOT NULL,
    consumption_amount DECIMAL(10,2) NOT NULL, -- Số nước tiêu thụ trong kỳ
    total DECIMAL(10,2) NOT NULL, -- Tổng tiền thanh toán
    status VARCHAR(20) CHECK (status IN ('Pending', 'Paid')) DEFAULT 'Pending',
    created_by INT NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(id) ON DELETE CASCADE,
    FOREIGN KEY (created_by) REFERENCES employees(id) ON DELETE SET NULL
);
GO

SET IDENTITY_INSERT employees ON;

INSERT INTO employees (id, name, username, password, role)
VALUES
(1, 'Admin', 'admin', 'admin123', 'Manager'),
(2, 'Nhân viên A', 'nva', 'password1', 'Staff'),
(3, 'Nhân viên B', 'nvb', 'password2', 'Staff');

SET IDENTITY_INSERT employees OFF;

SET IDENTITY_INSERT customers ON;

INSERT INTO customers (id, name, phone_number, water_meter_code, created_by) 
VALUES 
(1, 'NguyenVanA', '0912345678', 'WM1001', 1),
(2, 'NguyenVanB', '0923456789', 'WM1002', 2),
(3, 'NguyenVanC', '0934567890', 'WM1003', NULL);

SET IDENTITY_INSERT customers OFF;

SET IDENTITY_INSERT invoices ON;

INSERT INTO invoices (id, customer_id, collect_month, collect_year, consumption_amount, total, status, created_by) 
VALUES 
(1, 1, 1, 2025, 5000, 152500, 'Pending', 1),
(2, 2, 1, 2025, 5000, 125000, 'Paid', 2),
(3, 3, 1, 2025, 5000, 200000, 'Pending', NULL);

SET IDENTITY_INSERT invoices OFF;