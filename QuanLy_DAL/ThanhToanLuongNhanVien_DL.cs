using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data.SqlClient;
using System.Data;

namespace QuanLy_DAL
{
    public class ThanhToanLuongNhanVien_DL : DataProvider
    {
        public List<NhanVien> LayDanhSachNhanVien()
        {
            string manv, tennv;
            List<NhanVien> nhanViens = new List<NhanVien>();
            string sql = "SELECT manv, tennv FROM NhanVien";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    manv = reader[0].ToString();
                    tennv = reader[1].ToString();

                    NhanVien nhanVien = new NhanVien(manv, tennv, "", "", "", "");
                    nhanViens.Add(nhanVien);
                }
                reader.Close();
                return nhanViens;
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

        public List<LuongNhanVien> LayDanhLuongNhanVien()
        {
            string maluong, manv, tennv, thang, luongcoban, phucap, thuongphat, ngaythanhtoan, tongluong;
            List<LuongNhanVien> luongNhanViens = new List<LuongNhanVien>();
            string sql = "SELECT * FROM LuongNhanVien";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    maluong = reader[0].ToString();
                    manv = reader[1].ToString();
                    tennv = reader[2].ToString();
                    thang = reader[3].ToString();
                    luongcoban = reader[4].ToString();
                    phucap = reader[5].ToString();
                    thuongphat = reader[6].ToString();
                    ngaythanhtoan = reader[7].ToString();
                    tongluong = reader[8].ToString();

                    LuongNhanVien luongNhanVien = new LuongNhanVien(maluong, manv, tennv, thang, luongcoban, phucap, thuongphat, ngaythanhtoan, tongluong);
                    luongNhanViens.Add(luongNhanVien);
                }
                reader.Close();
                return luongNhanViens;
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
        public void ThemHoacCapNhatLuong(LuongNhanVien luongNV)
        {
            string sql = @"
        INSERT INTO LuongNhanVien 
            (manv, tennv, thang, luongcoban, phucap, thuongphat, ngaythanhtoan, tongluong)
        VALUES 
            (@manv, @tennv, @thang, @luongcoban, @phucap, @thuongphat, @ngaythanhtoan, @tongluong)";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@manv", luongNV.manv);
                cmd.Parameters.AddWithValue("@tennv", luongNV.tennv);
                cmd.Parameters.AddWithValue("@thang", luongNV.thang);
                cmd.Parameters.AddWithValue("@luongcoban", decimal.Parse(luongNV.luongcoban));
                cmd.Parameters.AddWithValue("@phucap", decimal.Parse(luongNV.phucap));
                cmd.Parameters.AddWithValue("@thuongphat", decimal.Parse(luongNV.thuongphat));
                cmd.Parameters.AddWithValue("@ngaythanhtoan", DateTime.Parse(luongNV.ngaythanhtoan));
                cmd.Parameters.AddWithValue("@tongluong", decimal.Parse(luongNV.tongluong));
                cmd.ExecuteNonQuery();
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

        public void CapNhatLuongNhanVien(LuongNhanVien luongNV)
        {
            string sql = @"
        UPDATE LuongNhanVien 
        SET 
            manv = @manv, 
            tennv = @tennv, 
            thang = @thang, 
            luongcoban = @luongcoban, 
            phucap = @phucap, 
            thuongphat = @thuongphat, 
            ngaythanhtoan = @ngaythanhtoan, 
            tongluong = @tongluong
        WHERE maluong = @maluong";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@maluong", luongNV.maluong);
                cmd.Parameters.AddWithValue("@manv", luongNV.manv);
                cmd.Parameters.AddWithValue("@tennv", luongNV.tennv);
                cmd.Parameters.AddWithValue("@thang", luongNV.thang);
                cmd.Parameters.AddWithValue("@luongcoban", decimal.Parse(luongNV.luongcoban));
                cmd.Parameters.AddWithValue("@phucap", decimal.Parse(luongNV.phucap));
                cmd.Parameters.AddWithValue("@thuongphat", decimal.Parse(luongNV.thuongphat));
                cmd.Parameters.AddWithValue("@ngaythanhtoan", DateTime.Parse(luongNV.ngaythanhtoan));
                cmd.Parameters.AddWithValue("@tongluong", decimal.Parse(luongNV.tongluong));
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw ex; }
            finally { DisConnect(); }
        }

        public void XoaLuongNhanVien(string maLuong)
        {
            string sql = "DELETE FROM LuongNhanVien WHERE maluong = @maluong";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@maluong", maLuong);
                cmd.ExecuteNonQuery();
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
