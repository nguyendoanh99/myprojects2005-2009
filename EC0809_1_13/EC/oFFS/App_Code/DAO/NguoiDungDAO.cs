 using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Reflection;
using System.Data.OleDb;

/// <summary>
/// Summary description for NguoiDungDAO
/// </summary>
public class NguoiDungDAO : AbstractDAO
{
    public bool CapNhatThongTinNguoiDung(NguoiDungDTO ndDto)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spCapNhatThongTinNguoiDung", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@hoten", SqlDbType.Char);
        cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime);
        cmd.Parameters.Add("@gioitinh", SqlDbType.Bit);
        cmd.Parameters.Add("@diachi", SqlDbType.Char);
        cmd.Parameters.Add("@dienthoai", SqlDbType.Char);
        cmd.Parameters.Add("@email", SqlDbType.Char);
        cmd.Parameters.Add("@manguoidung", SqlDbType.Int);

        cmd.Parameters["@hoten"].Value = ndDto.Ho_ten;
        cmd.Parameters["@ngaysinh"].Value = ndDto.Ngay_sinh;
        cmd.Parameters["@gioitinh"].Value = ndDto.Gioi_tinh;
        cmd.Parameters["@diachi"].Value = ndDto.Dia_chi;
        cmd.Parameters["@dienthoai"].Value = ndDto.Dien_thoai;
        cmd.Parameters["@email"].Value = ndDto.Email;
        cmd.Parameters["@manguoidung"].Value = ndDto.Ma_nguoi_dung;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            //throw ex;
            Disconnect();
            return false;
        }

        //cnn.Close();
        Disconnect();
        return true;
    }

    public NguoiDungDTO LayThongTinNguoiDung(string username)
    {
        NguoiDungDTO Kq = null;

        //SqlConnection cnn = Connect(strConnection);
        Connect();
        SqlCommand cmd = new SqlCommand("spLayThongTinNguoiDung", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@username", SqlDbType.VarChar);
        cmd.Parameters["@username"].Value = username;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Kq = new NguoiDungDTO();
            Kq.Ma_nguoi_dung = int.Parse(dr["MaNguoiDung"].ToString());
            Kq.Ho_ten = dr["HoTen"].ToString();
            Kq.Ngay_sinh = DateTime.Parse(dr["NgaySinh"].ToString());
            Kq.Gioi_tinh = bool.Parse(dr["GioiTinh"].ToString());
            Kq.Dia_chi = dr["DiaChi"].ToString();
            Kq.Dien_thoai = dr["DienThoai"].ToString();
            Kq.Email = dr["Email"].ToString();
            Kq.Username = dr["Username"].ToString();
            Kq.Password = dr["Password"].ToString();
        }

        Disconnect();
        return Kq;
    }

    public NguoiDungDTO KiemTraAccount(string username, string password) 
    {
        NguoiDungDTO Kq = null;
        Connect();
        SqlCommand cmd = new SqlCommand("spKiemTraAccount", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@username", SqlDbType.VarChar);
        cmd.Parameters.Add("@password", SqlDbType.VarChar);

        cmd.Parameters["@username"].Value = username;
        cmd.Parameters["@password"].Value = password;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            int loai =(int)dr["MaLoaiNguoiDung"];
            switch (loai)
            {
                case 1:
                    {
                        Kq = new KhachHangDTO();
                        break;
                    }
                case 2:
                    {
                        Kq = new NhanVienDTO();
                        break;
                    }
                case 3:
                    {
                        Kq = new QuanLyDTO();
                        break;
                    }
                default:
                    {
                        Kq = new QuanTriDTO();
                        break;
                    }
            }

            Kq.Ma_nguoi_dung = (int)dr["MaNguoiDung"];
            Kq.Ho_ten = dr["HoTen"].ToString();
            Kq.Email = dr["Email"].ToString();
            Kq.Username = dr["Username"].ToString();
            Kq.Password = dr["Password"].ToString();
            Kq.Tinh_trang_kich_hoat = (bool)dr["TinhTrangKichHoat"];
            Kq.Ma_loai_nguoi_dung = (int)dr["MaLoaiNguoiDung"];
        }

        Disconnect();
        return Kq;
    }

    public bool CapNhatThongTinMatKhau(string Password, int Ma_nguoi_dung)
    {
        Connect();
        string strSql = "update NGUOI_DUNG set Password = @password ";
        strSql += "where MaNguoiDung = @manguoidung";

        SqlCommand cmd = new SqlCommand(strSql, cnn);
        cmd.Parameters.Add("@password", SqlDbType.Char);
        cmd.Parameters.Add("@manguoidung", SqlDbType.Int);

        cmd.Parameters["@password"].Value = Password;
        cmd.Parameters["@manguoidung"].Value = Ma_nguoi_dung;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            cnn.Close();
            return false;
        }

        Disconnect();
        return true;
    }

    public int ThemNguoiDung(NguoiDungDTO nguoidungDTO)
    {
        int Kq = 0; //mã người dùng
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemNguoiDung", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@hoten", SqlDbType.NVarChar);
        cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
        cmd.Parameters.Add("@ngaysinh", SqlDbType.SmallDateTime);
        cmd.Parameters.Add("@gioitinh", SqlDbType.Bit);
        cmd.Parameters.Add("@email", SqlDbType.VarChar);
        cmd.Parameters.Add("@dienthoai", SqlDbType.VarChar);
        cmd.Parameters.Add("@username", SqlDbType.VarChar);
        cmd.Parameters.Add("@password", SqlDbType.VarChar);
        cmd.Parameters.Add("@maloainguoidung", SqlDbType.Int);
        cmd.Parameters.Add("@tinhtrangkichhoat", SqlDbType.Bit);

        cmd.Parameters["@hoten"].Value = nguoidungDTO.Ho_ten;
        cmd.Parameters["@diachi"].Value = nguoidungDTO.Dia_chi;
        cmd.Parameters["@ngaysinh"].Value = nguoidungDTO.Ngay_sinh;
        cmd.Parameters["@gioitinh"].Value = nguoidungDTO.Gioi_tinh;
        cmd.Parameters["@email"].Value = nguoidungDTO.Email;
        cmd.Parameters["@dienthoai"].Value = nguoidungDTO.Dien_thoai;
        cmd.Parameters["@username"].Value = nguoidungDTO.Username;
        cmd.Parameters["@password"].Value = nguoidungDTO.Password;
        cmd.Parameters["@maloainguoidung"].Value = nguoidungDTO.Ma_loai_nguoi_dung;
        cmd.Parameters["@tinhtrangkichhoat"].Value = nguoidungDTO.Tinh_trang_kich_hoat;

        cmd.Parameters.Add("@manguoidung", SqlDbType.Int);
        cmd.Parameters["@manguoidung"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        Kq = (int)cmd.Parameters["@manguoidung"].Value;

        Disconnect();
        return Kq;
    }

    public NguoiDungDTO[] LayDanhSachNguoiDung(int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spLayDanhSachNguoiDung", new string[] { "@pageNum", "@pageSize" }, new object[] { pageNum, pageSize });
        NguoiDungDTO[] kq = (NguoiDungDTO[])LayDanhSach(typeof(NguoiDungDTO), cmd);
        return kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(NguoiDungDTO), dt.Rows[i]);
    }

    public bool XoaNguoiDung(int maNguoiDung)
    {
        SqlCommand cmd = CreateCommandStored("spXoaNguoiDung",
             new string[] { "@maNguoiDung"},
             new object[] { maNguoiDung});
        return ExecuteNonQuery(cmd);
    }
    public bool CapNhatTinhTrangKichHoat(bool tinhTrangKichHoat, int maNguoiDung)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatTinhTrangKichHoat",
             new string[] { "@manguoidung", "@tinhtrangkichhoat" },
             new object[] { maNguoiDung, tinhTrangKichHoat });
        return ExecuteNonQuery(cmd);
    }
    public int TongSoNguoiDung()
    {
        SqlCommand cmd = CreateCommandStored("spTongSoNguoiDung", null, null);
        int kq = (int)ExecuteScalar(cmd);
        return kq;
    }

    // Khoa
    // Lấy thông tin người dùng
    public NguoiDungDTO ThongTinNguoiDung(int maNguoiDung)
    {
        SqlCommand cmd = CreateCommandStored("spThongTinNguoiDung",
            new string[] { "maNguoiDung" },
            new object[] { maNguoiDung });
        NguoiDungDTO[] kq = (NguoiDungDTO[])LayDanhSach(typeof(NguoiDungDTO), cmd);
        return kq[0];
    }

   
}
