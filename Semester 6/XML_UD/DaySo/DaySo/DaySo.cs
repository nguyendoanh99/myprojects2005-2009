using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace DaySo
{
    class DaySo
    {
        List<int> m_DaySo = new List<int>();
        public DaySo()
        {

        }
        public DaySo(string tenfile)
        {
            
            
        }
        public void ReadXML(string tenfile)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(tenfile);
                XmlElement root = doc.DocumentElement;
                XmlElement node = root;
                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    int temp = int.Parse(node.ChildNodes[i].Attributes["value"].Value);
                    m_DaySo.Add(temp);
                }
            }
            catch (System.Exception )
            {
                throw;
            }
        }
        public void Sort()
        {
            m_DaySo.Sort(ComparisonInt);
        }

        private int ComparisonInt(int x, int y)
        {
            if (x > y)
                return -1;
            else
                if (x < y)
                    return 1;
            return 0;
        }

        public void WriteXML(string tenfile)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("DAYSO");
                doc.AppendChild(root);

                for (int i = 0; i < m_DaySo.Count; ++i)
                {
                    XmlElement temp = doc.CreateElement("SO");
                    temp.SetAttribute("value", m_DaySo[i].ToString());
                    root.AppendChild(temp);
                }
                doc.Save(tenfile);
            }
            catch (System.Exception )
            {
            	
            }            
        }
    }
    public class Comp : IComparable
    {

        #region IComparable Members

        public int CompareTo(object obj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
