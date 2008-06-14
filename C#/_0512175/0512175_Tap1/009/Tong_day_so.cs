using System;

class Tong_day_so
{
    public static int[] Nhap_mang()
    {
        int[] kq;
        String Chuoi;
        Console.Write("Day cac so nguyen:");
        Chuoi = Console.ReadLine();
        String[] M = Chuoi.Split(new char[] { ',' });
        kq = new int[M.Length];
        for (int i=0;i<M.Length;i++)
            kq[i]=(int.Parse(M[i]));
        return kq;
    }
    public static long Tinh_tong(int[] a)
    {
        long kq = 0;
        foreach (int So in a)
            kq = kq + So;
        return kq;
    }
    public static string Chuoi_mang(int[] a)
    {
        String kq = "";
        for (int i = 0; i < a.Length; i++)
        {
            kq = kq + a[i];
            if (i < a.Length - 1)
                kq = kq + ",";
        }
        return kq;
    }
    public static void Main(string[] args)
    {
        int[] a;
        long kq;
        a = Nhap_mang();
        kq = Tinh_tong(a);
        String Chuoi;
        Chuoi = "Day so nguyen: " + Chuoi_mang(a) + "\n";
        Chuoi = Chuoi + "co tong la " + kq;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}