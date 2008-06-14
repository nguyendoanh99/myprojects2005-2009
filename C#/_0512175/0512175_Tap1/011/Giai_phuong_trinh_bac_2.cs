using System;
using System.Collections;

public struct TAM_THUC
{
    public Double a;
    public Double b;
    public Double c;
}
class Giai_phuong_trinh_bac_2
{
    public static TAM_THUC Nhap_tam_thuc()
    {
        TAM_THUC kq;
        kq.a = SoThuc.NhapSoThuc("a=");
        kq.b = SoThuc.NhapSoThuc("b=");
        kq.c = SoThuc.NhapSoThuc("c=");
        return kq;
    }
    public static ArrayList Giai_phuong_trinh(TAM_THUC P)
    {
        ArrayList kq = new ArrayList();
        Double Delta = P.b * P.b - 4 * P.a * P.c;
        if (Delta == 0)
            kq.Add(P.b / (2 * P.a));
        else
            if (Delta > 0)
            {
                kq.Add((-P.b - Math.Sqrt(Delta)) / (2 * P.a));
                kq.Add((-P.b + Math.Sqrt(Delta)) / (2 * P.a));
            }
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
    public static String Chuoi_nghiem(ArrayList Nghiem)
    {
        String kq = "";
        if (Nghiem.Count == 0)
            kq = "Phuong trinh vo nghiem";
        else
            if (Nghiem.Count == 1)
            {
                kq = "Phuong trinh co nghiem kep x1=x2=";
                Double x = (Double)Nghiem[0];
                kq=kq+Math.Round(x,2);                     
            }
            else
                if (Nghiem.Count == 2)
                {
                    kq = "Phuong trinh co 2 nghiem phan biet x1=";
                    Double x1 = (Double)Nghiem[0];
                    kq = kq + Math.Round(x1, 2);
                    Double x2 = (Double)Nghiem[1];
                    kq = kq + ", x2=" + Math.Round(x2, 2);
                }
        return kq;
    }
    public static void Main(string[] args)
    {
        TAM_THUC P;
        ArrayList Nghiem;
        P = Nhap_tam_thuc();
        Nghiem = Giai_phuong_trinh(P);
        String Chuoi = "Ket qua phuong trinh ";
        Chuoi = Chuoi + Chuoi_tam_thuc(P) + "=0" + "\n";
        Chuoi = Chuoi + Chuoi_nghiem(Nghiem);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}