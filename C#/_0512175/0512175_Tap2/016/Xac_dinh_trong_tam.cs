using System;
class Xac_dinh_trong_tam
{
    public static void Main()
    {
        TAM_GIAC tg;
        DIEM G;
        tg = XL_TAM_GIAC.Nhap("Nhap toa do 3 diem trong tam giac:\n");
        G = XL_TAM_GIAC.Trong_tam(tg);
        String Chuoi;
        Chuoi = "Tam giac ABC voi ";
        Chuoi = Chuoi + XL_TAM_GIAC.Chuoi(tg);
        Chuoi = Chuoi + " co trong tam G" + XL_DIEM.Chuoi(G);
        XL_CHUOI.Xuat(Chuoi);
    }
}
