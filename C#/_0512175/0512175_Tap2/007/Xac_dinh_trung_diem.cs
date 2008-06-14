using System;

class Xac_dinh_trung_diem
{    
    public static void Main()
    {
        DIEM I;
        DIEM A, B;
        A = XL_DIEM.Nhap("Toa do A:\n");
        B = XL_DIEM.Nhap("Toa do B:\n");
        I = XL_DIEM.Xac_dinh_trung_diem(A, B);
        String Chuoi;
        Chuoi = "Trung diem cua A" + XL_DIEM.Chuoi(A);
        Chuoi = Chuoi + "va B" + XL_DIEM.Chuoi(B);
        Chuoi = Chuoi + "la diem I" + XL_DIEM.Chuoi(I);
        XL_CHUOI.Xuat(Chuoi);
    }
}