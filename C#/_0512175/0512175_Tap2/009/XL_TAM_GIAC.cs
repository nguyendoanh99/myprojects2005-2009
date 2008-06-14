using System;
public struct TAM_GIAC
{
    public DIEM A;
    public DIEM B;
    public DIEM C;
}
class XL_TAM_GIAC
{
    public static TAM_GIAC Nhap(String Ghi_chu)
    {
        TAM_GIAC kq;
        XL_CHUOI.Xuat(Ghi_chu);
        do
        {
            kq.A = XL_DIEM.Nhap("Toa do A:\n");
            kq.B = XL_DIEM.Nhap("Toa do B:\n");
            kq.C = XL_DIEM.Nhap("Toa do C:\n");
        } while (XL_DIEM.Thang_hang(kq.A, kq.B, kq.C));

        return kq;
    }
    public static Double Chu_vi(TAM_GIAC tg)
    {
        Double kq;
        kq = XL_DIEM.Khoang_cach(tg.A, tg.B);
        kq = kq + XL_DIEM.Khoang_cach(tg.B, tg.C);
        kq = kq + XL_DIEM.Khoang_cach(tg.C, tg.A);
        return kq;
    }
    public static String Chuoi(TAM_GIAC tg)
    {
        String kq;
        kq = "A" + XL_DIEM.Chuoi(tg.A);
        kq = kq + "B" + XL_DIEM.Chuoi(tg.B);
        kq = kq + "C" + XL_DIEM.Chuoi(tg.C);
        return kq;
    }
}
