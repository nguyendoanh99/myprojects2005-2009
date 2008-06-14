using System;
public enum _NGHIEM
{
    Co_nghiem,
    Vo_nghiem,
    Vo_so_nghiem
}
public struct NHI_THUC
{
    public Double a;
    public Double b;
}
public struct NGHIEM
{
    public Double x;
    public _NGHIEM nghiem;
}
class Giai_phuong_trinh_bac_nhat
{
    public static NHI_THUC Nhap_nhi_thuc()
    {
        NHI_THUC kq;
        Console.Write("Nhap a : ");
        kq.a = Double.Parse(Console.ReadLine());
        Console.Write("Nhap b : ");
        kq.b = Double.Parse(Console.ReadLine());
        return kq;
    }
    public static NGHIEM Giai_phuong_trinh(NHI_THUC P)
    {
        NGHIEM kq;
        kq.nghiem = _NGHIEM.Co_nghiem;
        kq.x = 0;
        if(P.a==0)
        {
            if (P.b==0)
                kq.nghiem=_NGHIEM.Vo_so_nghiem;
            else
                kq.nghiem=_NGHIEM.Vo_nghiem;            
        }
        else
        {
            kq.nghiem=_NGHIEM.Co_nghiem;
            kq.x=-P.b/P.a;            
        }
        return kq;
    }
    public static String Chuoi_nhi_thuc(NHI_THUC P)
    {
        String kq="";
        kq = kq + P.a;
        kq = kq + "x";
        if (P.b >= 0)
            kq = kq + "+" + P.b;
        else
            kq = kq + P.b;
        return kq;
    }
    public static String Chuoi_nghiem(NGHIEM ng)
    {
        String kq="";
        if (ng.nghiem == _NGHIEM.Co_nghiem)
            kq = kq + "co nghiem la x = " + Math.Round(ng.x, 2);
        else
            if (ng.nghiem == _NGHIEM.Vo_nghiem)
                kq = kq + "vo nghiem";
            else
                if (ng.nghiem == _NGHIEM.Vo_so_nghiem)
                    kq = kq + "co vo so nghiem";        
        return kq;
    }
    static void Main(string[] args)
    {
        NHI_THUC P;
        NGHIEM ng;
        P = Nhap_nhi_thuc();
        ng = Giai_phuong_trinh(P);

        String Chuoi="Phuong trinh ";
        Chuoi = Chuoi + Chuoi_nhi_thuc(P)+" = 0\n";
        Chuoi = Chuoi + Chuoi_nghiem(ng);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}