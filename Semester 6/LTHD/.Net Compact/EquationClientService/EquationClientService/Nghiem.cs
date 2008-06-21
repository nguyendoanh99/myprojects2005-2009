using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
public abstract class Nghiem : List<float>
{
    public virtual String ToXMLDocument() { return null; }
    public virtual void GetXMLDocument(String xmlDoc) {} // Chuyen noi dung XML thanh Nghiem
    public static Nghiem XMLtoNghiem(String xmlDoc)
    {
        Nghiem kq;
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlDoc);
        XmlElement root = doc.DocumentElement;
        switch (root.Name)
        {
            case "NGHIEMBAC2":
                kq = new NghiemBac2();
        	    break;
            case "NGHIEMBAC1":
                kq = new NghiemBac1();            
                break;
            default:
                kq = null;
                break;
        }
        
        kq.GetXMLDocument(xmlDoc);
        return kq;
    }
}