using System;
public struct CUC_TRI
{
    public Double x;
    public Double y;
    public Boolean Cuc_dai;
}
class XL_CUC_TRI
{
    public static String Chuoi(CUC_TRI c)
    {
        String kq;
        kq = "(" + c.x + "," + c.y + ")";
        if (c.Cuc_dai == true)
            kq = kq + " la cuc dai";
        else
            kq = kq + " la cuc tieu";
        return kq;
    }
}
