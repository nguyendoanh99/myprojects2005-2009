using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


    public class XL_THUOC_TINH
    {
        private string Ten;
        private string Gia_tri;
        public XL_THUOC_TINH(string S, string Gt)
        {
            Ten = S;
            Gia_tri = Gt;
        }
        public string Chuoi()
        {
            string Kq = "";
            Kq += " " +Ten + "='";
            Kq += Gia_tri + "' ";
            return Kq;
        }
    }
