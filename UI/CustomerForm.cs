using CleanWaterFeeManagement.BusinessLogic;
using System.Data;

namespace CleanWaterFeeManagement.UI
{
    public partial class CustomerForm : Form
    {
        private DataTable customerTable;

        public CustomerForm()
        {
            InitializeComponent();
            dgvCustomers.AutoGenerateColumns = true;
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
    }
}
