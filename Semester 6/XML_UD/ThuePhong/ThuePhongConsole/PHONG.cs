using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace ThuePhongConsole
{
    class PHONG
    {
        private string m_ten = "";
        private float m_dongia = 0;
        private int m_ngaygiam = 0;
        private int m_mucgiam = 0;
        public PHONG()
        {

        }
        public XmlElement CreateNode(XmlDocument doc)
        {
            XmlElement result = doc.CreateElement("PHONG");
            result.SetAttribute("loai", m_ten);
            result.SetAttribute("dongia", m_dongia.ToString());
            if (m_mucgiam != 0)
                result.SetAttribute("mucgiam", m_mucgiam.ToString());
            if (m_ngaygiam != 0)
                result.SetAttribute("ngaygiam", m_ngaygiam.ToString());
            return result;
        }
        public static PHONG CreateObject(XmlElement node)
        {
            PHONG result = new PHONG();
            result.m_ten = node.GetAttribute("loai");
            result.m_dongia = float.Parse(node.GetAttribute("dongia"));
            if (node.GetAttribute("ngaygiam") != "")
                result.m_ngaygiam = int.Parse(node.GetAttribute("ngaygiam"));
            if (node.GetAttribute("mucgiam") != "")
                result.m_mucgiam = int.Parse(node.GetAttribute("mucgiam"));
            return result;
        }
    }
}
