using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

public class NhiThuc: DaThuc
{
    private float m_A;
    private float m_B;

    #region Properties
    public float A
    {
        get { return m_A; }
        set { m_A = value; }
    }
    public float B
    {
        get { return m_B; }
        set { m_B = value; }
    }
    #endregion
    public NhiThuc()
    {

    }
    public NhiThuc(float A, float B)
    {
        m_A = A;
        m_B = B;
    }
    public override Nghiem GiaiPT()
    {
        NghiemBac1 kq = new NghiemBac1();

        if (A == 0)
        {
            if (B == 0)
                kq.VoSoNghiem = true;
        }
        else
        {
            kq.Add(-B/A);
        }

        return kq;
    }
    public override void GetXMLDocument(String xmlDoc)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlDoc);
        XmlElement root = doc.DocumentElement;
        A = float.Parse(root.Attributes["A"].Value);
        B = float.Parse(root.Attributes["B"].Value);
    }
}
