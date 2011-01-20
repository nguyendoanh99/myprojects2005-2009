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
    public bool KiemTraGuiHopLe(CardDTO cardsend, decimal money)
    {
        return (new CardDAO()).KiemTraGuiHopLe(cardsend, money);
    }

    public bool KiemTraNhanHopLe(CardDTO cardreci)
    {
        return (new CardDAO()).KiemTraNhanHopLe(cardreci);
    }

    public bool NhanTien(CardDTO cardreci, decimal money)
    {
        return (new CardDAO()).NhanTien(cardreci, money);
    }

    public bool GuiTien(CardDTO cardsend, decimal money)
    {
        return (new CardDAO()).GuiTien(cardsend, money);
    }
}
