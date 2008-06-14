using System;
using System.Collections;
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
        kq.a = XL_SO_THUC.Nhap("a=");
        kq.b = XL_SO_THUC.Nhap("b=");
        kq.c = XL_SO_THUC.Nhap("c=");
        return kq;
    }
    public static ArrayList Nghiem(TAM_THUC P)
    {
        ArrayList kq = new ArrayList();
        Double Delta = P.b * P.b - 4 * P.a * P.c;
        if (Delta == 0)
            kq.Add(P.b / (2 * P.a));
        else
            if (Delta > 0)
            {
                kq.Add((-P.b - Math.Sqrt(Delta)) / (2 * P.a));
                kq.Add((-P.b + Math.Sqrt(Delta)) / (2 * P.a));
            }
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
