using System;
using System.Collections.Generic;
using System.Text;
public struct DATHUC
{
    public String Ten;
    public String BienSo;
    public DONTHUC[] DonThuc;
}
class XuLyDaThuc
{
    private static String ChuoiPhanCach = "+";
    public static DATHUC Doc(String TenFile)
    {
        DATHUC kq;
        String Chuoi = XuLyTapTin.Doc(TenFile);
        kq = KhoiTao(Chuoi);
        return kq;
    }
    public static DATHUC KhoiTao(String Chuoi)
    {
        DATHUC kq;
        kq.DonThuc = null;
        kq.Ten = "";
        kq.BienSo = "";
        if (KiemTra(Chuoi))
        {
            String[] T = Chuoi.Split(new String[] { "=" },
                StringSplitOptions.None);
            String[] N = T[0].Split(new String[] { "(", ")" },
                StringSplitOptions.None);
            kq.Ten = N[0].Trim();
            kq.BienSo = N[1].Trim();

            XuLyDonThuc.Set_ChuoiPhanCach(kq.BienSo);
            String[] M = T[1].Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.DonThuc = new DONTHUC[M.Length];
            for (int i = 0; i < M.Length; i++)
                kq.DonThuc[i] = XuLyDonThuc.KhoiTao(M[i]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] T = Chuoi.Split(new String[] { "=" },
                StringSplitOptions.None);

        T[0] = T[0].Trim();
        String[] N = T[0].Split(new String[] { "(", ")" },
            StringSplitOptions.None);
        flag = N.Length == 3;
        if (flag)
        {

            XuLyDonThuc.Set_ChuoiPhanCach(N[1]);
            String[] M = T[1].Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);            
            for (int i = 0; i < M.Length; i++)
                flag = flag && XuLyDonThuc.KiemTra(M[i]);
        }
        return flag;
    }
    public static String XuatChuoi(DATHUC P)
    {
        String kq = P.Ten+"("+P.BienSo+") = ";
        int i = 0;
        foreach (DONTHUC q in P.DonThuc)
        {
            kq = kq + XuLyDonThuc.XuatChuoi(q);
            if (i < P.DonThuc.GetLength(0) - 1)
                kq = kq + " + ";
            i++;
        }
        return kq;
    }
    public static Double TinhGiaTri(DATHUC P,Double x0)
    {
        Double kq = 0;
        foreach (DONTHUC q in P.DonThuc)
        {
            kq = kq + XuLyDonThuc.TinhGiaTri(q, x0);
        }
        return kq;
    }
}