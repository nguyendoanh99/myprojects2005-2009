using System;

class XL_DAY_SO
{
    private static char Ky_tu_phan_cach = ',';
    public static long[] Nhap(String Ghi_chu)
    {
        long[] kq;
        String Chuoi;        
        do
        {
            XL_CHUOI.Xuat(Ghi_chu);
            Chuoi = Console.ReadLine();
        } while (!Kiem_tra(Chuoi));
        String[] M = Chuoi.Split(new char[] {Ky_tu_phan_cach});
        kq = new long[M.Length];
        for (int i = 0; i < M.Length; i++)
            kq[i] = (long.Parse(M[i]));
        return kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            String[] M = Chuoi.Split(new char[] { Ky_tu_phan_cach });
            for (int i = 0; i < M.Length; i++)
                if (!XL_SO_NGUYEN.Kiem_tra(M[i]))
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
    public static long Max(long[] a)
    {
        long kq = a[0];
        foreach (long So in a)
            if (So > kq)
                kq = So;
        return kq;
    }
    public static string Chuoi(long[] a)
    {
        String kq = "";
        for (int i = 0; i < a.Length; i++)
        {
            kq = kq + a[i];
            if (i < a.Length - 1)
                kq = kq + Ky_tu_phan_cach;
        }
        return kq;
    }
}
