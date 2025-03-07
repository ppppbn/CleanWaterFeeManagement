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
            dgvWaterConsumption = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
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
            dgvWaterConsumption.RowValidated += dgvWaterConsumption_RowValidated;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(104, 66);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(170, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(298, 65);
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
            label1.Location = new Point(104, 48);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 4;
            label1.Text = "Tìm theo mã khách hàng";
            // 
            // WaterConsumptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvWaterConsumption);
            Name = "WaterConsumptionForm";
            Text = "WaterConsumptionForm";
            Load += WaterConsumptionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWaterConsumption).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvWaterConsumption;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
    }
}