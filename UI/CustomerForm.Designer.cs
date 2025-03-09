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
            dgvCustomers.RowValidated += dgvCustomer_RowValidated;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(93, 72);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(157, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(268, 71);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 53);
            label1.Name = "label1";
            label1.Size = new Size(278, 15);
            label1.TabIndex = 4;
            label1.Text = "Tìm theo tên , số điện thoại hoặc mã đồng hồ nước";
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomers);
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
    }
}