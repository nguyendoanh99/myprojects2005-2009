using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
public class NghiemBac1: Nghiem
{
    private bool m_VoSoNghiem = false;

    #region Properties
    public bool VoSoNghiem
    {
        get
        {
            return m_VoSoNghiem;
        }
        set
        {
            m_VoSoNghiem = value;
        }
    }
    #endregion
    public override String ToString()
    {
        String kq = "";
        
        if (VoSoNghiem == true)
        {
            kq = "Phương trình vô số nghiệm";
            return kq;
        }

        switch (this.Count)
        {
            case 0:
                kq = "Phương trình vô nghiệm";
                break;
            case 1:
                kq = "Phương trình có nghiệm :\n";
                kq += "x = " + this[0].ToString();
                break;
        }

        return kq;
    }
    public override String ToXMLDocument()
    {
        StringBuilder kq = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        kq.Append("<NGHIEMBAC1 VoSoNghiem=\"" + VoSoNghiem.ToString() + "\">");
        foreach (float f in this)
        {
            String str = "<SOTHUC GiaTri=\"" + f.ToString() + "\"/>";
            kq.Append(str);
        }
        kq.Append("</NGHIEMBAC1>");
        return kq.ToString();
    }
    public override void GetXMLDocument(String xmlDoc) // Chuyen noi dung XML thanh Nghiem
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlDoc);
        XmlElement root = doc.DocumentElement;
        this.Clear();
        VoSoNghiem = Boolean.Parse(root.Attributes["VoSoNghiem"].Value);
        foreach (XmlElement ele in root.ChildNodes)
        {
            this.Add(float.Parse(ele.Attributes["GiaTri"].Value));
        }
    }
    
}