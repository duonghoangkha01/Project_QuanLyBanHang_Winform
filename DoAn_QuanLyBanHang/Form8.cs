using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_QuanLyBanHang
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        // Chuỗi kết nối
        string strConnectionString = "Data Source=HOANGKHA;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtHoaDon
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtKhachHang
        SqlDataAdapter daKhachHang = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;
        // Đối tượng đưa dữ liệu vào DataTable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;

        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtHoaDon.Dispose();
            dtHoaDon = null;
            // Hủy kết nối
            conn = null;
        }

        

        private void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtKhachHang
                daKhachHang = new SqlDataAdapter("SELECT * FROM KHACHHANG", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvHOADON.Columns["TenCty"] as DataGridViewComboBoxColumn).DataSource = dtKhachHang;
                (dgvHOADON.Columns["TenCty"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
                (dgvHOADON.Columns["TenCty"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";
                // Vận chuyển dữ liệu vào DataTable dtNhanVien
                daNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvHOADON.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHOADON.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "Ten";
                (dgvHOADON.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";
                // Vận chuyển dữ liệu vào DataTable dtHoaDon
                daHoaDon = new SqlDataAdapter("SELECT * FROM HOADON", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvHOADON.DataSource = dtHoaDon;
                // Xóa trống các đối tượng trong Panel
                this.txtMaHD.ResetText();
                this.txtNgayLapHoaDon.ResetText();
                this.txtNgayNhanHang.ResetText();
                this.cboMaNV.SelectedItem = null;
                this.cboMaKH.SelectedItem = null;
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuyBo.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table KHACHHANG.Lỗi rồi!!!");
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvHOADON.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strMAHD =
                dgvHOADON.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From HoaDon Where MaHD = '" + strMAHD + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã xóa xong!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaHD.ResetText();
            this.txtNgayLapHoaDon.ResetText();
            this.txtNgayNhanHang.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa dữ liệu lên ComboBox
            this.cboMaKH.DataSource = dtKhachHang;
            this.cboMaKH.DisplayMember = "TenCty";
            this.cboMaKH.ValueMember = "MaKH";
            this.cboMaKH.SelectedItem = null;

            this.cboMaNV.DataSource = dtNhanVien;
            this.cboMaNV.DisplayMember = "Ten";
            this.cboMaNV.ValueMember = "MaNV";
            this.cboMaNV.SelectedItem = null;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaHD.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Đưa dữ liệu lên ComboBox
            this.cboMaKH.DataSource = dtKhachHang;
            this.cboMaKH.DisplayMember = "TenCty";
            this.cboMaKH.ValueMember = "MaKH";

            this.cboMaNV.DataSource = dtNhanVien;
            this.cboMaNV.DisplayMember = "Ten";
            this.cboMaNV.ValueMember = "MaNV";
            // Cho phép thao tác trên Panel
            this.panel.Enabled = true;
            // Thứ tự dòng hiện hành
            int r = dgvHOADON.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaHD.Text = dgvHOADON.Rows[r].Cells[0].Value.ToString();
            this.cboMaKH.SelectedValue = dgvHOADON.Rows[r].Cells[1].Value.ToString();
            this.cboMaNV.SelectedValue = dgvHOADON.Rows[r].Cells[2].Value.ToString();
            this.txtNgayLapHoaDon.Text = dgvHOADON.Rows[r].Cells[3].Value.ToString();
            this.txtNgayNhanHang.Text = dgvHOADON.Rows[r].Cells[4].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuyBo.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaHD.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into HoaDon Values(" + "'" +
                    this.txtMaHD.Text.ToString() + "','" +
                    this.cboMaKH.SelectedValue.ToString() + "','" +
                    this.cboMaNV.SelectedValue.ToString() + "','" +
                    this.txtNgayLapHoaDon.Text.ToString() + "','" +
                    this.txtNgayNhanHang.Text.ToString() + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvHOADON.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMAHD =
                    dgvHOADON.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update HoaDon Set MaKH = '" +
                    this.cboMaKH.SelectedValue.ToString() + "', MaNV ='" +
                    this.cboMaNV.SelectedValue.ToString() + "', NgayLapHD = '" +
                    this.txtNgayLapHoaDon.Text.ToString() + "', NgayNhanHang = '" +
                    this.txtNgayNhanHang.Text.ToString() + "' Where MaHD = '" + strMAHD + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            // Đóng kết nối
            conn.Close();

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtMaHD.ResetText();
            this.txtNgayLapHoaDon.ResetText();
            this.txtNgayNhanHang.ResetText();
            this.cboMaNV.SelectedItem = null;
            this.cboMaKH.SelectedItem = null;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuyBo.Enabled = false;
            this.panel.Enabled = false;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 
}
