using System;
using System.Collections.Generic;
using System.Text;

public struct DonThuc
{
    public Double HeSo;
    public long SoMu;
}

class XuLyDonThuc
{
    private static String ChuoiPhanCach = "x^";
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean temp = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        temp=(M.Length==2);
        if (temp)
            temp = temp&&XuLySoThuc.KiemTra(M[0])&&XuLySoNguyen.KiemTra(M[1]);
        return temp;
    }
    public static DonThuc KhoiTao(String Chuoi)
    {
        DonThuc temp;
        temp.HeSo = Double.MaxValue;
        temp.SoMu = long.MaxValue;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
            temp.HeSo = Double.Parse(M[0]);
            temp.SoMu = long.Parse(M[1]);
        }
        return temp;
    }
    public static DonThuc Doc(String TenTapTin)
    {
        DonThuc temp;
        String Chuoi = XuLyTapTin.Doc(TenTapTin);
        temp = KhoiTao(Chuoi);
        return temp;
    }
    public static Double TinhGiaTri(DonThuc P, Double x0)
    {
        Double temp;
        temp = P.HeSo * Math.Pow(x0, P.SoMu);
        return temp;
    }
    public static String XuatChuoi(DonThuc P)
    {
        String temp;
        temp = P.HeSo + ChuoiPhanCach + P.SoMu;
        // Chưa xem xét hết các trường hợp
        return temp;
    }
}

