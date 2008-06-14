using System;

class So_lon_nhat
{    
    public static void Main(string[] args)
    {
        Double[,] a;
        Double kq;
        a = XL_MA_TRAN.Nhap("Nhap ma tran :\n");
        kq = XL_MA_TRAN.Max(a);
        String Chuoi;
        Chuoi = "Ma tran cac so nguyen\n";
        Chuoi = Chuoi + XL_MA_TRAN.Chuoi(a) + "\n";
        Chuoi = Chuoi + "Co so nguyen lon nhat la: " + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}