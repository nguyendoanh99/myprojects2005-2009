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
/// Summary description for XL_THUOC_TINH
/// </summary>
public class XL_THUOC_TINH
{
    // Biến thành phần
    private String Ten;
    private String Gia_tri;
    // Xử lý khởi tạo
	public XL_THUOC_TINH(String S, String gt)
	{
        Ten = S;
        Gia_tri = gt;
	}
    // Xử lý kết xuất
    public String Chuoi()
    {
        String kq = "";
        kq += " " + Ten + "='";
        kq += Gia_tri + "'";
        return kq;
    }
}
