using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
abstract class _PhanTu
{
    public static _PhanTu CreateObject(XmlNode node)
    {
        string name = node.Name;
        _PhanTu kq;
        if (name == "PHANSO")
            kq = new _PhanSo(node);
        else
            kq = new _TichSo(node);

        return kq;
    }
    public abstract void KetXuat(XmlNode nodeCha);
}
