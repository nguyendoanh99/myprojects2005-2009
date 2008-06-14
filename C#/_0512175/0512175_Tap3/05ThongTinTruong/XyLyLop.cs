using System;
using System.Collections;


public struct LOP
{
    public String Ten;
    public long Siso;
}

class XyLyLop
{
    private static String ChuoiPhanCach = ";";
    public static LOP KhoiTao(String Chuoi)
    {
        Chuoi = Chuoi.Trim();
        LOP kq;
        kq.Siso = int.MaxValue;
        kq.Ten = "";
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Ten = M[0];
            kq.Siso = long.Parse(M[1]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean kq = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach }, StringSplitOptions.None);
        kq=M.Length==2;
        if (kq)
            kq=kq && XuLySoNguyen.KiemTra(M[1]);
        return kq;
    }
    public static String XuatChuoi(LOP x)
    {
        String kq = x.Ten.Trim() + "(" + x.Siso + " hoc sinh)";
        return kq;
    }
}