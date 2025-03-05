using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.BusinessLogic;

namespace CleanWaterFeeManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Database connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = "John Smith";  // Replace with actual user input
            string phoneNumber = "123456789";
            string waterMeterCode = "WM-001";
            int createdBy = 1;  // Assuming Admin ID 1 is creating customers

            bool success = CustomerService.RegisterCustomer(name, phoneNumber, waterMeterCode, createdBy);

            if (success)
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string name = "Test User";
            string username = "test";
            string password = "securepassword";
            string role = "User";

            bool success = EmployeeService.RegisterEmployee(name, username, password, role);

            if (success)
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRecordWaterConsumption_Click(object sender, EventArgs e)
        {
            int customerId = 2;
            int recordedMonth = 3;
            int recordedYear = 2025;
            decimal value = 505;
            int recordedBy = 1;

            bool success = WaterConsumptionService.RecordWaterConsumption(customerId, recordedMonth, recordedYear, value, recordedBy);

            if (success)
                MessageBox.Show("Water consumption recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to record water consumption.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            int customerId = 2;
            int collectMonth = 3;
            int collectYear = 2025;
            decimal unitPrice = 1.5m;
            int createdBy = 1;

            bool success = InvoiceService.CreateInvoice(customerId, collectMonth, collectYear, unitPrice, createdBy);

            if (success)
                MessageBox.Show("Invoice generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to generate invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
