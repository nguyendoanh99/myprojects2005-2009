using System;
class Xuat_thong_bao
{
    public static void Main()
    {
        String Ho_ten;
        String Loi_chao;
        Console.Write("Ho va ten:");
        Ho_ten = Console.ReadLine();

        Loi_chao = "Xin chao " + Ho_ten + "\n";
        Loi_chao = Loi_chao + "Cam on vi da su dung chuong trinh nay";
        Console.Write(Loi_chao);
        Console.ReadLine();
    }
}