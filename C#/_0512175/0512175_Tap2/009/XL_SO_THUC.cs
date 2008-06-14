using System;

class XL_SO_THUC
{
    public static Double Nhap(String Ghi_chu)
    {
        Double kq;
        kq = Nhap(Ghi_chu, Double.MinValue, Double.MaxValue);
        return kq;
    }
    public static Double Nhap(String Ghi_chu, Double Can_duoi)
    {
        Double kq;
        kq = Nhap(Ghi_chu, Can_duoi, Double.MaxValue);
        return kq;
    }
    public static Double Nhap(String Ghi_chu, Double Can_duoi,Double Can_tren)
    {
        Double kq=0;
        do
        {
            kq = Nhap_cuc_bo(Ghi_chu);
        } while (kq <= Can_duoi || kq >= Can_tren);        
        return kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            Double So = Double.Parse(Chuoi);
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    private static Double Nhap_cuc_bo(String Ghi_chu)
    {
        Double kq;
        String Chuoi;
        do
        {
            Chuoi = XL_CHUOI.Nhap(Ghi_chu);
        } while (!Kiem_tra(Chuoi));
        kq = Double.Parse(Chuoi);
        return kq;
    }	
}