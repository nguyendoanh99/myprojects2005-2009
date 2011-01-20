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
using System.Text;

/// <summary>
/// Summary description for MasterCardDAO
/// </summary>
public class CardDAO : AbstractDAO
{
    public bool KiemTraHopLe(CardDTO cardDto)
    {
        SqlConnection cnn =  Connect();
        /*
        SqlCommand cmd = new SqlCommand("spKiemTraHopLeMasterCard", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        string de_code = code; //Security.Decrypt(code);

        cmd.Parameters.Add("@code", SqlDbType.VarChar);
        cmd.Parameters["@code"].Value = de_code
        */

        //string de_code = Security.Decrypt(code);
        
        string de_code = cardDto.Code;
        byte[] b = UnicodeEncoding.Unicode.GetBytes(cardDto.Type);

        
        string strSQL = "Select * From " + cardDto.Type;
        strSQL += " Where Code = 0x" + cardDto.Code;
        //strSQL += " And datediff(s, ExpiredDate, @ngayhethan) = 0";
        strSQL += " And datediff(s, ExpiredDate, getDate()) < 0";
        

        SqlCommand cmd = new SqlCommand(strSQL, cnn);
        //cmd.Parameters.Add("@code", SqlDbType.VarBinary);
        //cmd.Parameters.Add("@ngayhethan", SqlDbType.DateTime);

        //cmd.Parameters["@code"].Value = b;
        //cmd.Parameters["@ngayhethan"].Value = cardDto.Expried_date.ToShortDateString();

        /*
        strSQL += " Where Code = 0x" + de_code;
        strSQL += " And datediff(s, ExpiredDate,'" + cardDto.Expried_date.ToShortDateString()+ "') = 0";
        strSQL += " And datediff(s, ExpiredDate, getDate()) < 0";
        */


        //SqlCommand cmd = new SqlCommand(strSQL, cnn);

        SqlDataReader dr = cmd.ExecuteReader();
        try
        {
            if (dr.Read())
            {
                Disconnect();
                return true;
            }
        }
        catch (System.Exception e)
        {
        	
        }
        

        Disconnect();
        return false;
    }
}
