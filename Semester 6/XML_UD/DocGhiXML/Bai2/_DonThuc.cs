using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai2
{
    class _DonThuc
    {
        private int m_Mu;
        private float m_HeSo;
        private string m_BienSo;
        public string BienSo
        {
            get { return m_BienSo; }
            set { m_BienSo = value; }
        }
        public int Mu
        {
            get { return m_Mu; }
            set { m_Mu = value; }
        }
        public float HeSo
        {
            get { return m_HeSo; }
            set { m_HeSo = value; }
        }
        public _DonThuc()
        {
            HeSo = 0;
            Mu = 0;
        }
        public _DonThuc(float fHeSo, int iMu)
        {
            HeSo = fHeSo;
            Mu = iMu;
        }
        public _DonThuc(XmlNode node)
        {
            GetInfo(node);
        }
        public override string ToString()
        {
            if (m_Mu != 0)
                return HeSo.ToString("n2") + BienSo + "^" + Mu;
            else
                return HeSo.ToString("n2");
        }
        public void GetInfo(XmlNode node)
        {
            Mu = int.Parse(node.Attributes["Mu"].Value);
            HeSo = float.Parse(node.Attributes["HeSo"].Value);
        }
        public void KetXuat(XmlNode nodeCha)
        {
            XmlElement nodeCon = nodeCha.OwnerDocument.CreateElement("DONTHUC");
            nodeCon.SetAttribute("Mu", Mu.ToString());
            nodeCon.SetAttribute("HeSo", HeSo.ToString("n2"));
            nodeCha.AppendChild(nodeCon);
        }
    }
}
