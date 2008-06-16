using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai9
{
    class CNoiTiep: CMachDien
    {
        List<CMachDien> _arrMachDien = new List<CMachDien>();
        public static new CNoiTiep KhoiTao(XmlElement node)
        {
            CNoiTiep result = new CNoiTiep();
            foreach (XmlElement nodeCon in node.ChildNodes)
            {
                string name = nodeCon.Name;
                CMachDien temp = null;
                switch (name)
                {
                    case "NOI_TIEP":
                        temp = CNoiTiep.KhoiTao(nodeCon);
                        break;
                    case "SONG_SONG":
                        temp = CSongSong.KhoiTao(nodeCon);
                        break;
                    case "DIEN_TRO":
                        temp = CDienTro.KhoiTao(nodeCon);
                        break;
                }
                result._arrMachDien.Add(temp);
            }

            return result;
        }
        public XmlElement CreateNode(XmlDocument doc)
        {
            XmlElement result = doc.CreateElement("NOI_TIEP");
            for (int i = 0; i < _arrMachDien.Count; ++i)
            {
                CMachDien temp = _arrMachDien[i];
//                result.AppendChild(temp)
            }
                /*
                for (CMachDien temp in _arrMachDien)
                {
                }
                 */
                return result;
        }
    }
}
