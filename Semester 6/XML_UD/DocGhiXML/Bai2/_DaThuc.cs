using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai2
{
    class _DaThuc
    {
        private string m_Ten;
        private string m_BienSo;
        private List<_DonThuc> m_arrDonThuc = new List<_DonThuc>();
        #region Properties
        public string Ten
        {
            get {return m_Ten;}
            set { m_Ten = value;}
        }
        public string BienSo
        {
            get {return m_BienSo;}
            set {m_BienSo = value;}
        }

        public _DonThuc this[int index]
        {
            get { return m_arrDonThuc[index];}
            set { m_arrDonThuc[index] = value;}
        }
        #endregion
        public _DaThuc()
        {
            Ten = "";
            BienSo = "";
        }
        public _DaThuc(string strTen, string strBienSo)
        {
            Ten = strTen;
            BienSo = strBienSo;
        }
        public override string ToString()
        {
            string kq = "";
            kq += Ten + "(" + BienSo + ") = ";
            for (int i = 0; i < m_arrDonThuc.Count; ++i)
            {
                if (i < m_arrDonThuc.Count - 1)
                    kq += m_arrDonThuc[i] + " + ";
                else
                    kq += m_arrDonThuc[i];
            }
            return kq;
        }
        public void ReadXML(string strFile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(strFile);
            XmlElement root = doc.DocumentElement;
            Ten = root.GetAttribute("Ten");
            BienSo = root.GetAttribute("BienSo");
            
            XmlNode node = root.FirstChild;            
            while (node != null)
            {
                _DonThuc dt = new _DonThuc(node);
                dt.BienSo = BienSo;
                m_arrDonThuc.Add(dt);
                node = node.NextSibling;
            }
        }
        public void WriteXML(string strFile)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("DATHUC");
            root.SetAttribute("Ten", Ten);
            root.SetAttribute("BienSo", BienSo);
            foreach (_DonThuc dt in m_arrDonThuc)
            {
                dt.KetXuat(root);
            }
            doc.AppendChild(root);
            doc.Save(strFile);
        }
    }
}
