using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String Thong_bao;
        Thong_bao = Tao_thong_bao();
        String Chuoi_xml = "";
        Chuoi_xml += "<Goc ";
        Chuoi_xml += "Thong_bao='" + Thong_bao + "'";
        Chuoi_xml += "/>";
        
        Response.ContentType = "text/xml";
        Response.Write(Chuoi_xml);
    }
    public String Tao_thong_bao()
    {
        String kq = "";
        kq += "Xin chào\n";
        kq += "Đây là chương trình AJAX đầu tiên của tôi";
        return kq;
    }
}
