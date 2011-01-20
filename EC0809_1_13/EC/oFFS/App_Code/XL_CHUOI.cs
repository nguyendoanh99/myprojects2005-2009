using System;
using System.Web;

    public class XL_CHUOI
    {

        public static string Nhap(HttpRequest Nguon, string Ten)
        {
            string Kq = null;
            Kq = Nguon[Ten];
            return Kq;
        }
        public static void XuatXML(HttpResponse Dich, string Chuoi)
        {
            Dich.ContentType = "text/xml";
            Dich.Write(Chuoi);
        }
        public static void XuatChuoi(HttpResponse Dich, string Chuoi)
        {
            Dich.Write(Chuoi);
        }
    }

