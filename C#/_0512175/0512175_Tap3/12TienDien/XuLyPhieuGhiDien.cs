using System;
using System.Collections.Generic;
using System.Text;
public struct PHIEUGHIDIEN
{
    public String HoTen;
    public Double SoKw;
    public long Thang;
    public long Nam;
}
class XuLyPhieuGhiDien
{
    public static PHIEUGHIDIEN Nhap(String GhiChu)
    {
        XuLyChuoi.Xuat(GhiChu);
        PHIEUGHIDIEN kq;
        kq.HoTen = XuLyChuoi.Nhap("Nhap ho ten :");
        kq.SoKw = XuLySoThuc.Nhap("Nhap so Kw da su dung:", 0);
        kq.Thang = XuLySoNguyen.Nhap("Nhap thang da su dung:", 1, 12);
        kq.Nam = XuLySoNguyen.Nhap("Nhap nam da su dung:",2000,2010);
        return kq;
    }
    public static String XuatChuoi(PHIEUGHIDIEN P)
    {
        String Chuoi = "Ho ten nguoi su dung: " + P.HoTen + "\n";
        Chuoi = Chuoi + "Da su dung: " + P.SoKw;
        Chuoi = Chuoi + " Kw trong thang " + P.Thang + " nam " + P.Nam;
        return Chuoi;
    }
}