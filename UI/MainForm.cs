using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.BusinessLogic;

namespace CleanWaterFeeManagement.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string role = LoginForm.LoggedInRole;

            if (role == "Admin")
            {
                // Admin has access to everything (leave as is)
            }
            else if (role == "Employee")
            {
                // Employees can manage customers & invoices, but NOT employees
                employeesToolStripMenuItem.Visible = false;
            }
            else if (role == "Customer")
            {
                // Customers can only view their own invoices
                employeesToolStripMenuItem.Visible = false;
                customersToolStripMenuItem.Visible = false;
                waterConsumptionToolStripMenuItem.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new EmployeeForm();
            empForm.ShowDialog();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm custForm = new CustomerForm();
            custForm.ShowDialog();
        }

        private void waterConsumptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaterConsumptionForm waterForm = new WaterConsumptionForm();
            waterForm.ShowDialog();
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceForm invoiceForm = new InvoiceForm();
            invoiceForm.ShowDialog();
        }

        private void generateReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }
    }
}
