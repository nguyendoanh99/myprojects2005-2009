using System;
using System.Collections;

    class Tinh_gia_tri_da_thuc
    {
        
        static void Main(string[] args)
        {
            ArrayList P;
            Double x0;
            Double kq;
            P = XL_DA_THUC.Nhap("Nhap da thuc P(x):\n");
            x0 = XL_SO_THUC.Nhap("Nhap x0 = ");
            kq = XL_DA_THUC.Tinh_gia_tri(P, x0);
            String Chuoi;
            Chuoi = "Gia tri da thuc P(x)=" + XL_DA_THUC.Chuoi(P)+"\n";
            Chuoi = Chuoi + "voi x0=" + x0 + " la :" + kq;
            XL_CHUOI.Xuat(Chuoi);
        }
    }
