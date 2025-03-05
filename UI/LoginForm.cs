using System;
using System.Data;
using System.Windows.Forms;
using CleanWaterFeeManagement.BusinessLogic;
using CleanWaterFeeManagement.Models;

namespace CleanWaterFeeManagement.UI
{
    public partial class LoginForm : Form
    {
        public static string LoggedInRole = "";
        public static int LoggedInUserId = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Employee user = EmployeeService.AuthenticateUser(username, password);

            if (user != null)
            {
                LoggedInUserId = user.Id;
                LoggedInRole = user.Role;

                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuest_click(object sender, EventArgs e)
        {
            LoggedInRole = "Customer"; // Guest will be treated as Customer
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
