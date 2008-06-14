using System;
using System.Collections;
class XL_DA_THUC
{
    public static ArrayList Nhap(String Ghi_Chu)
    {
        ArrayList kq = new ArrayList();
        long n;
        XL_CHUOI.Xuat(Ghi_Chu);
        n = XL_SO_NGUYEN.Nhap("Da thuc co bao nhieu don thuc:");
        DON_THUC p;
        for (int i = 0; i < n; i++)
        {
            p = XL_DON_THUC.Nhap();
            kq.Add(p);
        }
        return kq;
    }
    public static Double Tinh_gia_tri(ArrayList P, Double x0)
    {
        Double kq = 0;
        foreach (DON_THUC q in P)
        {
            kq = kq + XL_DON_THUC.Tinh_gia_tri(q, x0);
        }
        return kq;
    }
    public static String Chuoi(ArrayList P)
    {
        String kq = "";
        int i = 0;
        foreach (DON_THUC q in P)
        {
            kq = kq + XL_DON_THUC.Chuoi(q);
            if (i < P.Count - 1)
                kq = kq + "+";
            i++;
        }
        return kq;
    }        
}