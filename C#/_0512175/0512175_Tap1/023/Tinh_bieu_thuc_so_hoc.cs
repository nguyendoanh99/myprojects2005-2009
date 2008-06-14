using System;
using System.Collections;
public enum TOAN_TU
{
    Cong, Tru
}
public struct BIEU_THUC
{
    public int[] So_hang;
    public TOAN_TU[] Toan_tu;
}
class Tinh_bieu_thuc_so_hoc
{
    public static BIEU_THUC Nhap_bieu_thuc()
    {
        BIEU_THUC kq;
        int n;
        Console.Write("Bieu thuc co bao nhieu so hang:");
        n=int.Parse(Console.ReadLine());
        kq.So_hang = new int[n];
        kq.Toan_tu = new TOAN_TU[n - 1];
        char c;
        Console.Write("Nhap so hang thu 1 : ");
        kq.So_hang[0] = int.Parse(Console.ReadLine());
        for (int i = 1; i < n; i++)
        {
            Console.Write("Nhap toan tu thu " + i + " : ");
            c=char.Parse(Console.ReadLine());
            if (c=='+')
                kq.Toan_tu[i - 1] = TOAN_TU.Cong;
            else
                if (c=='-')
                    kq.Toan_tu[i - 1] = TOAN_TU.Tru;
            Console.Write("Nhap so hang thu " + (i + 1) + " : ");
            kq.So_hang[i]=int.Parse(Console.ReadLine());
        }
        return kq;
    }
    public static int Tinh_bieu_thuc(BIEU_THUC P)
    {
        int kq=P.So_hang[0];
        for (int i = 1; i < P.So_hang.GetLength(0); i++)
        {
            if (P.Toan_tu[i - 1] == TOAN_TU.Cong)
                kq = kq + P.So_hang[i];
            else
                if (P.Toan_tu[i - 1] == TOAN_TU.Tru)
                    kq = kq - P.So_hang[i];
        }
        return kq;
    }
    public static String Chuoi_bieu_thuc(BIEU_THUC P)
    {
        String kq="";
        kq = kq + P.So_hang[0];
        for (int i = 1; i < P.So_hang.GetLength(0); i++)
        {
            if (P.Toan_tu[i-1]==TOAN_TU.Cong)
                kq = kq + " + ";
            else
                if (P.Toan_tu[i - 1] == TOAN_TU.Tru)
                    kq = kq + " - ";
            kq = kq + P.So_hang[i];
        }
        return kq;
    }
    public static void Main(string[] args)
    {
        BIEU_THUC P;
        int kq;

        P = Nhap_bieu_thuc();
        kq = Tinh_bieu_thuc(P);

        String Chuoi="";
        Chuoi = Chuoi + Chuoi_bieu_thuc(P) + " = ";
        Chuoi = Chuoi + kq;
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}