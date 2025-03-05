namespace CleanWaterFeeManagement.UI
{
    partial class LoginForm
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
            username = new Label();
            password = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            login = new Button();
            loginAsGuest = new Button();
            title = new Label();
            SuspendLayout();
            // 
            // username
            // 
            username.AutoSize = true;
            username.Location = new Point(313, 117);
            username.Name = "username";
            username.Size = new Size(85, 15);
            username.TabIndex = 0;
            username.Text = "Tên đăng nhập";
            // 
            // password
            // 
            password.AutoSize = true;
            password.Location = new Point(313, 175);
            password.Name = "password";
            password.Size = new Size(57, 15);
            password.TabIndex = 1;
            password.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(313, 135);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(167, 23);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(313, 193);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(167, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // login
            // 
            login.Location = new Point(330, 236);
            login.Name = "login";
            login.Size = new Size(133, 23);
            login.TabIndex = 4;
            login.Text = "Đăng nhập";
            login.UseVisualStyleBackColor = true;
            login.Click += btnLogin_click;
            // 
            // loginAsGuest
            // 
            loginAsGuest.Location = new Point(330, 274);
            loginAsGuest.Name = "loginAsGuest";
            loginAsGuest.Size = new Size(133, 23);
            loginAsGuest.TabIndex = 5;
            loginAsGuest.Text = "Bỏ qua (Khách hàng)";
            loginAsGuest.UseVisualStyleBackColor = true;
            loginAsGuest.Click += btnGuest_click;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 14F);
            title.Location = new Point(272, 34);
            title.Name = "title";
            title.Size = new Size(263, 25);
            title.TabIndex = 6;
            title.Text = "Quản lí thu phí cấp nước sạch";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(title);
            Controls.Add(loginAsGuest);
            Controls.Add(login);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(password);
            Controls.Add(username);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label username;
        private Label password;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button login;
        private Button loginAsGuest;
        private Label title;
    }
}