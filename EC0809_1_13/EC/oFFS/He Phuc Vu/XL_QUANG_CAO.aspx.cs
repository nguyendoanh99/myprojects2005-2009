using System;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class He_Phuc_Vu_XL_QUANG_CAO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Xac_nhan"] == "Lay_danh_sach")
            Lay_danh_sach();
        else if (Request["Xac_nhan"] == "Lay_danh_sach_qc_cua_website")
            Lay_danh_sach_qc_cua_website();
        else if (Request["Xac_nhan"] == "Lay_danh_sach_website")
            Lay_danh_sach_website();
        else if (Request["Xac_nhan"] == "Cong_ty_cap_nhat")
            Cong_ty_cap_nhat();
        else if (Request["Xac_nhan"] == "Hien_thi_cap_nhat")
            Hien_thi_cap_nhat();
        else if (Request["Xac_nhan"] == "Kiem_Tra_Du_Lieu_Nhap")
            Kiem_Tra_Du_Lieu_Nhap();
        else if (Request["Xac_nhan"] == "Cap_Nhat_Thong_Tin")
            Cap_nhat_thong_tin();
        else if (Request["Xac_nhan"] == "Them_Quang_Cao")
            Them_quang_cao();
        else if (Request["Xac_nhan"] == "Xoa_Quang_Cao")
            Xoa_Quang_Cao();
        else if (Request["Xac_nhan"] == "Cap_Nhat_Tinh_Trang")
            Cap_Nhat_Tinh_Trang();
        else if (Request["Xac_nhan"] == "Kiem_tra_ten_quang_cao")
            Kiem_tra_ten_quang_cao();
    }

    private void Lay_danh_sach()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Quang_cao = null;        

        Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
        Quang_cao = Tai_lieu.DocumentElement;

        XL_THE Kq = new XL_THE("QUANG_CAO");

        foreach(XmlElement Thong_tin in Quang_cao.ChildNodes)
        {
            XL_THE Kq1 = new XL_THE("ThongTin");

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ten_cong_ty", Thong_tin.GetAttribute("Ten"));
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Dia_chi", Thong_tin.GetAttribute("DiaChi"));
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Website", Thong_tin.GetAttribute("Website"));
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Logo", Thong_tin.GetAttribute("Logo"));
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            //lay danh sach cac website co dat quang cao nay
            string website_the_hien = "";

            XmlDocument Tai_lieu1 = new XmlDocument();
            XmlElement website = null;

            Tai_lieu1.Load(Server.MapPath("WEBSITE.xml"));
            website = Tai_lieu1.DocumentElement;
            String strExp = "//WEBSITE//ThongTin//QuangCao[@Ten='" + Thong_tin.GetAttribute("Ten") + "']";
            XmlNodeList nodeAdv = website.SelectNodes(strExp);
            int i = 0;
            foreach (XmlNode node in nodeAdv)
            {
                XmlNode parent = node.ParentNode;
                website_the_hien += parent.Attributes["Ten"].Value;
                if (i < nodeAdv.Count - 1)
                    website_the_hien += '-';
                i++;
            }

            Thuoc_tinh = new XL_THUOC_TINH("WebsiteTheHien", website_the_hien);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("Tinh_trang", Thong_tin.GetAttribute("TinhTrang"));
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
    private void Lay_danh_sach_qc_cua_website()
    {
        XmlDocument Tai_lieu1 = new XmlDocument();
        XmlElement website = null;
        string arr_quangcao = "";

        Tai_lieu1.Load(Server.MapPath("WEBSITE.xml"));
        website = Tai_lieu1.DocumentElement;
        String strExp = "//WEBSITE//ThongTin[@Ten='" + Request["Ten_website"] + "']";
        XmlNode nodeAdv = website.SelectSingleNode(strExp);
        XL_THE Kq = new XL_THE("QUANG_CAO");
        if (nodeAdv != null)
        {
            foreach (XmlNode node in nodeAdv.ChildNodes)
            {
                string ten_quang_cao = node.Attributes["Ten"].Value.ToString();

                XmlDocument Tai_lieu = new XmlDocument();
                XmlElement Quang_cao = null;

                Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
                Quang_cao = Tai_lieu.DocumentElement;
                String strExp1 = "//QUANG_CAO//ThongTin[@Ten='" + ten_quang_cao + "']";
                XmlNode _node = Quang_cao.SelectSingleNode(strExp1);
                if (_node.Attributes["TinhTrang"].Value.ToString() == "1")
                {
                    XL_THE Kq1 = new XL_THE("ThongTin");
                    //arr_quangcao += ten_quang_cao + "-";
                    XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Logo", _node.Attributes["Logo"].Value.ToString());
                    Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
                    Thuoc_tinh = new XL_THUOC_TINH("Website", _node.Attributes["Website"].Value.ToString());
                    Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                    Kq.Danh_sach_the.Add(Kq1);
                }
            }
        }
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }


    private void Lay_danh_sach_website()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Website = null;

        Tai_lieu.Load(Server.MapPath("WEBSITE.xml"));
        Website = Tai_lieu.DocumentElement;

        XL_THE Kq = new XL_THE("WEBSITE");

        foreach (XmlElement Thong_tin in Website.ChildNodes)
        {
            if (Thong_tin.GetAttribute("TinhTrang").ToString() == "0")
                continue;

            XL_THE Kq1 = new XL_THE("ThongTin");

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ten_website", Thong_tin.GetAttribute("Ten"));
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);            

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Them_quang_cao()
    {
        //them bao quang cao
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Quang_cao = null;

        Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
        Quang_cao = Tai_lieu.DocumentElement;

        XmlElement Thong_tin = Tai_lieu.CreateElement("ThongTin");
        Thong_tin.SetAttribute("Ten", Request["Ten_quang_cao"]);
        Thong_tin.SetAttribute("DiaChi", Request["Dia_chi"]);
        if(Request["Logo"] != null)
            Thong_tin.SetAttribute("Logo", Request["Logo"]);
        Thong_tin.SetAttribute("Website", Request["Website"]);
        Thong_tin.SetAttribute("TinhTrang", Request["Tinh_trang"]);
        //Thong_tin.SetAttribute("TrangXuatHien", Request["WebsiteTheHien"]);        

        Quang_cao.AppendChild(Thong_tin);
        Tai_lieu.Save(Server.MapPath("QUANG_CAO.xml"));

        //them vao tung website
        string website_the_hien = Request["WebsiteTheHien"].ToString();
        string[] arr = website_the_hien.Split('-');
        XmlDocument Tai_lieu1 = new XmlDocument();
        XmlElement website = null;
        Tai_lieu1.Load(Server.MapPath("WEBSITE.xml"));
        website = Tai_lieu1.DocumentElement;

        for (int i = 0; i < arr.Length; i++)
        {
            foreach (XmlElement Thong_tin1 in website.ChildNodes)
            {
                if (Thong_tin1.GetAttribute("Ten").CompareTo(arr[i]) == 0)
                {
                    XmlElement _quangcao = Tai_lieu1.CreateElement("QuangCao");
                    _quangcao.SetAttribute("Ten", Request["Ten_quang_cao"]);
                    Thong_tin1.AppendChild(_quangcao);
                }
                if (Thong_tin1.ChildNodes.Count >= 4)
                    Thong_tin1.SetAttribute("TinhTrang", "0");
            }            
        }

        Tai_lieu1.Save(Server.MapPath("WEBSITE.xml"));

        Session["Ten_quang_cao"] = Request["Ten_quang_cao"];

        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Xoa_Quang_Cao()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Quang_cao = null;

        Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
        Quang_cao = Tai_lieu.DocumentElement;        
       
        foreach (XmlElement Thong_tin in Quang_cao.ChildNodes)
        {
            if (Thong_tin.GetAttribute("Ten").CompareTo(Request["Ten_cong_ty"]) == 0)
            {
                Quang_cao.RemoveChild(Thong_tin);

                //xoa trong website
                XmlDocument Tai_lieu1 = new XmlDocument();
                XmlElement website = null;

                Tai_lieu1.Load(Server.MapPath("WEBSITE.xml"));
                website = Tai_lieu1.DocumentElement;
                String strExp = "//WEBSITE//ThongTin//QuangCao[@Ten='" + Thong_tin.GetAttribute("Ten") + "']";
                XmlNodeList nodeAdv = website.SelectNodes(strExp);
                foreach (XmlNode node in nodeAdv)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }

                Tai_lieu1.Save(Server.MapPath("WEBSITE.xml"));

                break;
            }
        }
            
        Tai_lieu.Save(Server.MapPath("QUANG_CAO.xml"));        
        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Cong_ty_cap_nhat()
    {
        Session["Ten_cong_ty"] = Request["Ten_cong_ty"];
        XL_THE The = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, The.Chuoi());
    }

    private void Hien_thi_cap_nhat()
    {
        if (Session["Ten_cong_ty"].ToString() != "")
        {
            XmlDocument Tai_lieu = new XmlDocument();
            XmlElement Quang_cao = null;

            Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
            Quang_cao = Tai_lieu.DocumentElement;

            XL_THE Kq = new XL_THE("THONG_TIN");

            foreach (XmlElement Thong_tin in Quang_cao.ChildNodes)
            {
                if (Thong_tin.GetAttribute("Ten").CompareTo(Session["Ten_cong_ty"]) == 0)
                {
                    XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ten_cong_ty", Thong_tin.GetAttribute("Ten"));
                    Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
                    Thuoc_tinh = new XL_THUOC_TINH("Dia_chi", Thong_tin.GetAttribute("DiaChi"));
                    Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
                    Thuoc_tinh = new XL_THUOC_TINH("Website", Thong_tin.GetAttribute("Website"));
                    Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
                    Thuoc_tinh = new XL_THUOC_TINH("Logo", Thong_tin.GetAttribute("Logo"));
                    Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                    string website_the_hien = "";

                    XmlDocument Tai_lieu1 = new XmlDocument();
                    XmlElement website = null;

                    Tai_lieu1.Load(Server.MapPath("WEBSITE.xml"));
                    website = Tai_lieu1.DocumentElement;
                    String strExp = "//WEBSITE//ThongTin/QuangCao[@Ten='" + Thong_tin.GetAttribute("Ten") + "']";
                    XmlNodeList nodeAdv = website.SelectNodes(strExp);
                    int i = 0;
                    foreach (XmlNode node in nodeAdv)
                    {
                        XmlNode parent = node.ParentNode;                        
                        website_the_hien += parent.Attributes["Ten"].Value;
                        if(i < nodeAdv.Count - 1)
                            website_the_hien += '-';
                        i++;
                    }

                    Thuoc_tinh = new XL_THUOC_TINH("WebsiteTheHien", website_the_hien);
                    Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                    Thuoc_tinh = new XL_THUOC_TINH("Tinh_trang", Thong_tin.GetAttribute("TinhTrang"));
                    Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                    break;
                }                                
            }
            
            XL_CHUOI.XuatXML(Response, Kq.Chuoi());
        }
    }

    private void Cap_Nhat_Tinh_Trang()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Quang_cao = null;

        Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
        Quang_cao = Tai_lieu.DocumentElement;        
       
        foreach (XmlElement Thong_tin in Quang_cao.ChildNodes)
        {
            if (Thong_tin.GetAttribute("Ten").CompareTo(Request["Ten_cong_ty"]) == 0)
            {
                if(Request["Loai"] == "1")
                    Thong_tin.SetAttribute("TinhTrang", "1");
                else if (Request["Loai"] == "0")
                    Thong_tin.SetAttribute("TinhTrang", "0");
                break;
            }
        }
            
        Tai_lieu.Save(Server.MapPath("QUANG_CAO.xml"));
        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Kiem_tra_ten_quang_cao()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Quang_cao = null;

        Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
        Quang_cao = Tai_lieu.DocumentElement;

        String strExp1 = "//QUANG_CAO//ThongTin[@Ten='" + Request["Ten_quang_cao"] + "']";
        XmlNode _node = Quang_cao.SelectSingleNode(strExp1);

        if (_node != null)
            return;

        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Kiem_Tra_Du_Lieu_Nhap()
    {
        String data = Request["Du_lieu_nhap"].ToString();

        String protocol = data.Substring(0, 7);
        protocol.ToLower();
        if (protocol.CompareTo("http://") != 0)
            return;
        if (data.IndexOf(".") < 0)
            return;

        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
    private void Cap_nhat_thong_tin()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Quang_cao = null;

        Tai_lieu.Load(Server.MapPath("QUANG_CAO.xml"));
        Quang_cao = Tai_lieu.DocumentElement;

        foreach (XmlElement Thong_tin in Quang_cao.ChildNodes)
        {
            if (Thong_tin.GetAttribute("Ten").CompareTo(Session["Ten_cong_ty"]) == 0)
            {
                Session["Ten_cong_ty"] = Request["Ten_cong_ty"];

                Thong_tin.SetAttribute("Ten", Request["Ten_cong_ty"]);
                Thong_tin.SetAttribute("DiaChi", Request["Dia_chi"]);
                Thong_tin.SetAttribute("Website", Request["Website"]);

                //Thong_tin.SetAttribute("TrangXuatHien", Request["WebsiteTheHien"]);
                string website_the_hien = Request["WebsiteTheHien"].ToString();
                string[] arr = website_the_hien.Split('-');
                XmlDocument Tai_lieu1 = new XmlDocument();
                XmlElement website = null;
                Tai_lieu1.Load(Server.MapPath("WEBSITE.xml"));
                website = Tai_lieu1.DocumentElement;

                String strExp = "//WEBSITE//ThongTin//QuangCao[@Ten='" + Thong_tin.GetAttribute("Ten") + "']";
                XmlNodeList nodeAdv = website.SelectNodes(strExp);
                foreach (XmlNode node in nodeAdv)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    foreach (XmlElement Thong_tin1 in website.ChildNodes)
                    {
                        if (Thong_tin1.GetAttribute("Ten").CompareTo(arr[i]) == 0)
                        {
                            XmlElement _quangcao = Tai_lieu1.CreateElement("QuangCao");
                            _quangcao.SetAttribute("Ten", Request["Ten_cong_ty"]);
                            Thong_tin1.AppendChild(_quangcao);
                        }
                    }
                }
                Tai_lieu1.Save(Server.MapPath("WEBSITE.xml"));
                ////////////////////////////////////////////////////////////////////////////

                if (Request["Logo"] != null)
                    Thong_tin.SetAttribute("Logo", Request["Logo"]);

                Thong_tin.SetAttribute("TinhTrang", Request["Tinh_trang"]);

                Tai_lieu.Save(Server.MapPath("QUANG_CAO.xml"));
                XL_THE Kq = new XL_THE("Goc");
                XL_CHUOI.XuatXML(Response, Kq.Chuoi());

                break;
            }
        }
    }

}
