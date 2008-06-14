using System;
class Xac_dinh_cuc_tri
{   
    public static void Main(string[] args)
    {
        TAM_THUC P;
        CUC_TRI M;
        P = XL_TAM_THUC.Nhap("Nhap tam thuc bac 2:\n");
        M = XL_TAM_THUC.Cuc_tri(P);
        String Chuoi;
        Chuoi = "Ham bac 2 f(x)=" + XL_TAM_THUC.Chuoi(P) + "\n";
        Chuoi = Chuoi + "co cuc tri M" + XL_CUC_TRI.Chuoi(M);
        XL_CHUOI.Xuat(Chuoi);
    }
}