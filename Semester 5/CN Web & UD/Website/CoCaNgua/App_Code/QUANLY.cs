using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for QUANLY
/// </summary>
public class QUANLY
{
    private BANCO mBanCo;
    private int mLuotDi;
    private int mSoNguoiChoi;
    private int m_SoNguoiXem;
    private List<NGUOICHOI> m_arrNguoiChoi;
    private int mXiNgau;
    private Boolean mDangDoXiNgau;
    public Boolean DangDoXiNgau
    {
        get
        {
            return mDangDoXiNgau;
        }
        set
        {
            mDangDoXiNgau = value;
        }
    }
    public int XiNgau 
    {
        get
        {
            return mXiNgau;
        }
        set
        {
            mXiNgau = value;
        }
    }
    public BANCO BanCo
    {
        get
        {
            return mBanCo;
        }
        set
        {
            mBanCo = value;
        }
    }
    public int LuotDi
    {
        get
        {
            return mLuotDi;
        }
        set
        {
            mLuotDi = value;
        }
    }
    public int SoNguoiChoi
    {
        get
        {
            return m_arrNguoiChoi.Count;
        }
    }
	public List<NGUOICHOI> arrNguoiChoi
    {
        get
        {
            return m_arrNguoiChoi;
        }
        set
        {
            m_arrNguoiChoi = value;
        }
    }
    public int SoNguoiXem
    {
        get
        {
            return m_SoNguoiXem;
        }
        set
        {
            m_SoNguoiXem = value;
        }
    }
    public QUANLY()
	{
		//
		// TODO: Add constructor logic here
		//
        LuotDi = -1;
        XiNgau = -1;
        DangDoXiNgau = false;
        BanCo = new BANCO();
        m_arrNguoiChoi = new List<NGUOICHOI>();
        m_SoNguoiXem = 0;
	}
}
