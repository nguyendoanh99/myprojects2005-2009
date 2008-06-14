using System;
using System.Collections.Generic;
using System.Text;

class XuLyMaTran
{
    private static String ChuoiPhanCach = "\r\n";
    public static Double[][] Doc(String TenTapTin)
    {
        Double[][]temp;
        String Chuoi = XuLyTapTin.Doc(TenTapTin);
        temp = KhoiTao(Chuoi);
        return temp;
    }
    public static Double[][] KhoiTao(String Chuoi)
    {
        Double [][]temp=null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
            temp = new Double[M.Length][];
            for (int i = 0; i < M.Length; i++)
                temp[i] = XuLyDaySo.KhoiTao(M[i]);
        }
        return temp;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        flag = M.Length > 0;
        if (flag)
            foreach (String ChuoiCon in M)
                flag = flag && XuLyDaySo.KiemTra(ChuoiCon);
        return flag;
    }
    public static Double Tong(Double[][] a)
    {
        Double s = 0;
        foreach (Double[] dong in a)
            s = s + XuLyDaySo.Tong(dong);
        return s;
    }
    public static String XuatChuoi(Double[][] a)
    {
        String temp = "";
        foreach (Double[] dong in a)
            temp = temp + XuLyDaySo.XuatChuoi(dong) + ChuoiPhanCach;
        return temp;
    }
}

