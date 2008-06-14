using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Double[][] a;
        Double s = 0;
        a = XuLyMaTran.Doc("MaTran.inp");
        String Chuoi = "Du lieu khong hop le.";
        if (a != null)
        {
            s = XuLyMaTran.Tong(a);
            Chuoi = "Ma Tran cac so \n";
            Chuoi = Chuoi + XuLyMaTran.XuatChuoi(a) + "\n";
            Chuoi = Chuoi + "co tong la:" + s+"\n";
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}

