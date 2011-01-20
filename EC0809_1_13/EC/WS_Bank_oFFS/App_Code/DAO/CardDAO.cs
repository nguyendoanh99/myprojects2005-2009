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
/// Summary description for CardDAO
/// </summary>
public class CardDAO: AbstractDAO
{
    public bool KiemTraGuiHopLe(CardDTO cardsend, decimal money)
    {
        SqlConnection cnn =  Connect();
        /*
        SqlCommand cmd = new SqlCommand("spKiemTraHopLeMasterCard", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        string de_code = code; //Security.Decrypt(code);

        cmd.Parameters.Add("@code", SqlDbType.VarChar);
        cmd.Parameters["@code"].Value = de_code;
        */

        //string de_code = Security.Decrypt(code);

        string strSQL = "Select * From " + cardsend.Type.Trim() + "Balance";
        strSQL += " Where Code = 0x" + cardsend.Code;
        strSQL += " and Balance >= " + money;

        SqlCommand cmd = new SqlCommand(strSQL, cnn);

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Disconnect();
            return true;
        }

        Disconnect();
        return false;
    }

    public bool KiemTraNhanHopLe(CardDTO cardreci)
    {
        SqlConnection cnn = Connect();

        string strSQL = "Select * From " + cardreci.Type.Trim() + "Balance";
        strSQL += " Where Code = 0x" + cardreci.Code;
  
        SqlCommand cmd = new SqlCommand(strSQL, cnn);

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Disconnect();
            return true;
        }

        Disconnect();
        return false;
    }

    public bool GuiTien(CardDTO cardsend, decimal money)
    {
        SqlConnection cnn = Connect();

        string strSQL = "Update " + cardsend.Type.Trim() + "Balance";
        strSQL += " Set Balance = Balance - " + money;
        strSQL += " Where Code = 0x" + cardsend.Code;

        SqlCommand cmd = new SqlCommand(strSQL, cnn);
        
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            return false;
        }

        Disconnect();
        return true;
    }

    public bool NhanTien(CardDTO cardreci, decimal money)
    {
        SqlConnection cnn = Connect();

        string strSQL = "Update " + cardreci.Type.Trim() + "Balance";
        strSQL += " Set Balance = Balance + " + money;
        strSQL += " Where Code = 0x" + cardreci.Code;

        SqlCommand cmd = new SqlCommand(strSQL, cnn);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            return false;
        }

        Disconnect();
        return true;
    }

}
