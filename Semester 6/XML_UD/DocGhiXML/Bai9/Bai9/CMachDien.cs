using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Bai9
{
    class CMachDien
    {
        public static CMachDien KhoiTao(XmlElement node)
        {
            CMachDien result = null;
            XmlElement nodeCon = (XmlElement) node.FirstChild;
            string name = nodeCon.Name;
            switch (name)
            {
                case "NOI_TIEP":
                    result = CNoiTiep.KhoiTao(nodeCon);
                    break;
                case "SONG_SONG":
                    result = CSongSong.KhoiTao(nodeCon);
                    break;
                case "DIEN_TRO":
                    result = CDienTro.KhoiTao(nodeCon);
                    break;
            }
            return result;
        }
        public static CMachDien Doc(string FileName)
        {
            CMachDien result;
            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);
            XmlElement root = doc.DocumentElement;
            result = KhoiTao(root);

            return result;
        }
        
    }
}
