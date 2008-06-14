using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        DINHMUC[] P = XuLyQuiTac.Doc("HoaDonTienDien.txt");
        String Chuoi = "Du lieu khong hop le";
        if (P != null)
        {
            PHIEUGHIDIEN Phieu;
            Phieu = XuLyPhieuGhiDien.Nhap("Nhap thong tin cua phieu ghi dien:\n");
            HOADON kq;
            kq=XuLyHoaDon.LapHoaDon(Phieu,P);
            Chuoi = "\nKhach hang co thong tin:\n" + XuLyPhieuGhiDien.XuatChuoi(Phieu);
            Chuoi=Chuoi+"\n\nCo hoa don tien dien la:\n"+XuLyHoaDon.XuatChuoi(kq);
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}
