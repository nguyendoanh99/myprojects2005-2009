using System;
using System.Web;

/// <summary>
/// Summary description for XL_CHUOI
/// </summary>
public class XL_CHUOI
{
    // Xử lý tiếp nhận
    public static String Nhap(HttpRequest Nguon, String Ten)
    {
        String kq = null;
        kq = Nguon[Ten];
        return kq;
    }
    // Xử lý kết xuất
    public static void Xuat(HttpResponse Dich, String Chuoi)
    {
        Dich.ContentType = "text/xml";
        Dich.Write(Chuoi);
    }
	public XL_CHUOI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
