using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace QuanLy_DAL
{
    public class QuanLySinhVien_DL : DataProvider
    {

        public List<SinhVien> LayDanhSachSinhVien()
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            string sql = "sp_LayTatCaSinhVien";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.StoredProcedure);
                while (reader.Read())
                {
                    SinhVien sv = new SinhVien(
                        reader["masv"].ToString(),
                        reader["tensv"].ToString(),
                        reader["gioitinh"].ToString(),
                        reader["ngaysinh"].ToString(),
                        reader["quequan"].ToString(),
                        reader["email"].ToString(),
                        reader["khoa"].ToString(),
                        reader["lop"].ToString(),
                        reader["loaiuutien"].ToString(),
                        reader["maphong"].ToString()
                    );
                    sinhViens.Add(sv);
                }
                reader.Close();
                return sinhViens;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }



        //public bool ThemSinhVien(SinhVien sv)
        //{
            //string sql = "sp_ThemSinhVienMoi";
            //try
            //{
            //    Connect();

            //    List<SqlParameter> parameters = new List<SqlParameter>();
            //    //parameters.Add(new SqlParameter("@MaSV", sv.masv));
            //    parameters.Add(new SqlParameter("@HoTen", sv.tensv));
            //    parameters.Add(new SqlParameter("@GioiTinh", sv.gioitinh));
            //    parameters.Add(new SqlParameter("@NgaySinh", DateTime.Parse(sv.ngaysinh)));
            //    parameters.Add(new SqlParameter("@QueQuan", sv.quequan));
            //    parameters.Add(new SqlParameter("@Email", sv.email));
            //    parameters.Add(new SqlParameter("@Khoa", sv.khoa));
            //    parameters.Add(new SqlParameter("@Lop", sv.lop));
            //    parameters.Add(new SqlParameter("@LoaiUuTien", sv.loaiuutien));
            //    parameters.Add(new SqlParameter("@MaPhong", sv.maphong));

            //    return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters) > 0;


            //}

            //catch (SqlException ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    DisConnect();
            //}
        //}

       
        public bool CapNhatSinhVien(SinhVien sv)
        {
            string sql = "sp_SuaSinhVien";
            try
            {
                Connect();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@MaSV", sv.masv));
                parameters.Add(new SqlParameter("@HoTen", sv.tensv));
                parameters.Add(new SqlParameter("@GioiTinh", sv.gioitinh));
                parameters.Add(new SqlParameter("@NgaySinh", DateTime.Parse(sv.ngaysinh)));
                parameters.Add(new SqlParameter("@QueQuan", sv.quequan));
                parameters.Add(new SqlParameter("@Email", sv.email));
                parameters.Add(new SqlParameter("@Khoa", sv.khoa));
                parameters.Add(new SqlParameter("@Lop", sv.lop));
                parameters.Add(new SqlParameter("@LoaiUuTien", sv.loaiuutien));
                parameters.Add(new SqlParameter("@MaPhong", sv.maphong));
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters) > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
      
       

        //public bool CapNhatSinhVien(SinhVien sv)
        //{
        //    string sql = @"UPDATE SinhVien 
        //          SET tensv = @tensv, 
        //              gioitinh = @gioitinh, 
        //              ngaysinh = @ngaysinh, 
        //              quequan = @quequan, 
        //              khoa = @khoa,
        //              lop = @lop, 
        //              loaiuutien = @loaiuutien, 
        //              maphong = @maphong 
        //          WHERE masv = @masv";
        //    try
        //    {
        //        Connect();
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //        cmd.Parameters.AddWithValue("@masv", sv.masv);
        //        cmd.Parameters.AddWithValue("@tensv", sv.tensv);
        //        cmd.Parameters.AddWithValue("@gioitinh", sv.gioitinh);
        //        cmd.Parameters.AddWithValue("@ngaysinh", DateTime.Parse(sv.ngaysinh));
        //        cmd.Parameters.AddWithValue("@quequan", sv.quequan);
        //        cmd.Parameters.AddWithValue("@khoa", sv.khoa);
        //        cmd.Parameters.AddWithValue("@lop", sv.lop);
        //        cmd.Parameters.AddWithValue("@loaiuutien", sv.loaiuutien);
        //        cmd.Parameters.AddWithValue("@maphong", sv.maphong);
        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        return rowsAffected > 0;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //}


        public bool XoaSinhVien(string masv)
        {
            string sql = "sp_XoaSinhVien";
            try
            {
                Connect();

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@MaSV", masv));

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters) > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        //public bool XoaSinhVien(string masv)
        //{
        //    string sql = "DELETE FROM SinhVien WHERE masv = @masv";
        //    try
        //    {
        //        Connect();
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //        cmd.Parameters.AddWithValue("@masv", masv);
        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        return rowsAffected > 0;
        //    }
        //    catch (SqlException ex)
        //    { 
        //        throw ex;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //}


        public List<SinhVien> TimKiemSinhVien(string keyword, KieuTimKiem kieuTim)
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            string sql = "";

            switch (kieuTim)
            {
                case KieuTimKiem.TheoMaSV:
                    sql = "sp_TimKiemSinhVien_TheoMa";
                    break;
                case KieuTimKiem.TheoTenSV:
                    sql = "sp_TimKiemSinhVien_TheoTen";
                    break;
                case KieuTimKiem.TheoMaPhong:
                    sql = "sp_TimKiemSinhVien_TheoPhong";
                    break;
                default:
                    throw new Exception("Kiểu tìm kiếm không hợp lệ");
            }

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuKhoa", keyword);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SinhVien sv = new SinhVien(
                        reader["masv"].ToString(),
                        reader["tensv"].ToString(),
                        reader["gioitinh"].ToString(),
                        reader["ngaysinh"].ToString(),
                        reader["quequan"].ToString(),
                        reader["email"].ToString(),
                        reader["khoa"].ToString(),
                        reader["lop"].ToString(),
                        reader["loaiuutien"].ToString(),
                        reader["maphong"].ToString()
                    );
                    sinhViens.Add(sv);
                }

                reader.Close();
                return sinhViens;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        //    public List<SinhVien> TimKiemSinhVien(string keyword, KieuTimKiem kieuTim)
        //    {
        //        List<SinhVien> sinhViens = new List<SinhVien>();
        //        string sql = "SELECT * FROM SinhVien WHERE ";

        //        switch (kieuTim)
        //        {
        //            case KieuTimKiem.TheoMaSV:
        //                sql += "masv LIKE @keyword";
        //                break;
        //            case KieuTimKiem.TheoTenSV:
        //                sql += "tensv LIKE @keyword";
        //                break;
        //            case KieuTimKiem.TheoMaPhong:
        //                sql += "maphong LIKE @keyword";
        //                break;
        //            default:
        //                throw new Exception("Kiểu tìm kiếm không hợp lệ");
        //        }

        //        try
        //        {
        //            Connect();
        //            SqlCommand cmd = new SqlCommand(sql, cn);
        //            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                SinhVien sv = new SinhVien(
        //                    reader["masv"].ToString(),
        //                    reader["tensv"].ToString(),
        //                    reader["gioitinh"].ToString(),
        //                    reader["ngaysinh"].ToString(),
        //                    reader["quequan"].ToString(),
        //                    reader["khoa"].ToString(),
        //                    reader["lop"].ToString(),
        //                    reader["loaiuutien"].ToString(),
        //                    reader["maphong"].ToString()
        //                );
        //                sinhViens.Add(sv);
        //            }

        //            reader.Close();
        //            return sinhViens;
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            DisConnect();
        //        }

        public List<string> SelectMaSinhVien()
        {
            List<string> list = new List<string>();
            string sql = "SELECT masv FROM SinhVien";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    list.Add(reader["masv"].ToString());
                }
                reader.Close();
                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
