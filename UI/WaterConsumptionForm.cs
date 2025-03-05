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
    public partial class WaterConsumptionForm: Form
    {
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
            dgvWaterConsumption.DataSource = WaterConsumptionService.GetWaterConsumptions();
        }

        private void btnAddWaterConsumption_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId) ||
                !int.TryParse(txtRecordedMonth.Text, out int recordedMonth) ||
                !int.TryParse(txtRecordedYear.Text, out int recordedYear) ||
                !decimal.TryParse(txtConsumptionValue.Text, out decimal consumptionValue))
            {
                MessageBox.Show("Dữ liệu không phù hợp. Vui lòng kiểm tra định dạng số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int recordedBy = LoginForm.LoggedInUserId; // The logged-in employee ID

            bool success = WaterConsumptionService.RecordWaterConsumption(customerId, recordedMonth, recordedYear, consumptionValue, recordedBy);

            if (success)
            {
                MessageBox.Show("Ghi nhận chỉ số nước thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWaterConsumption();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditWaterConsumption_Click(object sender, EventArgs e)
        {
            if (dgvWaterConsumption.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hàng dữ liệu cần cập nhật.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(dgvWaterConsumption.SelectedRows[0].Cells["Id"].Value.ToString(), out int id) ||
                !int.TryParse(txtCustomerId.Text, out int customerId) ||
                !int.TryParse(txtRecordedMonth.Text, out int recordedMonth) ||
                !int.TryParse(txtRecordedYear.Text, out int recordedYear) ||
                !decimal.TryParse(txtConsumptionValue.Text, out decimal consumptionValue))
            {
                MessageBox.Show("Dữ liệu không phù hợp. Vui lòng kiểm tra định dạng số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int recordedBy = LoginForm.LoggedInUserId;

            bool success = WaterConsumptionService.EditWaterConsumption(id, customerId, recordedMonth, recordedYear, consumptionValue, recordedBy);

            if (success)
            {
                MessageBox.Show("Dữ liệu được cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWaterConsumption();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
