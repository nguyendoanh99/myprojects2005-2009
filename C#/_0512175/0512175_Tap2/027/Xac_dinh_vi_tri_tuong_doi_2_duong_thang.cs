using System;
class Xac_dinh_vi_tri_tuong_doi_2_duong_thang
{    
    static void Main(string[] args)
    {
        PHUONG_TRINH_DUONG_THANG D1, D2;
        VI_TRI_TUONG_DOI kq;

        D1 = XL_DUONG_THANG.Nhap("Nhap phuong trinh duong thang D1 dang ax+by+c=0\n");
        D2 = XL_DUONG_THANG.Nhap("Nhap phuong trinh duong thang D2 dang ax+by+c=0\n");
        kq = XL_DUONG_THANG.Vi_tri_tuong_doi(D1, D2);

        String Chuoi;
        Chuoi = "Duong thang D1:" + XL_DUONG_THANG.Chuoi(D1);
        Chuoi = Chuoi + " _ duong thang D2:" + XL_DUONG_THANG.Chuoi(D2);
        if (kq == VI_TRI_TUONG_DOI.Cat_nhau)
            Chuoi = Chuoi.Replace("_", "cat");
        else
            if (kq==VI_TRI_TUONG_DOI.Song_song)
                Chuoi=Chuoi.Replace("_","song song voi");
            else
                Chuoi = Chuoi.Replace("_", "trung voi");
        XL_CHUOI.Xuat(Chuoi);
    }
}
