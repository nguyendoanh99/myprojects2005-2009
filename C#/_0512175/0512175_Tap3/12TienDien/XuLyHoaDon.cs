using System;
using System.Collections.Generic;
using System.Text;

public struct HOADON
{
    public String HoTen;
    public Double SoKw;
    public DINHMUC[] SuDung;
    public Double TongTien;
}
class XuLyHoaDon
{    
    public static HOADON LapHoaDon(PHIEUGHIDIEN P,DINHMUC[] QuiTac)
    {
        HOADON kq;
        kq.HoTen = P.HoTen;
        kq.SoKw = P.SoKw;
        long a = 0;
        long d = 0;
        for (; d < QuiTac.Length; d++)
        {
            if (a <= P.SoKw && P.SoKw <= QuiTac[d].GiaTri)
                break;
            a = a + QuiTac[d].GiaTri;
        }
        d++;
        kq.SuDung = new DINHMUC[d];
        
        for (; d!=0; d--)        
            kq.SuDung[d-1] = QuiTac[d-1];
        kq.TongTien = XuLyQuiTac.TinhTien(QuiTac,P.SoKw);
        return kq;
    }    
    public static String XuatChuoi(HOADON P)
    {
        String Chuoi = "Ho ten nguoi su dung: "+P.HoTen+"\n";
        Chuoi = Chuoi + "Da su dung :" + P.SoKw;
        Chuoi = Chuoi + " Kw nam trong cac don gia sau:\n" + XuLyQuiTac.XuatChuoi(P.SuDung);
        Chuoi = Chuoi + "\nTong so tien phai tra: " + XuLySoThuc.XuatChuoi(P.TongTien)+" dong";
        return Chuoi;
    }
}