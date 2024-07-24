using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Tạo thêm thư viện này khi làm việc với các đối tượng ADO cung cấp SQL
using System.Data; //làm việc với datatable
using System.Configuration; //Làm việc với file cấu hình App.config
//chuột phải References > Add > Tích vào System.connection

namespace FormQLNV
{
    public static class Data_Provider //dùng trực tiếp lớp từ lớp khác mà không cần tạo đối tượng
    {
        private static SqlConnection cnn;
        private static SqlDataAdapter da;
        private static SqlCommand cmd;

        //Kết nối đến CSDL
        public static void moKetNoi()
        {
            cnn = new SqlConnection(); //Tạo kết nối
            //Lấy chuỗi kết nối
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["QLNS"].ConnectionString.ToString(); //QLNS là tên đã tạo bên App.config
            cnn.Open(); //Mở kế nối
        }
        
        //Đóng kết nối
        public static void dongKetNoi()
        {
            cnn.Close();
        }

        //Lấy dữ liệu từ database đổ lên datatale
        public static DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sql, cnn); //Thực thi câu lệnh truy vấn sql,  kết nối
            da.Fill(dt); //đổ lên datatable
            return dt;
        }

        //Cập nhật dữ liệu
        public static void updateData(string sql, object[] value=null, string[]name=null) //Xoa ko can object va string name
        {
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Clear();
            for (int i = 0; i < value.Length; i++)
                cmd.Parameters.AddWithValue(name[i], value[i]);

            cmd.ExecuteNonQuery();//Thực thi câu lệnh truy vấn Insert, Update, Delete
        }
    }
}
