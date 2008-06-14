using System;
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
        kq.Tu_so = XL_SO_NGUYEN.Nhap("Tu so:");        
        kq.Mau_so = XL_SO_NGUYEN.Nhap("Mau so:");
        return kq;
    }
    public static PHAN_SO Tong(PHAN_SO M, PHAN_SO N)
    {
        PHAN_SO kq;
        kq.Tu_so = M.Tu_so * N.Mau_so + N.Tu_so * M.Mau_so;
        kq.Mau_so = M.Mau_so * N.Mau_so;
        return kq;
    }
    public static String Chuoi(PHAN_SO M)
    {
        String kq;
        kq = M.Tu_so + "/" + M.Mau_so;
        return kq;
    }
}