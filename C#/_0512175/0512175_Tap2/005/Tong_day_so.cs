using System;

class Tong_day_so
{
    public static void Main(string[] args)
    {
        Double[] a;
        Double kq;
        a = XL_DAY_SO.Nhap("Nhap day so:");
        kq = XL_DAY_SO.Tinh_tong(a);
        String Chuoi;
        Chuoi = "Day so : " + XL_DAY_SO.Chuoi(a) + "\n";
        Chuoi = Chuoi + "co tong la " + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}