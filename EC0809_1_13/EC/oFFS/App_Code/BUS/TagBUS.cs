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
/// Summary description for TagBUS
/// </summary>
public class TagBUS
{

    /// <summary>
    /// Cap nhat do uu tien cua tag
    /// </summary>
    /// <param name="maItem">ma item</param>
    /// <param name="loai">0 : mon an, 1 : thuc don</param>
    public void CapNhatDoUuTien(int maItem, int loai)
    {
        dao.CapNhatDoUuTien(maItem, loai);
    }

	public TagBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    TagDAO dao = new TagDAO();
    public TagDTO[] LayDanhSachTag()
    {
        return dao.LayDanhSachTag();
    }
}
