using System;

class Tong_ma_tran
{
    public static void Main(string[] args)
    {
        Double[,] a;
        Double kq;
        a = XL_MA_TRAN.Nhap("Nhap ma tran:\n");
        kq = XL_MA_TRAN.Tinh_tong(a);
        String Chuoi;
        Chuoi = "Ma tran cac so " + "\n";
        Chuoi = Chuoi + XL_MA_TRAN.Chuoi(a) + "\n";
        Chuoi = Chuoi + "co tong la " + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}
