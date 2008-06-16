using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai1
{
    class _BieuThuc
    {
        private String m_Ten;
        private List<_PhanSo> m_arrPhanSo = new List<_PhanSo>();
        public String Ten
        {
            get { return m_Ten; }
            set { m_Ten = value; }
        }
        public _PhanSo this[int index]
        {
            get { return m_arrPhanSo[index]; }
            set { m_arrPhanSo[index] = value; }
        }
        public _BieuThuc()
        {
        }
        public _BieuThuc(String strTen)
        {
            Ten = strTen;
        }
        public override string ToString()
        {
            string kq = Ten + " = ";
            for (int i = 0; i < m_arrPhanSo.Count; ++i )
            {
                if (i < m_arrPhanSo.Count - 1)
                    kq += m_arrPhanSo[i] + " + ";
                else
                    kq += m_arrPhanSo[i];
            }
            return kq;
        }
        public void ReadXML(string strfile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(strfile);
            XmlElement root = doc.DocumentElement;
            Ten = root.Attributes["Ten"].Value;
            XmlNode node = root.FirstChild;
            while (node != null)
            {
                _PhanSo ps = new _PhanSo(node);
                m_arrPhanSo.Add(ps);
                node = node.NextSibling;
            }
        }
        public void WriteXML(string strFile)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("BIEUTHUC");
            root.SetAttribute("Ten", Ten);
            foreach(_PhanSo ps in m_arrPhanSo)
            {
                ps.KetXuat(root);
            }
            doc.AppendChild(root);
            doc.Save(strFile);
        }
    }
}
