namespace CleanWaterFeeManagement.UI
{
    partial class WaterConsumptionForm
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
            this.Load += new System.EventHandler(this.WaterConsumptionForm_Load);
            dgvWaterConsumption = new DataGridView();
            btnAddWaterConsumption = new Button();
            btnEditWaterConsumption = new Button();
            label1 = new Label();
            txtCustomerId = new TextBox();
            txtRecordedMonth = new TextBox();
            txtRecordedYear = new TextBox();
            txtConsumptionValue = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvWaterConsumption).BeginInit();
            SuspendLayout();
            // 
            // dgvWaterConsumption
            // 
            dgvWaterConsumption.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWaterConsumption.Location = new Point(104, 95);
            dgvWaterConsumption.Name = "dgvWaterConsumption";
            dgvWaterConsumption.Size = new Size(572, 236);
            dgvWaterConsumption.TabIndex = 0;
            // 
            // btnAddWaterConsumption
            // 
            btnAddWaterConsumption.Location = new Point(104, 57);
            btnAddWaterConsumption.Name = "btnAddWaterConsumption";
            btnAddWaterConsumption.Size = new Size(123, 23);
            btnAddWaterConsumption.TabIndex = 1;
            btnAddWaterConsumption.Text = "Thêm chỉ số nước";
            btnAddWaterConsumption.UseVisualStyleBackColor = true;
            btnAddWaterConsumption.Click += btnAddWaterConsumption_Click;
            // 
            // btnEditWaterConsumption
            // 
            btnEditWaterConsumption.Location = new Point(256, 57);
            btnEditWaterConsumption.Name = "btnEditWaterConsumption";
            btnEditWaterConsumption.Size = new Size(130, 23);
            btnEditWaterConsumption.TabIndex = 2;
            btnEditWaterConsumption.Text = "Cập nhật chỉ số nước";
            btnEditWaterConsumption.TextAlign = ContentAlignment.BottomLeft;
            btnEditWaterConsumption.UseVisualStyleBackColor = true;
            btnEditWaterConsumption.Click += btnEditWaterConsumption_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 345);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "Mã KH";
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(104, 363);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(100, 23);
            txtCustomerId.TabIndex = 4;
            // 
            // txtRecordedMonth
            // 
            txtRecordedMonth.Location = new Point(247, 363);
            txtRecordedMonth.Name = "txtRecordedMonth";
            txtRecordedMonth.Size = new Size(100, 23);
            txtRecordedMonth.TabIndex = 5;
            // 
            // txtRecordedYear
            // 
            txtRecordedYear.Location = new Point(394, 363);
            txtRecordedYear.Name = "txtRecordedYear";
            txtRecordedYear.Size = new Size(100, 23);
            txtRecordedYear.TabIndex = 6;
            // 
            // txtConsumptionValue
            // 
            txtConsumptionValue.Location = new Point(543, 363);
            txtConsumptionValue.Name = "txtConsumptionValue";
            txtConsumptionValue.Size = new Size(100, 23);
            txtConsumptionValue.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(247, 345);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Tháng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(394, 345);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 9;
            label3.Text = "Năm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(543, 345);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 10;
            label4.Text = "Chỉ số nước";
            // 
            // WaterConsumptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtConsumptionValue);
            Controls.Add(txtRecordedYear);
            Controls.Add(txtRecordedMonth);
            Controls.Add(txtCustomerId);
            Controls.Add(label1);
            Controls.Add(btnEditWaterConsumption);
            Controls.Add(btnAddWaterConsumption);
            Controls.Add(dgvWaterConsumption);
            Name = "WaterConsumptionForm";
            Text = "WaterConsumptionForm";
            ((System.ComponentModel.ISupportInitialize)dgvWaterConsumption).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvWaterConsumption;
        private Button btnAddWaterConsumption;
        private Button btnEditWaterConsumption;
        private Label label1;
        private TextBox txtCustomerId;
        private TextBox txtRecordedMonth;
        private TextBox txtRecordedYear;
        private TextBox txtConsumptionValue;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}