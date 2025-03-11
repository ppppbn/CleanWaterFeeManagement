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
            dgvEmployees = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            labelName = new Label();
            labelUsername = new Label();
            labelPassword = new Label();
            labelRole = new Label();
            txtName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            roleManager = new RadioButton();
            roleStaff = new RadioButton();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(110, 131);
            dgvEmployees.Margin = new Padding(3, 4, 3, 4);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(693, 311);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.RowValidated += dgvEmployee_RowValidated;
            dgvEmployees.CellContentClick += dataGridView_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(110, 76);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(195, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(329, 76);
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
            label1.Location = new Point(110, 52);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 3;
            label1.Text = "Tìm theo tên tài khoản";
            txtName.PlaceholderText = "Nhập tài khoản";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(130, 501);
            labelName.Name = "labelName";
            labelName.Size = new Size(99, 20);
            labelName.TabIndex = 4;
            labelName.Text = "Tên nhân viên";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(130, 551);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(71, 20);
            labelUsername.TabIndex = 5;
            labelUsername.Text = "Tài khoản";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(131, 599);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 20);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Mật khẩu";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new Point(131, 652);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(52, 20);
            labelRole.TabIndex = 7;
            labelRole.Text = "Vai trò";
            // 
            // txtName
            // 
            txtName.Location = new Point(275, 494);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập tên nhân viên";
            txtName.Size = new Size(261, 27);
            txtName.TabIndex = 8;
            //txtName.TextChanged += textBox1_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(275, 544);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tài khoản";
            txtUsername.Size = new Size(261, 27);
            txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(275, 592);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Nhập mật khẩu";
            txtPassword.Size = new Size(261, 27);
            txtPassword.TabIndex = 10;
            // 
            // roleManager
            // 
            roleManager.AutoSize = true;
            roleManager.Location = new Point(447, 650);
            roleManager.Name = "roleManager";
            roleManager.Size = new Size(89, 24);
            roleManager.TabIndex = 11;
            roleManager.Text = "Manager";
            roleManager.UseVisualStyleBackColor = true;
            // 
            // roleStaff
            // 
            roleStaff.AutoSize = true;
            roleStaff.Checked = true;
            roleStaff.Location = new Point(275, 648);
            roleStaff.Name = "roleStaff";
            roleStaff.Size = new Size(61, 24);
            roleStaff.TabIndex = 12;
            roleStaff.TabStop = true;
            roleStaff.Text = "Staff";
            roleStaff.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(356, 703);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 13;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 787);
            Controls.Add(btnSave);
            Controls.Add(roleStaff);
            Controls.Add(roleManager);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtName);
            Controls.Add(labelRole);
            Controls.Add(labelPassword);
            Controls.Add(labelUsername);
            Controls.Add(labelName);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvEmployees);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            Load += EmployeeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private Label labelName;
        private Label labelUsername;
        private Label labelPassword;
        private Label labelRole;
        private TextBox txtName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private RadioButton roleManager;
        private RadioButton roleStaff;
        private Button btnSave;
    }
}