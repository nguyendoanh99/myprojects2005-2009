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
using System.Collections;
/// <summary>
/// Summary description for MonAnBUS
/// </summary>
public class MonAnBUS
{
    MonAnDAO monanDAO = new MonAnDAO();
    public int ThemMonAn(MonAnDTO monan, String strTag)
    {
        int Kq = 0;
        try
        {
            Kq = monanDAO.ThemMonAn(monan, strTag);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return Kq;
    }

    public int TongSoMonAn()
    {
        try
        {
            return monanDAO.TongSoMonAn();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return -1;
    }

    public MonAnDTO[] DanhSachMonAn(int pageNum, int pageSize)
    {
        try
        {
            return monanDAO.DanhSachMonAn(pageNum, pageSize);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }
    public MonAnDTO[] DanhSachMonAn()
    {
        int pageSize = monanDAO.TongSoMonAn();
        return monanDAO.DanhSachMonAn(1, pageSize);
    }

    //LẤY DANH SÁCH MÓN ĂN CỦA 1 LOẠI MÓN BẤT KÌ, KHÔNG CẦN PHẢI LÀ LOẠI MÓN LÁ
    public ArrayList LayDSMonAnThuocLoaiMonBatKy(int maloaimon)
    {
        try
        {
            return monanDAO.LayDSMonAnThuocLoaiMonBatKy(maloaimon);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }


    public MonAnDTO[] LayDSMonAnHienThi(int pageNum, int pageSize)
    {
        try
        {
            return monanDAO.LayDSMonAnHienThi(pageNum, pageSize);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }

    public MonAnDTO ChiTietMonAn(int ma_mon)
    {
        try
        {            
            return monanDAO.ChiTietMonAn(ma_mon);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }

    public int TinhSoLuongMonAnThuocLoaiMon(int maloaimon)
    {
        return (new MonAnDAO()).TinhSoLuongMonAnThuocLoaiMon(maloaimon);
    }
    public MonAnDTO[] DSMonAnThuocLoaiMon(int maloaimon)
    {
        try
        {
            return monanDAO.DSMonAnThuocLoaiMon(maloaimon);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }

    public MonAnDTO[] TimKiemMonAnTheoTen(string ten_mon)
    {
        try
        {
            return monanDAO.TimKiemMonAnTheoTen(ten_mon);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }

    public MonAnDTO[] TimKiemMonAnNangCao(string ten_mon, int ma_loai_mon, string tag, double gia_min, double gia_max)
    {
        try
        {
            return monanDAO.TimKiemMonAnNangCao(ten_mon, ma_loai_mon, tag, gia_min, gia_max);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }

    public MonAnDTO[] LayDSQuaTang(double gia)
    {
        try
        {
            return monanDAO.LayDSQuaTang(gia);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }
    // Cập nhật tình trạng (còn, hết)
    public bool CapNhatTinhTrang(bool tinhTrang, int maMonAn)
    {
        return monanDAO.CapNhatTinhTrang(tinhTrang, maMonAn);
    }
    // Câp nhật trạng thái hiển thị (ẩn, hiện)
    public bool CapNhatTrangThaiHienThi(bool trangThai, int maMonAn)
    {
        return monanDAO.CapNhatTrangThaiHienThi(trangThai, maMonAn);
    }
    public bool XoaMonAn(int maMonAn)
    {
        return monanDAO.XoaMonAn(maMonAn);
    }
}
