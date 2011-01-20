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
/// Summary description for TagThucDonBUS
/// </summary>
public class TagThucDonBUS
{
    public void ThemTagThucDon(TagThucDonDTO tagthucdon)
    {
        (new TagThucDonDAO()).ThemTagThucDon(tagthucdon);
    }

    public ThucDonDTO[] DSThucDonTheoTag(int matag)
    {
        return (new TagThucDonDAO()).DSThucDonTheoTag(matag);
    }
}
