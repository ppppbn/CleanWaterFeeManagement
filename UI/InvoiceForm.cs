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
    public partial class InvoiceForm: Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            List<HoaDon> people = new List<HoaDon>
            {
                new HoaDon(1, "001", "MaKH001", "Test1", 10, 10, 1, 10, 10),
                new HoaDon(2, "001", "MaKH001", "Test1", 20, 10, 2, 10, 10),
                new HoaDon(3, "003", "MaKH003", "Test3", 10, 10, 10, 10, 10)
            };

            // Bind the list to the DataGridView
            dataHoaDon.DataSource = new BindingList<HoaDon>(people);
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "DeleteColumn";
            btnDeleteColumn.HeaderText = "Xóa";
            btnDeleteColumn.Text = "Xóa";
            btnDeleteColumn.UseColumnTextForButtonValue = true;

            // Thêm cột vào DataGridView
            dataHoaDon.Columns.Add(btnDeleteColumn);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataHoaDon.Rows.Clear();

            List<HoaDon> people = new List<HoaDon>
            {
                new HoaDon(3, "003", "MaKH003", "Test3", 10, 10, 10, 10, 10)
            };
            dataHoaDon.DataSource = new BindingList<HoaDon>(people);
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (validateForm(txtMaKH.Text, txtMaNuoc.Text, numGia.Value, numHienTai.Value))
            {
                List<HoaDon> people = new List<HoaDon>
                {
                    new HoaDon(4, txtMaNuoc.Text, txtMaKH.Text, txtTenKH.Text, numTong.Value, numTongSD.Value, 07, numGia.Value, numThanhTien.Value)
                };

                dataHoaDon.DataSource = new BindingList<HoaDon>(people);
                MessageBox.Show("Tạo thành công hóa đơn");
                clearData();
            }
            //else
            //{
            //    MessageBox.Show("Tổng tháng hiện tại không được nhỏ hơn 0 !");
            //}
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
                        MessageBox.Show(row.Cells[1].Value.ToString());
                        clearData();
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
            List<HoaDon> people = new List<HoaDon>
            {
                new HoaDon(1, "001","MaKH001", "Test1",10,10,1,10,10),
                new HoaDon(2, "001","MaKH001", "Test1",20,10,2,10,10),
                new HoaDon(3, "003","MaKH003", "Test3",10,10,10,10,10)
            };
            if (txtMaKH.Text != "")
            {
                var groupedHoaDons = people
                    .Where(hd => hd.MaKhachHang == txtMaKH.Text)
                    .GroupBy(hd => hd.MaKhachHang)
                    .Select(group => new
                    {
                        MaKH = group.Key,
                        tongDaSuDung = group.Sum(hd => hd.TongDaSuDung)
                    }).ToList();

                if (groupedHoaDons.Count > 0)
                {
                    foreach (var group in groupedHoaDons)
                    {
                        numTongSD.Value = group.tongDaSuDung;
                    }
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
