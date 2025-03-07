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
            // WaterConsumptionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvWaterConsumption);
            Name = "WaterConsumptionForm";
            Text = "WaterConsumptionForm";
            Load += WaterConsumptionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWaterConsumption).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvWaterConsumption;
    }
}