using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        DATHUC P;
        Double kq;
        Double x0;
        P = XuLyDaThuc.Doc("DaThuc.txt");
        String Chuoi="Du lieu khong hop le";
        if (P.DonThuc != null)
        {
            x0 = XuLySoThuc.Nhap("Nhap "+P.BienSo+"0 = ");
            kq = XuLyDaThuc.TinhGiaTri(P, x0);

            Chuoi = "Gia tri cua " + XuLyDaThuc.XuatChuoi(P) + "\n";
            Chuoi = Chuoi + " voi "+P.BienSo+"0=" + x0 + " la :"
                + XuLySoThuc.XuatChuoi(kq);
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}
