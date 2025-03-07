using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CleanWaterFeeManagement.Models;
using System.Diagnostics;

namespace CleanWaterFeeManagement.DataAccess
{
    public class EmployeeDAO
    {
        private static SqlDataAdapter dataAdapter;
        private static SqlCommandBuilder commandBuilder;

        // Fetch Employee Data
        public static DataTable GetEmployeeData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM employees";
                dataAdapter = new SqlDataAdapter(query, conn);
                commandBuilder = new SqlCommandBuilder(dataAdapter); // Auto-generates commands

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void InitializeDataAdapter()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM employees";
                dataAdapter = new SqlDataAdapter(query, conn);
                new SqlCommandBuilder(dataAdapter); // ✅ Auto-generate commands
            }
        }

        private static void GenerateInsertCommand()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                dataAdapter.InsertCommand = new SqlCommand(
                    "INSERT INTO employees (name, username, password, role) " +
                    "VALUES (@name, @username, @password, @role);", conn);

                dataAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "name");
                dataAdapter.InsertCommand.Parameters.Add("@username", SqlDbType.NVarChar, 50, "username");
                dataAdapter.InsertCommand.Parameters.Add("@password", SqlDbType.NVarChar, 255, "password");
                dataAdapter.InsertCommand.Parameters.Add("@role", SqlDbType.NVarChar, 50, "role");
            }
        }

        private static void GenerateUpdateCommand()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                dataAdapter.UpdateCommand = new SqlCommand(
                    "UPDATE employees " +
                    "SET name = @name, username = @username, password = @password, role = @role " +
                    "WHERE id = @id", conn);

                dataAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "name");
                dataAdapter.UpdateCommand.Parameters.Add("@username", SqlDbType.NVarChar, 50, "username");
                dataAdapter.UpdateCommand.Parameters.Add("@password", SqlDbType.NVarChar, 255, "password");
                dataAdapter.UpdateCommand.Parameters.Add("@role", SqlDbType.NVarChar, 50, "role");
                dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            }
        }

        // Save Changes to the Database
        public static void SaveEmployeeChanges(DataTable updatedTable)
        {
            Debug.WriteLine("🚀 Checking DataTable Changes...");

            if (dataAdapter == null)
            {
                InitializeDataAdapter(); // ✅ Reinitialize adapter if needed
            }
            if (dataAdapter.InsertCommand == null)
            {
                Debug.WriteLine("⚠️ No InsertCommand found. Generating manually...");
                GenerateInsertCommand();
            }
            if (dataAdapter.UpdateCommand == null)
            {
                Debug.WriteLine("⚠️ No UpdateCommand found. Generating manually...");
                GenerateUpdateCommand();
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                dataAdapter.InsertCommand.Connection = conn;
                dataAdapter.UpdateCommand.Connection = conn;

                if (updatedTable.GetChanges(DataRowState.Added) != null || updatedTable.GetChanges(DataRowState.Modified) != null)
                {
                    Debug.WriteLine("Updating database...");
                    int rowsAffected = dataAdapter.Update(updatedTable);
                    Debug.WriteLine($"✅ Update completed! Rows affected: {rowsAffected}");
                }
                else
                {
                    Debug.WriteLine("⚠️ No new rows detected, skipping insert.");
                }
            }

            updatedTable.AcceptChanges();
        }

        // Add Employee
        public static bool AddEmployee(Employee employee)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@username", employee.Username);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@role", employee.Role);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Update Employee
        public static bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", employee.Id);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@username", employee.Username);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@role", employee.Role);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete Employee
        public static bool DeleteEmployee(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get All Employees
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Username = reader.GetString(2),
                        Role = reader.GetString(3)
                    });
                }
            }
            return employees;
        }

        public static Employee AuthenticateUser(string username, string password)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AuthenticateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Username = reader.GetString(2),
                        Role = reader.GetString(3)
                    };
                }
            }

            return null; // No user found
        }

    }
}
