using System;

class Gia_tri_don_thuc
{    
    public static void Main(string[] args)
    {
        DON_THUC P;
        Double x0;

        Double kq;

        P = XL_DON_THUC.Nhap("Nhap don thuc:\n");
        x0 = XL_SO_THUC.Nhap("Gia tri x0 = ");
        kq = XL_DON_THUC.Tinh_gia_tri(P, x0);
        String Chuoi = "Gia tri cua don thuc P(x)=";
        Chuoi = Chuoi + XL_DON_THUC.Chuoi(P) + "\n";
        Chuoi = Chuoi + "voi x0=" + x0;
        Chuoi = Chuoi + " la " + kq;
        XL_CHUOI.Xuat(Chuoi);
    }
}