using CleanWaterFeeManagement.BusinessLogic;
using System.ComponentModel;
using System.Data;

namespace CleanWaterFeeManagement.UI
{
    public partial class CustomerForm : Form
    {
        private DataTable customerTable;
        private int idCustomerEdit;

        public CustomerForm()
        {
            InitializeComponent();
            dgvCustomers.AutoGenerateColumns = true;
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;

            // Thêm cột vào DataGridView
            dgvCustomers.Columns.Add(btnDelete);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "Edit";
            btnEdit.Text = "Sửa";
            btnEdit.UseColumnTextForButtonValue = true;

            // Thêm cột vào DataGridView
            dgvCustomers.Columns.Add(btnEdit);
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text.Trim());
        }

        private void LoadCustomers(string filter = null)
        {
            dgvCustomers.DataSource = CustomerService.GetCustomers();
            if (InvokeRequired)
            {
                Invoke(new Action(() => LoadCustomers(txtSearch.Text.Trim()))); // ✅ Ensure UI safety
                return;
            }

            // Reinitialize the data adapter when the form is reopened
            CustomerService.InitializeDataAdapter();

            customerTable = CustomerService.GetCustomerData(filter);

            dgvCustomers.DataSource = null; // ✅ Clear binding before reloading
            dgvCustomers.DataSource = customerTable;

            customerTable.AcceptChanges();
        }

        private void dgvCustomer_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var isSaving = false;
                // Skip updates when loading the form
                if (customerTable == null || customerTable.GetChanges() == null)
                {
                    return;
                }

                // Prevent recursive updates
                if (!isSaving)
                {
                    isSaving = true;
                    CustomerService.SaveCustomerChanges(customerTable);
                    MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ✅ Defer the UI update to prevent conflicts
                    BeginInvoke(new Action(() => LoadCustomers(txtSearch.Text.Trim())));
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
            LoadCustomers(searchQuery);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Tên nhân viên không được để trống");
                    return;
                }
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Số điện thoại không được để trống");
                    return;
                }
                if (txtMeterCode.Text == "")
                {
                    MessageBox.Show("Mã đồng hồ không được để trống");
                    return;
                } 
                if (idCustomerEdit > 0)
                {
                    CustomerService.EditCustomer(idCustomerEdit, txtName.Text, txtPhone.Text, txtMeterCode.Text);
                    MessageBox.Show("Sửa thông tin khách hàng thành công!");
                }
                else
                {
                    CustomerService.AddCustomer(txtName.Text, txtPhone.Text, txtMeterCode.Text, txtCustomerCode.Text, 1);
                    MessageBox.Show("Thêm mới khách hàng thành công!");
                }
                idCustomerEdit = 0;
                EmptyTextBoxes(this);
                LoadCustomers();
            }
            catch (Exception ex)
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
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCustomers.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xóa", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var idCustomer = row.Cells[2].Value.ToString();
                        CustomerService.RemoveCustomer(int.Parse(idCustomer));
                        LoadCustomers();
                    }
                }
                if (e.ColumnIndex == dgvCustomers.Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                    idCustomerEdit = int.Parse(row.Cells[2].Value.ToString());
                    var name = row.Cells[3].Value.ToString();
                    var customerCode = row.Cells[4].Value.ToString();
                    var phone = row.Cells[5].Value.ToString();
                    var meterCode = row.Cells[6].Value.ToString();

                    txtName.Text = name;
                    txtPhone.Text = phone;
                    txtMeterCode.Text = meterCode;
                    txtCustomerCode.Text = customerCode;
                }
        }
    }
}
}
