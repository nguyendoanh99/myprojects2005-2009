using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
class TamThuc: DaThuc
{
    private float m_A;
    private float m_B;
    private float m_C;
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
    public float C
    {
        get { return m_C; }
        set { m_C = value; }
    }
    #endregion
    public TamThuc()
    {
    }
    public TamThuc(float A, float B, float C)
    {
        m_A = A;
        m_B = B;
        m_C = C;
    }
    public override Nghiem GiaiPT()
    {
        Nghiem kq;
        if (A == 0)
        {
            NhiThuc nt = new NhiThuc(B, C);
            kq = nt.GiaiPT();
        }
        else
        {
            kq = new NghiemBac2();

            float delta = m_B * m_B - 4 * m_A * m_C;
            if (delta > 0)
            {
                float temp = (float)Math.Sqrt((double)delta);
                kq.Add((-m_B + temp) / (2 * m_A));
                kq.Add((-m_B - temp) / (2 * m_A));
            }
            else
                if (delta == 0)
                {
                    kq.Add(-m_B / (2 * m_A));
                }
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
        C = float.Parse(root.Attributes["C"].Value);
    }
}