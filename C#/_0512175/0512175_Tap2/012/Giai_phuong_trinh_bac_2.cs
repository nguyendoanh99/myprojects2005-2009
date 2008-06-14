using System;
using System.Collections;
class Giai_phuong_trinh_bac_2
{   
    public static void Main(string[] args)
    {
        TAM_THUC P;
        ArrayList Nghiem;
        P = XL_TAM_THUC.Nhap("Nhap tam thuc bac 2:\n");
        Nghiem = XL_TAM_THUC.Nghiem(P);
        String Chuoi = "Ket qua phuong trinh ";
        Chuoi = Chuoi + XL_TAM_THUC.Chuoi(P) + "=0" + "\n";
        Chuoi = Chuoi + XL_NGHIEM.Chuoi(Nghiem);
        XL_CHUOI.Xuat(Chuoi);
    }
}