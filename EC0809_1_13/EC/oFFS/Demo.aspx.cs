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

public partial class Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MultipleFileUpload1_Click(object sender, FileCollectionEventArgs e)
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
                    oHttpPostedFile.SaveAs(Server.MapPath("Hinh Anh") + "\\" + System.IO.Path.GetFileName(oHttpPostedFile.FileName));
                    
            }
        }
    }
}
