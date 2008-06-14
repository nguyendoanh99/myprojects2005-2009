using System;
class Chu_vi_tam_giac
{   
    public static void Main(string[] args)
    {
        TAM_GIAC tg;
        Double kq;
        tg = XL_TAM_GIAC.Nhap("Nhap toa do cac dinh cua tam giac:\n");
        kq = XL_TAM_GIAC.Chu_vi(tg);

        String Chuoi;
        Chuoi = "Tam giac " + XL_TAM_GIAC.Chuoi(tg) + "\n";
        Chuoi = Chuoi + "co chu vi la " + Math.Round(kq, 2);
        XL_CHUOI.Xuat(Chuoi);
    }
}