using System;
public struct DON_THUC
{
    public Double He_so;
    public int So_mu;
}

class Dao_ham_don_thuc
{
    public static DON_THUC Nhap_don_thuc()
    {
        DON_THUC kq;
        kq.He_so = SoThuc.NhapSoThuc("He so a = ");
        kq.So_mu = SoNguyen.NhapSoNguyen("So mu n = ");
        return kq;
    }
    public static DON_THUC Dao_ham_1_don_thuc(DON_THUC P)
    {
        DON_THUC kq;
        kq.He_so = P.So_mu * P.He_so;
        kq.So_mu = P.So_mu - 1;
        if (kq.So_mu < 0)
            kq.So_mu = 0;
        return kq;
    }
    public static String Chuoi_don_thuc(DON_THUC P)
    {
        String kq;
        kq = P.He_so + "x^" + P.So_mu;
        return kq;
    }
    public static void Main(string[] args)
    {
        DON_THUC P;
        DON_THUC Q;
        P = Nhap_don_thuc();
        Q = Dao_ham_1_don_thuc(P);
        String Chuoi="Dao ham cua P(x)=";
        Chuoi = Chuoi + Chuoi_don_thuc(P)+"\n";
        Chuoi = Chuoi + " la Q(x)=" + Chuoi_don_thuc(Q);
        Console.Write(Chuoi);
        Console.ReadLine();

        
    }
}