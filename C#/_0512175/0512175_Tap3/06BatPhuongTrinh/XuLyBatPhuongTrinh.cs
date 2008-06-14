using System;
using System.Collections.Generic;
using System.Text;
public struct BAT_PHUONG_TRINH
{
    public Double a;
    public Double b;
}
class XuLyBatPhuongTrinh
{
    private static String ChuoiPhanCach = " ";
    public static BAT_PHUONG_TRINH KhoiTao(String Chuoi)
    {
        BAT_PHUONG_TRINH kq;
        kq.a = 0;
        kq.b = 0;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.a = Double.Parse(M[0]);
            kq.b = Double.Parse(M[1]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
            StringSplitOptions.None);
        flag = M.Length == 2;
        if (flag)
            flag = XuLySoThuc.KiemTra(M[0]) && XuLySoThuc.KiemTra(M[1]);
        return flag;
    }
    public static NGHIEM Nghiem(BAT_PHUONG_TRINH P)
    {
        NGHIEM kq;
        kq.CanDuoi = Double.MaxValue;
        kq.CanTren = Double.MinValue;
        if (P.a == 0)
        {
            if (P.b >= 0)
            {
                kq.CanDuoi = Double.MinValue;
                kq.CanTren = Double.MaxValue;
            }
        }
        else
            if (P.a > 0)
            {
                kq.CanDuoi = -P.b / P.a;
                kq.CanTren = Double.MaxValue;
            }
            else
                if (P.a < 0)
                {
                    kq.CanDuoi = Double.MinValue;
                    kq.CanTren = -P.b / P.a;
                }
        return kq;
    }
    public static String XuatChuoi(BAT_PHUONG_TRINH P)
    {
        String kq;
        kq = XuLySoThuc.XuatChuoi(P.a) + "x + " + 
            XuLySoThuc.XuatChuoi(P.b) + ">=0";
        return kq;
    }
}
