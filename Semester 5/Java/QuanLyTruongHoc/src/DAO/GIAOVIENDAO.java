package DAO;

import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import DTO.GIAOVIENDTO;

public class GIAOVIENDAO extends AbstractDAO {

	public GIAOVIENDAO() {
		// TODO Auto-generated constructor stub
	}

	public GIAOVIENDAO(Node node) {
		super(node);
		// TODO Auto-generated constructor stub
	}
	public GIAOVIENDTO getGiaoVien()
	{
		Node node = getNode();
		GIAOVIENDTO kq = new GIAOVIENDTO();		
		
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
				
				if (name.compareToIgnoreCase("MaGiaoVien") == 0)
					kq.setMaGiaoVien(value);
				else
					if (name.compareToIgnoreCase("HoTen") == 0)
						kq.setHoTen(value);
					else
						if (name.compareToIgnoreCase("TenTat") == 0)
							kq.setTenTat(value);
						else
							if (name.compareToIgnoreCase("DiaChi") == 0)
								kq.setDiaChi(value);
							else
								if (name.compareToIgnoreCase("DienThoai") == 0)
									kq.setDienThoai(value);
			}
			item = item.getNextSibling();
		}	
				
		return kq;
	}
	public Node createNode(GIAOVIENDTO giaoviendto)
	{
		Node _node = doc.createElement("GIAOVIEN");
		// MaGiaoVien
		Node MaGiaoVienElement = doc.createElement("MaGiaoVien");
		Node value = doc.createTextNode(String.valueOf(giaoviendto.getMaGiaoVien()));
		_node.appendChild(MaGiaoVienElement);
		MaGiaoVienElement.appendChild(value);
		// HoTen
		Node HoTenElement = doc.createElement("HoTen");
		value = doc.createTextNode(giaoviendto.getHoTen());
		_node.appendChild(HoTenElement);
		HoTenElement.appendChild(value);
		// TenTat
		Node TenTatElement = doc.createElement("TenTat");
		value = doc.createTextNode(giaoviendto.getTenTat());
		_node.appendChild(TenTatElement);
		TenTatElement.appendChild(value);
		// DiaChi
		Node DiaChiElement = doc.createElement("DiaChi");
		value = doc.createTextNode(giaoviendto.getDiaChi());
		_node.appendChild(DiaChiElement);
		DiaChiElement.appendChild(value);
		// DienThoai
		Node DienThoaiElement = doc.createElement("DienThoai");
		value = doc.createTextNode(giaoviendto.getDienThoai());
		_node.appendChild(DienThoaiElement);
		DienThoaiElement.appendChild(value);
		
		setNode(_node);
		return _node;
	}
	public Node TimGiaoVien(GIAOVIENDTO giaovien)
	{
		Node _node = null;
		NodeList nodelist = doc.getElementsByTagName("GIAOVIEN");
		
		int i = 0;
		while (i < nodelist.getLength())
		{
			Element GiaoVienElement = (Element) nodelist.item(i);
			Element MaGiaoVienElement = (Element) GiaoVienElement.getElementsByTagName("MaGiaoVien").item(0);
			Node FirstNode = MaGiaoVienElement.getFirstChild();
			String MaGiaoVien = "";
			if (FirstNode != null)
				MaGiaoVien = FirstNode.getNodeValue();
			
			if (MaGiaoVien.compareToIgnoreCase(giaovien.getMaGiaoVien()) == 0)
			{
				_node = GiaoVienElement;
				break;
			}
			++i;
		}
		
		setNode(_node);
		return _node;
	}
}
