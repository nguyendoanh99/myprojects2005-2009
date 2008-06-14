using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        KET_QUA_XO_SO x = XuLyKetQuaXoSo.Doc("KetQuaXoSo.txt");
        String Chuoi = "Du lieu khong hop le";
        if (x.Giai != null)
        {
            long so = XuLySoNguyen.Nhap("Nhap so ve ma ban muon do:",0);
            Chuoi = XuLyKetQuaXoSo.XuatChuoi(x) + "\n";
            Chuoi += " Tong tien thuong ban nhan duoc la " 
                + XuLyKetQuaXoSo.DoSo(x, so);
        }
        XuLyChuoi.Xuat(Chuoi);
    }
}