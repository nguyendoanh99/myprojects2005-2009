using System;
class Canh_huyen
{
    public static void Main()
    {
        Double a;
        Double b;
        Double c;

        a = XL_SO_THUC.Nhap("Canh goc vuong thu 1:");
        b = XL_SO_THUC.Nhap("Canh goc vuong thu 2:");
        c = Math.Sqrt(a * a + b * b);
        String Chuoi;
        Chuoi = "Tam giac voi 2 canh goc vuong la a=" + a;
        Chuoi = Chuoi + " va b=" + b;
        Chuoi = Chuoi + " co chieu dai canh huyen la c=" + c;
        XL_CHUOI.Xuat(Chuoi);
    }
}