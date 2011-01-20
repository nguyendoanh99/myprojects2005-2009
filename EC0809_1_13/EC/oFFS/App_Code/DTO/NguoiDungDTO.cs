using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for NguoiDungDTO
/// </summary>
public class NguoiDungDTO
{
	#region "Attributes"
    protected int _ma_nguoi_dung;
    protected string _ho_ten;
    protected string _username;
    protected string _password;

    protected string _email;
    private DateTime _ngay_sinh;
    private bool _gioi_tinh;
    private string _dia_chi;
    private string _dien_thoai;
    
    protected Boolean _tinh_trang_kich_hoat;
    protected int _ma_loai_nguoi_dung;    

    #endregion

    #region "Properties"
    public int Ma_nguoi_dung
    {
        get { return _ma_nguoi_dung; }
        set { _ma_nguoi_dung = value; }
    }
    public string Ho_ten
    {
        get { return _ho_ten; }
        set { _ho_ten = value; }
    }   
    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string Dia_chi
    {
        get { return _dia_chi; }
        set { _dia_chi = value; }
    }
    public DateTime Ngay_sinh
    {
        get { return _ngay_sinh; }
        set { _ngay_sinh = value; }
    }
    public bool Gioi_tinh
    {
        get { return _gioi_tinh; }
        set { _gioi_tinh = value; }
    }
    public string Dien_thoai
    {
        get { return _dien_thoai; }
        set { _dien_thoai = value; }
    }
    public Boolean Tinh_trang_kich_hoat
    {
        get { return _tinh_trang_kich_hoat; }
        set { _tinh_trang_kich_hoat = value; }
    }
    public int Ma_loai_nguoi_dung
    {
        get { return _ma_loai_nguoi_dung; }
        set { _ma_loai_nguoi_dung = value; }
    }
    #endregion

    #region"Constructor"
    public NguoiDungDTO()
	{
        Ma_nguoi_dung = -1;
        Ho_ten = "";
        Username = "";
        Password = "";
        Email = "";
        Dia_chi = "";
        Ngay_sinh = DateTime.Parse("1/1/1900");
        Gioi_tinh = true;
        Dien_thoai = "";
       
        Tinh_trang_kich_hoat = true;
        Ma_loai_nguoi_dung = -1; 
    }
    public NguoiDungDTO(string name, string pass)
    {
        Ma_nguoi_dung = -1;
        Ho_ten = "";
        Username = name;
        Password = pass;
        Email = "";
        Dia_chi = "";
        Ngay_sinh = DateTime.Parse("1/1/1900");
        Gioi_tinh = true;
        Dien_thoai = "";

        Tinh_trang_kich_hoat = true;
        Ma_loai_nguoi_dung = -1; 
    }

    public NguoiDungDTO(NguoiDungDTO vkhDto)
    {
        Ma_nguoi_dung = vkhDto.Ma_nguoi_dung;
        Ho_ten = vkhDto.Ho_ten;
        Ngay_sinh = vkhDto.Ngay_sinh;
        Gioi_tinh = vkhDto.Gioi_tinh;
        Dia_chi = vkhDto.Dia_chi;
        Dien_thoai = vkhDto.Dien_thoai;
        Email = vkhDto.Email;
        Username = vkhDto.Username;
        Password = vkhDto.Password;
    }
    #endregion

    public virtual string LoaiNguoiDung()
    {
        return "";
    }
    
}
