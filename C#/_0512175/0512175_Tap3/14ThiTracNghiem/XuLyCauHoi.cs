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
    private static String ChuoiPhanCach = "\r\n";
    private static long n_traloi = 4;
    public static CAUHOI[] Doc(String TenFile)
    {
        CAUHOI[] kq;
        String Chuoi = XuLyTapTin.Doc(TenFile);
        kq = KhoiTao(Chuoi);
        return kq;
    }
    public static CAUHOI[] KhoiTao(String Chuoi)
    {
        CAUHOI[] kq;
        kq = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq = new CAUHOI[M.Length / 2];
            String S;
            for (int i = 0, j = 0; i < M.Length; i += 2, j++)
            {
                S = M[i].Replace("=", "");
                kq[j].NoiDung = S.Trim();
                kq[j].TraLoi = XuLyTraLoi.KhoiTao(M[i + 1]);
            }
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
            StringSplitOptions.None);
        flag = (M.Length > 0) && (M.Length % 2 == 0);        
        String S;
        for (int i = 0, j = 0; flag && i < M.Length; i += 2, j++)
            flag= XuLyTraLoi.KiemTra(M[i + 1]);
        return flag;
    }
    public static long TraLoiCauHoi(CAUHOI P)
    {
        Boolean flag = true;
        BIEUTHUC Q = XuLyBieuThuc.KhoiTao(P.NoiDung);
        long t=XuLyBieuThuc.TinhToan(Q);
        for (int i = 0; i < P.TraLoi.Length; i++)
            if (t == long.Parse(P.TraLoi[i].NoiDung))
                return i+1;
        return -1;
    }
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