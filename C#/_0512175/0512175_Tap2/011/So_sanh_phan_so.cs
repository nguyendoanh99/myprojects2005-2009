using System;
class So_sanh_phan_so
{
    
    public static void Main(string[] args)
    {
        PHAN_SO A;
        PHAN_SO B;
        QUAN_HE kq;
        A = XL_PHAN_SO.Nhap("Nhap phan so A:\n");
        B = XL_PHAN_SO.Nhap("Nhap phan so B:\n");
        kq = XL_PHAN_SO.So_sanh(A, B);
        String Chuoi;
        Chuoi = XL_PHAN_SO.Chuoi(A) + "kq" + XL_PHAN_SO.Chuoi(B);
        if (kq == QUAN_HE.Nho_hon)
            Chuoi = Chuoi.Replace("kq", "<");
        else
            if (kq == QUAN_HE.Bang_nhau)
                Chuoi = Chuoi.Replace("kq", "=");
            else
                if (kq == QUAN_HE.Lon_hon)
                    Chuoi = Chuoi.Replace("kq", ">");
        XL_CHUOI.Xuat(Chuoi);
    }
}