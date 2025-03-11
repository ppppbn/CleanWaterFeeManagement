using CleanWaterFeeManagement.BusinessLogic;
using CleanWaterFeeManagement.DataAccess;
using CleanWaterFeeManagement.Models;
using DocumentFormat.OpenXml.Office2010.Drawing;
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
        private int idEmployeeEdit;
        public EmployeeForm()
        {
            InitializeComponent();
            dgvEmployees.AutoGenerateColumns = true;
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;

            // Thêm cột vào DataGridView
            dgvEmployees.Columns.Add(btnDelete);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "Edit";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            // Thêm cột vào DataGridView
            dgvEmployees.Columns.Add(btnEdit);
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees(txtSearch.Text.Trim());
        }

        private void LoadEmployees(string filter = null)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LoadEmployees(txtSearch.Text.Trim()))); // ✅ Ensure UI safety
                return;
            }

            // Reinitialize the data adapter when the form is reopened
            EmployeeService.InitializeDataAdapter();

            employeeTable = EmployeeService.GetEmployeeData(filter);

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
                    BeginInvoke(new Action(() => LoadEmployees(txtSearch.Text.Trim())));
                    isSaving = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            LoadEmployees(searchQuery);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Tên nhân viên không được để trống");
                    return;
                }
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Tài khoản không được để trống");
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;
                }
                var roleEmployee = roleManager.Checked ? roleManager.Text : roleStaff.Text;
                if(idEmployeeEdit > 0)
                {
                    EmployeeService.EditEmployee(idEmployeeEdit, txtName.Text, txtUsername.Text, txtPassword.Text, roleEmployee);
                    MessageBox.Show("Sửa thông tin nhân viên thành công!");
                } else
                {
                    EmployeeService.RegisterEmployee(txtName.Text, txtUsername.Text, txtPassword.Text, roleEmployee);
                    MessageBox.Show("Thêm mới nhân viên thành công!");
                }
                idEmployeeEdit = 0;
                EmptyTextBoxes(this);
                roleStaff.Checked = true;
                LoadEmployees();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
                if (c.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)c).Checked = false;
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvEmployees.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xóa", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var idEmployee = row.Cells[2].Value.ToString();
                        EmployeeService.RemoveEmployee(int.Parse(idEmployee));
                        LoadEmployees();
                    }
                }
                if (e.ColumnIndex == dgvEmployees.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                    idEmployeeEdit = int.Parse(row.Cells[2].Value.ToString());
                    var name = row.Cells[3].Value.ToString();
                    var username = row.Cells[4].Value.ToString();
                    var password = row.Cells[5].Value.ToString();
                    var role = row.Cells[6].Value.ToString();

                    txtName.Text = name;
                    txtUsername.Text = username;
                    txtPassword.Text = password;
                    roleManager.Checked = role == "Manager" ? true : false;
                    roleStaff.Checked = role == "Staff" ? true : false;
                    
                }

            }

        }
    }
}
