namespace CleanWaterFeeManagement.UI
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtSearchMa = new TextBox();
            btnSearch = new Button();
            dataHoaDon = new DataGridView();
            btnCreateInvoice = new Button();
            txtMaNuoc = new TextBox();
            txtTenKH = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numHienTai = new NumericUpDown();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            txtMaKH = new TextBox();
            btnTimKH = new Button();
            label7 = new Label();
            numTongSD = new NumericUpDown();
            numTong = new NumericUpDown();
            label8 = new Label();
            numGia = new NumericUpDown();
            numThanhTien = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHienTai).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTongSD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numThanhTien).BeginInit();
            SuspendLayout();
            // 
            // txtSearchMa
            // 
            txtSearchMa.Location = new Point(512, 22);
            txtSearchMa.Name = "txtSearchMa";
            txtSearchMa.Size = new Size(222, 23);
            txtSearchMa.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(740, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataHoaDon
            // 
            dataHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataHoaDon.Location = new Point(12, 48);
            dataHoaDon.Name = "dataHoaDon";
            dataHoaDon.ReadOnly = true;
            dataHoaDon.Size = new Size(1059, 268);
            dataHoaDon.TabIndex = 2;
            dataHoaDon.CellContentClick += dataHoaDon_CellContentClick;
            // 
            // btnCreateInvoice
            // 
            btnCreateInvoice.Location = new Point(500, 531);
            btnCreateInvoice.Name = "btnCreateInvoice";
            btnCreateInvoice.Size = new Size(102, 23);
            btnCreateInvoice.TabIndex = 3;
            btnCreateInvoice.Text = "Tạo Hóa Đơn";
            btnCreateInvoice.UseVisualStyleBackColor = true;
            btnCreateInvoice.Click += btnCreateInvoice_Click;
            // 
            // txtMaNuoc
            // 
            txtMaNuoc.Location = new Point(418, 360);
            txtMaNuoc.Name = "txtMaNuoc";
            txtMaNuoc.ReadOnly = true;
            txtMaNuoc.Size = new Size(132, 23);
            txtMaNuoc.TabIndex = 4;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(418, 412);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(132, 23);
            txtTenKH.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 363);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 8;
            label1.Text = "Mã đồng hồ nước";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(285, 389);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 9;
            label2.Text = "Mã khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 440);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 10;
            label3.Text = "Tổng số nước ĐSD";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(285, 469);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 12;
            label4.Text = "Tổng số nước tháng HT";
            // 
            // numHienTai
            // 
            numHienTai.Location = new Point(418, 467);
            numHienTai.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numHienTai.Name = "numHienTai";
            numHienTai.Size = new Size(137, 23);
            numHienTai.TabIndex = 13;
            numHienTai.ValueChanged += numHienTai_ValueChanged;
            numHienTai.KeyUp += numHienTai_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(285, 495);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 15;
            label5.Text = "Tổng";
            // 
            // button1
            // 
            button1.Location = new Point(821, 19);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 16;
            button1.Text = "Xuất hóa đơn";
            button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(285, 412);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 18;
            label6.Text = "Tên khách hàng";
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(418, 386);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(132, 23);
            txtMaKH.TabIndex = 17;
            txtMaKH.KeyUp += txtMaKH_TextChanged;
            // 
            // btnTimKH
            // 
            btnTimKH.Location = new Point(556, 386);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(102, 23);
            btnTimKH.TabIndex = 19;
            btnTimKH.Text = "Tìm khách hàng";
            btnTimKH.UseVisualStyleBackColor = true;
            btnTimKH.Click += btnTimKH_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(365, 25);
            label7.Name = "label7";
            label7.Size = new Size(141, 15);
            label7.TabIndex = 20;
            label7.Text = "Tìm kiếm mã khách hàng";
            // 
            // numTongSD
            // 
            numTongSD.Location = new Point(418, 438);
            numTongSD.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numTongSD.Name = "numTongSD";
            numTongSD.ReadOnly = true;
            numTongSD.Size = new Size(137, 23);
            numTongSD.TabIndex = 21;
            numTongSD.ValueChanged += numHienTai_ValueChanged;
            // 
            // numTong
            // 
            numTong.Location = new Point(418, 493);
            numTong.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numTong.Name = "numTong";
            numTong.ReadOnly = true;
            numTong.Size = new Size(137, 23);
            numTong.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(586, 448);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 25;
            label8.Text = "Giá/Khối";
            // 
            // numGia
            // 
            numGia.Location = new Point(576, 469);
            numGia.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(137, 23);
            numGia.TabIndex = 26;
            numGia.ValueChanged += numGia_ValueChanged;
            numGia.KeyUp += numGia_ValueChanged;
            // 
            // numThanhTien
            // 
            numThanhTien.Location = new Point(734, 469);
            numThanhTien.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numThanhTien.Name = "numThanhTien";
            numThanhTien.ReadOnly = true;
            numThanhTien.Size = new Size(137, 23);
            numThanhTien.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(744, 448);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 27;
            label9.Text = "Thành tiền";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(895, 320);
            label10.Name = "label10";
            label10.Size = new Size(95, 15);
            label10.TabIndex = 29;
            label10.Text = "Đơn vị tính: Khối";
            // 
            // InvoiceForm
            // 
            ClientSize = new Size(1083, 582);
            Controls.Add(label10);
            Controls.Add(numThanhTien);
            Controls.Add(label9);
            Controls.Add(numGia);
            Controls.Add(label8);
            Controls.Add(numTong);
            Controls.Add(numTongSD);
            Controls.Add(label7);
            Controls.Add(btnTimKH);
            Controls.Add(label6);
            Controls.Add(txtMaKH);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(numHienTai);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTenKH);
            Controls.Add(txtMaNuoc);
            Controls.Add(btnCreateInvoice);
            Controls.Add(dataHoaDon);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchMa);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InvoiceForm";
            Text = "Quản Lý Hóa Đơn";
            ((System.ComponentModel.ISupportInitialize)dataHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHienTai).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTongSD).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTong).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numThanhTien).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.TextBox txtSearchMa;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataHoaDon;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.TextBox txtMaNuoc;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numHienTai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Button btnTimKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numTongSD;
        private System.Windows.Forms.NumericUpDown numTong;
        private Label label8;
        private NumericUpDown numGia;
        private NumericUpDown numThanhTien;
        private Label label9;
        private Label label10;
    }
}