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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        // Chuỗi kết nối
        string strConnectionString = "Data Source=HOANGKHA;Initial Catalog=QuanLyBanHang;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtChiTietHoaDon
        SqlDataAdapter daChiTietHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtChiTietHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtSanPham
        SqlDataAdapter daHoaDon = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;
        // Đối tượng đưa dữ liệu vào DataTable dtSanPham
        SqlDataAdapter daSanPham = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;


        private void Form14_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            dtChiTietHoaDon.Dispose();
            dtChiTietHoaDon = null;
            // Hủy kết nối
            conn = null;
        }

        private void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtHoaDon
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvCHITIETHOADON.Columns["MaHD"] as DataGridViewComboBoxColumn).DataSource = dtHoaDon;
                (dgvCHITIETHOADON.Columns["MaHD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
                (dgvCHITIETHOADON.Columns["MaHD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";
                // Vận chuyển dữ liệu vào DataTable dtHoaDon
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                // Đưa dữ liệu lên ComboBox trong DataGridView
                (dgvCHITIETHOADON.Columns["TenSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvCHITIETHOADON.Columns["TenSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvCHITIETHOADON.Columns["TenSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
                //Đưa dữ liệu lên ComboBox ChonHD
                this.cboChonHD.DataSource = dtHoaDon;
                this.cboChonHD.DisplayMember = "MaHD";
                this.cboChonHD.ValueMember = "MaHD";
                // Vận chuyển dữ liệu vào DataTable dtHoaDon
                daChiTietHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoaDon where MaHD = '" + this.cboChonHD.SelectedValue + "'", conn);
                dtChiTietHoaDon = new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvCHITIETHOADON.DataSource = dtChiTietHoaDon;
                // Đếm
                this.txtTongSoChiTietHD.Text = dgvCHITIETHOADON.RowCount.ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table CHITIETHOADON.Lỗi rồi!!!");
            }
        }
        private void Form14_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtHoaDon
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                // Vận chuyển dữ liệu vào DataTable dtHoaDon
                daChiTietHoaDon = new SqlDataAdapter("SELECT * FROM ChiTietHoaDon where MaHD = '" + this.cboChonHD.SelectedValue + "'", conn);
                dtChiTietHoaDon = new DataTable();
                dtChiTietHoaDon.Clear();
                daChiTietHoaDon.Fill(dtChiTietHoaDon);
                // Đưa dữ liệu lên DataGridView
                dgvCHITIETHOADON.DataSource = dtChiTietHoaDon;
                // Đếm
                this.txtTongSoChiTietHD.Text = dgvCHITIETHOADON.RowCount.ToString();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table CHITIETHOADON.Lỗi rồi!!!");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
