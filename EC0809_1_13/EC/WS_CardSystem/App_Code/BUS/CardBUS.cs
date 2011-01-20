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
/// Summary description for CardBUS
/// </summary>
public class CardBUS
{
    public bool KiemTraHopLe(CardDTO cardDto)
    {
        return (new CardDAO()).KiemTraHopLe(cardDto);
    }
}
