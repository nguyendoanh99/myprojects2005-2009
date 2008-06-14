using System;
using System.Collections;

class XL_DAY_PHAN_SO
{
    private static char Ky_tu_phan_cach = ',';
    public static ArrayList Nhap(String Ghi_chu)
    {
        ArrayList kq = new ArrayList();
        String Chuoi;
        do
        {
            Chuoi = XL_CHUOI.Nhap(Ghi_chu);
        } while (!Kiem_tra(Chuoi));
        String[] M = Chuoi.Split(new char[] { Ky_tu_phan_cach });
        for (int i = 0; i < M.Length; i++)
            kq.Add(XL_PHAN_SO.Tao(M[i]));
        return kq;
    }
    public static PHAN_SO Max(ArrayList Ps)
    {
        PHAN_SO kq;
        kq = (PHAN_SO)Ps[0];
        foreach (PHAN_SO x in Ps)
            if (XL_PHAN_SO.So_sanh(x, kq) == QUAN_HE.Lon_hon)
                kq = x;
        return kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            String[] M = Chuoi.Split(new char[] { Ky_tu_phan_cach });
            for (int i = 0; i < M.Length; i++)
                if (!XL_PHAN_SO.Kiem_tra(M[i]))
                {
                    kq = false;
                    break;
                }
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    public static String Chuoi(ArrayList Ps)
    {
        String kq = "";
        for (int i = 0; i < Ps.Count; i++)
        {
            PHAN_SO x = (PHAN_SO)Ps[i];
            kq = kq + XL_PHAN_SO.Chuoi(x);
            if (i < Ps.Count - 1)
                kq = kq + Ky_tu_phan_cach;
        }
        return kq;
    }
}
