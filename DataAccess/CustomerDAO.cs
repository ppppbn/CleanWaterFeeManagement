using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CleanWaterFeeManagement.Models;
using System.Diagnostics;

namespace CleanWaterFeeManagement.DataAccess
{
    public class CustomerDAO
    {
        private static SqlDataAdapter dataAdapter;
        private static SqlCommandBuilder commandBuilder;

        // Fetch Customer Data
        public static DataTable GetCustomerData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM customers";
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
                string query = "SELECT * FROM customers";
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
                    "INSERT INTO customers (name, phone_number, water_meter_code, created_by) " +
                    "VALUES (@name, @phone_number, @water_meter_code, @created_by);", conn);

                dataAdapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "name");
                dataAdapter.InsertCommand.Parameters.Add("@phone_number", SqlDbType.NVarChar, 20, "phone_number");
                dataAdapter.InsertCommand.Parameters.Add("@water_meter_code", SqlDbType.NVarChar, 50, "water_meter_code");
                dataAdapter.InsertCommand.Parameters.Add("@created_by", SqlDbType.Int, 4, "created_by");
            }
        }

        private static void GenerateUpdateCommand()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                dataAdapter.UpdateCommand = new SqlCommand(
                    "UPDATE customers " +
                    "SET name = @name, phone_number = @phone_number, water_meter_code = @water_meter_code, created_by = @created_by " +
                    "WHERE id = @id", conn);

                dataAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "name");
                dataAdapter.UpdateCommand.Parameters.Add("@phone_number", SqlDbType.NVarChar, 20, "phone_number");
                dataAdapter.UpdateCommand.Parameters.Add("@water_meter_code", SqlDbType.NVarChar, 50, "water_meter_code");
                dataAdapter.UpdateCommand.Parameters.Add("@created_by", SqlDbType.Int, 4, "created_by");
                dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            }
        }

        // Save Changes to the Database
        public static void SaveCustomerChanges(DataTable updatedTable)
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

        // Add Customer
        public static bool AddCustomer(Customer customer)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AddCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@water_meter_code", customer.WaterMeterCode);
                cmd.Parameters.AddWithValue("@created_by", customer.CreatedBy);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Update Customer
        public static bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", customer.Id);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@water_meter_code", customer.WaterMeterCode);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete Customer
        public static bool DeleteCustomer(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get All Customers
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PhoneNumber = reader.GetString(2),
                        WaterMeterCode = reader.GetString(3),
                        CreatedBy = reader.GetInt32(4)
                    });
                }
            }
            return customers;
        }
    }
}
