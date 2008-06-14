using System;
class Giai_bat_phuong_trinh_bac_nhat
{    
    
    static void Main(string[] args)
    {
        NHI_THUC P;
        NGHIEM ng;
        P = XL_NHI_THUC.Nhap("Nhap vao nhi thuc dang ax+b:\n");
        ng = XL_NHI_THUC.Tim_Nghiem(P);

        String Chuoi = "Bat phuong trinh ";
        Chuoi = Chuoi + XL_NHI_THUC.Chuoi(P) + ">0\n";
        Chuoi = Chuoi + XL_NGHIEM.Chuoi(ng);
        XL_CHUOI.Xuat(Chuoi);
    }
}
