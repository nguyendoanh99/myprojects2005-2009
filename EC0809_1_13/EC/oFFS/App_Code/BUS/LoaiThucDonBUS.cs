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
/// Summary description for LoaiThucDonBUS
/// </summary>
public class LoaiThucDonBUS
{
    LoaiThucDonDAO dao = new LoaiThucDonDAO();
    public LoaiThucDonDTO[] LayDanhSachLoaiThucDon()
    {
        return dao.LayDanhSachLoaiThucDon();
    }

    public LoaiThucDonDTO[] LayDanhSachLoaiThucDonRoot()
    {
        return dao.LayDanhSachLoaiThucDonRoot();
    }

    public LoaiThucDonDTO[] LayDanhSachLoaiThucDonConTrucTiep(int maloaithucdon)
    {
        return dao.LayDanhSachLoaiThucDonConTrucTiep(maloaithucdon);
    }
    public LoaiThucDonDTO[] DanhSachLoaiThucDonCon(int MaLTDCha)
    {
        return (new LoaiThucDonDAO()).DanhSachLoaiThucDonCon(MaLTDCha);
    }

    public LoaiThucDonDTO ChiTietLoaiThucDon(int maloaithucdon)
    {
        return (new LoaiThucDonDAO()).ChiTietLoaiThucDon(maloaithucdon);
    }
}
