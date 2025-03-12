namespace CleanWaterFeeManagement.UI
{
  partial class InvoiceForm
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      dgvInvoices = new DataGridView();
      txtMeterId = new TextBox();
      txtMonth = new TextBox();
      txtYear = new TextBox();
      txtUnitPrice = new TextBox();
      btnCreateInvoice = new Button();
      btnSearchInvoice = new Button();
      lblMeterId = new Label();
      lblMonth = new Label();
      lblYear = new Label();
      lblUnitPrice = new Label();

      SuspendLayout();

      // DataGridView - danh sách hóa đơn
      dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvInvoices.Location = new Point(50, 150);
      dgvInvoices.Name = "dgvInvoices";
      dgvInvoices.Size = new Size(600, 250);

      // Label và TextBox - Mã đồng hồ nước
      lblMeterId.Text = "Mã đồng hồ nước";
      lblMeterId.Location = new Point(50, 20);
      txtMeterId.Location = new Point(180, 20);

      // Label và TextBox - Tháng
      lblMonth.Text = "Tháng";
      lblMonth.Location = new Point(50, 50);
      txtMonth.Location = new Point(180, 50);

      // Label và TextBox - Năm
      lblYear.Text = "Năm";
      lblYear.Location = new Point(50, 80);
      txtYear.Location = new Point(180, 80);

      // Label và TextBox - Đơn giá
      lblUnitPrice.Text = "Đơn giá";
      lblUnitPrice.Location = new Point(50, 110);
      txtUnitPrice.Location = new Point(180, 110);

      // Button - Tạo hóa đơn
      btnCreateInvoice.Text = "Tạo hóa đơn";
      btnCreateInvoice.Location = new Point(400, 20);
      btnCreateInvoice.Size = new Size(100, 23);
      btnCreateInvoice.Click += btnCreateInvoice_Click;

      // Button - Tìm kiếm hóa đơn
      btnSearchInvoice.Text = "Tìm kiếm";
      btnSearchInvoice.Location = new Point(400, 50);
      btnSearchInvoice.Size = new Size(100, 23);
      btnSearchInvoice.Click += btnSearch_Click;

      // InvoiceForm
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(700, 450);
      Controls.Add(lblMeterId);
      Controls.Add(txtMeterId);
      Controls.Add(lblMonth);
      Controls.Add(txtMonth);
      Controls.Add(lblYear);
      Controls.Add(txtYear);
      Controls.Add(lblUnitPrice);
      Controls.Add(txtUnitPrice);
      Controls.Add(btnCreateInvoice);
      Controls.Add(btnSearchInvoice);
      Controls.Add(dgvInvoices);
      Name = "InvoiceForm";
      Text = "Quản lý hóa đơn";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DataGridView dgvInvoices;
    private TextBox txtMeterId;
    private TextBox txtMonth;
    private TextBox txtYear;
    private TextBox txtUnitPrice;
    private Button btnCreateInvoice;
    private Button btnSearchInvoice;
    private Label lblMeterId;
    private Label lblMonth;
    private Label lblYear;
    private Label lblUnitPrice;
  }
}
