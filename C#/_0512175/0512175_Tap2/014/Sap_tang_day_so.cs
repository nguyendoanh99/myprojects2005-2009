using System;
class Sap_tang_day_so
{    
    public static void Main(string[] args)
    {
        Double[] a;
        Double[] b;
        a = XL_DAY_SO.Nhap("Nhap day so nguyen:\n");
        b = XL_DAY_SO.Sap_Tang(a);
        String Chuoi;
        Chuoi = "Day so nguyen truoc khi sap: \n" + XL_DAY_SO.Chuoi(a);
        Chuoi = Chuoi + "\n" + "Day so nguyen sau khi sap: \n";
        Chuoi = Chuoi + XL_DAY_SO.Chuoi(b);
        XL_CHUOI.Xuat(Chuoi);
    }
}
