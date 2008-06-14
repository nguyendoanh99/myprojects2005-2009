using System;
using System.Collections.Generic;
using System.Text;

class XuLyChuoi
{
    public static void Xuat(String GhiChu)
    {
        Console.Write(GhiChu);
    }
    public static String Nhap(String GhiChu)
    {
        String temp;
        Xuat(GhiChu);
        temp = Console.ReadLine();
        return temp;
    }
}

