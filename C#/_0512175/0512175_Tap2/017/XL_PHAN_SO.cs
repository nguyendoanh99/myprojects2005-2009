using System;

public enum QUAN_HE
{
    Nho_hon,
    Bang_nhau,
    Lon_hon
}
public struct PHAN_SO
{
    public int Tu_so;
    public int Mau_so;
}
class XL_PHAN_SO
{
    public static PHAN_SO Tao(String Chuoi)
    {
        PHAN_SO Kq;
        String[] M;
        M = Chuoi.Split(new char[] { '/' });
        Kq.Tu_so = int.Parse(M[0]);
        Kq.Mau_so = int.Parse(M[1]);
        return Kq;
    }
    public static QUAN_HE So_sanh(PHAN_SO M, PHAN_SO N)
    {
        QUAN_HE Kq = QUAN_HE.Nho_hon;
        long D;
        D = M.Tu_so * N.Mau_so - M.Mau_so * N.Tu_so;
        if (D < 0)
            Kq = QUAN_HE.Nho_hon;
        else
            if (D == 0)
                Kq = QUAN_HE.Bang_nhau;
            else
                if (D > 0)
                    Kq = QUAN_HE.Lon_hon;
        return Kq;
    }
    public static Boolean Kiem_tra(String Chuoi)
    {
        Boolean kq = true;
        String[] M;
        try
        {
            M = Chuoi.Split(new char[] { '/' });
            if (M.Length > 2)
                kq = false;
            kq = kq && XL_SO_NGUYEN.Kiem_tra(M[0]);
            kq = kq && XL_SO_NGUYEN.Kiem_tra(M[1]);            
        }
        catch (Exception Loi)
        {
            kq = false;
        }
        return kq;
    }
    public static String Chuoi(PHAN_SO Ps)
    {
        String kq;
        kq = Ps.Tu_so + "/" + Ps.Mau_so;
        return kq;
    }
}
