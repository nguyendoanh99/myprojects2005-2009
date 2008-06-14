using System;
public struct DIEM
{
    public Double x;
    public Double y;
}
class XL_DIEM
{
    public static DIEM Nhap(String Ghi_chu)
    {
        DIEM kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.x = XL_SO_THUC.Nhap("Hoanh do:");
        kq.y = XL_SO_THUC.Nhap("Tung do:");
        return kq;
    }
    public static Double Khoang_cach(DIEM M, DIEM N)
    {
        Double kq;
        Double Dx = M.x - N.x;
        Double Dy = M.y - N.y;
        kq = Math.Sqrt(Dx * Dx + Dy * Dy);
        return kq;
    }
    public static String Chuoi(DIEM M)
    {
        String kq;
        kq = "(" + M.x + "," + M.y + ")";
        return kq;
    }
    public static Boolean Thang_hang(DIEM M, DIEM N, DIEM P)
    {
        Boolean kq;
        Double x_MN = N.x - M.x;
        Double y_MN = N.y - M.y;

        Double x_MP = P.x - M.x;
        Double y_MP = P.y - M.y;

        kq = (x_MN * y_MP - y_MN * x_MP)==0;
        return kq;
    }
}
