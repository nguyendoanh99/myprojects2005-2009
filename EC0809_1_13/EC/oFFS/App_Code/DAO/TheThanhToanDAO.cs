using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TheThanhToan
/// </summary>
public class TheThanhToanDAO : AbstractDAO
{
    public bool CapNhatTheThanhToan(TheThanhToanDTO tttDto)
    {
        Connect();
        string strSql = "update THE_THANH_TOAN set MaLoaiThe = @maloaithe ";
        strSql += ", SoThe = @sothe ";
        strSql += ", NgayHetHan = @ngayhethan ";
        strSql += "where MaThe = @mathe";

        SqlCommand cmd = new SqlCommand(strSql, cnn);
        cmd.Parameters.Add("@maloaithe", SqlDbType.Int);
        cmd.Parameters.Add("@sothe", SqlDbType.VarChar);
        cmd.Parameters.Add("@ngayhethan", SqlDbType.DateTime);
        cmd.Parameters.Add("@mathe", SqlDbType.Int);

        cmd.Parameters["@maloaithe"].Value = tttDto.Ma_loai_the;
        cmd.Parameters["@sothe"].Value = tttDto.So_the; 
        cmd.Parameters["@ngayhethan"].Value = tttDto.Ngay_het_han;
        cmd.Parameters["@mathe"].Value = tttDto.Ma_the;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            cnn.Close();
            return false;
        }

        Disconnect();
        return true;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        TheThanhToanDTO the = new TheThanhToanDTO();
        the.Ma_the = (int)dt.Rows[i]["MaThe"];
        the.So_the = dt.Rows[i]["SoThe"].ToString();
        the.Ngay_het_han = (DateTime)dt.Rows[i]["NgayHetHan"];
        the.Ma_loai_the = (int)dt.Rows[i]["MaLoaiThe"];

        return (object)the;
    }  
   
}
