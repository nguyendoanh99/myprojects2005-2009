using System;
class Tinh_tuoi
{
    public static void Main()
    {
        String Ho_ten;
        DateTime Ngay_sinh;
        int Tuoi;
        Ho_ten = XL_CHUOI.Nhap("Ho va ten:");
        DateTime Ngay_toi_thieu = XL_NGAY.Ngay_sinh(1, 1, 20);
        DateTime Ngay_toi_da = XL_NGAY.Ngay_sinh(31, 12, 15);
        Ngay_sinh = XL_NGAY.Nhap("Ngay sinh:", Ngay_toi_thieu, Ngay_toi_da);        
        int Nam_hien_hanh = DateTime.Today.Year;
        int Nam_sinh = Ngay_sinh.Year;
        Tuoi = Nam_hien_hanh - Nam_sinh;
        String Chuoi;
        Chuoi = "Hoc sinh " + Ho_ten;
        Chuoi = Chuoi + " sinh ngay " + Ngay_sinh;
        Chuoi = Chuoi + " co tuoi la " + Tuoi;
        XL_CHUOI.Xuat(Chuoi);
    }
}