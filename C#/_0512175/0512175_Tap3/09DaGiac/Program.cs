using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        DAGIAC D=XuLyDaGiac.Doc("DaGiac.txt");        
        String Chuoi = "Du lieu khong hop le";
        if (D.Dinh != null)
        {
            Double kq=XuLyDaGiac.TinhChuVi(D);
            Chuoi = "Da giac D" + XuLyDaGiac.XuatChuoi(D) + "\n";
            Chuoi = Chuoi + " co chu vi = " + XuLySoThuc.XuatChuoi(kq);
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}