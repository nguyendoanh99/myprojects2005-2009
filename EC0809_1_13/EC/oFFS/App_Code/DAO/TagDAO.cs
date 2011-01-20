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
/// Summary description for Tag
/// </summary>
public class TagDAO : AbstractDAO
{
    public int ThemTag(TagDTO tag)
    {
        int Kq = 0; //mã người dùng
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemTag", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tentag", SqlDbType.NVarChar);
        cmd.Parameters["@tentag"].Value = tag.Ten_tag;

        cmd.Parameters.Add("@douutien", SqlDbType.Int);
        cmd.Parameters["@douutien"].Value = tag.Do_uu_tien;

        cmd.Parameters.Add("@matag", SqlDbType.Int);
        cmd.Parameters["@matag"].Direction = ParameterDirection.Output;

        try
        {   
            cmd.ExecuteNonQuery();
            Kq = (int)cmd.Parameters["@matag"].Value;
        }
        catch (Exception ex)
        { }

        Disconnect();
        return Kq;
        
    }

    public void CapNhatDoUuTien(int maItem, int loai)
    {
        SqlConnection cnn = Connect();
        SqlCommand cmd = new SqlCommand();
        if (loai == 0)
            cmd = new SqlCommand("spCapNhatDoUuTienTagMonAn", cnn);
        else
            cmd = new SqlCommand("spCapNhatDoUuTienTagThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@maItem", SqlDbType.Int);
        cmd.Parameters["@maItem"].Value = maItem;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        { }

        Disconnect();        
    }

    public TagDTO[] LayDanhSachTag()
    {
        TagDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachTag", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new TagDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (TagDTO)loaithe;
        }

        Disconnect();
        return Kq;
    }

    public static String[] XuLyChuoiTag(string strTag)
    {
        String[] Kq;
        char[] splitSign = { ',', ';' };

        Kq = strTag.Split(splitSign, StringSplitOptions.RemoveEmptyEntries);
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        TagDTO tag = new TagDTO();

        tag.Ma_tag = (int)dt.Rows[i]["MaTag"];
        tag.Ten_tag = dt.Rows[i]["TenTag"].ToString();
        tag.Do_uu_tien = (int)dt.Rows[i]["DoUuTien"];

        return (object)tag;
    } 
}
