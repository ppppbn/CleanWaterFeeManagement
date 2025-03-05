using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.DataAccess
{
    public class WaterConsumptionDAO
    {
        // Add Water Consumption Record
        public static bool AddWaterConsumption(WaterConsumption consumption)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AddWaterConsumption", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", consumption.CustomerId);
                cmd.Parameters.AddWithValue("@recorded_month", consumption.RecordedMonth);
                cmd.Parameters.AddWithValue("@recorded_year", consumption.RecordedYear);
                cmd.Parameters.AddWithValue("@value", consumption.Value);
                cmd.Parameters.AddWithValue("@recorded_by", consumption.RecordedBy);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Update Water Consumption Record
        public static bool UpdateWaterConsumption(WaterConsumption consumption)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateWaterConsumption", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", consumption.Id);
                cmd.Parameters.AddWithValue("@customer_id", consumption.CustomerId);
                cmd.Parameters.AddWithValue("@recorded_month", consumption.RecordedMonth);
                cmd.Parameters.AddWithValue("@recorded_year", consumption.RecordedYear);
                cmd.Parameters.AddWithValue("@value", consumption.Value);
                cmd.Parameters.AddWithValue("@recorded_by", consumption.RecordedBy);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Delete Water Consumption Record
        public static bool DeleteWaterConsumption(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteWaterConsumption", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Get All Water Consumption Records
        public static List<WaterConsumption> GetAllWaterConsumptions()
        {
            List<WaterConsumption> consumptions = new List<WaterConsumption>();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllWaterConsumptions", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    consumptions.Add(new WaterConsumption
                    {
                        Id = reader.GetInt32(0),
                        CustomerId = reader.GetInt32(1),
                        RecordedMonth = reader.GetInt32(2),
                        RecordedYear = reader.GetInt32(3),
                        Value = reader.GetDecimal(4),
                        RecordedBy = reader.GetInt32(5)
                    });
                }
            }
            return consumptions;
        }
    }
}
