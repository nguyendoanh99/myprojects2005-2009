using System;
using System.Collections.Generic;
using System.Text;
public enum VI_TRI_TUONG_DOI
{
    Cat_nhau,    
    Tiep_xuc_trong,
    Tiep_xuc_ngoai,
    Nam_trong_nhau,
    Nam_ngoai_nhau,
    Trung_nhau
}
public struct DIEM
{
    public Double x;
    public Double y;
}
public struct DUONG_TRON
{
    public DIEM I;
    public Double R;
}
class Xac_dinh_vi_tri_tuong_doi_2_duong_tron
{
    public static DUONG_TRON Nhap_duong_tron()
    {
        DUONG_TRON kq;
        kq.I = Nhap_diem();
        Console.Write("Nhap R:");
        kq.R = Double.Parse(Console.ReadLine());
        return kq;
    }
    public static String Chuoi_duong_tron(DUONG_TRON C)
    {
        String kq;
        kq = "(" + Chuoi_diem(C.I) + "," + Math.Round(C.R, 2) + ")";
        return kq;
    }
    public static Double Khoang_cach(DIEM A,DIEM B)
    {
        Double kq;
        Double x_AB = A.x - B.x;
        Double y_AB = A.y - B.y;
        kq = Math.Sqrt(x_AB * x_AB + y_AB * y_AB);
        return kq;
    }
    public static VI_TRI_TUONG_DOI Xac_dinh_vi_tri_tuong_doi(DUONG_TRON A,
        DUONG_TRON B)
    {
        VI_TRI_TUONG_DOI kq;
        kq = VI_TRI_TUONG_DOI.Cat_nhau;
        Double kc = Khoang_cach(A.I, B.I);
        if (kc == Math.Abs(A.R - B.R))
        {
            if (kc != 0)
                kq = VI_TRI_TUONG_DOI.Tiep_xuc_trong;
            else
                kq = VI_TRI_TUONG_DOI.Trung_nhau;
        }
        else
            if (kc == A.R + B.R)
                kq = VI_TRI_TUONG_DOI.Tiep_xuc_ngoai;
            else
                if (kc < A.R + B.R)
                {
                    if (kc > Math.Abs(A.R - B.R))
                        kq = VI_TRI_TUONG_DOI.Nam_trong_nhau;
                    else
                        kq = VI_TRI_TUONG_DOI.Cat_nhau;
                }
                else
                    if (kc > A.R + B.R)
                        kq = VI_TRI_TUONG_DOI.Nam_ngoai_nhau;
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
    public static String Chuoi_diem(DIEM M)
    {
        String kq;
        kq = "(" + M.x + "," + M.y + ")";
        return kq;
    }
    static void Main(string[] args)
    {
        DUONG_TRON C1, C2;
        VI_TRI_TUONG_DOI kq;

        C1 = Nhap_duong_tron();
        C2 = Nhap_duong_tron();
        kq = Xac_dinh_vi_tri_tuong_doi(C1, C2);

        String Chuoi = "Duong tron C1";
        Chuoi = Chuoi + Chuoi_duong_tron(C1) + " va duong tron C2";
        Chuoi = Chuoi + Chuoi_duong_tron(C2);
        switch (kq)
        {
            case VI_TRI_TUONG_DOI.Cat_nhau:
                Chuoi = Chuoi + " cat nhau";
                break;
            case VI_TRI_TUONG_DOI.Nam_ngoai_nhau:
                Chuoi = Chuoi + " nam ngoai nhau";
                break;
            case VI_TRI_TUONG_DOI.Nam_trong_nhau:
                Chuoi = Chuoi + " nam trong nhau";
                break;
            case VI_TRI_TUONG_DOI.Tiep_xuc_ngoai:
                Chuoi = Chuoi + " tiep xuc ngoai";
                break;
            case VI_TRI_TUONG_DOI.Tiep_xuc_trong:
                Chuoi = Chuoi + " tiep xuc trong";
                break;
            case VI_TRI_TUONG_DOI.Trung_nhau:
                Chuoi = Chuoi + " trung nhau";
                break;
        };
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
