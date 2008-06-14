package DAO;

import java.util.ArrayList;
import java.util.List;

import org.w3c.dom.DOMException;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import DTO.KHOIDTO;
import DTO.LOPHOCDTO;
import LIB.DOMUtil;

public class KHOIDAO extends AbstractDAO{
	
	public KHOIDAO() {
		// TODO Auto-generated constructor stub
		super();
	}
	public KHOIDAO(Node node)
	{
		super(node);
	}
	public List<KHOIDTO> getDanhSachKhoiHoc()
	{
		KHOIDAO khoidao = new KHOIDAO();
		Node node = getNode();
		List<KHOIDTO> kq = new ArrayList<KHOIDTO>();
		node = node.getFirstChild();
		
		while (node != null)
		{
			if (node.getNodeType() == Node.ELEMENT_NODE)
			{
				khoidao.setNode(node);
				kq.add(khoidao.getKhoi());
			}
			node = node.getNextSibling();
		}
		return kq;
	}
	public KHOIDTO getKhoi()
	{
		Node node = getNode();
		KHOIDTO kq = new KHOIDTO();
		
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
				
				if (name.compareToIgnoreCase("MaKhoi") == 0)
					kq.setMaKhoi(value);
				else
					if (name.compareToIgnoreCase("TenKhoi") == 0)
						kq.setTenKhoi(value);
					else
						if (name.compareToIgnoreCase("DanhSachLop") == 0)
						{							
							LOPHOCDAO lophocdao = new LOPHOCDAO(item);
							List<LOPHOCDTO> arrLopHoc = lophocdao.getDanhSachLopHoc();
							kq.setDanhSachLopHoc(arrLopHoc);
						}				
			}
			item = item.getNextSibling();
		}	
		
		return kq;
	}	
	public Node createNode(KHOIDTO khoidto)
	{
		Node _node = doc.createElement("KHOI");
		// MaKhoi
		Node MaKhoiElement = doc.createElement("MaKhoi");
		Node value = doc.createTextNode(khoidto.getMaKhoi());
		_node.appendChild(MaKhoiElement);
		MaKhoiElement.appendChild(value);
		// TenKhoi
		Node TenKhoiElement = doc.createElement("TenKhoi");
		value = doc.createTextNode(khoidto.getTenKhoi());
		_node.appendChild(TenKhoiElement);
		TenKhoiElement.appendChild(value);
		// DanhSachLop
		Node DanhSachLopElement = doc.createElement("DanhSachLop");
		_node.appendChild(DanhSachLopElement);
		List<LOPHOCDTO> lst = khoidto.getDanhSachLopHoc();
		LOPHOCDAO lophocdao = new LOPHOCDAO();
		for (int i = 0; i < lst.size(); ++i)
		{
			lophocdao.createNode(lst.get(i));
			DanhSachLopElement.appendChild(lophocdao.getNode());
		}
		
		setNode(_node);
		return _node;
	}
	public boolean ThemLop(KHOIDTO khoidto, LOPHOCDTO lophocdto)
	{
		boolean kq = true;
		
		Element KhoiNode = (Element) TimKhoi(khoidto);
		Node DanhSachElement = KhoiNode.getElementsByTagName("DanhSachLop").item(0);
//		 Khong tim thay
		if (DanhSachElement == null)
		{			
			DanhSachElement = doc.createElement("DanhSachLop");
			KhoiNode.appendChild(DanhSachElement);
		}
		
		LOPHOCDAO lophocdao = new LOPHOCDAO();
		lophocdao.createNode(lophocdto);
		
		DanhSachElement.appendChild(lophocdao.getNode());
		DOMUtil.writeXmlToFile(TenFile, doc);
		// Them vao dto
		khoidto.getDanhSachLopHoc().add(lophocdto);
		return kq;
	}
	public boolean XoaLop(KHOIDTO khoidto, LOPHOCDTO lophocdto)
	{
		boolean kq = true;
		
		Element KhoiNode = (Element) TimKhoi(khoidto);
		Node DanhSachElement = KhoiNode.getElementsByTagName("DanhSachLop").item(0);
		// Khong tim thay
		if (DanhSachElement == null)					
			return false;
		// Tim lop
		LOPHOCDAO lophocdao = new LOPHOCDAO();
		Node LopNode = (Node) lophocdao.TimLopHoc(lophocdto);
		if (LopNode == null)
			return false;
		
		try
		{
			DanhSachElement.removeChild(LopNode);
		}
		catch (DOMException DOMe)
		{
			if (DOMe.code == DOMException.NOT_FOUND_ERR)
				return false;
			
			System.out.println(DOMe);
			return false;
		}		
		DOMUtil.writeXmlToFile(TenFile, doc);
		 
		khoidto.getDanhSachLopHoc().remove(lophocdto);
		
		return kq;
	}
	public Node TimKhoi(KHOIDTO khoidto)
	{
		Node _node = null;
		NodeList nodelist = doc.getElementsByTagName("KHOI");
		
		int i = 0;
		while (i < nodelist.getLength())
		{
			Element KhoiElement = (Element) nodelist.item(i);
			Element MaKhoiElement = (Element) KhoiElement.getElementsByTagName("MaKhoi").item(0);
			Node FirstNode = MaKhoiElement.getFirstChild();
			String MaKhoi = "";
			if (FirstNode != null)
				MaKhoi = FirstNode.getNodeValue();
			
			if (MaKhoi.compareToIgnoreCase(khoidto.getMaKhoi()) == 0)
			{
				_node = KhoiElement;
				break;
			}
			++i;
		}
		
		setNode(_node);
		return _node;
	}
}
