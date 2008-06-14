using System;
using System.Collections;
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

class Tim_phan_so_lon_nhat
{
    public static PHAN_SO Tao_phan_so(String Chuoi)
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
    public static String Chuoi_phan_so(PHAN_SO Ps)
    {
        String kq;
        kq = Ps.Tu_so + "/" + Ps.Mau_so;
        return kq;
    }
    public static ArrayList Nhap_day_phan_so()
    {
        ArrayList kq = new ArrayList();
        Console.Write("Day cac phan so:");
        String Chuoi = Console.ReadLine();
        String[] M = Chuoi.Split(new char[] { ',' });
        for (int i = 0; i < M.Length; i++)
            kq.Add(Tao_phan_so(M[i]));
        return kq;
    }
    public static PHAN_SO Phan_so_lon_nhat(ArrayList Ps)
    {
        PHAN_SO kq;
        kq = (PHAN_SO)Ps[0];
        foreach (PHAN_SO x in Ps)
            if (So_sanh(x, kq) == QUAN_HE.Lon_hon)
                kq = x;
        return kq;
    }
    public static String Chuoi_day_phan_so(ArrayList Ps)
    {
        String kq = "";
        for (int i=0;i<Ps.Count;i++)
        {
            PHAN_SO x=(PHAN_SO) Ps[i];
            kq=kq+Chuoi_phan_so(x);
            if (i < Ps.Count - 1)
                kq = kq + ",";
        }
        return kq;
    }
    public static void Main(string[] args)
    {
        ArrayList Ps;
        PHAN_SO kq;
        Ps = Nhap_day_phan_so();
        kq = Phan_so_lon_nhat(Ps);
        String Chuoi = "Day cac phan so ";
        Chuoi = Chuoi + Chuoi_day_phan_so(Ps) + "\n";
        Chuoi = Chuoi + "co phan so lon nhat la ";
        Chuoi = Chuoi + Chuoi_phan_so(kq);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
