using System;
using System.Collections.Generic;
using System.Text;

public struct TRALOI
{
    public String NoiDung;
}
class XuLyTraLoi
{
    private static String ChuoiPhanCach = "\t\t";
    public static TRALOI[] KhoiTao(String Chuoi)
    {
        TRALOI[] kq;
        kq = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq = new TRALOI[M.Length];
            for (int i = 0; i < M.Length; i++)
            {
                String[] N = M[i].Split(new String[] { " " },
                    StringSplitOptions.None);
                kq[i].NoiDung = N[1].Trim();
            }
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
            StringSplitOptions.None);
        flag = M.Length > 0;
        for (int i = 0; flag && i < M.Length; i++)
        {
            String[] N = M[i].Split(new String[] { " " },
                StringSplitOptions.None);
            flag = N.Length == 2;
            if (flag)
                flag = XuLySoNguyen.KiemTra(N[1].Trim());
        }
        return flag;
    }
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
