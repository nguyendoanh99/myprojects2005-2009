using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

public abstract class DaThuc
{
    public abstract void GetXMLDocument(String xmlDoc);
    public abstract Nghiem GiaiPT();
    public static DaThuc XMLtoDaThuc(String xmlDoc)
    {
        DaThuc kq;
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlDoc);
        XmlElement root = doc.DocumentElement;
        switch (root.Name)
        {
            case "TAMTHUC":
                kq = new TamThuc();
                break;
            case "NHITHUC":
                kq = new NhiThuc();
                break;
            default:
                kq = null;
                break;
        }   

        kq.GetXMLDocument(xmlDoc);
        return kq;
    }
}
