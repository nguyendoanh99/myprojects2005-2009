using System;
public enum CHIEU_BAT_PHUONG_TRINH
{
    Lon_hon,
    Nho_hon
}
public enum _NGHIEM
{
    Co_nghiem,
    Vo_nghiem,
    Vo_so_nghiem
}
public struct NGHIEM
{
    public Double x;
    public _NGHIEM nghiem;
    public CHIEU_BAT_PHUONG_TRINH chieu_bpt;
}
class XL_NGHIEM
{
    public static String Chuoi(NGHIEM ng)
    {
        String kq = "";
        if (ng.nghiem == _NGHIEM.Co_nghiem)
        {
            kq = kq + "co nghiem la x = " + Math.Round(ng.x, 2);
            if (ng.chieu_bpt == CHIEU_BAT_PHUONG_TRINH.Nho_hon)
                kq = kq.Replace('=', '<');
            else
                kq = kq.Replace('=', '>');
        }
        else
            if (ng.nghiem == _NGHIEM.Vo_nghiem)
                kq = kq + "vo nghiem";
            else
                if (ng.nghiem == _NGHIEM.Vo_so_nghiem)
                    kq = kq + "co vo so nghiem";
        return kq;
    }
}
