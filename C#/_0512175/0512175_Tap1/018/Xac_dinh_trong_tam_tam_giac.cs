using System;
public struct DIEM 
{
    public Double x;
    public Double y;
}
public struct TAM_GIAC
{
    public DIEM A;
    public DIEM B;
    public DIEM C;
}
class Xac_dinh_trong_tam_tam_giac
{
    public static TAM_GIAC Nhap_tam_giac()
    {
        TAM_GIAC kq;
        Console.Write("Toa do diem A:\n");
        kq.A = Nhap_diem();
        Console.Write("Toa do diem B:\n");
        kq.B = Nhap_diem();
        Console.Write("Toa do diem C:\n");
        kq.C = Nhap_diem();
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
    public static DIEM Xac_dinh_trong_tam(TAM_GIAC tg)
    {
        DIEM kq;
        kq.x = (tg.A.x + tg.B.x + tg.C.x) / 3;
        kq.y = (tg.A.y + tg.B.y + tg.C.y) / 3;
        return kq;
    }
    public static String Chuoi_tam_giac(TAM_GIAC tg)
    {
        String kq;
        kq = "A" + Chuoi_diem(tg.A);
        kq = kq + " B" + Chuoi_diem(tg.B);
        kq = kq + " C" + Chuoi_diem(tg.C);
        return kq;
    }
    public static String Chuoi_diem(DIEM d)
    {
        String kq;
        kq = "(" + Math.Round(d.x,2) + "," + Math.Round(d.y,2) + ")";
        return kq;
    }
    public static void Main()
    {
        TAM_GIAC tg;
        DIEM G;
        tg = Nhap_tam_giac();
        G = Xac_dinh_trong_tam(tg);
        String Chuoi;
        Chuoi = "Tam giac ABC voi ";
        Chuoi = Chuoi + Chuoi_tam_giac(tg);
        Chuoi = Chuoi + " co trong tam G" + Chuoi_diem(G);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
