using System;
using System.Collections.Generic;
using System.Text;

public struct TRALOI
{
    public String NoiDung;
}
class XuLyTraLoi
{
    public static TRALOI KhoiTao(BIEUTHUC P,Random t)
    {

        TRALOI kq;
        kq.NoiDung = "";
        long k = XuLyBieuThuc.TinhToan(P) + t.Next()%100;
        kq.NoiDung = k.ToString();
        return kq;
    }
    public static String XuatChuoi(TRALOI P)
    {
        String kq = "";
        kq = P.NoiDung;
        return kq;
    }
}
