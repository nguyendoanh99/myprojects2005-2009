using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai9
{
    class CDienTro: CMachDien
    {
        float _R = 0;
        public static new CDienTro KhoiTao(XmlElement node)
        {
            CDienTro result = new CDienTro();
            result._R = float.Parse(node.GetAttribute("R"));
            return result;
        }
        public XmlElement CreateNode(XmlDocument doc)
        {
            XmlElement result;
            result = doc.CreateElement("DIEN_TRO");
            result.SetAttribute("R", _R.ToString());
            return result;
        }
    }
}
