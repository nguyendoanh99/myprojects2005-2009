using System;
class Tong_so_nguyen
{
    public static void Main()
    {
        int So_1;
        int So_2;
        long kq;
        So_1 = SoNguyen.NhapSoNguyen("So nguyen thu 1:");
        So_2 = SoNguyen.NhapSoNguyen("So nguyen thu 2:");
        kq = So_1 + So_2;
        String Chuoi;
        Chuoi = "Tong cua " + So_1;
        Chuoi = Chuoi + " va " + So_2;
        Chuoi = Chuoi + " la " + kq;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}