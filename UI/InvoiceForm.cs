using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;

namespace CleanWaterFeeManagement.UI
{
    public partial class InvoiceForm : Form
    {
        private string connectionString;

        public InvoiceForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            HoaDonDAL();

            List<HoaDon> hoaDon = GetHoaDons();

        }

        private void HoaDonDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private List<HoaDon> GetHoaDons()
        {
            List<HoaDon> hoaDons = new List<HoaDon>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tblHoaDon";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HoaDon hd = new HoaDon
                    (
                        Convert.ToInt32(reader["MaHoaDon"]),
                        reader["MaDongHoNuoc"].ToString(),
                        reader["MaKhachHang"].ToString(),
                        reader["TenKhachHang"].ToString(),
                        Convert.ToInt32(reader["TongSoNuocDSD"]),
                        Convert.ToInt32(reader["TongSoNuocThangHT"]),
                        Convert.ToInt32(reader["Thang"]),
                        Convert.ToDecimal(reader["GiaKhoi"]),
                        Convert.ToDecimal(reader["ThanhTien"])
                    );
                    hoaDons.Add(hd);
                }
                reader.Close();
            }
            // Bind the list to the DataGridView
            dataHoaDon.DataSource = new BindingList<HoaDon>(hoaDons);
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "DeleteColumn";
            btnDeleteColumn.HeaderText = "Xóa";
            btnDeleteColumn.Text = "Xóa";
            btnDeleteColumn.UseColumnTextForButtonValue = true;

            // Thêm cột vào DataGridView
            dataHoaDon.Columns.Add(btnDeleteColumn);

            return hoaDons;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataHoaDon.Rows.Clear();

            List<HoaDon> hoaDon = SearchHoaDons(txtSearchMa.Text);
            dataHoaDon.DataSource = new BindingList<HoaDon>(hoaDon);
        }

        public List<HoaDon> SearchHoaDons(string maKhachHang)
        {
            List<HoaDon> hoaDons = new List<HoaDon>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query;
                SqlCommand cmd;

                if (maKhachHang == "")
                {
                    query = @"SELECT * FROM tblHoaDon";
                    cmd = new SqlCommand(query, conn);
                }
                else
                {
                    query = @"SELECT * FROM tblHoaDon WHERE MaKhachHang = @MaKhachHang";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                }

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HoaDon hd = new HoaDon
                    (
                        Convert.ToInt32(reader["MaHoaDon"]),
                        reader["MaDongHoNuoc"].ToString(),
                        reader["MaKhachHang"].ToString(),
                        reader["TenKhachHang"].ToString(),
                        Convert.ToInt32(reader["TongSoNuocDSD"]),
                        Convert.ToInt32(reader["TongSoNuocThangHT"]),
                        Convert.ToInt32(reader["Thang"]),
                        Convert.ToDecimal(reader["GiaKhoi"]),
                        Convert.ToDecimal(reader["ThanhTien"])
                    );
                    hoaDons.Add(hd);
                }
                reader.Close();
            }
            return hoaDons;
        }

        private HoaDon HoaDonData(string maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT KH.MaKhachHang, KH.TenKhachHang, KH.MaDongHoNuoc, 
                   COALESCE(SUM(HD.TongSoNuocDSD), 0) AS TongSoNuocDaSuDung 
            FROM tblKhachHang KH 
            LEFT JOIN tblHoaDon HD ON KH.MaKhachHang = HD.MaKhachHang 
            WHERE KH.MaKhachHang = @MaKhachHang
            GROUP BY KH.MaKhachHang, KH.TenKhachHang, KH.MaDongHoNuoc";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    HoaDon hd = new HoaDon
                    (
                        0,
                        reader["MaDongHoNuoc"].ToString(),
                        reader["MaKhachHang"].ToString(),
                        reader["TenKhachHang"].ToString(),
                        Convert.ToInt32(reader["TongSoNuocDaSuDung"]),
                        0,
                        0,
                        0,
                        0
                    );
                    reader.Close();
                    return hd;
                }

                reader.Close();
            }

            return null;
        }


        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (validateForm(txtMaKH.Text, txtMaNuoc.Text, numGia.Value, numHienTai.Value))
            {
                HoaDon hoaDon = new HoaDon(4, txtMaNuoc.Text, txtMaKH.Text, txtTenKH.Text, numTong.Value, numTongSD.Value, 03, numGia.Value, numThanhTien.Value);

                AddHoaDon(hoaDon);
                MessageBox.Show("Tạo thành công hóa đơn");
                clearData();
                btnSearch_Click(sender, e);
            }
        }

        private bool AddHoaDon(HoaDon hoaDon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO tblHoaDon (MaDongHoNuoc, MaKhachHang, TenKhachHang, Thang, TongSoNuocDSD, TongSoNuocThangHT, GiaKhoi, ThanhTien) 
                         VALUES (@MaDongHoNuoc, @MaKhachHang, @TenKhachHang, @Thang, @TongSoNuocDSD, @TongSoNuocThangHT, @GiaKhoi, @ThanhTien)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDongHoNuoc", hoaDon.MaDongHo);
                cmd.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
                cmd.Parameters.AddWithValue("@TenKhachHang", hoaDon.TenKhachHang);
                cmd.Parameters.AddWithValue("@Thang", hoaDon.Thang);
                cmd.Parameters.AddWithValue("@TongSoNuocDSD", hoaDon.TongDaSuDung);
                cmd.Parameters.AddWithValue("@TongSoNuocThangHT", hoaDon.TongThangHienTai);
                cmd.Parameters.AddWithValue("@GiaKhoi", hoaDon.GiaKhoiNuoc);
                cmd.Parameters.AddWithValue("@ThanhTien", hoaDon.ThanhTien);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        private bool DeleteHoaDon(string maHoaDon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"Delete tblHoaDon where MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        private void dataHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataHoaDon.Columns["DeleteColumn"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataHoaDon.Rows[e.RowIndex];
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?", "Xóa", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        //dataHoaDon.Rows.RemoveAt(e.RowIndex);
                        DeleteHoaDon(row.Cells[1].Value.ToString());
                        MessageBox.Show("Xóa thành công mã hóa đơn : " + row.Cells[1].Value.ToString());
                        clearData();
                        btnSearch_Click(sender, e);
                    }
                }
                else
                {
                    DataGridViewRow row = dataHoaDon.Rows[e.RowIndex];
                    string maDH = row.Cells[2].Value.ToString();
                    string maKH = row.Cells[3].Value.ToString();
                    string tenKH = row.Cells[4].Value.ToString();
                    string tongDaSD = row.Cells[5].Value.ToString();

                    txtMaNuoc.Text = maDH;
                    txtMaKH.Text = maKH;
                    txtTenKH.Text = tenKH;

                    decimal tongCong = 0;
                    foreach (DataGridViewRow r in dataHoaDon.Rows)
                    {
                        if (!r.IsNewRow && r.Cells[3].Value.ToString() == maKH)
                        {
                            decimal currentTongDaSD = 0;
                            if (decimal.TryParse(r.Cells[5].Value.ToString(), out currentTongDaSD))
                            {
                                tongCong += currentTongDaSD;
                            }
                        }
                    }

                    numTongSD.Value = tongCong;
                }

            }

        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {

                HoaDon hoaDon = HoaDonData(txtMaKH.Text);
                if (hoaDon != null)
                {
                    numTongSD.Value = hoaDon.TongDaSuDung;
                    txtTenKH.Text = hoaDon.TenKhachHang;
                    txtMaNuoc.Text = hoaDon.MaDongHo;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn với mã khách hàng này.");
                    clearData();
                }
            }
            else
            {
                MessageBox.Show("Mã khách hàng không được để trống");
                clearData();
            }
        }


        private void numHienTai_ValueChanged(object sender, EventArgs e)
        {
            if (numHienTai.Value < 1000)
            {
                numTong.Value = numTongSD.Value + numHienTai.Value;
                numThanhTien.Value = numHienTai.Value * numGia.Value;
            }
            else
            {
                numHienTai.Value = 999;
                numTong.Value = numTongSD.Value + numHienTai.Value;
                numThanhTien.Value = numHienTai.Value * numGia.Value;
            }

        }

        private void numGia_ValueChanged(object sender, EventArgs e)
        {

            if (numGia.Value < 100000)
            {
                numThanhTien.Value = numHienTai.Value * numGia.Value;
                numTong.Value = numTongSD.Value + numHienTai.Value;
            }
            else
            {
                numGia.Value = 99999;
                numThanhTien.Value = numHienTai.Value * numGia.Value;
                numTong.Value = numTongSD.Value + numHienTai.Value;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = "HoaDon.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            DataTable dt = new DataTable();

                            foreach (DataGridViewColumn col in dataHoaDon.Columns)
                            {
                                if (col.Visible && col.Name != "DeleteColumn")
                                    dt.Columns.Add(col.HeaderText);
                            }

                            foreach (DataGridViewRow row in dataHoaDon.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    DataRow dr = dt.NewRow();
                                    for (int i = 1; i < dt.Columns.Count+1; i++)
                                    {
                                        dr[i-1] = row.Cells[i].Value ?? "";
                                    }
                                    dt.Rows.Add(dr);
                                }
                            }

                            wb.Worksheets.Add(dt, "Hóa Đơn");
                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void clearData()
        {
            txtMaNuoc.Text = "";
            txtTenKH.Text = "";
            numGia.Value = 0;
            numHienTai.Value = 0;
            numThanhTien.Value = 0;
            numTong.Value = 0;
            numTongSD.Value = 0;

        }

        private bool validateForm(string maKH, string maDH, decimal gia, decimal tongHienTai)
        {
            if (maKH == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống !");
                return false;
            }

            if (maDH == "")
            {
                MessageBox.Show("Mã đồng hồ không được để trống !");
                return false;
            }

            if (tongHienTai < 1)
            {
                MessageBox.Show("Tổng số nước hiện tại đã sử dụng lớn hơn 0 !");
                return false;
            }

            if (gia < 1)
            {
                MessageBox.Show("Giá/Khối phải lớn hơn 0 !");
                return false;
            }
            return true;
        }

        private void txtMaKH_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                clearData();
        }

        private void txtSearchMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKH.PerformClick();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
    public class HoaDon
    {
        public int ID { get; set; }
        public string MaDongHo { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public decimal TongDaSuDung { get; set; }
        public decimal TongThangHienTai { get; set; }
        public decimal Thang { get; set; }
        public decimal GiaKhoiNuoc { get; set; }
        public decimal ThanhTien { get; set; }

        public HoaDon(int id, string maDongHo, string maKhachHang, string tenKhachHang, decimal tongDaSuDung, decimal tongThangHienTai, decimal thang, decimal giaKhoiNuoc, decimal thanhTien)
        {
            ID = id;
            MaDongHo = maDongHo;
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            TongDaSuDung = tongDaSuDung;
            TongThangHienTai = tongThangHienTai;
            Thang = thang;
            GiaKhoiNuoc = giaKhoiNuoc;
            ThanhTien = thanhTien;
        }
    }
}
