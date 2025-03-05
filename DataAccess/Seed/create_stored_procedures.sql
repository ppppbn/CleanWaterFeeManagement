-- Drop procedures if they already exist
IF OBJECT_ID('dbo.AddCustomer', 'P') IS NOT NULL DROP PROCEDURE dbo.AddCustomer;
IF OBJECT_ID('dbo.UpdateCustomer', 'P') IS NOT NULL DROP PROCEDURE dbo.UpdateCustomer;
IF OBJECT_ID('dbo.DeleteCustomer', 'P') IS NOT NULL DROP PROCEDURE dbo.DeleteCustomer;
IF OBJECT_ID('dbo.GetAllCustomers', 'P') IS NOT NULL DROP PROCEDURE dbo.GetAllCustomers;

IF OBJECT_ID('dbo.AddEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.AddEmployee;
IF OBJECT_ID('dbo.UpdateEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.UpdateEmployee;
IF OBJECT_ID('dbo.DeleteEmployee', 'P') IS NOT NULL DROP PROCEDURE dbo.DeleteEmployee;
IF OBJECT_ID('dbo.GetAllEmployees', 'P') IS NOT NULL DROP PROCEDURE dbo.GetAllEmployees;

IF OBJECT_ID('dbo.AddWaterConsumption', 'P') IS NOT NULL DROP PROCEDURE dbo.AddWaterConsumption;
IF OBJECT_ID('dbo.UpdateWaterConsumption', 'P') IS NOT NULL DROP PROCEDURE dbo.UpdateWaterConsumption;
IF OBJECT_ID('dbo.DeleteWaterConsumption', 'P') IS NOT NULL DROP PROCEDURE dbo.DeleteWaterConsumption;
IF OBJECT_ID('dbo.GetAllWaterConsumptions', 'P') IS NOT NULL DROP PROCEDURE dbo.GetAllWaterConsumptions;

IF OBJECT_ID('dbo.GenerateInvoice', 'P') IS NOT NULL DROP PROCEDURE dbo.GenerateInvoice;
IF OBJECT_ID('dbo.GetAllInvoices', 'P') IS NOT NULL DROP PROCEDURE dbo.GetAllInvoices;

-- Stored Procedure: Add Customer
CREATE PROCEDURE AddCustomer
    @name VARCHAR(100),
    @phone_number VARCHAR(20),
    @water_meter_code VARCHAR(50),
    @created_by INT
AS
BEGIN
    INSERT INTO customers (name, phone_number, water_meter_code, created_by)
    VALUES (@name, @phone_number, @water_meter_code, @created_by);
END;
GO

-- Stored Procedure: Update Customer
CREATE PROCEDURE UpdateCustomer
    @id INT,
    @name VARCHAR(100),
    @phone_number VARCHAR(20),
    @water_meter_code VARCHAR(50)
AS
BEGIN
    UPDATE customers
    SET name = @name, phone_number = @phone_number, water_meter_code = @water_meter_code
    WHERE id = @id;
END;
GO

-- Stored Procedure: Delete Customer
CREATE PROCEDURE DeleteCustomer
    @id INT
AS
BEGIN
    DELETE FROM customers WHERE id = @id;
END;
GO

-- Stored Procedure: Get All Customers
CREATE PROCEDURE GetAllCustomers
AS
BEGIN
    SELECT id, name, phone_number, water_meter_code, created_by FROM customers;
END;
GO

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

-- Stored Procedure: Add Water Consumption
CREATE PROCEDURE AddWaterConsumption
    @customer_id INT,
    @recorded_month INT,
    @recorded_year INT,
    @value DECIMAL(10,2),
    @recorded_by INT
AS
BEGIN
    INSERT INTO water_consumption (customer_id, recorded_month, recorded_year, value, recorded_by)
    VALUES (@customer_id, @recorded_month, @recorded_year, @value, @recorded_by);
END;
GO

-- Stored Procedure: Get All Water Consumptions
CREATE PROCEDURE GetAllWaterConsumptions
AS
BEGIN
    SELECT id, customer_id, recorded_month, recorded_year, value, recorded_by FROM water_consumption;
END;
GO

-- Stored Procedure: Generate Invoice
CREATE PROCEDURE GenerateInvoice
    @customer_id INT,
    @collect_month INT,
    @collect_year INT,
    @unit_price DECIMAL(10,2),
    @created_by INT
AS
BEGIN
    DECLARE @current_usage DECIMAL(10,2), @last_usage DECIMAL(10,2), @consumption DECIMAL(10,2), @total_amount DECIMAL(10,2);
    
    -- Get the current and last month's usage
    SELECT @current_usage = value FROM water_consumption
    WHERE customer_id = @customer_id AND recorded_month = @collect_month AND recorded_year = @collect_year;
    
    SELECT @last_usage = value FROM water_consumption
    WHERE customer_id = @customer_id AND recorded_month = @collect_month - 1 AND recorded_year = @collect_year;
    
    -- Calculate the consumption amount
    SET @consumption = ISNULL(@current_usage, 0) - ISNULL(@last_usage, 0);
    SET @total_amount = @consumption * @unit_price;
    
    -- Insert invoice record
    INSERT INTO invoices (customer_id, collect_month, collect_year, consumption_amount, total, created_by)
    VALUES (@customer_id, @collect_month, @collect_year, @consumption, @total_amount, @created_by);
END;
GO

-- Stored Procedure: Get All Invoices
CREATE PROCEDURE GetAllInvoices
AS
BEGIN
    SELECT id, customer_id, collect_month, collect_year, consumption_amount, total, status, created_by FROM invoices;
END;
GO