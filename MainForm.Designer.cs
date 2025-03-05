namespace CleanWaterFeeManagement
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
            btnTestConnection = new Button();
            testAddCustomer = new Button();
            testAddEmployee = new Button();
            btnAddWaterConsumption = new Button();
            btnAddInvoice = new Button();
            SuspendLayout();
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(100, 50);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(200, 50);
            btnTestConnection.TabIndex = 0;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // testAddCustomer
            // 
            testAddCustomer.Location = new Point(474, 50);
            testAddCustomer.Name = "testAddCustomer";
            testAddCustomer.Size = new Size(200, 50);
            testAddCustomer.TabIndex = 1;
            testAddCustomer.Text = "Test Add Customer";
            testAddCustomer.UseVisualStyleBackColor = true;
            testAddCustomer.Click += btnAddCustomer_Click;
            // 
            // testAddEmployee
            // 
            testAddEmployee.Location = new Point(100, 167);
            testAddEmployee.Name = "testAddEmployee";
            testAddEmployee.Size = new Size(200, 50);
            testAddEmployee.TabIndex = 2;
            testAddEmployee.Text = "Test Add Employee";
            testAddEmployee.UseVisualStyleBackColor = true;
            testAddEmployee.Click += btnAddEmployee_Click;
            // 
            // btnAddWaterConsumption
            // 
            btnAddWaterConsumption.Location = new Point(474, 167);
            btnAddWaterConsumption.Name = "btnAddWaterConsumption";
            btnAddWaterConsumption.Size = new Size(200, 50);
            btnAddWaterConsumption.TabIndex = 3;
            btnAddWaterConsumption.Text = "Test Add Water Consumption";
            btnAddWaterConsumption.UseVisualStyleBackColor = true;
            btnAddWaterConsumption.Click += btnRecordWaterConsumption_Click;
            // 
            // btnAddInvoice
            // 
            btnAddInvoice.Location = new Point(100, 281);
            btnAddInvoice.Name = "btnAddInvoice";
            btnAddInvoice.Size = new Size(200, 50);
            btnAddInvoice.TabIndex = 4;
            btnAddInvoice.Text = "Test Add Invoice";
            btnAddInvoice.UseVisualStyleBackColor = true;
            btnAddInvoice.Click += btnGenerateInvoice_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddInvoice);
            Controls.Add(btnAddWaterConsumption);
            Controls.Add(testAddEmployee);
            Controls.Add(testAddCustomer);
            Controls.Add(btnTestConnection);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnTestConnection;
        private Button testAddCustomer;
        private Button testAddEmployee;
        private Button btnAddWaterConsumption;
        private Button btnAddInvoice;
    }
}
