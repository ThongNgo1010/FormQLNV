﻿using System;
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
        private static SqlDataAdapter da; //Cầu nối giữa DataSet và cơ sở dữ liệu cho phép đổ dữ liệu vào một DataSet và cập nhật thay đổi vào database.
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

        //lấy các đối tượng object[] value truyền vào các trường name trong sql
        public static void updateData(string sql, object[] value=null, string[]name=null) //Xoa ko can object va string name
        {
            cmd = new SqlCommand(sql, cnn); //Thông qua các câu lệnh SQL nó sẽ thực hiện câu lệnh truy vấn
            cmd.Parameters.Clear();
            if (value != null) //dùng cho trường hợp xóa, vì giá trị là null để không bị lỗi
            {
                for (int i = 0; i < value.Length; i++)
                    cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            cmd.ExecuteNonQuery(); //thực thi câu lệnh Insert, update, delete
            cmd.Dispose(); //Giải phóng tài nguyên khi kết thúc sử dụng SqlCommand
        }

        //Kiểm tra khóa chính có trùng hay k (trường hợp bài có mã...) nếu phải nhập 
        public static int checkData(string sql)//kiểm tra thông qua câu lệnh truy vấn "string sql"
        {
            int i = 0;
            cmd = new SqlCommand(sql, cnn);
            i = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            return i;
        }
    }
}
