using System;
using System.Collections.Generic;
using System.Text;
public struct KHACHSAN
{
    public String Ten;
    public long MucGiam;
    public Double TyLeGiam;
    public LOAIPHONG[] PhongThue;
}
class XuLyKhachSan
{
    private static String ChuoiPhanCach = "\r\n";
    public static KHACHSAN Doc(String TenFile)
    {
        KHACHSAN kq;
        String Chuoi = XuLyTapTin.Doc(TenFile);
        kq = KhoiTao(Chuoi);
        return kq;
    }
    public static KHACHSAN KhoiTao(String Chuoi)
    {
        KHACHSAN kq;
        kq.MucGiam = 0;
        kq.PhongThue = null;
        kq.Ten = "";
        kq.TyLeGiam = 0;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Ten = M[0].Trim();
            kq.PhongThue=new LOAIPHONG[M.Length-2];
            for (int i = 1; i < M.Length - 1; i++)
                kq.PhongThue[i-1] = XuLyLoaiPhong.KhoiTao(M[i]);
            String [] N=M[M.Length-1].Split(new String[] {";"},
                StringSplitOptions.None);
            kq.MucGiam=long.Parse(N[0]);
            kq.TyLeGiam=long.Parse(N[1]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
        flag = M.Length >= 3;
        for (int i = 1; flag && (i < M.Length - 1); i++)        
            flag = XuLyLoaiPhong.KiemTra(M[i]);                    
        String[] N = M[M.Length - 1].Split(new String[] { ";" },
            StringSplitOptions.None);
        flag = flag && N.Length == 2;
        if (flag)
        {
            flag = flag && XuLySoNguyen.KiemTra(N[0]);
            flag = flag && XuLySoNguyen.KiemTra(N[1]);
        }
        return flag;
    }
    public static String XuatChuoi(KHACHSAN P)
    {
        String kq = P.Ten + "\n";
        for (int i = 0; i < P.PhongThue.Length; i++)
            kq = kq + "\t" + XuLyLoaiPhong.XuatChuoi(P.PhongThue[i]) + "\n";
        kq = kq + "Neu thue qua "+P.MucGiam+" ngay duoc giam "+P.TyLeGiam+"% tien";
        return kq;
    }
    public static Double TinhTien(KHACHSAN P, PHIEUTHUE Phieu)
    {
        Double kq = 0;
        for (int i = 0; kq == 0 && i < P.PhongThue.Length; i++)
            kq = XuLyLoaiPhong.TinhTien(P.PhongThue[i], Phieu);
        if (Phieu.SoNgay > P.MucGiam)
            kq = kq - kq * P.TyLeGiam / 100;
        return kq;
    }
}
