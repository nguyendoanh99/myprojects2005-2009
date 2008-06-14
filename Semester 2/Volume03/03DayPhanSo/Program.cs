using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        ArrayList b = XuLyDayPhanSo.Doc("PhanSo.inp");
        String Chuoi = "Du lieu khong hop le.";
        if (b != null)
        {
            PHANSO lc = XuLyDayPhanSo.LonNhat(b);
            Chuoi = "Day so:" + XuLyDayPhanSo.XuatChuoi(b) + "\n";
            Chuoi = Chuoi + "Co phan so lon nhat la:" + XuLyPhanSo.XuatChuoi(lc) + "\n";
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}

