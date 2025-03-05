# Clean Water Fee Management System

## 📌 Project Overview

### This application is a Windows Forms (.NET) application for managing water fee collection. It supports role-based access for Admin, Employees, and Customers.

🛠️ Prerequisites

Before running the project, ensure you have:

- Windows 10 or later

- Visual Studio (latest version) with .NET Desktop Development workload installed

- SQL Server (Express or Developer)

- SQL Server Management Studio (SSMS)

- .NET 8.0 or later

## 🚀 Installation Steps

### 1. Clone the Repository

```
 git clone git@github.com:ppppbn/CleanWaterFeeManagement.git
 cd CleanWaterFeeManagement
```

### 2. Set Up the Database

- Open SQL Server Management Studio (SSMS).

- Create a new database:

```
CREATE DATABASE water_fee;
```

- Run the SQL Script:

+ Open DataAccess/Seed

+ Execute the scripts to create tables and stored procedures.

### 3. Configure Connection String

- Open App.config.

- Locate the <connectionStrings> section and modify it:

```
<connectionStrings>
  <add name="DatabaseConnection" connectionString="Server=YOUR_SERVER;Database=water_fee;Trusted_Connection=True;TrustServerCertificate=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

- Replace YOUR_SERVER with your SQL Server instance name.

### 4. Install Dependencies (NuGet)

If you don't have NuGet dependencies installed, open Visual Studio Package Manager Console and run:

```Install-Package Microsoft.Data.SqlClient```

Or run this command in your terminal

```
dotnet add package Microsoft.Data.SqlClient
```

### 5. Run the Application

- Open the project in Visual Studio.

- Click Start (F5) to run the application.

## 📖 Role-Based Access

### Admin

- ✅ Manage Employees
- ✅ Manage Customers
- ✅ Manage Water Consumption
- ✅ Manage Invoices
- ✅ Generate Reports

### Employee

- ✅ Manage Customers
- ✅ Manage Water Consumption
- ✅ Manage Invoices
- ❌ Cannot manage employees

### Customer

- ✅ View their own invoices
- ❌ Cannot modify any data

## 📌 Features Implemented

- ✔️ Login System with Authentication
- ✔️ Role-Based UI Access (Admin, Employee, Customer)
- ✔️ CRUD Operations for Employees & Customers
- ✔️ Water Consumption Tracking
- ✔️ Invoice Management
- ✔️ SQL Server Stored Procedures for Database Operations

## ❓ Troubleshooting

1️ If InitializeComponent() Gives an Error

- Open Form.Designer.cs and ensure it exists.

- If missing, delete the form and re-add it in Visual Studio.

2️ If DataGridView Is Empty

- Check SQL Server:

```SELECT * FROM employees;```

- Ensure the database has records.

3️ If Connection Fails

- Ensure SQL Server is running.

- Update App.config with the correct SQL Server instance name.