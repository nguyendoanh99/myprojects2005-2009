using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for NoiDungEmail
/// </summary>
public class NoiDungEmailDAO : AbstractDAO
{
    public NoiDungEmailDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(NoiDungEmailDTO), dt.Rows[i]);
    }

    public bool ThemNoiDungEmail(NoiDungEmailDTO dto)
    {
        SqlCommand cmd = CreateCommandStored("spThemNoiDungEmail",
             new string[] { "@UserName", "@Email", "@NgayGui", "@TieuDe", "@NoiDung"},
             new object[] { dto.Username, dto.Email, dto.NgayGui, dto.TieuDe, dto.NoiDung});
        return ExecuteNonQuery(cmd);
    }

    public NoiDungEmailDTO[] LayDanhSach()
    {
        SqlCommand cmd = CreateCommandStored("spLayDanhSach",
             new string[] { },
             new object[] {  });
        NoiDungEmailDTO[] kq = (NoiDungEmailDTO[])LayDanhSach(typeof(NoiDungEmailDTO), cmd);
        return kq;
    }

    public NoiDungEmailDTO LayNoiDungEmail(int maMail)
    {
        SqlCommand cmd = CreateCommandStored("spLayNoiDungEmail",
             new string[] { "@MaMail" },
             new object[] { maMail });
        NoiDungEmailDTO[] kq = (NoiDungEmailDTO[])LayDanhSach(typeof(NoiDungEmailDTO), cmd);
        if (kq.Length == 0)
            return null;

        return kq[0];
    }
}
