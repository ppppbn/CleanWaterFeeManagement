-- Drop procedure if it exists
IF OBJECT_ID('dbo.AddCustomer', 'P') IS NOT NULL DROP PROCEDURE dbo.AddCustomer;
GO

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

-- Drop procedure if it exists
IF OBJECT_ID('dbo.UpdateCustomer', 'P') IS NOT NULL DROP PROCEDURE dbo.UpdateCustomer;
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
