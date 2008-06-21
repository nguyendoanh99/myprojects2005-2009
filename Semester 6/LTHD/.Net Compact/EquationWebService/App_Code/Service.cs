using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]    
    public byte[] GiaiPT(float a, float b, float c)
    {
        TamThuc tt = new TamThuc(a, b, c);
        Nghiem kq = tt.GiaiPT();
        string s = kq.ToXMLDocument();
        return Encoding.ASCII.GetBytes(s);
    }
    
}