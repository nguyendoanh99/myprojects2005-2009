using System;
using System.Collections;

class Sap_tang_day_so_nguyen
{
    public static int[] Nhap_mang()
    {
        int[] kq;
        Console.Write("Nhap day so nguyen: ");
        String Chuoi = Console.ReadLine();
        String[] M = Chuoi.Split(new char[] { ',' });
        kq = new int[M.Length];
        for (int i = 0; i < M.Length; i++)
            kq[i] = int.Parse(M[i]);
        return kq;
    }
    public static int[] Sap_Tang(int[] A)
    {
        int[] kq;
        kq = new int[A.Length];
        for (int i = 0; i < A.Length; i++)
            kq[i] = A[i];
        for (int i=0;i<kq.Length-1;i++)
            for (int j=i+1;j<kq.Length;j++)
                if (kq[i] > kq[j])
                {
                    int temp = kq[i];
                    kq[i] = kq[j];
                    kq[j] = temp;
                }
        return kq;
    }
    public static String Chuoi_mang(int[] A)
    {
        String kq="";
        for (int i = 0; i < A.Length; i++)
        {
            kq = kq + A[i];
            if (i < A.Length - 1)
                kq = kq + ", ";
        }
        return kq;
    }
    public static void Main(string[] args)
    {
        int[] a;
        int[] b;
        a = Nhap_mang();
        b = Sap_Tang(a);
        String Chuoi;
        Chuoi = "Day so nguyen truoc khi sap: \n" + Chuoi_mang(a);
        Chuoi = Chuoi + "\n" + "Day so nguyen sau khi sap: \n";
        Chuoi = Chuoi + Chuoi_mang(b);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
