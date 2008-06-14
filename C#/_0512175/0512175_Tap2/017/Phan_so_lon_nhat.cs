using System;
using System.Collections;


class Phan_so_lon_nhat
{
    
    
    public static void Main(string[] args)
    {
        ArrayList Ps;
        PHAN_SO kq;
        Ps = XL_DAY_PHAN_SO.Nhap("Nhap vao day phan so:\n");
        kq = XL_DAY_PHAN_SO.Max(Ps);
        String Chuoi = "Day cac phan so ";
        Chuoi = Chuoi + XL_DAY_PHAN_SO.Chuoi(Ps) + "\n";
        Chuoi = Chuoi + "co phan so lon nhat la ";
        Chuoi = Chuoi + XL_PHAN_SO.Chuoi(kq);
        XL_CHUOI.Xuat(Chuoi);
    }
}
