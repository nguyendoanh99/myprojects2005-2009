using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        if (XuLyTapTin.KiemTra("DonThuc.inp")==true)
        {
            DonThuc P;
            Double x0;
            Double kq;
            P = XuLyDonThuc.Doc("DonThuc.inp");
            String Chuoi;
            Chuoi = "Tinh gia tri cua don thuc P(x)=";
            Chuoi = Chuoi + XuLyDonThuc.XuatChuoi(P) + "\n";
            XuLyChuoi.Xuat(Chuoi);
            do
            {
                x0 = XuLySoThuc.Nhap("Nhap gia tri x0: ");
                kq = XuLyDonThuc.TinhGiaTri(P,x0);
                Chuoi = "Gia tri cua don thuc ";
                Chuoi = Chuoi + XuLyDonThuc.XuatChuoi(P);
                Chuoi = Chuoi + " la:" + XuLySoThuc.XuatChuoi(kq);
                XuLyChuoi.Xuat(Chuoi);
            } while (XuLySoNguyen.Nhap("\n Tiep tuc (0. Dung, 1.Tiep tuc):", 0, 1) != 0);
        }
    }
}

