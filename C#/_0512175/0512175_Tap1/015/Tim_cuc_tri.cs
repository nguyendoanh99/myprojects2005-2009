using System;
public struct TAM_THUC
{
    public Double a;
    public Double b;
    public Double c;
}
public struct CUC_TRI
{
    public Double x;
    public Double y;
    public Boolean Cuc_dai;
}
class Tim_cuc_tri
{
    public static TAM_THUC Nhap_tam_thuc()
    {
        TAM_THUC kq;
        kq.a = SoThuc.NhapSoThuc("Nhap a: ");
        kq.b = SoThuc.NhapSoThuc("Nhap b: ");
        kq.c = SoThuc.NhapSoThuc("Nhap c: ");
        return kq;
    }
    public static CUC_TRI Xac_dinh_cuc_tri(TAM_THUC P)
    {
        CUC_TRI kq;
        kq.x=-P.b/(2*P.a);
        kq.y = Tinh_gia_tri(P, kq.x);
        if (P.a > 0)
            kq.Cuc_dai = false;
        else
            kq.Cuc_dai = true;
        return kq;
    }
    public static Double Tinh_gia_tri(TAM_THUC P, Double x0)
    {
        Double kq;
        kq = P.a * x0 * x0 + P.b * x0 + P.c;
        return kq;
    }
    public static String Chuoi_tam_thuc(TAM_THUC P)
    {
        String kq;
        kq = P.a + "x^2";
        if (P.b < 0)
            kq = kq + P.b + "x";
        else
            kq = kq + "+" + P.b + "x";
        if (P.c < 0)
            kq = kq + P.c;
        else
            kq = kq + "+" + P.c;
        return kq;
    }
    public static String Chuoi_cuc_tri(CUC_TRI c)
    {
        String kq;        
        kq = "(" + c.x + "," + c.y + ")";
        if (c.Cuc_dai == true)
            kq = kq + " la cuc dai";
        else
            kq = kq + " la cuc tieu";
        return kq;
    }
    public static void Main(string[] args)
    {
        TAM_THUC P;
        CUC_TRI M;
        P = Nhap_tam_thuc();
        M = Xac_dinh_cuc_tri(P);
        String Chuoi;
        Chuoi = "Ham bac 2 f(x)=" + Chuoi_tam_thuc(P) + "\n";
        Chuoi = Chuoi + "co cuc tri M" + Chuoi_cuc_tri(M);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}