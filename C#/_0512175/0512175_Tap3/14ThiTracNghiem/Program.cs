using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        CAUHOI[] DeThi=XuLyCauHoi.Doc("DeThiTracNghiem.txt");
        String Chuoi="Du lieu khong hop le";
        if (DeThi != null)
        {
            Random t = new Random();
            do
            {
                CAUHOI cauhoi = DeThi[t.Next() % DeThi.Length];
                Chuoi = XuLyCauHoi.XuatChuoi(cauhoi);
                XuLyChuoi.Xuat(Chuoi);
                long ChonLua = XuLySoNguyen.Nhap("\nBan chon cau tra loi nao?(1.." + cauhoi.TraLoi.Length + ")"
                    , 1, cauhoi.TraLoi.Length);
                long tl = XuLyCauHoi.TraLoiCauHoi(cauhoi);
                Chuoi = "Cau tra loi dung la cau so " + tl + "\n\t ==> ";
                if (tl == ChonLua)
                    Chuoi = Chuoi + "Ban da tra loi dung";
                else
                    Chuoi = Chuoi + "Ban da tra loi sai";
                XuLyChuoi.Xuat(Chuoi);
            } while (XuLySoNguyen.Nhap("\n\nBan co muon lam tiep khong? (1. Tiep; 0. Thoat)") == 1);
        }
        else
            XuLyChuoi.Xuat(Chuoi);        
    }
}