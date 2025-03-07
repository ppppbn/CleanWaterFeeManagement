using CleanWaterFeeManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanWaterFeeManagement.UI
{
    public partial class WaterConsumptionForm : Form
    {
        private DataTable waterConsumptionTable;

        public WaterConsumptionForm()
        {
            InitializeComponent();
        }

        private void WaterConsumptionForm_Load(object sender, EventArgs e)
        {
            LoadWaterConsumption();
        }

        private void LoadWaterConsumption()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadWaterConsumption)); // ✅ Ensure UI safety
                return;
            }

            // Reinitialize the data adapter when the form is reopened
            WaterConsumptionService.InitializeDataAdapter();

            waterConsumptionTable = WaterConsumptionService.GetWaterConsumptionData();

            dgvWaterConsumption.DataSource = null; // ✅ Clear binding before reloading
            dgvWaterConsumption.DataSource = waterConsumptionTable;

            waterConsumptionTable.AcceptChanges(); // ✅ Mark initial data as clean
        }

        private void dgvWaterConsumption_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var isSaving = false;
                // Skip updates when loading the form
                if (waterConsumptionTable == null || waterConsumptionTable.GetChanges() == null)
                {
                    return;
                }

                // Prevent recursive updates
                if (!isSaving)
                {
                    isSaving = true;
                    WaterConsumptionService.SaveWaterConsumptionChanges(waterConsumptionTable);
                    MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // ✅ Defer the UI update to prevent conflicts
                    BeginInvoke(new Action(() => LoadWaterConsumption()));
                    isSaving = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
