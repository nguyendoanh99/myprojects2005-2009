using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        BIEUTHUC[] NoiDung;
        CAUHOI[] De;
        NoiDung=XuLyBieuThuc.Nhap("Nhap vao noi dung cac cau hoi:\n");
        De=new CAUHOI[NoiDung.Length];
        String Chuoi = "";
        Random t = new Random();
        for (int i = 0; i < NoiDung.Length; i++)
        {            
            De[i] = XuLyCauHoi.KhoiTao(NoiDung[i],t);
            Chuoi = Chuoi + XuLyCauHoi.XuatChuoi(De[i]);
            if (i < NoiDung.Length - 1)
                Chuoi+="\r\n";            
        }
        XuLyTapTin.Ghi("DeThiTracNghiem.txt", Chuoi);
        XuLyChuoi.Xuat(Chuoi);

    }
}