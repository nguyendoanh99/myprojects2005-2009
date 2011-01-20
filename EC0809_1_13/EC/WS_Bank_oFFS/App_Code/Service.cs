using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
   
    [WebMethod]
    public bool KiemTraNhanHopLe(CardDTO cardreci) 
    {
        return (new CardBUS()).KiemTraNhanHopLe(cardreci);
    }

    [WebMethod]
    public bool KiemTraGuiHopLe(CardDTO cardsend, decimal money)
    {
        return (new CardBUS()).KiemTraGuiHopLe(cardsend, money);
    }

    [WebMethod]
    public bool GuiTien(CardDTO cardsend, decimal money)
    {
        bool kq = KiemTraGuiHopLe(cardsend, money);
        if (kq == true)
            return (new CardBUS()).GuiTien(cardsend, money);
        return false;
    }

    [WebMethod]
    public bool NhanTien(CardDTO cardreci, decimal money)
    {
        bool kq = KiemTraNhanHopLe(cardreci);
        if(kq == true)
            return (new CardBUS()).NhanTien(cardreci, money);
        return false;
    }
}
