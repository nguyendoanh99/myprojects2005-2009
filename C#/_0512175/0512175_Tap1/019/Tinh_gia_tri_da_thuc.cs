using System;
using System.Collections;
public struct DON_THUC
{
    public Double He_so;
    public int So_mu;
}
    class Tinh_gia_tri_da_thuc
    {
        public static ArrayList Nhap_da_thuc()
        {
            ArrayList kq=new ArrayList();
            int n;
            n = SoNguyen.NhapSoNguyenDuong("Da thuc co bao nhieu don thuc:");
            DON_THUC p;
            for (int i = 0; i < n; i++)
            {
                p = Nhap_don_thuc();
                kq.Add(p);
            }
            return kq;
        }
        public static DON_THUC Nhap_don_thuc()
        {
            DON_THUC kq;
            kq.He_so = SoThuc.NhapSoThuc("Nhap he so: ");
            kq.So_mu = SoNguyen.NhapSoNguyen("Nhap so mu: ");
            return kq;
        }
        public static Double Tinh_gia_tri(ArrayList P, Double x0)
        {
            Double kq=0;
            foreach (DON_THUC q in P)
            {
                kq = kq + Tinh_gia_tri(q, x0);
            }
            return kq;
        }
        public static Double Tinh_gia_tri(DON_THUC Q, Double x0)
        {
            Double kq;
            kq = Q.He_so * Math.Pow(x0, Q.So_mu);
            return kq;
        }
        public static String Chuoi_da_thuc(ArrayList P)
        {
            String kq = "";
            int i = 0;
            foreach (DON_THUC q in P)
            {
                kq = kq + Chuoi_don_thuc(q);
                if (i < P.Count - 1)
                    kq = kq + "+";
                i++;
            }
            return kq;
        }
        public static String Chuoi_don_thuc(DON_THUC Q)
        {
            String kq="";
            kq = Q.He_so + "x^" + Q.So_mu;
            return kq;
        }
        static void Main(string[] args)
        {
            ArrayList P;
            Double x0;
            Double kq;
            P = Nhap_da_thuc();
            x0 = SoThuc.NhapSoThuc("Nhap x0 = ");
            kq = Tinh_gia_tri(P, x0);
            String Chuoi;
            Chuoi = "Gia tri da thuc P(x)=" + Chuoi_da_thuc(P)+"\n";
            Chuoi = Chuoi + "voi x0=" + x0 + " la :" + kq;
            Console.Write(Chuoi);
            Console.ReadLine();
        }
    }
