using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_QuanLyBanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void frmLogin()
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLogin();
        }

        private void danhMụcThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        // Hàm xemm danh mục
         public void XemDanhMuc(int intDanhMuc)
        {
            Form frm = new Form3();
            frm.Text = intDanhMuc.ToString();
            frm.ShowDialog();
        }

        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }

        private void danhMụcHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }

        private void danhMụcChiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(6);
        }

        private void danhMụcThànhPhốToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Text = "Quản lý Danh mục Thành Phố";
            frm.ShowDialog();
        }

        private void danhMụcKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Text = "Quản lý Danh mục Khách Hàng";
            frm.ShowDialog();
        }

        private void danhMụcNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.Text = "Quản lý Danh mục Nhân Viên";
            frm.ShowDialog();
        }

        private void danhMụcSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form7();
            frm.Text = "Quản lý Danh mục Sản Phẩm";
            frm.ShowDialog();
        }

        private void danhMụcHoáĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form8();
            frm.Text = "Quản lý Danh mục Hoá Đơn";
            frm.ShowDialog();
        }

        private void danhMụcChiTiếtHoáĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new Form9();
            frm.Text = "Quản lý Danh mục Chi Tiết Hoá Đơn";
            frm.ShowDialog();
        }

        private void kháchHàngTheoThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form10();
            frm.Text = "Quản lý Khách Hàng theo Thành Phố";
            frm.ShowDialog();
        }

        private void hoáĐơnTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form11();
            frm.Text = "Quản lý Hoá Đơn theo Khách Hàng";
            frm.ShowDialog();
        }

        private void hoáĐơnTheoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form12();
            frm.Text = "Quản lý Hoá Đơn theo Sản Phẩm";
            frm.ShowDialog();
        }

        private void hoáĐơnTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form13();
            frm.Text = "Quản lý Hoá Đơn theo Nhân Viên";
            frm.ShowDialog();
        }

        private void chiTiếtHoáĐơnTheoHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form14();
            frm.Text = "Quản lý Chi Tiết Hoá Đơn theo Hoá Đơn";
            frm.ShowDialog();
        }

        private void quảnLýĐaCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form15();
            frm.Text = "Quản lý Đa cấp";
            frm.ShowDialog();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dương Hoàng Kha B1906486 - Năm thực hiện: 2021", "Tác giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
