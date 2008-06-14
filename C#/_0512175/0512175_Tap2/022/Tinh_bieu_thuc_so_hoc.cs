using System;
using System.Collections;

class Tinh_bieu_thuc_so_hoc
{
    
    public static void Main(string[] args)
    {
        BIEU_THUC P;
        long kq;

        P = XL_BIEU_THUC.Nhap("Nhap vao 1 bieu thuc:\n");
        kq = XL_BIEU_THUC.Tinh(P);

        String Chuoi="";
        Chuoi = Chuoi + XL_BIEU_THUC.Chuoi(P) + " = ";
        Chuoi = Chuoi + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}