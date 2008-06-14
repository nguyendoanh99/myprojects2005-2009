using System;
using System.Collections.Generic;
using System.Text;



    class XL_SO_THUC
    {
        public static Double Nhap(String Ghi_chu)
        {
            Double Kq;
            Kq = Nhap(Ghi_chu, Double.MinValue, Double.MaxValue);
            return Kq;
        }
        public static Double Nhap(String Ghi_chu, Double Can_duoi)
        {
            Double Kq;
            Kq = Nhap(Ghi_chu, Can_duoi, Double.MaxValue);
            return Kq;
        }
        public static Double Nhap(String Ghi_chu, Double Can_duoi, Double Can_tren)
        {
            Double Kq = 0;
            do
            {
                Kq = Nhap_cuc_bo(Ghi_chu);
            } while (Kq <= Can_duoi || Kq >= Can_tren);
            return Kq;
        }
        public static Boolean Kiem_tra(String Chuoi)
        {
            Boolean Kq = true;
            try
            {
                Double So = Double.Parse(Chuoi);
            }
            catch (Exception loi)
            {
                Kq = false;
            }
            return Kq;
        }
        private static Double Nhap_cuc_bo(String Ghi_chu)
        {
            Double Kq;
            String Chuoi;
            do
            {
                Chuoi = XL_CHUOI.Nhap(Ghi_chu);
            } while (!Kiem_tra(Chuoi));
            Kq = Double.Parse(Chuoi);
            return Kq;
        }
    }

