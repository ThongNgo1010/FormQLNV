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
            btnTim.Click += new EventHandler(Tim);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(Data_Cell);
        }

        private void Data_Cell(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            txtMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateNgaySinh.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            string gt = dataGridView1.Rows[i].Cells[3].Value.ToString();
            if (gt == "True")
            {
                rdNam.Checked = true;
            }
            else
                rdNu.Checked = true;
            txtSoDT.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtHeSoLuong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            cboTenPhong.SelectedValue = dataGridView1.Rows[i].Cells[6].Value.ToString();
            cboTenChucVu.SelectedValue = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void Tim(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            string sql = string.Format("select * from DSNV where HoTen Like N'%{0}'", txtTimKiem.Text);
            dataGridView1.DataSource = Data_Provider.getTable(sql);
            Data_Provider.dongKetNoi();
        }

        private void Thoat(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void ThongKe(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LamMoi(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            dateNgaySinh.ResetText();
            if (rdNam.Checked == false)
                rdNam.Checked = true;
            txtSoDT.Clear();
            txtHeSoLuong.Clear();
            cboTenPhong.ResetText();
            cboTenChucVu.ResetText();
            txtTimKiem.Clear();
            load_DSNV();
        }

        private void Xoa(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int i = dataGridView1.CurrentCell.RowIndex; //i là dòng đang chọn
                int ma = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()); //Xác định vị trí trên Form
                string sql = string.Format("delete from DSNV where MaNV ='{0}'", ma); //câu lệnh SQL khi có tham số truyền vào thì dùng Format / Tìm MaNV ở CSDL
                Data_Provider.moKetNoi();
                Data_Provider.updateData(sql);
                load_DSNV();
                Data_Provider.dongKetNoi();
            }
        }

        private void Sua(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn cập nhật lại thông tin không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Data_Provider.moKetNoi();
                if (isNumber(txtHeSoLuong.Text) && !string.IsNullOrEmpty(txtHoTen.Text))
                {
                    string sql = string.Format("update DSNV set HoTen = @ht, NgaySinh =@ns, GioiTinh = @gt, SoDT=@soDT," +
                        "HeSoLuong=@hsl, MaPhong=@maP, MaChucVu=@maCV " +
                        "where MaNV ='{0}'", txtMaNV.Text);

                    bool gt = rdNam.Checked == true ? true : false;
                    object[] value = {txtHoTen.Text, dateNgaySinh.Value, gt, txtSoDT.Text,
                float.Parse(txtHeSoLuong.Text), cboTenPhong.SelectedValue.ToString(), cboTenChucVu.SelectedValue.ToString()};
                    string[] name = { "@ht", "@ns", "@gt", "@soDT", "@hsl", "@maP", "@maCV" };

                    Data_Provider.updateData(sql, value, name);
                    load_DSNV();
                }
                else
                    MessageBox.Show("Dữ liệu không hợp lệ!");

                Data_Provider.dongKetNoi();

            }
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
            Data_Provider.moKetNoi();
/*            string sql1 = string.Format("Select count (*) from DSNV where MaNV = '{0}'", txtMaNV.Text);
            if(Data_Provider.checkData(sql1) == 0 && isNumber(txtHeSoLuong.Text){

            }*/

            if (isNumber(txtHeSoLuong.Text) && !string.IsNullOrEmpty(txtHoTen.Text))
            {
                string sql = "insert into DSNV(HoTen, NgaySinh, GioiTinh, SoDT, HeSoLuong, MaPhong, MaChucVu)" +
                    "values(@ht, @ns, @gt, @soDT, @hsl, @maP, @maCV) ";
                bool gt = rdNam.Checked == true ? true : false;
                object[] value = {txtHoTen.Text, dateNgaySinh.Value, gt, txtSoDT.Text,
                float.Parse(txtHeSoLuong.Text), cboTenPhong.SelectedValue.ToString(), cboTenChucVu.SelectedValue.ToString()};
                string[] name = { "@ht", "@ns", "@gt", "@soDT", "@hsl", "@maP", "@maCV" };

                Data_Provider.updateData(sql, value, name);
                load_DSNV();
            }
            else
                MessageBox.Show("Dữ liệu không hợp lệ!");

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
