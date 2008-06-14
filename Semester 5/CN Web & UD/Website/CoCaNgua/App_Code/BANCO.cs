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
/// Summary description for TrangThaiBanCo
/// </summary>
public class BANCO
{
    private int[] marrViTriQuanCo;
    public int[] ViTriCacQuanCo
    {
        get
        {
            return marrViTriQuanCo;
        }
        set
        {
            marrViTriQuanCo = value;
        }
    }
	public BANCO()
	{
		//
		// TODO: Add constructor logic here
		//
        int[] DanhSachCo = new int[16];

        for (int i = 0; i < 16; ++i)
            DanhSachCo[i] = -1;

        ViTriCacQuanCo = DanhSachCo;
	}
}
