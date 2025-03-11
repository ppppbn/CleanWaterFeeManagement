namespace CleanWaterFeeManagement.UI
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCustomers = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            btnSave = new Button();
            labelName = new Label();
            lbNumberPhone = new Label();
            lbCodeMeter = new Label();
            lbCustomerCode = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtMeterCode = new TextBox();
            txtCustomerCode = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(106, 135);
            dgvCustomers.Margin = new Padding(3, 4, 3, 4);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(685, 325);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.RowValidated += dgvCustomer_RowValidated;
            dgvCustomers.CellContentClick += dataGridView_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(106, 96);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(179, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(306, 95);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(86, 31);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 71);
            label1.Name = "label1";
            label1.Size = new Size(348, 20);
            label1.TabIndex = 4;
            label1.Text = "Tìm theo tên , số điện thoại hoặc mã đồng hồ nước";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(405, 732);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(106, 517);
            labelName.Name = "labelName";
            labelName.Size = new Size(111, 20);
            labelName.TabIndex = 6;
            labelName.Text = "Tên khách hàng";
            // 
            // lbNumberPhone
            // 
            lbNumberPhone.AutoSize = true;
            lbNumberPhone.Location = new Point(106, 569);
            lbNumberPhone.Name = "lbNumberPhone";
            lbNumberPhone.Size = new Size(97, 20);
            lbNumberPhone.TabIndex = 7;
            lbNumberPhone.Text = "Số điện thoại";
            // 
            // lbCodeMeter
            // 
            lbCodeMeter.AutoSize = true;
            lbCodeMeter.Location = new Point(108, 678);
            lbCodeMeter.Name = "lbCodeMeter";
            lbCodeMeter.Size = new Size(127, 20);
            lbCodeMeter.TabIndex = 8;
            lbCodeMeter.Text = "Mã đồng hồ nước";
            // 
            // lbCustomerCode
            // 
            lbCustomerCode.AutoSize = true;
            lbCustomerCode.Location = new Point(108, 620);
            lbCustomerCode.Name = "lbCustomerCode";
            lbCustomerCode.Size = new Size(109, 20);
            lbCustomerCode.TabIndex = 9;
            lbCustomerCode.Text = "Mã khách hàng";
            // 
            // txtName
            // 
            txtName.Location = new Point(405, 510);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập tên khách hàng";
            txtName.Size = new Size(221, 27);
            txtName.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(405, 562);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Nhập số điện thoại";
            txtPhone.Size = new Size(221, 27);
            txtPhone.TabIndex = 11;
            // 
            // txtMeterCode
            // 
            txtMeterCode.Location = new Point(405, 671);
            txtMeterCode.Name = "txtMeterCode";
            txtMeterCode.PlaceholderText = "Nhập mã đồng hồ";
            txtMeterCode.Size = new Size(221, 27);
            txtMeterCode.TabIndex = 12;
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Location = new Point(405, 613);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.PlaceholderText = "Nhập mã khách hàng";
            txtCustomerCode.Size = new Size(221, 27);
            txtCustomerCode.TabIndex = 13;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 798);
            Controls.Add(txtCustomerCode);
            Controls.Add(txtMeterCode);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(lbCustomerCode);
            Controls.Add(lbCodeMeter);
            Controls.Add(lbNumberPhone);
            Controls.Add(labelName);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomers);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private Button btnSave;
        private Label labelName;
        private Label lbNumberPhone;
        private Label lbCodeMeter;
        private Label lbCustomerCode;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtMeterCode;
        private TextBox txtCustomerCode;
    }
}