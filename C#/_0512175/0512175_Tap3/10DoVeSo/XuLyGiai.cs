using System;
using System.Collections.Generic;
using System.Text;
public struct GIAI
{
    public String Ten;
    public long TienThuong;
    public long[] So;
}

class XuLyGiai
{
    private static String ChuoiPhanCach = "\t";
    public static GIAI KhoiTao(String Chuoi)
    {
        GIAI kq;
        kq.Ten = "";
        kq.So = null;
        kq.TienThuong = long.MinValue;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Ten = M[0].Trim();
            kq.TienThuong = long.Parse(M[1]);
            kq.So = new long[M.Length - 2];
            for (int i = 2; i < M.Length; i++)
                kq.So[i-2] = long.Parse(M[i]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean kq = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);        
        kq = M.Length >= 3;
        for (int i = 2; i < M.Length; i++)
        {
            kq = XuLySoNguyen.KiemTra(M[i]);
            if (!kq)
                break;
        }            
        return kq;
    }
    public static String XuatChuoi(GIAI x)
    {
        String kq = x.Ten+"\t"+x.TienThuong+"\t";        
        foreach (long t in x.So)
            kq = kq + "\t" + t;        
        return kq;
    }
    public static long DoSo(GIAI g,long So)
    {
        String s = So.ToString();
        long kq=0;
        long len = g.So[0].ToString().Length;
        if (len <= s.Length)
        {
            s = s.Substring((int)(s.Length - len));
            foreach (long x in g.So)
                if (s.CompareTo(x.ToString()) == 0)
                    kq += g.TienThuong;
        }
        return kq;
    }
}