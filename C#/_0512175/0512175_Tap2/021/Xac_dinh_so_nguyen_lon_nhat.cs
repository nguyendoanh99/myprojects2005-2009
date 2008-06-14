using System;
class Xac_dinh_so_nguyen_lon_nhat
{    
    public static void Main(string[] args)
    {
        long[] a;
        long kq;
        a = XL_DAY_SO.Nhap("Day cac so nguyen:\n");
        kq = XL_DAY_SO.Max(a);
        String Chuoi;        
        Chuoi = "So lon nhat cua day so nguyen: " + XL_DAY_SO.Chuoi(a) + "\n";
        Chuoi = Chuoi + "la " + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}