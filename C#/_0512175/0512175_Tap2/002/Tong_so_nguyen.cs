using System;
class Tong_so_nguyen
{
    public static void Main()
    {
        long So_1;
        long So_2;
        long kq;
        So_1 = XL_SO_NGUYEN.Nhap("So nguyen thu 1:");
        So_2 = XL_SO_NGUYEN.Nhap("So nguyen thu 2:");
        kq = So_1 + So_2;
        String Chuoi;
        Chuoi = "Tong cua " + So_1;
        Chuoi = Chuoi + " va " + So_2;
        Chuoi = Chuoi + " la " + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}