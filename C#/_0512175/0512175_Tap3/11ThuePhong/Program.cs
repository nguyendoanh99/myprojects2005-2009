using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        KHACHSAN KS = XuLyKhachSan.Doc("ThuePhong.txt");
        String Chuoi = "Du lieu khong hop le";
        if (KS.PhongThue != null)
        {
            XuLyChuoi.Xuat(XuLyKhachSan.XuatChuoi(KS));
            Console.WriteLine();
            PHIEUTHUE Phieu = XuLyPhieuThue.Nhap(KS, "Nhap thong tin cua phieu thue phong:\n");
            Double kq = XuLyKhachSan.TinhTien(KS, Phieu);
            Chuoi = "So tien phai tra la: " + XuLySoThuc.XuatChuoi(kq);
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}