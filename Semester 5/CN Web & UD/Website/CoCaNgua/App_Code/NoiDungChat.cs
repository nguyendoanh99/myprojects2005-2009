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
/// Summary description for NoiDungChat
/// </summary>
public class NoiDungChat
{
    private String mNoiDung;
    private int mSoLanLay;
    private int mSoNguoiDungHienTai;
    private String mTenNguoiGui;
    public String NoiDung
    {
        get
        {
            return mNoiDung;
        }
        set
        {
            mNoiDung = value;
        }
    }
    public int SoLanLay
    {
        get
        {
            return mSoLanLay;
        }
        set
        {
            mSoLanLay = value;
        }
    }
    public int SoNguoiDungHienTai
    {
        get
        {
            return mSoNguoiDungHienTai;
        }
        set
        {
            mSoNguoiDungHienTai = value;
        }
    }
    public String TenNguoiGui
    {
        get
        {
            return mTenNguoiGui;
        }
        set
        {
            mTenNguoiGui = value;
        }
    }
    public NoiDungChat(String str, String _TenNguoiGui, int _SoNguoiDungHienTai)
	{
		//
		// TODO: Add constructor logic here
		//
        NoiDung = str;
        SoLanLay = 0;
        SoNguoiDungHienTai = _SoNguoiDungHienTai;
        TenNguoiGui = _TenNguoiGui;
	}
}
