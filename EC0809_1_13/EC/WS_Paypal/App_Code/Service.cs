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
    public bool ThanhToan(WS_Bank_oFFS.CardDTO cardsend, WS_Bank_oFFS.CardDTO cardreci, decimal money) 
    {
        WS_Bank_oFFS.Service bankws = new WS_Bank_oFFS.Service();

        if (bankws.KiemTraGuiHopLe(cardsend, money) == true)
            if (bankws.KiemTraNhanHopLe(cardreci) == true)
                if (bankws.GuiTien(cardsend, money) == true)
                    return bankws.NhanTien(cardreci, money);
        return false;
    }
    
}
