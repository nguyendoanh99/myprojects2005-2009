using System;
using System.Collections.Generic;
using System.Text;
public struct TRUONG
{
    public String Ten;
    public KHOI[] Khoi;
}
class XuLyTruong
{
    private static String ChuoiPhanCach = "/TRUONG";    
    public static TRUONG Doc(String TenFile)
    {
        TRUONG kq;
        String Chuoi = XuLyTapTin.Doc(TenFile);
        kq = KhoiTao(Chuoi);
        return kq;
    }
    public static TRUONG KhoiTao(String Chuoi)
    {
        Chuoi = Chuoi.Trim();
        TRUONG kq;
        kq.Ten = "";
        kq.Khoi = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, 
                StringSplitOptions.None);
            kq.Ten = M[0];            
            kq.Khoi = new KHOI[M.Length-1];
            for (int i = 1; i < M.Length; i++)
                 kq.Khoi[i-1] = XuLyKhoi.KhoiTao(M[i]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
        flag = M.Length > 1;
        for (int i = 1; i < M.Length; i++)
            flag = flag && XuLyKhoi.KiemTra(M[i]);
        return flag;
    }
    public static String XuatChuoi(TRUONG Truong)
    {
        String kq = Truong.Ten.Trim() + "(" + Truong.Khoi.Length + " khoi)\n";
        foreach (KHOI x in Truong.Khoi)
            kq += "\t" + XuLyKhoi.XuatChuoi(x) + "\n";
        return kq;
    }
}
