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
/// <summary>
/// Summary description for KhachHangDAO
/// </summary>
public class KhachHangDAO:AbstractDAO
{
    public int ThemKhachHang(KhachHangDTO khachhang, TheThanhToanDTO the)
    {
        int Kq = 0; //mã người dùng
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemKhachHang", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@hoten", SqlDbType.NVarChar);
        cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
        cmd.Parameters.Add("@ngaysinh", SqlDbType.SmallDateTime);
        cmd.Parameters.Add("@gioitinh", SqlDbType.Bit);
        cmd.Parameters.Add("@email", SqlDbType.VarChar);
        cmd.Parameters.Add("@dienthoai", SqlDbType.VarChar);
        cmd.Parameters.Add("@username", SqlDbType.VarChar);
        cmd.Parameters.Add("@password", SqlDbType.VarChar);
        cmd.Parameters.Add("@maloaithe", SqlDbType.Int);
        cmd.Parameters.Add("@sothe", SqlDbType.VarChar);
        cmd.Parameters.Add("@ngayhethan", SqlDbType.SmallDateTime);

        cmd.Parameters["@hoten"].Value = khachhang.Ho_ten;
        cmd.Parameters["@diachi"].Value = khachhang.Dia_chi;
        cmd.Parameters["@ngaysinh"].Value = khachhang.Ngay_sinh;
        cmd.Parameters["@gioitinh"].Value = khachhang.Gioi_tinh;
        cmd.Parameters["@email"].Value = khachhang.Email;
        cmd.Parameters["@dienthoai"].Value = khachhang.Dien_thoai;
        cmd.Parameters["@username"].Value = khachhang.Username;
        cmd.Parameters["@password"].Value = khachhang.Password;
        cmd.Parameters["@maloaithe"].Value = the.Ma_loai_the;
        cmd.Parameters["@sothe"].Value = the.So_the;
        cmd.Parameters["@ngayhethan"].Value = the.Ngay_het_han;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters["@makhachhang"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        Kq = (int)cmd.Parameters["@makhachhang"].Value;

        Disconnect();
        return Kq;
    }

    public viewKhachHangDTO LayThongTinKhachHang(string username)
    {
        viewKhachHangDTO Kq = null;

        //SqlConnection cnn = Connect(strConnection);
        Connect();
        SqlCommand cmd = new SqlCommand("spLayThongTinKhachHang", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@username", SqlDbType.VarChar);
        cmd.Parameters["@username"].Value = username;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Kq = new viewKhachHangDTO();
            Kq.Ma_nguoi_dung = int.Parse(dr["MaNguoiDung"].ToString());
            Kq.Ho_ten = dr["HoTen"].ToString();
            Kq.Ngay_sinh = DateTime.Parse(dr["NgaySinh"].ToString());
            Kq.Gioi_tinh = bool.Parse(dr["GioiTinh"].ToString());
            Kq.Dia_chi = dr["DiaChi"].ToString();
            Kq.Dien_thoai = dr["DienThoai"].ToString();
            Kq.Email = dr["Email"].ToString();
            Kq.Username = dr["Username"].ToString();
            Kq.Password = dr["Password"].ToString();
            Kq.Ma_the = int.Parse(dr["MaTheThanhToan"].ToString());
            Kq.Ma_loai_the = int.Parse(dr["MaLoaiThe"].ToString());
            Kq.Ten_loai_the = dr["TenLoaiThe"].ToString();
            Kq.So_the = dr["SoThe"].ToString();
            Kq.Ngay_het_han = DateTime.Parse(dr["NgayHetHan"].ToString());
            Kq.Diem_khuyen_mai = int.Parse(dr["DiemKhuyenMai"].ToString());
            Kq.Diem_tich_luy = int.Parse(dr["DiemTichLuy"].ToString());
        }

        Disconnect();
        return Kq;
    }

    public bool CapNhatThongTinKhachHang(viewKhachHangDTO viewKH)
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

        cmd.Parameters["@hoten"].Value = viewKH.Ho_ten;
        cmd.Parameters["@ngaysinh"].Value = viewKH.Ngay_sinh;
        cmd.Parameters["@gioitinh"].Value = viewKH.Gioi_tinh;
        cmd.Parameters["@diachi"].Value = viewKH.Dia_chi;
        cmd.Parameters["@dienthoai"].Value = viewKH.Dien_thoai;
        cmd.Parameters["@email"].Value = viewKH.Email;
        cmd.Parameters["@manguoidung"].Value = viewKH.Ma_nguoi_dung;

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

    public void CapNhatDiemKhuyenMai(int makh, int diemmoi)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spCapNhatDiemKhuyenMai", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters.Add("@diemmoi", SqlDbType.Int);

        cmd.Parameters["@makhachhang"].Value = makh;
        cmd.Parameters["@diemmoi"].Value = diemmoi;
       
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        Disconnect();
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return null;
    }
    
}
