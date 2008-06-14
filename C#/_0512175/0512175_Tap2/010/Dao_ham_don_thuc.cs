using System;
class Dao_ham_don_thuc
{    
    public static void Main(string[] args)
    {
        DON_THUC P;
        DON_THUC Q;
        P = XL_DON_THUC.Nhap("Nhap don thuc P(x):\n");
        Q = XL_DON_THUC.Dao_ham(P);
        String Chuoi="Dao ham cua P(x)=";
        Chuoi = Chuoi + XL_DON_THUC.Chuoi(P)+"\n";
        Chuoi = Chuoi + " la Q(x)=" + XL_DON_THUC.Chuoi(Q);
        XL_CHUOI.Xuat(Chuoi);        
    }
}