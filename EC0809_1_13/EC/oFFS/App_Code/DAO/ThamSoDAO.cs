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
/// Summary description for ThamSoDAO
/// </summary>
public class ThamSoDAO : AbstractDAO
{

    public ThamSoDTO LayThamSo()
    {
        SqlCommand cmd = CreateCommandStored("spLayThamSo",
             new string[] {  },
             new object[] {  });
        ThamSoDTO[] kq = (ThamSoDTO[])LayDanhSach(typeof(ThamSoDTO), cmd);
        return kq[0];
    }

    public bool LuuThamSo(ThamSoDTO ts)
    {
        SqlCommand cmd = CreateCommandStored("spLuuThamSo",
             new string[] { "@GiaTriDiemSo", "@DiemKhachHangThanThiet", "@TiLeGiamGiaThucDon", "@Thue", "@GiaTriDoiDiemKhuyenMai", "@GioiHanDoiDiemKhuyenMai" },
             new object[] { ts.GiaTriDiemSo, ts.DiemKhachHangThanThiet, ts.TiLeGiamGiaThucDon, ts.Thue, ts.GiaTriDoiDiemKhuyenMai, ts.GioiHanDoiDiemKhuyenMai });
        
        return ExecuteNonQuery(cmd);
    }
    
    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(ThamSoDTO), dt.Rows[i]);
    }
}
