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
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            dgvCustomers = new DataGridView();
            btnAddCustomer = new Button();
            btnEditCustomer = new Button();
            label1 = new Label();
            txtCustomerName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtWaterMeterCode = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(93, 101);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(599, 244);
            dgvCustomers.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(93, 61);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(127, 23);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "Thêm khách hàng";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnEditCustomer
            // 
            btnEditCustomer.Location = new Point(255, 61);
            btnEditCustomer.Name = "btnEditCustomer";
            btnEditCustomer.Size = new Size(127, 23);
            btnEditCustomer.TabIndex = 2;
            btnEditCustomer.Text = "Sửa khách hàng";
            btnEditCustomer.UseVisualStyleBackColor = true;
            btnEditCustomer.Click += btnEditCustomer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 358);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 3;
            label1.Text = "Tên KH";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(93, 376);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(100, 23);
            txtCustomerName.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(238, 376);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(100, 23);
            txtPhoneNumber.TabIndex = 5;
            // 
            // txtWaterMeterCode
            // 
            txtWaterMeterCode.Location = new Point(385, 376);
            txtWaterMeterCode.Name = "txtWaterMeterCode";
            txtWaterMeterCode.Size = new Size(100, 23);
            txtWaterMeterCode.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 358);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 7;
            label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(385, 358);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 8;
            label3.Text = "Mã đồng hồ";
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtWaterMeterCode);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtCustomerName);
            Controls.Add(label1);
            Controls.Add(btnEditCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(dgvCustomers);
            Name = "CustomerForm";
            Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private Button btnAddCustomer;
        private Button btnEditCustomer;
        private Label label1;
        private TextBox txtCustomerName;
        private TextBox txtPhoneNumber;
        private TextBox txtWaterMeterCode;
        private Label label2;
        private Label label3;
    }
}