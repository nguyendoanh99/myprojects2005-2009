using System;

public struct NGHIEM
{
    public Double CanDuoi;
    public Double CanTren;
}
class XuLyNghiem
{
    public static String XuatChuoi(NGHIEM ng)
    {
        String kq = "";
        if (ng.CanDuoi <= ng.CanTren)
        {
            kq = kq + +Math.Round(ng.CanDuoi, 2) + " <= x <= " +
                Math.Round(ng.CanTren, 2);
        }
        else
            kq = kq + "vo nghiem";            
        return kq;
    }
}
