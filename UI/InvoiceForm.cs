using CleanWaterFeeManagement.BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;

namespace CleanWaterFeeManagement.UI
{
  public partial class InvoiceForm : Form
  {
    private DataTable invoiceTable;

    public InvoiceForm()
    {
      InitializeComponent();
      dgvInvoices.AutoGenerateColumns = true;
    }

    private void InvoiceForm_Load(object sender, EventArgs e)
    {
      LoadInvoices();
    }

    private void LoadInvoices(int? customerId = null, int? month = null, int? year = null)
    {
      invoiceTable = InvoiceService.GetInvoiceData(customerId, month, year);
      dgvInvoices.DataSource = null;
      dgvInvoices.DataSource = invoiceTable;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      int? month = string.IsNullOrEmpty(txtMonth.Text) ? null : int.Parse(txtMonth.Text);
      int? year = string.IsNullOrEmpty(txtYear.Text) ? null : int.Parse(txtYear.Text);
      LoadInvoices(null, month, year);
    }

    private void btnCreateInvoice_Click(object sender, EventArgs e)
    {
      try
      {
        DataTable customerTable = CustomerService.GetCustomerData(txtMeterId.Text);
        if (customerTable.Rows.Count == 0)
        {
          MessageBox.Show("Không tìm thấy khách hàng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        int customerId = Convert.ToInt32(customerTable.Rows[0]["Id"]);
        int month = int.Parse(txtMonth.Text);
        int year = int.Parse(txtYear.Text);
        decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
        int createdBy = 1; // Mock data

        bool success = InvoiceService.CreateInvoice(customerId, month, year, unitPrice, createdBy);
        if (success)
        {
          MessageBox.Show("Hóa đơn đã được tạo thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          LoadInvoices();
        }
        else
        {
          MessageBox.Show("Tạo hóa đơn thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
