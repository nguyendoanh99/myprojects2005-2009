using System;
using System.Collections.Generic;
using System.Text;



    class Xuat_loi_chao
    {
        public static void Main()
        {
            String Ho_ten;
            String Loi_chao;
            Ho_ten = XL_CHUOI.Nhap("Ho va ten:");
            Loi_chao = "Xin chao" + Ho_ten + "\n";
            Loi_chao = Loi_chao + "Cam on vi da su dung chuong trinh nay";
            XL_CHUOI.Xuat(Loi_chao);
        }
    }

