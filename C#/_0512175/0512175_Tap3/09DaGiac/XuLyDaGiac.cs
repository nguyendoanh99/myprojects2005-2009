using System;
using System.Collections.Generic;
using System.Text;
public struct DAGIAC
{
    public DIEM[] Dinh;
}
class XuLyDaGiac
{
    private static String ChuoiPhanCach = " ";
    public static DAGIAC Doc(String TenFile)
    {
        String Chuoi = XuLyTapTin.Doc(TenFile);
        DAGIAC kq = KhoiTao(Chuoi);
        return kq;
    }
    public static DAGIAC KhoiTao(String Chuoi)
    {
        DAGIAC kq;
        kq.Dinh = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Dinh = new DIEM[M.Length];
            for (int i = 0; i < M.Length; i++)
                kq.Dinh[i] = XuLyDiem.KhoiTao(M[i]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
        flag = M.Length >= 3;
        if (flag)        
            for (int i = 0; i < M.Length; i++)
            {
                flag = XuLyDiem.KiemTra(M[i]);
                if (flag)
                    break;
            }        
        return flag;
    }
    public static String XuatChuoi(DAGIAC D)
    {
        String kq = "(";
        for (int i=0;i<D.Dinh.Length;i++)
        {
            kq = kq + XuLyDiem.XuatChuoi(D.Dinh[i]);
            if (i < D.Dinh.Length - 1)
                kq = kq + ChuoiPhanCach;
        }
        kq = kq + ")";
        return kq;
    }
    public static Double TinhChuVi(DAGIAC D)
    {
        Double kq = 0;
        for (int i = 1; i < D.Dinh.Length; i++)
            kq = kq + XuLyDiem.Khoang_cach(D.Dinh[i - 1], D.Dinh[i]);
        kq = kq + XuLyDiem.Khoang_cach(D.Dinh[D.Dinh.Length-1], D.Dinh[0]);
        return kq;
    }
}