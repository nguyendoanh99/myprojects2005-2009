using System;

class XL_CHUOI
{
    public static void Xuat(String Ghi_chu)
    {
        Console.Write(Ghi_chu);
    }
    public static String Nhap(String Ghi_chu)
    {
        String kq;
        Xuat(Ghi_chu);
        kq = Console.ReadLine();
        return kq;
    }
}
