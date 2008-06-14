using System;

class XL_NGAY
{
    public static DateTime Nhap(String Ghi_chu)
    {
        DateTime kq;
        kq = Nhap(Ghi_chu,DateTime.MinValue,DateTime.MaxValue);
        return kq;
    }
    public static DateTime Nhap(String Ghi_chu, DateTime Can_duoi)
    {
        DateTime kq;
        kq = Nhap(Ghi_chu, Can_duoi, DateTime.MaxValue);
        return kq;
    }
    public static DateTime Nhap(String Ghi_chu, DateTime Can_duoi, DateTime Can_tren)
    {
        DateTime kq;
        do
        {
            kq = Nhap_cuc_bo(Ghi_chu);
        } while (kq < Can_duoi || kq > Can_tren);
        return kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            DateTime Ngay = DateTime.Parse(Chuoi);
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    private static DateTime Nhap_cuc_bo(String Ghi_chu)
    {
        DateTime kq;
        String Chuoi;
        do
        {
            Chuoi = XL_CHUOI.Nhap(Ghi_chu);
        } while (!Kiem_tra(Chuoi));
        kq = DateTime.Parse(Chuoi);
        return kq;
    }
    public static DateTime Ngay_sinh(int Ngay, int Thang, int Tuoi)
    {
        DateTime kq;
        int Nam_sinh = DateTime.Today.Year - Tuoi;
        kq = new DateTime(Nam_sinh, Thang, Ngay);
        return kq;
    }
}