using System;
public struct DON_THUC
{
    public Double He_so;
    public int So_mu;
}
class Gia_tri_don_thuc
{
    public static DON_THUC Nhap_don_thuc()
    {
        DON_THUC kq;
        kq.He_so = SoThuc.NhapSoThuc("He so = ");
        kq.So_mu = SoNguyen.NhapSoNguyen("So mu = ");
        return kq;
    }
    public static Double Tinh_gia_tri(DON_THUC P, Double x0)
    {
        Double kq;
        kq = P.He_so * Math.Pow(x0, P.So_mu);
        return kq;
    }
    public static String Chuoi_don_thuc(DON_THUC P)
    {
        String kq;
        kq = P.He_so + "x^" + P.So_mu;
        return kq;
    }
    public static void Main(string[] args)
    {
        DON_THUC P;
        Double x0;
        Double kq;
        P = Nhap_don_thuc();
        x0 = SoThuc.NhapSoThuc("x0 = ");
        kq = Tinh_gia_tri(P, x0);
        String Chuoi = "Gia tri cua don thuc P(x)=";
        Chuoi = Chuoi + Chuoi_don_thuc(P) + "\n";
        Chuoi = Chuoi + "voi x0=" + x0;
        Chuoi = Chuoi + " la " + kq;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}