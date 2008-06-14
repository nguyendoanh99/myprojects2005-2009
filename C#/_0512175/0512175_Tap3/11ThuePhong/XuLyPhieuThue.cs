using System;
using System.Collections.Generic;
using System.Text;
public struct PHIEUTHUE
{
    public String HoTen;
    public long SoNgay;
    public LOAIPHONG LoaiPhong;
}
class XuLyPhieuThue
{
    public static PHIEUTHUE Nhap(KHACHSAN P,String Chuoi)
    {
        PHIEUTHUE kq;
        kq.HoTen = XuLyChuoi.Nhap("Nhap ho va ten:");
        kq.SoNgay = XuLySoNguyen.Nhap("Nhap so ngay o tro:");
        long t = XuLySoNguyen.Nhap("Nhap loai phong muon thue:(1.."+P.PhongThue.Length+"):",0,P.PhongThue.Length);
        kq.LoaiPhong.Ten = P.PhongThue[t-1].Ten;
        kq.LoaiPhong.DonGia = P.PhongThue[t-1].DonGia;
        return kq;
    }
    public static String XuatChuoi(PHIEUTHUE P)
    {
        String kq = "Ho ten: "+P.HoTen+"\n";
        kq = kq + "So ngay thue: " + P.SoNgay + "\n";
        kq=kq+"Loai phong thue: "+P.LoaiPhong.Ten;
        return kq;
    }    
}