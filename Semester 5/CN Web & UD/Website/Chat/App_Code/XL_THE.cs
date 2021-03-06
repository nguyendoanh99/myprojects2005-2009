using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
/// <summary>
/// Summary description for XL_THE
/// </summary>
public class XL_THE
{
    // Biến thành phần
    private String Ten;
    private ArrayList Danh_sach_thuoc_tinh_cuc_bo;
    private ArrayList Danh_sach_the_cuc_bo;
    // Xử lý thuộc tính
    public ArrayList Danh_sach_the
    {
        get
        {
            return Danh_sach_the_cuc_bo;
        }
        set
        {
            Danh_sach_the_cuc_bo = value;
        }
    }
    public ArrayList Danh_sach_thuoc_tinh
    {
        get
        {
            return Danh_sach_thuoc_tinh_cuc_bo;
        }
        set
        {
            Danh_sach_thuoc_tinh_cuc_bo = value;
        }
    }
    // Xử lý khởi tạo
	public XL_THE(String S)
	{
        Ten = S;
        Danh_sach_thuoc_tinh = new ArrayList();
        Danh_sach_the = new ArrayList();
	}
    // Xử lý kết xuất
    public String Chuoi()
    {
        String kq = "";
        kq += "<" + Ten;
        foreach (XL_THUOC_TINH Thuoc_tinh in Danh_sach_thuoc_tinh)
            kq += Thuoc_tinh.Chuoi();

        if (Danh_sach_the.Count > 0)
        {
            kq += ">";
            foreach (XL_THE The in Danh_sach_the)
                kq += The.Chuoi();
            kq += "</" + Ten + ">";
        }
        else
            kq += "/>";
        return kq;

    }
}
