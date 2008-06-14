using System;
using System.Collections.Generic;
using System.Text;

class XuLySoNguyen
{
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean temp = true;
        try
        {
            long So = long.Parse(Chuoi);
        }
        catch (Exception e)
        {
            temp = false;
        }
        return temp;
    }
    private static long NhapCucBo(String GhiChu)
    {
        long temp;
        String Chuoi;
        do
        {
            Chuoi = XuLyChuoi.Nhap(GhiChu);
        } while (!KiemTra(Chuoi));
        temp = long.Parse(Chuoi);
        return temp;
    }
    public static long Nhap(String GhiChu, long CanDuoi, long CanTren)
    {
        long temp;
        do
        {
            temp = NhapCucBo(GhiChu);
        } while (!(temp >= CanDuoi && temp <= CanTren));
        return temp;
    }
    public static long Nhap(String GhiChu, long CanDuoi)
    {
        long temp;
        temp = Nhap(GhiChu, CanDuoi, long.MaxValue);
        return temp;
    }
    public static long Nhap(String GhiChu)
    {
        long temp;
        temp = Nhap(GhiChu, long.MinValue, long.MaxValue);
        return temp;
    }
}