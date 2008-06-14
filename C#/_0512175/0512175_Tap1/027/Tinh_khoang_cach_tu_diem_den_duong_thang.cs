using System;
public struct DIEM
{
    public Double x;
    public Double y;
}
public struct PHUONG_TRINH_DUONG_THANG
{
    public Double a;
    public Double b;
    public Double c;
}
class Tinh_khoang_cach_tu_diem_den_duong_thang
{
    public static PHUONG_TRINH_DUONG_THANG Nhap_duong_thang()
    {
        PHUONG_TRINH_DUONG_THANG kq;
        Console.Write("Nhap a:");
        kq.a = Double.Parse(Console.ReadLine());
        Console.Write("Nhap b:");
        kq.b = Double.Parse(Console.ReadLine());
        Console.Write("Nhap c:");
        kq.c = Double.Parse(Console.ReadLine());
        return kq;
    }
    public static DIEM Nhap_diem()
    {
        DIEM kq;
        Console.Write("Hoanh do:");
        kq.x = Double.Parse(Console.ReadLine());
        Console.Write("Tung do:");
        kq.y = Double.Parse(Console.ReadLine());
        return kq;
    }    
    public static Double Khoang_cach(PHUONG_TRINH_DUONG_THANG D, DIEM I)
    {
        Double kq;
        kq = Math.Abs(D.a * I.x + D.b * I.y + D.c) / (D.a * D.a + D.b * D.b);
        return kq;
    }
    public static String Chuoi_duong_thang(PHUONG_TRINH_DUONG_THANG D)
    {
        String kq = "";
        kq = kq + D.a+"x";
        if (D.b >= 0)
            kq = kq + "+" + D.b;
        else
            kq = kq + D.b;
        kq = kq + "y";
        if (D.c >= 0)
            kq = kq + "+" + D.c;
        else
            kq = kq + D.c;
        kq = kq + "=0";
        return kq;
    }
    public static String Chuoi_diem(DIEM M)
    {
        String kq;
        kq = "(" + M.x + "," + M.y + ")";
        return kq;
    }
    static void Main(string[] args)
    {
        PHUONG_TRINH_DUONG_THANG D;
        DIEM I;
        Double kq;

        D = Nhap_duong_thang();
        I = Nhap_diem();
        kq = Khoang_cach(D, I);

        String Chuoi="Khoach cach tu diem I";
        Chuoi = Chuoi + Chuoi_diem(I);
        Chuoi = Chuoi + " den duong thang D:" + Chuoi_duong_thang(D);
        Chuoi = Chuoi + " la " + Math.Round(kq,2);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}