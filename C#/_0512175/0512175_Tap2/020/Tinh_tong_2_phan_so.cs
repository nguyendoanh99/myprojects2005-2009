using System;

class Tinh_tong_2_phan_so
{
    static void Main(string[] args)
    {
        PHAN_SO A, B, kq;
        A = XL_PHAN_SO.Nhap("Nhap phan so thu nhat:\n");
        B = XL_PHAN_SO.Nhap("Nhap phan so thu hai:\n");
        kq = XL_PHAN_SO.Tong(A, B);
        String Chuoi;
        Chuoi = XL_PHAN_SO.Chuoi(A) + " + ";
        Chuoi = Chuoi + XL_PHAN_SO.Chuoi(B) + " = ";
        Chuoi = Chuoi + XL_PHAN_SO.Chuoi(kq);
        XL_CHUOI.Xuat(Chuoi);
    }
}
