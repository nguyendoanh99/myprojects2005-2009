using System;

class So_nguyen_lon_nhat
{
    public static int[,] Nhap_ma_tran()
    {
        int[,] kq;
        String Chuoi;
        Console.Write("Ma tran cac so nguyen: ");
        Chuoi = Console.ReadLine();
        String[] chuoi_dong = Chuoi.Split(new char[] { '-' });
        int So_dong = chuoi_dong.Length;
        int So_cot = chuoi_dong[0].Split(new char[] { ',' }).Length;
        kq = new int[So_dong, So_cot];
        for (int i = 0; i < So_dong; i++)
        {
            String[] dong=chuoi_dong[i].Split(new char[] {','});
            for (int j = 0; j < So_cot; j++)
                kq[i, j] = int.Parse(dong[j]);
        }
        return kq;
    }
    public static int So_lon_nhat(int[,] a)
    {
        int kq=a[0,0];
        foreach (int So in a)
            if (So > kq)
                kq = So;
        return kq;
    }
    public static String Chuoi_ma_tran(int[,] a)
    {
        String kq = "";
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                kq = kq + a[i, j];
                if (j < a.GetLength(1) - 1)
                    kq = kq + ", ";
            }
            kq = kq + "\n";
        }
        return kq;
    }
    public static void Main(string[] args)
    {
        int[,] a;
        int kq;
        a = Nhap_ma_tran();
        kq = So_lon_nhat(a);
        String Chuoi;
        Chuoi = "Ma tran cac so nguyen\n";
        Chuoi = Chuoi + Chuoi_ma_tran(a) + "\n";
        Chuoi = Chuoi + "Co so nguyen lon nhat la: " + kq;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}