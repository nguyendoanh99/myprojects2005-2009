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
        kq.He_so = XL_SO_THUC.Nhap("He so a = ");
        kq.So_mu = XL_SO_NGUYEN.Nhap("So mu n = ");
        return kq;
    }
    public static DON_THUC Dao_ham(DON_THUC P)
    {
        DON_THUC kq;
        kq.He_so = P.So_mu * P.He_so;
        kq.So_mu = P.So_mu - 1;
        if (kq.So_mu < 0)
            kq.So_mu = 0;
        return kq;
    }
    public static String Chuoi(DON_THUC P)
    {
        String kq;
        kq = P.He_so + "x^" + P.So_mu;
        return kq;
    }
}