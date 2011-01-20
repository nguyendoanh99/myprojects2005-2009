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
using System.Text;

public partial class ThemMonMoi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanLy" && Session["LoaiNguoiDung"] != "NhanVien")
        {
            Response.Redirect("ErrorPage.aspx");
        }
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);

        if (!IsPostBack)
        {
            //LoadDonVi();
        }
        //LoadLoaiMon();
    }
    
    /*
    public void LoadDonVi()
    {
        cmbDonViTinh.Items.Clear();
        for (int i = 0; i < GlobalConstant.dsDonVi.Length; ++i)
        {
            cmbDonViTinh.Items.Add(GlobalConstant.dsDonVi[i]);
        }
        cmbDonViTinh.SelectedIndex = 0;
    }

    public void LoadLoaiMon()
    {
        cmbLoaiMon.Items.Clear();
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        LoaiMonDTO[] dsLoaiMon = loaimonBUS.LayDanhSachLoaiMon();
        for (int i = 0; i < dsLoaiMon.Length; ++i)
        {
            cmbLoaiMon.Items.Add(dsLoaiMon[i].Ten_loai_mon);
            cmbLoaiMon.Items[i].Value = dsLoaiMon[i].Ma_loai_mon.ToString();
        }
    }
    */

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_MON_AN.Hienthi();\n");
        return JavaScript.ToString();
    }

    
    protected void Button1_Click1(object sender, EventArgs e)
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
                    String filepath = Server.MapPath("Hinh Anh\\San Pham\\") + "\\" + filename;
                    FileUpload1.SaveAs(filepath);

                    //txtHinhAnh.Value = "./Hinh Anh/" + filename\\;

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
                }
            }
        }
    }
}
