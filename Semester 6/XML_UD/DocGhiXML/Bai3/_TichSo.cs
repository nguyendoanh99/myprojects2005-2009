using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
class _TichSo: _PhanTu
{
    private List<_PhanSo> m_arrPhanSo = new List<_PhanSo>();
    public _PhanSo this[int index]
    {
        get { return m_arrPhanSo[index]; }
        set { m_arrPhanSo[index] = value; }
    }
    public _TichSo(XmlNode node)
    {
        GetInfo(node);
    }
    public override string ToString()
    {
        string kq = "";
        for (int i = 0; i < m_arrPhanSo.Count; ++i)
        {
            if (i < m_arrPhanSo.Count - 1)
                kq += m_arrPhanSo[i] + "*";
            else
                kq += m_arrPhanSo[i];
        }
        return kq;
    }
    public void GetInfo(XmlNode node)
    {
        XmlNode nodeCon = node.FirstChild;
        while (nodeCon != null)
        {
            _PhanSo ps = new _PhanSo(nodeCon);
            m_arrPhanSo.Add(ps);
            nodeCon = nodeCon.NextSibling;
        }
    }
    public override void KetXuat(XmlNode nodeCha)
    {
        XmlElement nodeCon = nodeCha.OwnerDocument.CreateElement("TICHSO");

        foreach (_PhanSo ps in m_arrPhanSo)
        {
            ps.KetXuat(nodeCon);
        }
        nodeCha.AppendChild(nodeCon);
    }
}
