using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TRUONG Truong;
        Truong = XuLyTruong.Doc("Truong.txt");
        String Chuoi = "Du lieu khong hop le";
        if (Truong.Khoi != null)        
            Chuoi = XuLyTruong.XuatChuoi(Truong);
        XuLyChuoi.Xuat(Chuoi);             
    }
}