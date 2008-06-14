using System;
public enum TOAN_TU
{
    Cong, Tru
}
class XL_TOAN_TU
{
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {            
            char c = char.Parse(Chuoi);
            if (c != '+' && c != '-')
                kq = false;
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    public static TOAN_TU Nhap(String Ghi_chu)
    {
        TOAN_TU kq=TOAN_TU.Tru;
        String Chuoi;
        do
        {
            Chuoi = XL_CHUOI.Nhap(Ghi_chu);
        } while (!Kiem_tra(Chuoi));
        char c = char.Parse(Chuoi);
        if (c == '+')
            kq = TOAN_TU.Cong;
        else
            if (c == '-')
                kq = TOAN_TU.Tru;        
        return kq;
    }	
}
