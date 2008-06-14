using System;
using System.Collections.Generic;
using System.Text;
public struct KET_QUA_XO_SO
{
    public String Ten;
    public GIAI[] Giai;
}
class XuLyKetQuaXoSo
{
    private static String ChuoiPhanCach = "\r\n";
    public static KET_QUA_XO_SO Doc(String TenFile)
    {
        KET_QUA_XO_SO kq;
        String Chuoi = XuLyTapTin.Doc(TenFile);
        kq = KhoiTao(Chuoi);
        return kq;
    }
    public static KET_QUA_XO_SO KhoiTao(String Chuoi)
    {
        KET_QUA_XO_SO kq;
        kq.Ten = "";
        kq.Giai = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Ten = M[0].Trim();
            kq.Giai = new GIAI[M.Length - 1];
            for (int i = 1; i < M.Length; i++)
                kq.Giai[i-1] = XuLyGiai.KhoiTao(M[i]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);        
        flag = M.Length >= 2;
        for (int i = 1; i < M.Length; i++)
        {
            flag= XuLyGiai.KiemTra(M[i]);
            if (flag == false)
                break;
        }
        return flag;
    }
    public static String XuatChuoi(KET_QUA_XO_SO K)
    {
        String kq = K.Ten;
        foreach (GIAI x in K.Giai)
            kq += "\n" + XuLyGiai.XuatChuoi(x);
        return kq;
    }
    public static long DoSo(KET_QUA_XO_SO K, long so)
    {
        long kq = 0;
        foreach (GIAI x in K.Giai)
            kq += XuLyGiai.DoSo(x, so);
        return kq;
    }
}
