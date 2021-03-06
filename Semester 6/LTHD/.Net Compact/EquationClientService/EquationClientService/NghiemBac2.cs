using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;

public class NghiemBac2: Nghiem
{
    public override void GetXMLDocument(String xmlDoc) // Chuyen noi dung XML thanh Nghiem
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlDoc);
        XmlElement root = doc.DocumentElement;
        this.Clear();
        foreach (XmlElement ele in root.ChildNodes)
        {
            this.Add(float.Parse(ele.Attributes["GiaTri"].Value));
        }
    }
    public override String ToXMLDocument()
    {
        StringBuilder kq = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        kq.Append("<NGHIEMBAC2>");
        foreach (float f in this)
        {
            String str = "<SOTHUC GiaTri=\"" + f.ToString() + "\"/>";
            kq.Append(str);
        }
        kq.Append("</NGHIEMBAC2>");
        return kq.ToString();
    }
    public override String ToString()
    {
        String kq = "";
        switch (this.Count)
        {
            case 0:
                kq = "Phương trình vô nghiệm";
                break;
            case 1:
                kq = "Phương trình có nghiệm kép:\n";
                kq += "x = " + this[0].ToString();
                break;
            case 2:
                kq = "Phương trình có 2 nghiệm phân biệt:\n";
                kq += "x1 = " + this[0].ToString();
                kq += "\nx2 = " + this[1].ToString();
                break;
        }

        return kq;
    }
    
}