using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        PHANSO B=XuLyPhanSo.Doc("PhanSo.txt");
        PHANSO A = XuLyPhanSo.Nhap("Nhap phan so :\n");        

        QUANHE kq = XuLyPhanSo.SoSanh(A, B);
        String Chuoi;
        Chuoi = XuLyPhanSo.XuatChuoi(A) + "kq" + XuLyPhanSo.XuatChuoi(B);
        if (kq == QUANHE.NhoHon)
            Chuoi = Chuoi.Replace("kq", "<");
        else
            if (kq == QUANHE.BangNhau)
                Chuoi = Chuoi.Replace("kq", "=");
            else
                if (kq == QUANHE.LonHon)
                    Chuoi = Chuoi.Replace("kq", ">");
        XuLyChuoi.Xuat(Chuoi);
    }
}