using System;
public enum VI_TRI_TUONG_DOI
{
    Cat_nhau,
    Song_song,
    Trung_nhau
}
public struct PHUONG_TRINH_DUONG_THANG
{
    public Double a;
    public Double b;
    public Double c;
}
class Xac_dinh_vi_tri_tuong_doi_2_duong_thang
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
    public static VI_TRI_TUONG_DOI Xac_dinh_vi_tri_tuong_doi(PHUONG_TRINH_DUONG_THANG D1,
        PHUONG_TRINH_DUONG_THANG D2)
    {
        VI_TRI_TUONG_DOI kq;
        Double D;
        Double Dx;
        Double Dy;
        D = D1.a * D2.b - D2.a * D1.b;
        Dx = D1.b * D2.c - D2.b * D1.c;
        Dy = D1.c * D2.a - D2.c * D1.a;
        if (D != 0)
            kq = VI_TRI_TUONG_DOI.Cat_nhau;
        else
        {
            if (Dx != 0 || Dy != 0)
                kq = VI_TRI_TUONG_DOI.Song_song;
            else
                kq = VI_TRI_TUONG_DOI.Trung_nhau;
        }
        return kq;
    }
    public static String Chuoi_duong_thang(PHUONG_TRINH_DUONG_THANG D)
    {
        String kq = "";
        kq = kq + D.a + "x";
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
        static void Main(string[] args)
    {
        PHUONG_TRINH_DUONG_THANG D1, D2;
        VI_TRI_TUONG_DOI kq;

        D1 = Nhap_duong_thang();
        D2 = Nhap_duong_thang();
        kq = Xac_dinh_vi_tri_tuong_doi(D1, D2);

        String Chuoi;
        Chuoi = "Duong thang D1:" + Chuoi_duong_thang(D1);
        Chuoi = Chuoi + " _ duong thang D2:" + Chuoi_duong_thang(D2);
        if (kq == VI_TRI_TUONG_DOI.Cat_nhau)
            Chuoi = Chuoi.Replace("_", "cat");
        else
            if (kq==VI_TRI_TUONG_DOI.Song_song)
                Chuoi=Chuoi.Replace("_","song song voi");
            else
                Chuoi = Chuoi.Replace("_", "trung voi");
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
