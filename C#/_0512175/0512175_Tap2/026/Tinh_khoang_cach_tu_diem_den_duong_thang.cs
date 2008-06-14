using System;
class Tinh_khoang_cach_tu_diem_den_duong_thang
{   
    static void Main(string[] args)
    {
        PHUONG_TRINH_DUONG_THANG D;
        DIEM I;
        Double kq;

        D = XL_DUONG_THANG.Nhap("Nhap vao phuong trinh duong thang dang:ax+by+c=0\n");
        I = XL_DIEM.Nhap("Nhap vao toa do cua diem I:\n");
        kq = XL_DUONG_THANG.Khoang_cach(D, I);

        String Chuoi="Khoach cach tu diem I";
        Chuoi = Chuoi + XL_DIEM.Chuoi(I);
        Chuoi = Chuoi + " den duong thang D:" + XL_DUONG_THANG.Chuoi(D);
        Chuoi = Chuoi + " la " + Math.Round(kq,2);
        XL_CHUOI.Xuat(Chuoi);
    }
}