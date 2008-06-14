using System;
using System.Collections.Generic;
using System.Text;
public struct KHOI
{
    public String Ten;
    public LOP[] Lop;
}
class XuLyKhoi
{
    private static String ChuoiPhanCach = "/KHOI";    
    public static KHOI KhoiTao(String Chuoi)
    {
        Chuoi = Chuoi.Trim();
        KHOI kq;
        kq.Ten = "";
        kq.Lop = null;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
            kq.Ten = M[0];
            kq.Lop = new LOP[M.Length - 2];
            for (int i = 1; i < M.Length - 1; i++)
                kq.Lop[i - 1] = XyLyLop.KhoiTao(M[i]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        flag = M.Length > 1;
        for (int i = 1; i < M.Length - 1; i++)
            flag = flag && XyLyLop.KiemTra(M[i]);
        return flag;
    }
    public static String XuatChuoi(KHOI khoi)
    {
        String kq = khoi.Ten.Trim() + "(" + khoi.Lop.Length + " lop)\n";
        foreach (LOP x in khoi.Lop)
            kq += "\t\t" + XyLyLop.XuatChuoi(x) + "\n";
        return kq;
    }
}