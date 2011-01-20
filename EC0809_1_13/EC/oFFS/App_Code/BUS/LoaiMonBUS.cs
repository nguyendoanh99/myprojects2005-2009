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
/// Summary description for LoaiMonBUS
/// </summary>
public class LoaiMonBUS
{
    LoaiMonDAO loaimonDAO = new LoaiMonDAO();
    public LoaiMonDTO[] LayDanhSachLoaiMon()
    {
        return loaimonDAO.LayDanhSachLoaiMon();
    }

    public LoaiMonDTO[] DanhSachLoaiMon()
    {
        return loaimonDAO.DanhSachLoaiMon();
    }

    public LoaiMonDTO[] DanhSachLoaiMonLa()
    {
        return loaimonDAO.DanhSachLoaiMonLa();
    }

    public LoaiMonDTO[] LayDanhSachLoaiMonGoc()
    {
        return loaimonDAO.LayDanhSachLoaiMonGoc();
    }

    public LoaiMonDTO[] DanhSachLoaiMonCon(int MaLMCha)
    {
        return loaimonDAO.DanhSachLoaiMonCon(MaLMCha);
    }

    public bool ThemLoaiMon(LoaiMonDTO lmDto)
    {
        return loaimonDAO.ThemLoaiMon(lmDto);
    }

    public bool XoaLoaiMon(int maloaimon)
    {
        return loaimonDAO.XoaLoaiMon(maloaimon);
    }

    public LoaiMonDTO ChiTietLoaiMon(int maloaimon)
    {
        return loaimonDAO.ChiTietLoaiMon(maloaimon);
    }
}
