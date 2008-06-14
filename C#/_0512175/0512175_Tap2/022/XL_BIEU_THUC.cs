using System;
public struct BIEU_THUC
{
    public long[] So_hang;
    public TOAN_TU[] Toan_tu;
}
class XL_BIEU_THUC
{
    public static BIEU_THUC Nhap(String Ghi_chu)
    {
        BIEU_THUC kq;
        long n;
        XL_CHUOI.Xuat(Ghi_chu);
        n = XL_SO_NGUYEN.Nhap("Bieu thuc co bao nhieu so hang:");
        kq.So_hang = new long[n];
        kq.Toan_tu = new TOAN_TU[n - 1];
        char c;        
        kq.So_hang[0] = XL_SO_NGUYEN.Nhap("Nhap so hang thu 1 : ");
        for (int i = 1; i < n; i++)
        {
            kq.Toan_tu[i - 1] = XL_TOAN_TU.Nhap("Nhap toan tu thu " + i + " : ");            
            kq.So_hang[i] = XL_SO_NGUYEN.Nhap("Nhap so hang thu " + (i + 1) + " : ");
        }
        return kq;
    }
    public static long Tinh(BIEU_THUC P)
    {
        long kq = P.So_hang[0];
        for (int i = 1; i < P.So_hang.GetLength(0); i++)
        {
            if (P.Toan_tu[i - 1] == TOAN_TU.Cong)
                kq = kq + P.So_hang[i];
            else
                if (P.Toan_tu[i - 1] == TOAN_TU.Tru)
                    kq = kq - P.So_hang[i];
        }
        return kq;
    }
    public static String Chuoi(BIEU_THUC P)
    {
        String kq = "";
        kq = kq + P.So_hang[0];
        for (int i = 1; i < P.So_hang.GetLength(0); i++)
        {
            if (P.Toan_tu[i - 1] == TOAN_TU.Cong)
                kq = kq + " + ";
            else
                if (P.Toan_tu[i - 1] == TOAN_TU.Tru)
                    kq = kq + " - ";
            kq = kq + P.So_hang[i];
        }
        return kq;
    }
}
