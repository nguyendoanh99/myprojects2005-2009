using System;
using System.Collections.Generic;
using System.Text;

class XuLyDaySo
{
    private static String ChuoiPhanCach = " ";
    public static Double[] Doc(String TenTapTin)
    {
        Double []temp;
        String Chuoi=XuLyTapTin.Doc(TenTapTin);
        temp=KhoiTao(Chuoi);
        return temp;
    }
    public static Double[] KhoiTao(String Chuoi)
    {
        Double []temp=null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
            temp = new Double[M.Length];
            for (int i = 0; i < M.Length; i++)
                temp[i] = Double.Parse(M[i]);
        }
        return temp;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean temp = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        temp = (M.Length>0);
        if (temp)
            foreach(String ChuoiCon in M)
                temp = temp && XuLySoThuc.KiemTra(ChuoiCon);
        return temp;
    }
    public static Double Tong(Double[] a)
    {
        Double s = 0;
        foreach (Double x in a)
            s = s + x;
        return s;
    }
    public static String XuatChuoi(Double[]a)
    {
        String temp="";
        for(int i=0;i<a.Length;i++)
        {
            temp=temp+a[i];
            if (i < a.Length - 1)
                temp = temp + ChuoiPhanCach;
        }
        return temp;
    }
}
