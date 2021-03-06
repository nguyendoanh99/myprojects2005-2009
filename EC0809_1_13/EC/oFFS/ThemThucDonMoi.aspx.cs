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

public partial class ThemThucDonMoi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanLy" && Session["LoaiNguoiDung"] != "NhanVien")
        {
            Response.Redirect("ErrorPage.aspx");
        }

        LoadLoaiThucDon();
    }

    protected void LoadLoaiThucDon()
    {
        LoaiThucDonDTO[] dsLoaiTD = (new LoaiThucDonBUS()).LayDanhSachLoaiThucDon();

        cmbLoaiThucDon.Items.Clear();
        cmbLoaiThucDon.Items.Add("--Chọn loại thực đơn");
        cmbLoaiThucDon.Items[0].Value = "-1";

        for (int i = 0; i < dsLoaiTD.Length; i++)
        {
            cmbLoaiThucDon.Items.Add(dsLoaiTD[i].Ten_loai_thuc_don);
            cmbLoaiThucDon.Items[i + 1].Value = (dsLoaiTD[i]).Ma_loai_thuc_don.ToString();
        }
        cmbLoaiThucDon.SelectedIndex = 0;
    }
          

    protected void MultipleFileUpload1_Click(object sender, FileCollectionEventArgs e)
    {
        HttpFileCollection oHttpFileCollection = e.PostedFiles;
        HttpPostedFile oHttpPostedFile = null;
        String validFiles = "gif, jpg, bmp, png, GIF, JPG, BMP, PNG";

        if (e.HasFiles)
        {
            oHttpPostedFile = oHttpFileCollection[0];
            if (oHttpPostedFile.ContentLength > 0)
            {
                if (validFiles.IndexOf(oHttpPostedFile.FileName.Substring(oHttpPostedFile.FileName.LastIndexOf(".") + 1)) > 0)
                {
                    String path = "Hinh Anh\\San Pham\\Thuc don" + "\\" + System.IO.Path.GetFileName(oHttpPostedFile.FileName);
                    oHttpPostedFile.SaveAs(Server.MapPath(path));
                    txtHinhAnh.Value = path;

                }

            }
        }
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
                    String filepath = Server.MapPath("Hinh Anh\\San Pham\\Thuc Don\\") + "\\" + filename;
                    FileUpload1.SaveAs(filepath);

                    //txtHinhAnh.Value = "./Hinh Anh/" + filename\\;

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
                }
            }
        }
    }
}
