namespace CleanWaterFeeManagement.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            quảnLíToolStripMenuItem = new ToolStripMenuItem();
            employeesToolStripMenuItem = new ToolStripMenuItem();
            customersToolStripMenuItem = new ToolStripMenuItem();
            waterConsumptionToolStripMenuItem = new ToolStripMenuItem();
            invoicesToolStripMenuItem = new ToolStripMenuItem();
            báoCáoToolStripMenuItem = new ToolStripMenuItem();
            generateReportsToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, quảnLíToolStripMenuItem, báoCáoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // quảnLíToolStripMenuItem
            // 
            quảnLíToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { employeesToolStripMenuItem, customersToolStripMenuItem, waterConsumptionToolStripMenuItem, invoicesToolStripMenuItem });
            quảnLíToolStripMenuItem.Name = "quảnLíToolStripMenuItem";
            quảnLíToolStripMenuItem.Size = new Size(57, 20);
            quảnLíToolStripMenuItem.Text = "Quản lí";
            // 
            // employeesToolStripMenuItem
            // 
            employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            employeesToolStripMenuItem.Size = new Size(185, 22);
            employeesToolStripMenuItem.Text = "Nhân viên";
            employeesToolStripMenuItem.Click += employeesToolStripMenuItem_Click;
            // 
            // customersToolStripMenuItem
            // 
            customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            customersToolStripMenuItem.Size = new Size(185, 22);
            customersToolStripMenuItem.Text = "Khách hàng";
            customersToolStripMenuItem.Click += customersToolStripMenuItem_Click;
            // 
            // waterConsumptionToolStripMenuItem
            // 
            waterConsumptionToolStripMenuItem.Name = "waterConsumptionToolStripMenuItem";
            waterConsumptionToolStripMenuItem.Size = new Size(185, 22);
            waterConsumptionToolStripMenuItem.Text = "Chỉ số đồng hồ nước";
            waterConsumptionToolStripMenuItem.Click += waterConsumptionToolStripMenuItem_Click;
            // 
            // invoicesToolStripMenuItem
            // 
            invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            invoicesToolStripMenuItem.Size = new Size(185, 22);
            invoicesToolStripMenuItem.Text = "Hóa đơn";
            invoicesToolStripMenuItem.Click += invoicesToolStripMenuItem_Click;
            // 
            // báoCáoToolStripMenuItem
            // 
            báoCáoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateReportsToolStripMenuItem });
            báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            báoCáoToolStripMenuItem.Size = new Size(61, 20);
            báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // generateReportsToolStripMenuItem
            // 
            generateReportsToolStripMenuItem.Name = "generateReportsToolStripMenuItem";
            generateReportsToolStripMenuItem.Size = new Size(138, 22);
            generateReportsToolStripMenuItem.Text = "Tạo báo cáo";
            generateReportsToolStripMenuItem.Click += generateReportsToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(228, 171);
            label1.Name = "label1";
            label1.Size = new Size(334, 25);
            label1.TabIndex = 6;
            label1.Text = "Hãy chọn chức năng ở menu phía trên";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem quảnLíToolStripMenuItem;
        private ToolStripMenuItem employeesToolStripMenuItem;
        private ToolStripMenuItem customersToolStripMenuItem;
        private ToolStripMenuItem waterConsumptionToolStripMenuItem;
        private ToolStripMenuItem invoicesToolStripMenuItem;
        private ToolStripMenuItem báoCáoToolStripMenuItem;
        private ToolStripMenuItem generateReportsToolStripMenuItem;
        private Label label1;
    }
}
