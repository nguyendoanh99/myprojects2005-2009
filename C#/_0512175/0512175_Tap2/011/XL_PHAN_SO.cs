using System;
public enum QUAN_HE
{
    Nho_hon,
    Bang_nhau,
    Lon_hon
}
public struct PHAN_SO
{
    public long Tu_so;
    public long Mau_so;
}
class XL_PHAN_SO
{
    public static PHAN_SO Nhap(String Ghi_chu)
    {
        PHAN_SO kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.Tu_so = XL_SO_NGUYEN.Nhap("Tu so = ");
        kq.Mau_so = XL_SO_NGUYEN.Nhap("Mau so = ");
        return kq;
    }
    public static QUAN_HE So_sanh(PHAN_SO M, PHAN_SO N)
    {
        QUAN_HE kq = QUAN_HE.Nho_hon;
        long D;
        D = M.Tu_so * N.Mau_so - M.Mau_so * N.Tu_so;
        if (D < 0)
            kq = QUAN_HE.Nho_hon;
        else
            if (D == 0)
                kq = QUAN_HE.Bang_nhau;
            else
                if (D > 0)
                    kq = QUAN_HE.Lon_hon;
        return kq;
    }
    public static String Chuoi(PHAN_SO ps)
    {
        String kq;
        kq = ps.Tu_so + "/" + ps.Mau_so;
        return kq;
    }
}
