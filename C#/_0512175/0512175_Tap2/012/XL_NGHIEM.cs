using System;
using System.Collections;
class XL_NGHIEM
{
    public static String Chuoi(ArrayList Nghiem)
    {
        String kq = "";
        if (Nghiem.Count == 0)
            kq = "Phuong trinh vo nghiem";
        else
            if (Nghiem.Count == 1)
            {
                kq = "Phuong trinh co nghiem kep x1=x2=";
                Double x = (Double)Nghiem[0];
                kq = kq + Math.Round(x, 2);
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
}