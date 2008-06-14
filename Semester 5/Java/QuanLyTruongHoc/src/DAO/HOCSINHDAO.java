package DAO;

import java.text.DateFormat;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import org.w3c.dom.DOMException;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import DTO.HOCSINHDTO;
import DTO.KETQUAHOCTAPDTO;
import LIB.DOMUtil;

public class HOCSINHDAO extends AbstractDAO {
	public HOCSINHDAO() {
		// TODO Auto-generated constructor stub
	}
	public HOCSINHDAO(Node node) {
		super(node);
		// TODO Auto-generated constructor stub
	}
	public List<HOCSINHDTO> getDanhSachHocSinh()
	{
		HOCSINHDAO hocsinhdao = new HOCSINHDAO();
		Node node = getNode();
		List<HOCSINHDTO> kq = new ArrayList<HOCSINHDTO>();
		node = node.getFirstChild();
		
		while (node != null)
		{
			if (node.getNodeType() == Node.ELEMENT_NODE)
			{
				hocsinhdao.setNode(node);				
				kq.add(hocsinhdao.getHocSinh());
			}
			node = node.getNextSibling();
		}
		return kq;
	}
	public HOCSINHDTO getHocSinh()
	{
		Node node = getNode();
		HOCSINHDTO kq = new HOCSINHDTO();		
		
		Node item = node.getFirstChild();
		
		while (item != null)
		{
			if (item.getNodeType() == Node.ELEMENT_NODE)
			{
				String name = item.getNodeName();
				Node FirstNode = item.getFirstChild();
				String value = "";
				if (FirstNode != null)
					value = FirstNode.getNodeValue();
				
				if (name.compareToIgnoreCase("MaHocSinh") == 0)
					kq.setMaHocSinh(value);
				else
					if (name.compareToIgnoreCase("HoTen") == 0)
						kq.setHoTen(value);
					else
						if (name.compareToIgnoreCase("NamSinh") == 0)
						{
							DateFormat df = DateFormat.getDateInstance(DateFormat.SHORT, new Locale("vi", "VN"));
							try
							{
								Date d = df.parse(value);
								kq.setNamSinh(d);
							}
							catch (ParseException pe)
							{
								System.out.println(pe.toString());
							}
						}
						else
							if (name.compareToIgnoreCase("DiaChi") == 0)
								kq.setDiaChi(value);
							else
								if (name.compareToIgnoreCase("DienThoai") == 0)
									kq.setDienThoai(value);
								else
									if (name.compareToIgnoreCase("KQHT") == 0)
									{
										KETQUAHOCTAPDAO kqhtdao = new KETQUAHOCTAPDAO(item);
										KETQUAHOCTAPDTO kqht = kqhtdao.getKQHT();
										kq.setKQHT(kqht);
									}
			}
			item = item.getNextSibling();
		}	
				
		return kq;
	}
	public Node createNode(HOCSINHDTO hocsinhdto)
	{
		Node _node = doc.createElement("HOCSINH");
		// MaHocSinh
		Node MaHocSinhElement = doc.createElement("MaHocSinh");
		Node value = doc.createTextNode(hocsinhdto.getMaHocSinh());
		_node.appendChild(MaHocSinhElement);
		MaHocSinhElement.appendChild(value);
		// HoTen
		Node HoTenElement = doc.createElement("HoTen");
		value = doc.createTextNode(hocsinhdto.getHoTen());
		_node.appendChild(HoTenElement);
		HoTenElement.appendChild(value);
		// NamSinh
		DateFormat df = DateFormat.getDateInstance(DateFormat.SHORT, new Locale("vi", "VN"));
		Node NamSinhElement = doc.createElement("NamSinh");
		value = doc.createTextNode(df.format(hocsinhdto.getNamSinh()));
		_node.appendChild(NamSinhElement);
		NamSinhElement.appendChild(value);
		// DiaChi
		Node DiaChiElement = doc.createElement("DiaChi");
		value = doc.createTextNode(hocsinhdto.getDiaChi());
		_node.appendChild(DiaChiElement);
		DiaChiElement.appendChild(value);
		// DienThoai
		Node DienThoaiElement = doc.createElement("DienThoai");
		value = doc.createTextNode(hocsinhdto.getDienThoai());
		_node.appendChild(DienThoaiElement);
		DienThoaiElement.appendChild(value);
		// KQHT
		KETQUAHOCTAPDAO kqhtdao = new KETQUAHOCTAPDAO();		
		Node KQHTElement = kqhtdao.createNode(hocsinhdto.getKQHT());		
		_node.appendChild(KQHTElement);
		
		setNode(_node);
		return _node;
	}
	public boolean CapNhatThongTin(HOCSINHDTO hocsinh)
	{
		Node HocSinhNode = TimHocSinh(hocsinh);
		if (HocSinhNode == null)
			return false;		
				
		Node parent = HocSinhNode.getParentNode();
		try
		{			
			Node NewNode = createNode(hocsinh);
			parent.replaceChild(NewNode, HocSinhNode);		
		}
		catch (DOMException DOMe)
		{			
			return false;
		}		
		DOMUtil.writeXmlToFile(TenFile, doc);
		return true;
	}
	public Node TimHocSinh(HOCSINHDTO hocsinhdto)
	{
		Node _node = null;
		NodeList nodelist = doc.getElementsByTagName("HOCSINH");
		
		int i = 0;
		while (i < nodelist.getLength())
		{
			Element HocSinhElement = (Element) nodelist.item(i);
			Element MaHocSinhElement = (Element) HocSinhElement.getElementsByTagName("MaHocSinh").item(0);
			Node FirstNode = MaHocSinhElement.getFirstChild();
			String MaHocSinh = "";
			if (FirstNode != null)
				MaHocSinh = FirstNode.getNodeValue();
			
			if (MaHocSinh.compareToIgnoreCase(hocsinhdto.getMaHocSinh()) == 0)
			{
				_node = HocSinhElement;
				break;
			}
			++i;
		}
		
		setNode(_node);
		return _node;
	}
}
