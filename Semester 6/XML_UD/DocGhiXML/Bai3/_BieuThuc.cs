using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
class _BieuThuc
{
    private String m_Ten;
    private List<_PhanTu> m_arrPhanTu = new List<_PhanTu>();
    public String Ten
    {
        get { return m_Ten; }
        set { m_Ten = value; }
    }
    public _PhanTu this[int index]
    {
        get { return m_arrPhanTu[index]; }
        set { m_arrPhanTu[index] = value; }
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
        for (int i = 0; i < m_arrPhanTu.Count; ++i )
        {
            if (i < m_arrPhanTu.Count - 1)
                kq += m_arrPhanTu[i] + " + ";
            else
                kq += m_arrPhanTu[i];
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
            _PhanTu pt = _PhanTu.CreateObject(node);
            m_arrPhanTu.Add(pt);
            node = node.NextSibling;
        }
    }
    
    public void WriteXML(string strFile)
    {
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement("BIEUTHUC");
        root.SetAttribute("Ten", Ten);
        foreach(_PhanTu pt in m_arrPhanTu)
        {
            pt.KetXuat(root);
        }
        doc.AppendChild(root);
        doc.Save(strFile);
    }
      
}
