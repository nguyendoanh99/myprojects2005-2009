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
class So_sanh_phan_so
{
    public static PHAN_SO Nhap_phan_so()
    {
        PHAN_SO kq;
        kq.Tu_so = SoNguyen.NhapSoNguyen("Tu so = ");
        kq.Mau_so = SoNguyen.NhapSoNguyen("Mau so = ");
        return kq;
    }
    public static QUAN_HE So_sanh(PHAN_SO M, PHAN_SO N)
    {
        QUAN_HE kq = QUAN_HE.Nho_hon;
        long D;
        D = M.Tu_so * N.Mau_so - M.Mau_so * N.Tu_so;
        if (D < 0)
            kq = QUAN_HE.Nho_hon;
        else
            if (D == 0)
                kq = QUAN_HE.Bang_nhau;
            else
                if (D > 0)
                    kq = QUAN_HE.Lon_hon;
        return kq;
    }
    public static String Chuoi_phan_so(PHAN_SO ps)
    {
        String kq;
        kq = ps.Tu_so + "/" + ps.Mau_so;
        return kq;
    }
    public static void Main(string[] args)
    {
        PHAN_SO A;
        PHAN_SO B;
        QUAN_HE kq;
        A = Nhap_phan_so();
        B = Nhap_phan_so();
        kq = So_sanh(A, B);
        String Chuoi;
        Chuoi = Chuoi_phan_so(A) + "kq" + Chuoi_phan_so(B);
        if (kq == QUAN_HE.Nho_hon)
            Chuoi = Chuoi.Replace("kq", "<");
        else
            if (kq == QUAN_HE.Bang_nhau)
                Chuoi = Chuoi.Replace("kq", "=");
            else
                if (kq == QUAN_HE.Lon_hon)
                    Chuoi = Chuoi.Replace("kq", ">");
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}