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
        private DataTable employeeTable;
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
            if (InvokeRequired)
            {
                Invoke(new Action(LoadEmployees)); // ✅ Ensure UI safety
                return;
            }

            // Reinitialize the data adapter when the form is reopened
            EmployeeService.InitializeDataAdapter();

            employeeTable = EmployeeService.GetEmployeeData();

            dgvEmployees.DataSource = null; // ✅ Clear binding before reloading
            dgvEmployees.DataSource = employeeTable;

            employeeTable.AcceptChanges();
        }

        private void dgvEmployee_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var isSaving = false;
                // Skip updates when loading the form
                if (employeeTable == null || employeeTable.GetChanges() == null)
                {
                    return;
                }

                // Prevent recursive updates
                if (!isSaving)
                {
                    isSaving = true;
                    EmployeeService.SaveEmployeeChanges(employeeTable);
                    MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ✅ Defer the UI update to prevent conflicts
                    BeginInvoke(new Action(() => LoadEmployees()));
                    isSaving = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
