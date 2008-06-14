using System;
public struct PHAN_SO
{
    public int Tu_so;
    public int Mau_so;
}
class Tinh_tich_2_phan_so
{
    public static PHAN_SO Nhap_phan_so()
    {
        PHAN_SO kq;
        Console.Write("Tu so = ");
        kq.Tu_so = int.Parse(Console.ReadLine());
        Console.Write("Mau so = ");
        kq.Mau_so = int.Parse(Console.ReadLine());        
        return kq;
    }
    public static PHAN_SO Tich_phan_so(PHAN_SO M, PHAN_SO N)
    {
        PHAN_SO kq;
        kq.Tu_so = M.Tu_so * N.Tu_so;
        kq.Mau_so = M.Mau_so * N.Mau_so;
        return kq;
    }
    public static String Chuoi_phan_so(PHAN_SO M)
    {
        String kq;
        kq = M.Tu_so + "/" + M.Mau_so;
        return kq;
    }
    static void Main(string[] args)
    {
        PHAN_SO A, B, kq;
        A = Nhap_phan_so();
        B = Nhap_phan_so();
        kq = Tich_phan_so(A, B);
        String Chuoi;
        Chuoi = Chuoi_phan_so(A) + " * ";
        Chuoi = Chuoi + Chuoi_phan_so(B) + " = ";
        Chuoi = Chuoi + Chuoi_phan_so(kq);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
