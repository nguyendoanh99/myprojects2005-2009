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
/// Summary description for viewKhachHangDTO
/// </summary>
public class viewKhachHangDTO
{
    private int _ma_nguoi_dung;//
    private string _ho_ten;//
    private DateTime _ngay_sinh;//
    private bool _gioi_tinh;//
    private string _dia_chi;//
    private string _dien_thoai;//
    private string _email;
    private string _username;
    private string _password;
    private int _ma_the;//
    private int _ma_loai_the;
    private string _ten_loai_the;
    private char[] _so_the;
    private DateTime _ngay_het_han;
    private int _diem_khuyen_mai;//
    private int _diem_tich_luy;//    

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
    public string Dia_chi
    {
        get { return _dia_chi; }
        set { _dia_chi = value; }
    }
    public string Dien_thoai
    {
        get { return _dien_thoai; }
        set { _dien_thoai = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
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
    public int Ma_the
    {
        get { return _ma_the; }
        set { _ma_the = value; }
    }
    public int Ma_loai_the
    {
        get { return _ma_loai_the; }
        set { _ma_loai_the = value; }
    }
    public string Ten_loai_the
    {
        get { return _ten_loai_the; }
        set { _ten_loai_the = value; }
    }
    public char[] So_the
    {
        get { return _so_the; }
        set { _so_the = value; }
    }
    public DateTime Ngay_het_han
    {
        get { return _ngay_het_han; }
        set { _ngay_het_han = value; }
    }
    public int Diem_khuyen_mai
    {
        get { return _diem_khuyen_mai; }
        set { _diem_khuyen_mai = value; }
    }
    public int Diem_tich_luy
    {
        get { return _diem_tich_luy; }
        set { _diem_tich_luy = value; }
    }
    

	public viewKhachHangDTO()
	{
        Ma_nguoi_dung = -1;
        Ho_ten = "";
        Email = "";
        Username = "";
        Password = "";
        Dia_chi = "";
        Ngay_sinh = DateTime.Parse("1/1/1900");
        Gioi_tinh = true;
        Dien_thoai = "";
        Ma_the = -1;
        Ma_loai_the = -1;
        Ten_loai_the = "";
        So_the = "".ToCharArray();
        Ngay_het_han = DateTime.Parse("1/1/1900");
        Diem_khuyen_mai = -1;
        Diem_tich_luy = -1;
        
        
        
	}
}
