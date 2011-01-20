using System;
using System.Collections;
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
/// Summary description for ThucDonBUS
/// </summary>
public class ThucDonBUS
{
   ThucDonDAO dao = new ThucDonDAO();
   public int ThemThucDon(ThucDonDTO thucdon, String[] strDsMaMon, String strTag )
    {
        return dao.ThemThucDon(thucdon, strDsMaMon, strTag);
    }
    public ThucDonDTO ChiTietThucDon(int ma)
    {
        return dao.ChiTietThucDon(ma);
    }
    public ThucDonDTO[] DanhSachThucDon(int pageNum, int pageSize)
    {
        return dao.DanhSachThucDon(pageNum, pageSize);
    }
    public ArrayList ThongTinThucDon(int ma)
    {
        return dao.ThongTinThucDon(ma);
    }

    //NGHI
    public ArrayList LayDSThucDonThuocLoaiThucDonBatKy(int maloaithucdon)
    {
        return dao.LayDSThucDonThuocLoaiThucDonBatKy(maloaithucdon);
    }

    public ThucDonDTO LayThongTinTongQuatCuaThucDon(int ma)
    {
        return dao.LayThongTinTongQuatCuaThucDon(ma);
    }

    public ArrayList LayDSThucDonCuaLoaiThucDonLa(int maloaithucdon)
    {
        return dao.LayDSThucDonCuaLoaiThucDonLa(maloaithucdon);
    }

    public ThucDonDTO[] TimKiemThucDonTheoTen(string ten_thuc_don)
    {
        return dao.TimKiemThucDonTheoTen(ten_thuc_don);
    }

    public ThucDonDTO[] TimKiemThucDonNangCao(string ten_thuc_don, int ma_loai_thuc_don, string tag, double gia_min, double gia_max)
    {
        return dao.TimKiemThucDonNangCao(ten_thuc_don, ma_loai_thuc_don, tag, gia_min, gia_max);
    }

    public ThucDonDTO[] DSThucDonThuocLoaiThucDon(int maloaithucdon)
    {
        try
        {
            return dao.DSMThucDonThuocLoaiThucDon(maloaithucdon);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }
    public int TongSoThucDon()
    {
        return dao.TongSoThucDon();
    }

    public ThucDonDTO[] DanhSachThucDon()
    {
        int pageSize = dao.TongSoThucDon();
        return dao.DanhSachThucDon(1, pageSize);
    }

    public bool CapNhatTinhTrang(bool tinhTrang, int maThucDon)
    {
        return dao.CapNhatTinhTrang(tinhTrang, maThucDon);
    }
    public bool CapNhatTrangThaiHienThi(bool trangThai, int maThucDon)
    {
        return dao.CapNhatTrangThaiHienThi(trangThai, maThucDon);
    }
    public bool XoaThucDon(int maThucDon)
    {
        return dao.XoaThucDon(maThucDon);
    }
}
