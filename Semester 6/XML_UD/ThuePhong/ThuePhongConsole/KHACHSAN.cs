using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace ThuePhongConsole
{
    class KHACHSAN
    {
        private string m_ten;
        private string m_dienthoai;
        private string m_diachi;
        private List<PHONG> m_lstPhong = new List<PHONG>();
        public KHACHSAN()
        {

        }
        public void ReadXML(string FileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);
            XmlElement root = doc.DocumentElement;

            m_ten = root.GetAttribute("ten");
            m_diachi = root.GetAttribute("diachi");
            m_dienthoai = root.GetAttribute("dienthoai");

            for (int i = 0; i < root.ChildNodes.Count; ++i)
            {
                m_lstPhong.Add(PHONG.CreateObject((XmlElement) root.ChildNodes[i]));
            }
        }
        public void WriteXML(string FileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("KHACHSAN");
                root.SetAttribute("ten", m_ten);
                root.SetAttribute("dienthoai", m_dienthoai);
                root.SetAttribute("diachi", m_diachi);

                for (int i = 0; i < m_lstPhong.Count; ++i)
                {
                    XmlElement temp = m_lstPhong[i].CreateNode(doc);
                    root.AppendChild(temp);
                }

                doc.AppendChild(root);
                doc.Save(FileName);
            }
            catch (System.Exception )
            {
                throw;
            }
        }
    }
}
