using System;
using System.Collections.Generic;
using System.Text;

class XuLySoThuc
{
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean temp = true;
        try
        {
            Double So = Double.Parse(Chuoi);
        }
        catch (Exception e)
        {
            temp = false;
        }
        return temp;
    }
    private static Double NhapCucBo(String GhiChu)
    {
        Double temp;
        String Chuoi;
        do
        {
            Chuoi = XuLyChuoi.Nhap(GhiChu);
        } while (!KiemTra(Chuoi));
        temp = Double.Parse(Chuoi);
        return temp;
    }
    public static Double Nhap(String GhiChu, Double CanDuoi, Double CanTren)
    {
        Double temp;
        do
        {
            temp = NhapCucBo(GhiChu);
        } while (!(temp >= CanDuoi && temp <= CanTren));
        return temp;
    }
    public static Double Nhap(String GhiChu, Double CanDuoi)
    {
        Double temp;
        temp = Nhap(GhiChu, CanDuoi, Double.MaxValue);
        return temp;
    }
    public static Double Nhap(String GhiChu)
    {
        Double temp;
        temp = Nhap(GhiChu, Double.MinValue, Double.MaxValue);
        return temp;
    }
    public static String XuatChuoi(Double SoThuc)
    {
        String temp;
        temp = SoThuc.ToString();
        return temp;
    }
}

