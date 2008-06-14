using System;
public struct TAM_THUC
{
    public Double a;
    public Double b;
    public Double c;
}
class XL_TAM_THUC
{
    public static TAM_THUC Nhap(String Ghi_chu)
    {
        TAM_THUC kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.a = XL_SO_THUC.Nhap("Nhap a: ");
        kq.b = XL_SO_THUC.Nhap("Nhap b: ");
        kq.c = XL_SO_THUC.Nhap("Nhap c: ");
        return kq;
    }
    public static Double Gia_tri(TAM_THUC P, Double x0)
    {
        Double kq;
        kq = P.a * x0 * x0 + P.b * x0 + P.c;
        return kq;
    }
    public static CUC_TRI Cuc_tri(TAM_THUC P)
    {
        CUC_TRI kq;
        kq.x = -P.b / (2 * P.a);
        kq.y = Gia_tri(P, kq.x);
        if (P.a > 0)
            kq.Cuc_dai = false;
        else
            kq.Cuc_dai = true;
        return kq;
    }    
    public static String Chuoi(TAM_THUC P)
    {
        String kq;
        kq = P.a + "x^2";
        if (P.b < 0)
            kq = kq + P.b + "x";
        else
            kq = kq + "+" + P.b + "x";
        if (P.c < 0)
            kq = kq + P.c;
        else
            kq = kq + "+" + P.c;
        return kq;
    }
}
