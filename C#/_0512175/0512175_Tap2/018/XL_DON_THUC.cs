using System;
using System.Collections;
public struct DON_THUC
{
    public Double He_so;
    public long So_mu;
}
class XL_DON_THUC
{
    public static DON_THUC Nhap()
    {
        DON_THUC kq;
        kq.He_so = XL_SO_THUC.Nhap("Nhap he so: ");
        kq.So_mu = XL_SO_NGUYEN.Nhap("Nhap so mu: ");
        return kq;
    }
    public static Double Tinh_gia_tri(DON_THUC Q, Double x0)
    {
        Double kq;
        kq = Q.He_so * Math.Pow(x0, Q.So_mu);
        return kq;
    }
    public static String Chuoi(DON_THUC Q)
    {
        String kq = "";
        kq = Q.He_so + "x^" + Q.So_mu;
        return kq;
    }
}
