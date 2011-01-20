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
/// Summary description for LoaiThucDonDAO
/// </summary>
public class LoaiThucDonDAO : AbstractDAO
{
	public LoaiThucDonDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public LoaiThucDonDTO[] LayDanhSachLoaiThucDon()
    {
        LoaiThucDonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiThucDonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithucdon = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiThucDonDTO)loaithucdon;
        }

        Disconnect();
        return Kq;
    }

    // Lấy dah sách loại thực đơn ở cấp cao nhất
    public LoaiThucDonDTO[] LayDanhSachLoaiThucDonRoot()
    {
        LoaiThucDonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDSLoaiThucDonCapRoot", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiThucDonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithucdon = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiThucDonDTO)loaithucdon;
        }

        Disconnect();
        return Kq;
    }

    //Lấy danh sách loại thực đơn con trực tiếp của một loại thực đơn
    public LoaiThucDonDTO[] LayDanhSachLoaiThucDonConTrucTiep(int maloaithucdon)
    {
        LoaiThucDonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDSLoaiThucDonConTrucTiep", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@maloaithucdoncha", SqlDbType.Int);
        cmd.Parameters["@maloaithucdoncha"].Value = maloaithucdon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiThucDonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithucdon = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiThucDonDTO)loaithucdon;
        }

        Disconnect();
        return Kq;
    }

    public LoaiThucDonDTO ChiTietLoaiThucDon(int maloaithucdon)
    {
        SqlCommand cmd = CreateCommandStored("spChiTietLoaiThucDon",
            new string[] { "@ma_loai_thuc_don" },
            new object[] { maloaithucdon });
        LoaiThucDonDTO[] kq = (LoaiThucDonDTO[])LayDanhSach(typeof(LoaiThucDonDTO), cmd);
        if (kq.Length == 0)
            return null;

        return kq[0];        
    }

    public LoaiThucDonDTO[] DanhSachLoaiThucDonCon(int MaLTDCha)
    {
        LoaiThucDonDTO[] kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDSLoaiThucDonConTrucTiep", cnn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@maloaithucdoncha", SqlDbType.Int);
        cmd.Parameters["@maloaithucdoncha"].Value = MaLTDCha;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        kq = new LoaiThucDonDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object loaithucdon = GetDataFromDataRow(tab, i);
            kq[i] = (LoaiThucDonDTO)loaithucdon;
        }

        Disconnect();
        return kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(LoaiThucDonDTO), dt.Rows[i]);
    }  
}
