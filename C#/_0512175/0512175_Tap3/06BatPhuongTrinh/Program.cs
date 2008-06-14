using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        BAT_PHUONG_TRINH P;
        NGHIEM ng;
        String DuLieu = XuLyTapTin.Doc("Bat_phuong_trinh.txt");
        String[] M = DuLieu.Split(new String[] { "\r\n" },
            StringSplitOptions.None);
        String Chuoi = "";
        foreach (String x in M)
        {
            P = XuLyBatPhuongTrinh.KhoiTao(x);
            ng = XuLyBatPhuongTrinh.Nghiem(P);
            Chuoi += "Bat phuong trinh : "
                + XuLyBatPhuongTrinh.XuatChuoi(P) + "\r\n";
            Chuoi += " Nghiem: " + XuLyNghiem.XuatChuoi(ng) + "\r\n";
        }
        XuLyChuoi.Xuat(Chuoi);
        XuLyTapTin.Ghi(Chuoi, "Ket_qua.txt");
    }
}