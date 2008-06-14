using System;
using System.Collections.Generic;
using System.Text;
public enum QUANHE
{
    NhoHon,
    BangNhau,
    LonHon
}
public struct PHANSO
{
    public int Tu;
    public int Mau;
}

class XuLyPhanSo
{
    private static String ChuoiPhanCach = "/";
    public static PHANSO KhoiTao(String Chuoi)
    {
        PHANSO temp;
        temp.Tu = 1;
        temp.Mau = 1;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
            temp.Tu = int.Parse(M[0]);
            temp.Mau = int.Parse(M[1]);
        }
        return temp;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean temp = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        temp = (M.Length == 2);
        if (temp)
            temp = temp && XuLySoNguyen.KiemTra(M[0]) && XuLySoNguyen.KiemTra(M[1]);
        return temp;
    }
    public static PHANSO Hieu(PHANSO a, PHANSO b)
    {
        PHANSO temp;
        temp.Tu = a.Tu * b.Mau - a.Mau * b.Tu;
        temp.Mau = a.Mau * b.Mau;
        return temp;
    }
    public static Boolean KiemTraDuong(PHANSO x)
    {
        if (x.Tu > 0 && x.Mau > 0)
            return true;
        if (x.Tu < 0 && x.Mau < 0)
            return true;
        return false;
    }
    public static Boolean KiemTraAm(PHANSO x)
    {
        if (x.Tu > 0 && x.Mau < 0)
            return true;
        if (x.Tu < 0 && x.Mau > 0)
            return true;
        return false;
    }
    public static QUANHE SoSanh(PHANSO a, PHANSO b)
    {
        QUANHE temp = QUANHE.BangNhau;
        PHANSO h = Hieu(a, b);
        if (KiemTraDuong(h))
            temp = QUANHE.LonHon;
        if (KiemTraAm(h))
            temp = QUANHE.NhoHon;
        return temp;
    }
    public static String XuatChuoi(PHANSO x)
    {
        String Chuoi;
        Chuoi = x.Tu + ChuoiPhanCach + x.Mau;
        return Chuoi;
    }
}

