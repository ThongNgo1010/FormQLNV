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
    public partial class frmBangLuong : Form
    {
        public frmBangLuong()
        {
            float luongCB = 2340000.0f;

            InitializeComponent();
            Load += new EventHandler(Load_luong);
        }

        private void Load_luong(object sender, EventArgs e)
        {
            //luong = luongCB*HeSoLuong + phuCapCV
            //2340000*A.heSoLuong+B.phuCapCV as Luong
            string sql = @"select A.MaNV, A.HoTen, A.NgaySinh, A.GioiTinh, 2340000*A.heSoLuong+B.phuCapCV as Luong, B.TenChucVu, C.TenPhong
                from DSNV as A, CHUCVU as B, DMPHONG as C 
                where A.MaChucVu=B.MaChucVu and A.MaPhong=C.MaPhong";
            Data_Provider.moKetNoi();
            dataGridView1.DataSource = Data_Provider.getTable(sql);
            lblLuong.Text = "Lương cao nhất: " + string.Format("{0:0,0vnđ}", luongMax());
            Data_Provider.dongKetNoi();
        }

        //Luong MAX
        public float luongMax()
        {
            float max = 0;
            float luong = 0;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            foreach(DataRow row in dt.Rows)
            {
                luong = float.Parse(row[4].ToString());
                if (luong > max)
                    max = luong;
            }
            return max;
        }
    }
}
