using System;
public struct DIEM
{
    public Double x;
    public Double y;
}
class XuLyDiem
{
    private static String ChuoiPhanCach = ",";
    public static DIEM KhoiTao(String Chuoi)
    {
        DIEM kq;
        kq.x = Double.MaxValue;
        kq.y = Double.MaxValue;
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.x = Double.Parse(M[0]);
            kq.y = Double.Parse(M[1]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
        flag = M.Length == 2;
        if (flag)
            flag = XuLySoThuc.KiemTra(M[0]) && XuLySoThuc.KiemTra(M[1]);
        return flag;
    }
    public static DIEM Nhap(String Ghi_chu)
    {
        DIEM kq;
        XuLyChuoi.Xuat(Ghi_chu);
        kq.x = XuLySoThuc.Nhap("Hoanh do:");
        kq.y = XuLySoThuc.Nhap("Tung do:");
        return kq;
    }
    public static Double Khoang_cach(DIEM M, DIEM N)
    {
        Double kq;
        Double Dx = M.x - N.x;
        Double Dy = M.y - N.y;
        kq = Math.Sqrt(Dx * Dx + Dy * Dy);
        return kq;
    }
    public static String XuatChuoi(DIEM M)
    {
        String kq;
        kq = "(" + M.x + ChuoiPhanCach + M.y + ")";
        return kq;
    }
    public static Boolean Thang_hang(DIEM M, DIEM N, DIEM P)
    {
        Boolean kq;
        Double x_MN = N.x - M.x;
        Double y_MN = N.y - M.y;

        Double x_MP = P.x - M.x;
        Double y_MP = P.y - M.y;

        kq = (x_MN * y_MP - y_MN * x_MP)==0;
        return kq;
    }
}
