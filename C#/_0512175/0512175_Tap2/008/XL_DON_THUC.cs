using System;
public struct DON_THUC
{
    public Double He_so;
    public long So_mu;
}
class XL_DON_THUC
{
    public static DON_THUC Nhap(String Ghi_chu)
    {
        DON_THUC kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.He_so = XL_SO_THUC.Nhap("He so = ");
        kq.So_mu = XL_SO_NGUYEN.Nhap("So mu = ");
        return kq;
    }
    public static Double Tinh_gia_tri(DON_THUC P, Double x0)
    {
        Double kq;
        kq = P.He_so * Math.Pow(x0, P.So_mu);
        return kq;
    }
    public static String Chuoi(DON_THUC P)
    {
        String kq;
        kq = P.He_so + "x^" + P.So_mu;
        return kq;
    }
}

