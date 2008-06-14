using System;
using System.Collections.Generic;
using System.Text;

public struct CAUHOI
{
    public String NoiDung;
    public TRALOI[] TraLoi;
}
class XuLyCauHoi
{
    private static long n_traloi = 4;
    public static CAUHOI KhoiTao(BIEUTHUC P,Random t)
    {
        CAUHOI kq;
        kq.NoiDung = XuLyBieuThuc.XuatChuoi(P);
        kq.TraLoi = new TRALOI[n_traloi];
        for (int i = 0; i < n_traloi; i++)        
            kq.TraLoi[i] = XuLyTraLoi.KhoiTao(P,t);
        kq.TraLoi[t.Next() % n_traloi].NoiDung = XuLyBieuThuc.TinhToan(P).ToString();
        return kq;
    }
    public static String XuatChuoi(CAUHOI P)
    {
        String kq=P.NoiDung+" = \r\n";
        for (int i = 0; i < n_traloi; i++)
        {
            kq = kq + "(" + (i + 1) + ") " + XuLyTraLoi.XuatChuoi(P.TraLoi[i]);
            if (i < n_traloi - 1)
                kq = kq + "\t\t";
        }
        return kq;
    }
}