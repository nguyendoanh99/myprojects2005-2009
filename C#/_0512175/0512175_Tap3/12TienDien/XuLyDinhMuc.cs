using System;
using System.Collections.Generic;
using System.Text;

public struct DINHMUC
{
    public String Ten;
    public long GiaTri;
    public long DonGia;
}
class XuLyDinhMuc
{
    private static String ChuoiPhanCach = ";";
    
    public static DINHMUC KhoiTao(String Chuoi)
    {
        DINHMUC kq;
        kq.DonGia = long.MinValue;
        kq.GiaTri = long.MinValue;
        kq.Ten = "";
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Ten = M[0].Trim();
            if (M.Length == 3)
            {
                kq.GiaTri = long.Parse(M[1]);
                kq.DonGia = long.Parse(M[2]);
            }
            else
            {
                kq.GiaTri = long.MaxValue;
                kq.DonGia = long.Parse(M[1]);
            }
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
        flag = (M.Length == 3) || (M.Length == 2);
        if (flag)
        {
            flag=flag && XuLySoNguyen.KiemTra(M[1]);
            if (M.Length == 3)
                flag = flag && XuLySoNguyen.KiemTra(M[2]);
        }
        return flag;
    }
    public static String XuatChuoi(DINHMUC P)
    {
        String Chuoi = P.Ten + " : ";
        Chuoi = Chuoi + P.GiaTri + " Kw ke tiep co don gia ";
        Chuoi = Chuoi + P.DonGia + " dong/Kw";
        return Chuoi;
    }
}