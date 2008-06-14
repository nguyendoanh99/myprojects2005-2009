using System;
public enum VI_TRI_TUONG_DOI
{
    Cat_nhau,
    Tiep_xuc_trong,
    Tiep_xuc_ngoai,
    Nam_trong_nhau,
    Nam_ngoai_nhau,
    Trung_nhau
}
public struct DUONG_TRON
{
    public DIEM I;
    public Double R;
}
class XL_DUONG_TRON
{
    public static DUONG_TRON Nhap(String Ghi_chu)
    {
        DUONG_TRON kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.I = XL_DIEM.Nhap("Toa do tam I cua duong tron:\n");
        kq.R=XL_SO_THUC.Nhap("Nhap R:");        
        return kq;
    }
    public static VI_TRI_TUONG_DOI Vi_tri_tuong_doi(DUONG_TRON A,
        DUONG_TRON B)
    {
        VI_TRI_TUONG_DOI kq;
        kq = VI_TRI_TUONG_DOI.Cat_nhau;
        Double kc = XL_DIEM.Khoang_cach(A.I, B.I);
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
    public static String Chuoi(DUONG_TRON C)
    {
        String kq;
        kq = "(" + XL_DIEM.Chuoi(C.I) + "," + Math.Round(C.R, 2) + ")";
        return kq;
    }
}
