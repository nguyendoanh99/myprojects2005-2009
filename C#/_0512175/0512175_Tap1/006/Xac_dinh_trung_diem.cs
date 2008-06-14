using System;
public struct DIEM
{
    public Double x;
    public Double y;
}
class Xac_dinh_trung_diem
{
    public static DIEM Nhap_diem()
    {
        DIEM kq;
        kq.x = SoThuc.NhapSoThuc("Hoanh do:");
        kq.y = SoThuc.NhapSoThuc("Tung do:");
        return kq;
    }
    public static DIEM Xac_dinh_trung_diem_2_diem(DIEM M, DIEM N)
    {
        DIEM kq;
        kq.x = (N.x + M.x) / 2;
        kq.y = (N.y + M.y) / 2;
        return kq;
    }
    public static String Chuoi_diem(DIEM M)
    {
        String kq;
        kq = "(" + M.x + "," + M.y + ")";
        return kq;
    }
    public static void Main()
    {
        DIEM I;
        DIEM A, B;
        A = Nhap_diem();
        B = Nhap_diem();
        I = Xac_dinh_trung_diem_2_diem(A, B);
        String Chuoi;
        Chuoi = "Trung diem cua A" + Chuoi_diem(A);
        Chuoi = Chuoi + "va B" + Chuoi_diem(B);
        Chuoi = Chuoi + "la diem I" + Chuoi_diem(I);
        Console.Write(Chuoi);
        Console.ReadLine();
    }
}