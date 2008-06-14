using System;
using System.Collections.Generic;
using System.Text;


class Xac_dinh_vi_tri_tuong_doi_2_duong_tron
{
    static void Main(string[] args)
    {
        DUONG_TRON C1, C2;
        VI_TRI_TUONG_DOI kq;

        C1 = XL_DUONG_TRON.Nhap("Nhap du lieu cho duong tron C1:\n");
        C2 = XL_DUONG_TRON.Nhap("Nhap du lieu cho duong tron C2:\n");
        kq = XL_DUONG_TRON.Vi_tri_tuong_doi(C1, C2);

        String Chuoi = "Duong tron C1";
        Chuoi = Chuoi + XL_DUONG_TRON.Chuoi(C1) + " va duong tron C2";
        Chuoi = Chuoi + XL_DUONG_TRON.Chuoi(C2);
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
        XL_CHUOI.Xuat(Chuoi);
    }
}
