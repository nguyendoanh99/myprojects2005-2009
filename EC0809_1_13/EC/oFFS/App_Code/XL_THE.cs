using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

    public class XL_THE
    {
        private string Ten;
        private ArrayList Danh_sach_thuoc_tinh_cuc_bo;
        private ArrayList Danh_sach_the_cuc_bo;

        public ArrayList Danh_sach_thuoc_tinh
        {
            get { return Danh_sach_thuoc_tinh_cuc_bo; }
            set { Danh_sach_thuoc_tinh_cuc_bo = value; }
        }
        public ArrayList Danh_sach_the
        {
            get { return Danh_sach_the_cuc_bo; }
            set { Danh_sach_the_cuc_bo = value; }
        }
        public XL_THE(string S)
        {
            Ten = S;
            Danh_sach_thuoc_tinh = new ArrayList();
            Danh_sach_the = new ArrayList();
        }
        public string Chuoi()
        {
            string Kq = "";
            Kq += "<" + Ten;
            foreach (XL_THUOC_TINH Thuoc_tinh in Danh_sach_thuoc_tinh)
            {
                Kq += Thuoc_tinh.Chuoi();
            }
            if (Danh_sach_the.Count > 0)
            {
                Kq += ">";
                foreach (XL_THE The in Danh_sach_the)
                    Kq += The.Chuoi();
                Kq += "</" + Ten + ">";
            }
            else
                Kq += "/>";
            return Kq;
        }
    }
