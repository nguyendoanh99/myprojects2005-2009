using System;
public enum TOAN_TU
{
    Cong, Tru
}
public struct PHAN_SO
{
    public int Tu_so;
    public int Mau_so;
}
public struct BIEU_THUC
{
    public PHAN_SO[] So_hang;
    public TOAN_TU[] Toan_tu;
}
class Tinh_gia_tri_bieu_thuc_phan_so
{
    public static PHAN_SO Nhap_phan_so()
    {
        PHAN_SO kq;
        Console.Write("Tu so = ");
        kq.Tu_so = int.Parse(Console.ReadLine());
        Console.Write("Mau so = ");
        kq.Mau_so = int.Parse(Console.ReadLine());
        return kq;
    }
    public static PHAN_SO Tong_phan_so(PHAN_SO M, PHAN_SO N)
    {
        PHAN_SO kq;
        kq.Tu_so = M.Tu_so * N.Mau_so + N.Tu_so * M.Mau_so;
        kq.Mau_so = M.Mau_so * N.Mau_so;
        return kq;
    }
    public static PHAN_SO Hieu_phan_so(PHAN_SO M, PHAN_SO N)
    {
        PHAN_SO kq;
        kq.Tu_so = M.Tu_so * N.Mau_so - N.Tu_so * M.Mau_so;
        kq.Mau_so = M.Mau_so * N.Mau_so;
        return kq;
    }
    public static String Chuoi_phan_so(PHAN_SO M)
    {
        String kq;
        kq = M.Tu_so + "/" + M.Mau_so;
        return kq;
    }
    public static BIEU_THUC Nhap_bieu_thuc()
    {
        BIEU_THUC kq;
        int n;
        Console.Write("Bieu thuc co bao nhieu so hang:");
        n = int.Parse(Console.ReadLine());
        kq.So_hang = new PHAN_SO[n];
        kq.Toan_tu = new TOAN_TU[n - 1];
        char c;
        Console.Write("Nhap so hang thu 1 : \n");
        kq.So_hang[0] = Nhap_phan_so();
        for (int i = 1; i < n; i++)
        {
            Console.Write("Nhap toan tu thu " + i + " : ");
            c = char.Parse(Console.ReadLine());
            if (c == '+')
                kq.Toan_tu[i - 1] = TOAN_TU.Cong;
            else
                if (c == '-')
                    kq.Toan_tu[i - 1] = TOAN_TU.Tru;
            Console.Write("Nhap so hang thu " + (i + 1) + " : \n");
            kq.So_hang[i] = Nhap_phan_so();
        }
        return kq;
    }
    public static PHAN_SO Tinh_bieu_thuc(BIEU_THUC P)
    {
        PHAN_SO kq;
        kq = P.So_hang[0];
        for (int i = 1; i < P.So_hang.GetLength(0); i++)
        {
            if (P.Toan_tu[i - 1] == TOAN_TU.Cong)
                kq = Tong_phan_so(kq, P.So_hang[i]);
            else
                if (P.Toan_tu[i - 1] == TOAN_TU.Tru)
                    kq = Hieu_phan_so(kq, P.So_hang[i]);
        }
        return kq;
    }
    public static String Chuoi_bieu_thuc(BIEU_THUC P)
    {
        String kq = "";
        kq = kq + Chuoi_phan_so(P.So_hang[0]);
        for (int i = 1; i < P.So_hang.GetLength(0); i++)
        {
            if (P.Toan_tu[i - 1] == TOAN_TU.Cong)
                kq = kq + " + ";
            else
                if (P.Toan_tu[i - 1] == TOAN_TU.Tru)
                    kq = kq + " - ";
            kq = kq + Chuoi_phan_so(P.So_hang[i]);
        }
        return kq;
    }
    public static void Main(string[] args)
    {
        BIEU_THUC P;
        PHAN_SO kq;

        P = Nhap_bieu_thuc();
        kq = Tinh_bieu_thuc(P);

        String Chuoi = "";
        Chuoi = Chuoi + Chuoi_bieu_thuc(P) + " = ";
        Chuoi = Chuoi + Chuoi_phan_so(kq);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}
