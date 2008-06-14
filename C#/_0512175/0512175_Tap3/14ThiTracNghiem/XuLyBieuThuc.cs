using System;
using System.Collections.Generic;
using System.Text;
public enum PHEPTOAN
{
    CONG,
    TRU,
    NHAN
}
public struct BIEUTHUC
{
    public long So1;
    public long So2;
    public PHEPTOAN PhepToan;
}
class XuLyBieuThuc
{
    public static BIEUTHUC[] Nhap(String GhiChu)
    {
        BIEUTHUC[] kq;
        XuLyChuoi.Xuat(GhiChu);
        long n;
        n = XuLySoNguyen.Nhap("Ban muon tao bao nhieu cau hoi?", 1, 100);
        kq=new BIEUTHUC[n];
        for (int i = 0; i < n; i++)       
            kq[i] = NhapCucBo("Nhap bieu thuc thu "+(i+1)+":");
        return kq;
    }
    public static BIEUTHUC KhoiTao(String Chuoi)
    {
        BIEUTHUC kq;
        kq.So1 = long.MinValue;
        kq.So2 = long.MinValue;
        kq.PhepToan = PHEPTOAN.CONG;
        String[] M = Chuoi.Split(new String[] { "*", "+", "-" },
            StringSplitOptions.None);
        if (KiemTra(Chuoi))
        {
            kq.So1 = long.Parse(M[0]);
            kq.So2 = long.Parse(M[1]);
            if (Chuoi.Contains("+"))
                kq.PhepToan = PHEPTOAN.CONG;
            else
                if (Chuoi.Contains("-"))
                    kq.PhepToan = PHEPTOAN.TRU;
                else
                    kq.PhepToan = PHEPTOAN.NHAN;
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        String[] M = Chuoi.Split(new String[] { "*", "+", "-" },
            StringSplitOptions.None);
        Boolean flag = M.Length == 2;
        if (flag)
            flag = flag && XuLySoNguyen.KiemTra(M[0]) && XuLySoNguyen.KiemTra(M[1]);
        return flag;
    }
    private static BIEUTHUC NhapCucBo(String GhiChu)
    {
        String Chuoi;
        do
        {
            Chuoi = XuLyChuoi.Nhap(GhiChu);
        } while (!KiemTra(Chuoi));
        BIEUTHUC kq = KhoiTao(Chuoi);
        return kq;
    }
    public static String XuatChuoi(BIEUTHUC P)
    {
        String kq;
        kq = P.So1 + " _ " + P.So2;
        switch (P.PhepToan)
        {
            case PHEPTOAN.CONG:
                kq = kq.Replace("_", "+");
                break;
            case PHEPTOAN.TRU:
                kq = kq.Replace("_", "-");
                break;
            case PHEPTOAN.NHAN:
                kq = kq.Replace("_", "*");
                break;
        }
        return kq;
    }
    public static long TinhToan(BIEUTHUC P)
    {
        long kq = 0;
        switch (P.PhepToan)
        {
            case PHEPTOAN.CONG:
                kq = P.So1 + P.So2;
                break;
            case PHEPTOAN.TRU:
                kq = P.So1 - P.So2;
                break;
            case PHEPTOAN.NHAN:
                kq = P.So1 * P.So2;
                break;
        }
        return kq;
    }
}
