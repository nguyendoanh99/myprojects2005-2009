using System;

class XL_DAY_SO
{
    private static char Ky_tu_phan_cach = ',';
    public static Double[] Nhap(String Ghi_chu)
    {
        Double[] kq;
        String Chuoi;        
        do
        {
            XL_CHUOI.Xuat(Ghi_chu);
            Chuoi = Console.ReadLine();
        } while (!Kiem_tra(Chuoi));
        String[] M = Chuoi.Split(new char[] {Ky_tu_phan_cach});
        kq = new Double[M.Length];
        for (int i = 0; i < M.Length; i++)
            kq[i] = (Double.Parse(M[i]));
        return kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            String[] M = Chuoi.Split(new char[] { Ky_tu_phan_cach });
            for (int i = 0; i < M.Length; i++)
                if (!XL_SO_THUC.Kiem_tra(M[i]))
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
    public static Double Tinh_tong(Double[] a)
    {
        Double kq = 0;
        foreach (Double So in a)
            kq = kq + So;
        return kq;
    }
    public static string Chuoi(Double[] a)
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
