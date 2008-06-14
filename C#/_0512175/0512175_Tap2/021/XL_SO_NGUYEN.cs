using System;

class XL_SO_NGUYEN
{
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            long So = long.Parse(Chuoi);
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    public static long Nhap(String Ghi_chu)
    {
        long kq;
        String Chuoi;
        do
        {
            Chuoi = XL_CHUOI.Nhap(Ghi_chu);
        } while (!Kiem_tra(Chuoi));
        kq = long.Parse(Chuoi);
        return kq;
    }	
}
