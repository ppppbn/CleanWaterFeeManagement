namespace CleanWaterFeeManagement.UI
{
    partial class EmployeeForm
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
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            dgvEmployees = new DataGridView();
            btnAddEmployee = new Button();
            btnEditEmployee = new Button();
            txtName = new TextBox();
            label1 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtRole = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(96, 98);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(606, 233);
            dgvEmployees.TabIndex = 0;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(96, 48);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(112, 23);
            btnAddEmployee.TabIndex = 1;
            btnAddEmployee.Text = "Thêm nhân viên";
            btnAddEmployee.UseVisualStyleBackColor = true;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.Location = new Point(232, 48);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(112, 23);
            btnEditEmployee.TabIndex = 2;
            btnEditEmployee.Text = "Sửa nhân viên";
            btnEditEmployee.UseVisualStyleBackColor = true;
            btnEditEmployee.Click += btnEditEmployee_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(96, 368);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 350);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 4;
            label1.Text = "Tên";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(244, 368);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(397, 368);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 6;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(557, 368);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(100, 23);
            txtRole.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(244, 350);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 8;
            label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(397, 350);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 9;
            label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(557, 350);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 10;
            label4.Text = "Vai trò";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtRole);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(btnEditEmployee);
            Controls.Add(btnAddEmployee);
            Controls.Add(dgvEmployees);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private Button btnAddEmployee;
        private Button btnEditEmployee;
        private TextBox txtName;
        private Label label1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtRole;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}