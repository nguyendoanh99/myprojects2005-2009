using System;
class Tinh_tuoi
{
    public static void Main()
    {
        String Ho_ten;
        DateTime Ngay_sinh;
        int Tuoi;
        Console.Write("Ho ten: ");
        Ho_ten = Console.ReadLine();
        Console.Write("Cho biet ngay sinh:");
        Ngay_sinh = DateTime.Parse(Console.ReadLine());
        DateTime Ngay_hien_hanh = DateTime.Today;
        int Nam_hien_hanh = Ngay_hien_hanh.Year;
        int Nam_sinh = Ngay_sinh.Year;
        Tuoi = Nam_hien_hanh - Nam_sinh;
        String Chuoi;
        Chuoi = "Hoc sinh " + Ho_ten;
        Chuoi = Chuoi + " sinh ngay " + Ngay_sinh;
        Chuoi = Chuoi + " co tuoi la " + Tuoi;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}