using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Double[] a = XuLyDaySo.Doc("DaySo.inp");
        String Chuoi="Du lieu khong hop le.";
        if (a != null)
        {
            Double s = XuLyDaySo.Tong(a);
            Chuoi = "Day so:" + XuLyDaySo.XuatChuoi(a) + "\n";
            Chuoi = Chuoi + "Co tong la:" + XuLySoThuc.XuatChuoi(s)+"\n";
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}

