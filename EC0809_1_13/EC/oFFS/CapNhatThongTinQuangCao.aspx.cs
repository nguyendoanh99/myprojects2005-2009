using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CapNhatThongTinQuangCao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_QUANG_CAO.Cap_nhat_thong_tin();\n");        
        return JavaScript.ToString();
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        String validFiles = "gif, jpg, bmp, png, GIF, JPG, BMP, PNG";

        if (FileUpload1.HasFile && FileUpload1.Enabled == true)
        {
            String filename = FileUpload1.FileName;
            HttpPostedFile file = FileUpload1.PostedFile;

            if (file.ContentLength > 0)
            {
                if (validFiles.IndexOf(filename.Substring(filename.LastIndexOf(".") + 1)) > 0)
                {
                    String filepath = Server.MapPath("Hinh Anh\\Quang Cao") + "\\" + filename;
                    FileUpload1.SaveAs(filepath);

                    XmlDocument Tai_lieu = new XmlDocument();
                    XmlElement Quang_cao = null;

                    Tai_lieu.Load(Server.MapPath("He Phuc Vu/QUANG_CAO.xml"));
                    Quang_cao = Tai_lieu.DocumentElement;

                    foreach (XmlElement Thong_tin in Quang_cao.ChildNodes)
                    {
                        if (Thong_tin.GetAttribute("Ten").CompareTo(Session["Ten_quang_cao"]) == 0)
                        {
                            Thong_tin.SetAttribute("Logo", "./Hinh Anh/Quang Cao/" + filename);
                            Tai_lieu.Save(Server.MapPath("He Phuc Vu/QUANG_CAO.xml"));
                            break;
                        }
                    }
                }
            }
        }
    }
}
