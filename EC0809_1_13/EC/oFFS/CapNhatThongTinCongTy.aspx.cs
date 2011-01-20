using System;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class CapNhatThongTinCongTy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript1(), true);
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Script", SetJavaScriptLogo("1"));
        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Script1", SetJavaScriptBanner("1"));
    }
    private string GetJavaScript1()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_CongTy.HienThiCapNhat();");
        return JavaScript.ToString();
    }    

    protected void MultipleFileUpload2_Click(object sender, FileCollectionEventArgs e)
    {
        HttpFileCollection oHttpFileCollection = e.PostedFiles;
        HttpPostedFile oHttpPostedFile = null;
        String validFiles = "gif, jpg, bmp, png";
        if (e.HasFiles)
        {
            oHttpPostedFile = oHttpFileCollection[0];
            if (oHttpPostedFile.ContentLength > 0)
            {
                if (validFiles.IndexOf(oHttpPostedFile.FileName.Substring(oHttpPostedFile.FileName.LastIndexOf(".") + 1)) > 0)
                {
                    oHttpPostedFile.SaveAs(Server.MapPath("Hinh Anh") + "\\" + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                    //LabLogo.InnerText = "./Hinh Anh/" + System.IO.Path.GetFileName(oHttpPostedFile.FileName);
                    //LabBanner.Text = Server.MapPath("./Hinh Anh/") + System.IO.Path.GetFileName(oHttpPostedFile.FileName);
                    //SetJavaScriptBanner(System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                    XmlDocument Tai_lieu = new XmlDocument();
                    XmlElement Cong_ty = null;

                    Tai_lieu.Load(Server.MapPath("He Phuc Vu/CONG_TY.xml"));
                    Cong_ty = Tai_lieu.DocumentElement;

                    Cong_ty.SetAttribute("Banner", "./Hinh Anh/" + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                    Tai_lieu.Save(Server.MapPath("He Phuc Vu/CONG_TY.xml"));
                }

            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String validFiles = "gif, jpg, bmp, png, GIF, JPG, BMP, PNG";

        if (FileUpload2.HasFile && FileUpload2.Enabled == true)
        {
            String filename = FileUpload2.FileName;
            HttpPostedFile file = FileUpload2.PostedFile;

            if (file.ContentLength > 0)
            {
                if (validFiles.IndexOf(filename.Substring(filename.LastIndexOf(".") + 1)) > 0)
                {
                    String filepath = Server.MapPath("Hinh Anh\\") + "\\" + filename;
                    FileUpload2.SaveAs(filepath);

                    XmlDocument Tai_lieu = new XmlDocument();
                    XmlElement Cong_ty = null;

                    Tai_lieu.Load(Server.MapPath("He Phuc Vu/CONG_TY.xml"));
                    Cong_ty = Tai_lieu.DocumentElement;

                    Cong_ty.SetAttribute("Logo", "./Hinh Anh/" + filename);
                    Tai_lieu.Save(Server.MapPath("He Phuc Vu/CONG_TY.xml"));
                }
            }
        }

        if (FileUpload3.HasFile && FileUpload3.Enabled == true)
        {
            String filename = FileUpload3.FileName;
            HttpPostedFile file = FileUpload3.PostedFile;

            if (file.ContentLength > 0)
            {
                if (validFiles.IndexOf(filename.Substring(filename.LastIndexOf(".") + 1)) > 0)
                {
                    String filepath = Server.MapPath("Hinh Anh\\") + "\\" + filename;
                    FileUpload3.SaveAs(filepath);

                    XmlDocument Tai_lieu = new XmlDocument();
                    XmlElement Cong_ty = null;

                    Tai_lieu.Load(Server.MapPath("He Phuc Vu/CONG_TY.xml"));
                    Cong_ty = Tai_lieu.DocumentElement;

                    Cong_ty.SetAttribute("Banner", "./Hinh Anh/" + filename);
                    Tai_lieu.Save(Server.MapPath("He Phuc Vu/CONG_TY.xml"));
                }
            }
        }
    }
}
