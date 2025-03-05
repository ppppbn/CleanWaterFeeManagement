using CleanWaterFeeManagement.BusinessLogic;
using CleanWaterFeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CleanWaterFeeManagement.UI
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            dgvEmployees.AutoGenerateColumns = true;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = EmployeeService.GetEmployees();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = EmployeeService.RegisterEmployee(name, username, password, role);

            if (success)
            {
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh DataGridView
            }
            else
            {
                MessageBox.Show("Failed to add employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["Id"].Value);
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;

            bool success = EmployeeService.EditEmployee(id, name, username, password, role);

            if (success)
            {
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Failed to update employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
