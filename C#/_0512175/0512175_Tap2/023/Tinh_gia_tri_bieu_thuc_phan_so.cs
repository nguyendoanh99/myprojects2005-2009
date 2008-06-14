using System;

class Tinh_gia_tri_bieu_thuc_phan_so
{      
    public static void Main(string[] args)
    {
        BIEU_THUC P;
        PHAN_SO kq;

        P = XL_BIEU_THUC.Nhap("Nhap vao 1 bieu thuc phan so:\n");
        kq = XL_BIEU_THUC.Tinh(P);

        String Chuoi = "";
        Chuoi = Chuoi + XL_BIEU_THUC.Chuoi(P) + " = ";
        Chuoi = Chuoi + XL_PHAN_SO.Chuoi(kq);
        XL_CHUOI.Xuat(Chuoi);
    }
}
