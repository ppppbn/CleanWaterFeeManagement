using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CleanWaterFeeManagement.Models;
using System.Diagnostics;

namespace CleanWaterFeeManagement.DataAccess
{
    public class WaterConsumptionDAO
    {
        private static SqlDataAdapter dataAdapter;
        private static SqlCommandBuilder commandBuilder;

        // Fetch Water Consumption Data
        public static DataTable GetWaterConsumptionData(string filter = null)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM water_consumption";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE customer_id = @customer_id"; // ✅ Allows partial matching
                }

                dataAdapter = new SqlDataAdapter(query, conn);

                if (!string.IsNullOrEmpty(filter))
                {
                    dataAdapter.SelectCommand.Parameters.Add("@customer_id", SqlDbType.Int).Value = filter;
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
                string query = "SELECT * FROM water_consumption";
                dataAdapter = new SqlDataAdapter(query, conn);
                new SqlCommandBuilder(dataAdapter); // ✅ Auto-generate commands
            }
        }

        private static void GenerateInsertCommand()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection()) // Create a new connection
            {
                conn.Open();

                dataAdapter.InsertCommand = new SqlCommand(
                    "INSERT INTO water_consumption (customer_id, recorded_month, recorded_year, value, recorded_by) " +
                    "VALUES (@customer_id, @recorded_month, @recorded_year, @value, @recorded_by);", conn);

                dataAdapter.InsertCommand.Parameters.Add("@customer_id", SqlDbType.Int, 4, "customer_id");
                dataAdapter.InsertCommand.Parameters.Add("@recorded_month", SqlDbType.Int, 4, "recorded_month");
                dataAdapter.InsertCommand.Parameters.Add("@recorded_year", SqlDbType.Int, 4, "recorded_year");
                dataAdapter.InsertCommand.Parameters.Add("@value", SqlDbType.Decimal, 10, "value");
                dataAdapter.InsertCommand.Parameters.Add("@recorded_by", SqlDbType.Int, 4, "recorded_by");
            }
        }


        private static void GenerateUpdateCommand()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection()) // Create a new connection
            {
                conn.Open();

                dataAdapter.UpdateCommand = new SqlCommand(
                    "UPDATE water_consumption " +
                    "SET customer_id = @customer_id, recorded_month = @recorded_month, " +
                    "recorded_year = @recorded_year, value = @value, recorded_by = @recorded_by " +
                    "WHERE id = @id", conn); // ✅ Assign connection

                dataAdapter.UpdateCommand.Parameters.Add("@customer_id", SqlDbType.Int, 4, "customer_id");
                dataAdapter.UpdateCommand.Parameters.Add("@recorded_month", SqlDbType.Int, 4, "recorded_month");
                dataAdapter.UpdateCommand.Parameters.Add("@recorded_year", SqlDbType.Int, 4, "recorded_year");
                dataAdapter.UpdateCommand.Parameters.Add("@value", SqlDbType.Decimal, 10, "value");
                dataAdapter.UpdateCommand.Parameters.Add("@recorded_by", SqlDbType.Int, 4, "recorded_by");
                dataAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            }
        }


        // Save Changes to the Database
        public static void SaveWaterConsumptionChanges(DataTable updatedTable)
        {
            Debug.WriteLine("🚀 Checking DataTable Changes...");

            // Ensure InsertCommand & UpdateCommand exist
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

            using (SqlConnection conn = DatabaseHelper.GetConnection()) // Open a new connection
            {
                conn.Open();
                dataAdapter.InsertCommand.Connection = conn;
                dataAdapter.UpdateCommand.Connection = conn;

                if (updatedTable.GetChanges(DataRowState.Added) != null || updatedTable.GetChanges(DataRowState.Modified) != null)
                {
                    Debug.WriteLine("Updating database...");
                    int rowsAffected = dataAdapter.Update(updatedTable); // ✅ Perform insert/update
                    Debug.WriteLine($"✅ Update completed! Rows affected: {rowsAffected}");
                }
                else
                {
                    Debug.WriteLine("⚠️ No new rows detected, skipping insert.");
                }
            }

            updatedTable.AcceptChanges(); // ✅ Reset tracking after update
        }



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
