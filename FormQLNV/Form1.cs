using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormQLNV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(Load_Form);
            btnThem.Click += new EventHandler(Them);
            btnSua.Click += new EventHandler(Sua);
            btnXoa.Click += new EventHandler(Xoa);
            btnLamMoi.Click += new EventHandler(LamMoi);
            btnThongKe.Click += new EventHandler(ThongKe);
            btnThoat.Click += new EventHandler(Thoat);
        }

        private void Thoat(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ThongKe(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LamMoi(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Xoa(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Sua(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
#region Kiểm tra tính hợp lệ dữ liệu
        //Kiểm tra giá trị số
        public bool isNumber(string value)
        {
            bool ktra;
            float result;
            ktra = float.TryParse(value, out result);
            return ktra;
        }
#endregion
        private void Them(object sender, EventArgs e)
        {
            
            if (isNumber(txtHeSoLuong.Text) && !string.IsNullOrEmpty(txtHoTen.Text))
            {
                Data_Provider.moKetNoi();
                string sql = "insert into DSNV(HoTen, NgaySinh, GioiTinh, SoDT, HeSoLuong, MaPhong, MaChucVu)" +
                    "values(@ht, @ns, @gt, @soDT, @hsl, @maP, @maCV) ";
                bool gt = drNam.Checked == true ? true : false;
                object[] value = {txtHoTen.Text, dateNgaySinh.Value, gt, txtSoDT.Text,
                float.Parse(txtHeSoLuong.Text), cboTenPhong.SelectedValue.ToString(), cboTenChucVu.SelectedValue.ToString()};
                string[] name = { "@ht", "@ns", "@gt", "@soDT", "@hsl", "@maP", "@maCV" };

                Data_Provider.updateData(sql, value, name);
                load_DSNV();
            }
            else
                MessageBox.Show("Dữ liệu không hợp lệ!");
           // Data_Provider.updateData(sql, value, name);
           // load_DSNV();
            Data_Provider.dongKetNoi();

        }

#region Lấy dữ liệu
        public void load_PB()
        {
            string sql = "select * from DMPHONG";
            cboTenPhong.DataSource = Data_Provider.getTable(sql);
            cboTenPhong.DisplayMember = "TenPhong";
            cboTenPhong.ValueMember = "MaPhong";
        }
        public void load_CV()
        {
            string sql = "select * from CHUCVU";
            cboTenChucVu.DataSource = Data_Provider.getTable(sql);
            cboTenChucVu.DisplayMember = "TenChucVu";
            cboTenChucVu.ValueMember = "MaChucVu";
        }
        public void load_DSNV()
        {
            string sql = "select * from DSNV";
            dataGridView1.DataSource = Data_Provider.getTable(sql);
        }
#endregion
        private void Load_Form(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            load_PB();
            load_CV();
            load_DSNV();
            Data_Provider.dongKetNoi();
        }
    }
}
