using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class XuatLoiChao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String HoTen;
        String LoiChao;
        HoTen = Request["HoTen"];
        LoiChao = TaoLoiChao(HoTen);
        String ChuoiXML = "<Goc ";
        ChuoiXML += "LoiChao='" + LoiChao + "'";
        ChuoiXML += " />";
        Response.ContentType = "text/xml";
        Response.Write(ChuoiXML);
    }
    public String TaoLoiChao(String HoTen)
    {

        String kq = "";
        kq += "Xin chào " + HoTen + "\n";
        kq += " Cám ơn vì đã sử dụng chương  trình này.";
        return kq;
    }
}
