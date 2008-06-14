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
class Chu_vi_tam_giac
{
    public static DIEM Nhap_diem()
    {
        DIEM kq;
        kq.x = SoThuc.NhapSoThuc("Hoanh do:");
        kq.y = SoThuc.NhapSoThuc("Tung do:");
        return kq;
    }
    public static Double Khoang_cach(DIEM M, DIEM N)
    {
        Double kq;
        Double Dx = M.x - N.x;
        Double Dy = M.y - N.y;
        kq = Math.Sqrt(Dx * Dx + Dy * Dy);
        return kq;
    }
    public static String Chuoi_diem(DIEM M)
    {
        String kq;
        kq = "(" + M.x + "," + M.y + ")";
        return kq;
    }
    public static TAM_GIAC Nhap_tam_giac()
    {
        TAM_GIAC kq;
        kq.A = Nhap_diem();
        kq.B = Nhap_diem();
        kq.C = Nhap_diem();
        return kq;
    }
    public static Double Chu_vi(TAM_GIAC tg)
    {
        Double kq;
        kq = Khoang_cach(tg.A, tg.B);
        kq = kq + Khoang_cach(tg.B, tg.C);
        kq = kq + Khoang_cach(tg.C, tg.A);
        return kq;
    }
    public static String Chuoi_tam_giac(TAM_GIAC tg)
    {
        String kq;
        kq = "A" + Chuoi_diem(tg.A);
        kq = kq + "B" + Chuoi_diem(tg.B);
        kq = kq + "C" + Chuoi_diem(tg.C);
        return kq;
    }
    public static void Main(string[] args)
    {
        TAM_GIAC tg;
        Double kq;
        tg = Nhap_tam_giac();
        kq = Chu_vi(tg);
        String Chuoi;
        Chuoi = "Tam giac " + Chuoi_tam_giac(tg) + "\n";
        Chuoi = Chuoi + "co chu vi la " + Math.Round(kq, 2);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}