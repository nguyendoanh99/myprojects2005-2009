using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai1
{
    class _PhanSo
    {
        private int m_Tu;
        private int m_Mau;
        #region Properties
        public int Tu 
        {
            get { return m_Tu; }
            set { m_Tu = value; }
        }
        public int Mau
        {
            get { return m_Mau; }
            set 
            {
                if (value == 0)
                    throw new Exception("Mau ko the bang 0");

                m_Mau = value; 
            }
        }
        #endregion
        public _PhanSo(int tu, int mau)
        {
            Tu = tu;
            Mau = mau;
        }
        public _PhanSo()
        {
            Tu = 1;
            Mau = 0;
        }
        public _PhanSo(XmlNode node)
        {
            GetInfo(node);
        }
        public override string ToString()
        {
            return Tu.ToString() + "/" + Mau.ToString();
        }
        public void GetInfo(XmlNode node)
        {
            Tu = int.Parse(node.Attributes["Tu"].Value);
            Mau = int.Parse(node.Attributes["Mau"].Value);
        }
        public void KetXuat(XmlNode nodeCha)
        {
            XmlElement nodeCon = nodeCha.OwnerDocument.CreateElement("PHANSO");
            nodeCon.SetAttribute("Tu", Tu.ToString());
            nodeCon.SetAttribute("Mau", Mau.ToString());
            nodeCha.AppendChild(nodeCon);
        }        
    }
}
