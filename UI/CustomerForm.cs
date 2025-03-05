using CleanWaterFeeManagement.BusinessLogic;

namespace CleanWaterFeeManagement.UI
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            dgvCustomers.AutoGenerateColumns = true;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            dgvCustomers.DataSource = CustomerService.GetCustomers();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string waterMeterCode = txtWaterMeterCode.Text;
            int createdBy = LoginForm.LoggedInUserId; // The logged-in user

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(waterMeterCode))
            {
                MessageBox.Show("Vui lòng điền tất cả các trường.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = CustomerService.AddCustomer(name, phoneNumber, waterMeterCode, createdBy);

            if (success)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers(); // Refresh DataGridView
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để chỉnh sửa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["Id"].Value);
            string name = txtCustomerName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string waterMeterCode = txtWaterMeterCode.Text;

            bool success = CustomerService.EditCustomer(id, name, phoneNumber, waterMeterCode);

            if (success)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
