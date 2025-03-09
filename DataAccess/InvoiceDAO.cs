using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CleanWaterFeeManagement.Models;
using System.Diagnostics;

namespace CleanWaterFeeManagement.DataAccess
{
    public class InvoiceDAO
    {
        private static SqlDataAdapter dataAdapter;
        private static SqlCommandBuilder commandBuilder;

        // Fetch Invoice Data
        public static DataTable GetInvoiceData(int? customerIdFilter = null, int? monthFilter = null, int? yearFilter = null)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM invoices WHERE 1=1"; // Ensures WHERE clause can be dynamically extended

                if (customerIdFilter.HasValue)
                {
                    query += " AND customer_id = @customer_id";
                }
                if (monthFilter.HasValue)
                {
                    query += " AND collect_month = @collect_month";
                }
                if (yearFilter.HasValue)
                {
                    query += " AND collect_year = @collect_year";
                }

                dataAdapter = new SqlDataAdapter(query, conn);

                if (customerIdFilter.HasValue)
                {
                    dataAdapter.SelectCommand.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerIdFilter.Value;
                }
                if (monthFilter.HasValue)
                {
                    dataAdapter.SelectCommand.Parameters.Add("@collect_month", SqlDbType.Int).Value = monthFilter.Value;
                }
                if (yearFilter.HasValue)
                {
                    dataAdapter.SelectCommand.Parameters.Add("@collect_year", SqlDbType.Int).Value = yearFilter.Value;
                }

                commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void InitializeDataAdapter()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM invoices";
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
                    "INSERT INTO invoices (customer_id, collect_month, collect_year, consumtion_amount, total, status, created_by) " +
                    "VALUES (@customer_id, @collect_month, @collect_year, @consumtion_amount, @total, @status, @created_by);", conn);

                dataAdapter.InsertCommand.Parameters.Add("@customer_id", SqlDbType.Int, 4, "customer_id");
                dataAdapter.InsertCommand.Parameters.Add("@collect_month", SqlDbType.Int, 4, "collect_month");
                dataAdapter.InsertCommand.Parameters.Add("@collect_year", SqlDbType.Int, 4, "collect_year");
                dataAdapter.InsertCommand.Parameters.Add("@consumtion_amount", SqlDbType.Decimal, 10, "consumtion_amount");
                dataAdapter.InsertCommand.Parameters.Add("@total", SqlDbType.Decimal, 10, "total");
                dataAdapter.InsertCommand.Parameters.Add("@status", SqlDbType.NVarChar, 50, "status");
                dataAdapter.InsertCommand.Parameters.Add("@created_by", SqlDbType.Int, 4, "created_by");
            }
        }

        private static void GenerateUpdateCommand()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                dataAdapter.UpdateCommand = new SqlCommand(
                    "UPDATE invoices " +
                    "SET customer_id = @customer_id, collect_month = @collect_month, " +
                    "collect_year = @collect_year, consumtion_amount = @consumtion_amount, " +
                    "total = @total, status = @status, created_by = @created_by " +
                    "WHERE id = @id", conn);

                dataAdapter.UpdateCommand.Parameters.Add("@customer_id", SqlDbType.Int, 4, "customer_id");
                dataAdapter.UpdateCommand.Parameters.Add("@collect_month", SqlDbType.Int, 4, "collect_month");
                dataAdapter.UpdateCommand.Parameters.Add("@collect_year", SqlDbType.Int, 4, "collect_year");
                dataAdapter.UpdateCommand.Parameters.Add("@consumtion_amount", SqlDbType.Decimal, 10, "consumtion_amount");
                dataAdapter.UpdateCommand.Parameters.Add("@total", SqlDbType.Decimal, 10, "total");
                dataAdapter.UpdateCommand.Parameters.Add("@status", SqlDbType.NVarChar, 50, "status");
                dataAdapter.UpdateCommand.Parameters.Add("@created_by", SqlDbType.Int, 4, "created_by");
                dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            }
        }

        // Save Changes to the Database
        public static void SaveInvoiceChanges(DataTable updatedTable)
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

        // Generate Invoice
        public static bool GenerateInvoice(int customerId, int collectMonth, int collectYear, decimal unitPrice, int createdBy)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GenerateInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", customerId);
                cmd.Parameters.AddWithValue("@collect_month", collectMonth);
                cmd.Parameters.AddWithValue("@collect_year", collectYear);
                cmd.Parameters.AddWithValue("@unit_price", unitPrice);
                cmd.Parameters.AddWithValue("@created_by", createdBy);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Update Invoice
        public static bool UpdateInvoice(int id, string status)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", status);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete Invoice
        public static bool DeleteInvoice(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteInvoice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get All Invoices
        public static List<Invoice> GetAllInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllInvoices", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    invoices.Add(new Invoice
                    {
                        Id = reader.GetInt32(0),
                        CustomerId = reader.GetInt32(1),
                        CollectMonth = reader.GetInt32(2),
                        CollectYear = reader.GetInt32(3),
                        ConsumptionAmount = reader.GetDecimal(4),
                        Total = reader.GetDecimal(5),
                        Status = reader.GetString(6),
                        CreatedBy = reader.GetInt32(7)
                    });
                }
            }
            return invoices;
        }
    }
}
