using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace Bai9
{
    class CSongSong: CMachDien
    {
        List<CMachDien> _arrMachDien = new List<CMachDien>();
        public static new CSongSong KhoiTao(XmlElement node)
        {
            CSongSong result = new CSongSong();
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
    }
}
