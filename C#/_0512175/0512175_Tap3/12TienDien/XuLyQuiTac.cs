using System;
using System.Collections.Generic;
using System.Text;

class XuLyQuiTac
{
    private static String ChuoiPhanCach = "\r\n";
    public static DINHMUC[] Doc(String TenFile)
    {
        DINHMUC[] kq;
        String Chuoi = XuLyTapTin.Doc(TenFile);
        kq = KhoiTao(Chuoi);
        return kq;
    }
    public static DINHMUC[] KhoiTao(String Chuoi)
    {
        DINHMUC[] kq;
        kq= null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq= new DINHMUC[M.Length];
            for (int i = 0; i < M.Length; i++)
                kq[i] = XuLyDinhMuc.KhoiTao(M[i]);
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
            flag = XuLyDinhMuc.KiemTra(M[i]);
        return flag;
    }
    public static String XuatChuoi(DINHMUC[] QuiTac)
    {
        String Chuoi = "";
        for (int i = 0; i < QuiTac.Length; i++)
        {
            Chuoi = Chuoi + XuLyDinhMuc.XuatChuoi(QuiTac[i]);
            if (i < QuiTac.Length - 1)
                Chuoi = Chuoi + "\n";
        }
        return Chuoi;
    }
    public static Double TinhTien(DINHMUC[] P, Double SoKw)
    {
        Double kq = 0;
        int i = 0;
        for (; SoKw > 0 && i < P.Length; i++)
        {
            if (SoKw - P[i].GiaTri > 0)
                kq = kq + P[i].GiaTri * P[i].DonGia;
            else
                kq = kq + P[i].DonGia * SoKw;
            SoKw -= P[i].GiaTri;            
        }        
        return kq;
    }
}