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
        kq.x=XL_SO_THUC.Nhap("Hoanh do:");
        kq.y = XL_SO_THUC.Nhap("Tung do:");        
        return kq;
    }
    public static Double Khoang_cach(DIEM A, DIEM B)
    {
        Double kq;
        Double x_AB = A.x - B.x;
        Double y_AB = A.y - B.y;
        kq = Math.Sqrt(x_AB * x_AB + y_AB * y_AB);
        return kq;
    }
    public static String Chuoi(DIEM M)
    {
        String kq;
        kq = "(" + M.x + "," + M.y + ")";
        return kq;
    }
}
