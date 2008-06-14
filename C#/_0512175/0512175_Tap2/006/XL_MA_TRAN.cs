using System;

class XL_MA_TRAN
{
    private static char Ky_tu_phan_cach_dong = '-';
    private static char Ky_tu_phan_cach_cot = ',';
    public static Double[,] Nhap(String Ghi_chu)
    {
        Double[,] kq;
        String Chuoi;        
        do
        {
            XL_CHUOI.Xuat(Ghi_chu);
            Chuoi = Console.ReadLine();
        } while (!Kiem_tra(Chuoi));

        String[] Chuoi_dong = Chuoi.Split(new char[] { Ky_tu_phan_cach_dong });
        int So_dong = Chuoi_dong.Length;
        int So_cot = Chuoi_dong[0].Split(new char[] { Ky_tu_phan_cach_cot }).Length;
        kq = new Double[So_dong, So_cot];
        for (int i = 0; i < So_dong; i++)
        {
            String[] Dong = Chuoi_dong[i].Split(new char[] { Ky_tu_phan_cach_cot });
            for (int j = 0; j < So_cot; j++)
                kq[i, j] = Double.Parse(Dong[j]);
        }
        return kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        try
        {
            String[] Chuoi_dong = Chuoi.Split(new char[] { Ky_tu_phan_cach_dong });
            int So_dong = Chuoi_dong.Length;
            int So_cot = Chuoi_dong[0].Split(new char[] { Ky_tu_phan_cach_cot }).Length;            
            for (int i = 0; i < So_dong; i++)
            {
                String[] Dong = Chuoi_dong[i].Split(new char[] { ',' });
                for (int j = 0; j < So_cot; j++)
                    if (!XL_SO_THUC.Kiem_tra(Dong[j]))
                    {
                        kq = false;
                        break;
                    }
                if (!kq)
                    break;
            }
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    public static Double Tinh_tong(Double[,] a)
    {
        Double kq = 0;
        foreach (Double So in a)
            kq = kq + So;
        return kq;
    }
    public static string Chuoi(Double[,] a)
    {
        String kq = "";
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                kq = kq + a[i, j];
                if (j < a.GetLength(1) - 1)
                    kq = kq + Ky_tu_phan_cach_cot;
            }
            kq = kq + "\n";
        }
        return kq;
    }
}
