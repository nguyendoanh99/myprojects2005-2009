using System;


class Xac_dinh_so_nguyen_lon_nhat
{
    public static int[] Nhap_mang()
    {
        int[] kq;
        String Chuoi;
        Console.Write("Day cac so nguyen:");
        Chuoi = Console.ReadLine();
        String[] M = Chuoi.Split(new char[] { ',' });
        kq = new int[M.Length];
        for (int i = 0; i < M.Length; i++)
            kq[i] = (int.Parse(M[i]));
        return kq;
    }
    public static int So_nguyen_lon_nhat(int[] a)
    {
        int kq = a[0];
        foreach (int So in a)
            if (So > kq)
                kq = So;       
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
        int kq;
        a = Nhap_mang();
        kq = So_nguyen_lon_nhat(a);
        String Chuoi;        
        Chuoi = "So lon nhat cua day so nguyen: " + Chuoi_mang(a) + "\n";
        Chuoi = Chuoi + "la " + kq;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}