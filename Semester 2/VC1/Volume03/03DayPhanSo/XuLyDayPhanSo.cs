using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

class XuLyDayPhanSo
{
    private static String ChuoiPhanCach = ",";
    public static ArrayList Doc(String TenTapTin)
    {
        ArrayList temp;
        String Chuoi = XuLyTapTin.Doc(TenTapTin);
        temp = KhoiTao(Chuoi);
        return temp;
    }
    public static ArrayList KhoiTao(String Chuoi)
    {
        ArrayList temp = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
            temp = new ArrayList();
            foreach (String ChuoiCon in M)
                temp.Add(XuLyPhanSo.KhoiTao(ChuoiCon));
        }
        return temp;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean temp = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        temp = (M.Length > 0);
        if (temp)
            foreach (String ChuoiCon in M)
                temp = temp && XuLyPhanSo.KiemTra(ChuoiCon);
        return temp;
    }
    public static PHANSO LonNhat(ArrayList a)
    {
        PHANSO lc = (PHANSO)a[0];
        foreach (PHANSO x in a)
            if (XuLyPhanSo.SoSanh(x, lc) == QUANHE.LonHon)
                lc = x;
        return lc;
    }
    public static String XuatChuoi(ArrayList a)
    {
        String temp = "";
        for (int i = 0; i < a.Count; i++)
        {
            PHANSO x = (PHANSO)a[i];
            temp = temp + XuLyPhanSo.XuatChuoi(x);
            if (i < a.Count - 1)
                temp = temp + ChuoiPhanCach;
        }
        return temp;
    }
}

