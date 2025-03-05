using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.DataAccess
{
    public class InvoiceDAO
    {
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
