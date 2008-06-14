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

import DTO.GIAOVIENDTO;
import DTO.HOCSINHDTO;
import DTO.LOPHOCDTO;
import LIB.DOMUtil;

public class LOPHOCDAO extends AbstractDAO{

	public LOPHOCDAO() {
		// TODO Auto-generated constructor stub
		super();
	}
	public LOPHOCDAO(Node node)
	{
		super(node);
	}
	public List<LOPHOCDTO> getDanhSachLopHoc()
	{
		Node node = getNode();
		LOPHOCDAO lophocdao = new LOPHOCDAO();
		List<LOPHOCDTO> kq = new ArrayList<LOPHOCDTO>();
		node = node.getFirstChild();
		
		while (node != null)
		{
			if (node.getNodeType() == Node.ELEMENT_NODE)
			{
				lophocdao.setNode(node);
				kq.add(lophocdao.getLopHoc());
			}
			node = node.getNextSibling();
		}
		return kq;
	}
	public LOPHOCDTO getLopHoc()
	{
		Node node = getNode();
		LOPHOCDTO kq = new LOPHOCDTO();
		
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
				
				if (name.compareToIgnoreCase("MaLop") == 0)									
					kq.setMaLop(value);				
				else
					if (name.compareToIgnoreCase("TenLop") == 0)
						kq.setTenLop(value);
					else
						if (name.compareToIgnoreCase("GiaoVien") == 0)
						{
							GIAOVIENDAO giaoviendao = new GIAOVIENDAO(item);
							GIAOVIENDTO giaovien = giaoviendao.getGiaoVien();							
							kq.setGiaoVien(giaovien);
						}				
						else
							if (name.compareToIgnoreCase("PhongHoc") == 0)
								kq.setPhongHoc(value);
							else
								if (name.compareToIgnoreCase("GioHoc") == 0)
								{
									DateFormat df = DateFormat.getTimeInstance(DateFormat.SHORT, new Locale("vi", "VN"));
									try
									{
										Date d = df.parse(value);
										kq.setGioHoc(d);
									}
									catch (ParseException pe)
									{
										System.out.println(pe.toString());
									}
								}
								else
									if (name.compareToIgnoreCase("DanhSachHocSinh") == 0)
									{
										HOCSINHDAO hocsinhdao = new HOCSINHDAO(item);
										List<HOCSINHDTO> hocsinh = hocsinhdao.getDanhSachHocSinh();										
										kq.setDanhSachHocSinh(hocsinh);
									}	
			}
			item = item.getNextSibling();
		}	
		
		return kq;
	}
	public Node createNode(LOPHOCDTO lophocdto)
	{
		Node _node = doc.createElement("LOP");
		// MaLop
		Node MaLopElement = doc.createElement("MaLop");
		Node value = doc.createTextNode(lophocdto.getMaLop());
		_node.appendChild(MaLopElement);
		MaLopElement.appendChild(value);
		// TenLop
		Node TenLopElement = doc.createElement("TenLop");
		value = doc.createTextNode(lophocdto.getTenLop());
		_node.appendChild(TenLopElement);
		TenLopElement.appendChild(value);
		// GiaoVien
		GIAOVIENDAO giaoviendao = new GIAOVIENDAO();
		Node GiaoVienElement = giaoviendao.createNode(lophocdto.getGiaoVien());
		_node.appendChild(GiaoVienElement);
		// PhongHoc
		Node PhongHocElement = doc.createElement("PhongHoc");
		value = doc.createTextNode(lophocdto.getPhongHoc());
		_node.appendChild(PhongHocElement);
		PhongHocElement.appendChild(value);
		// GioHoc
		DateFormat df = DateFormat.getTimeInstance(DateFormat.SHORT, new Locale("vi", "VN"));
		Node GioHocElement = doc.createElement("GioHoc");
		value = doc.createTextNode(df.format(lophocdto.getGioHoc()));
		_node.appendChild(GioHocElement);
		GioHocElement.appendChild(value);
		// DanhSachHocSinh
		Node DanhSachHocSinhElement = doc.createElement("DanhSachHocSinh");
		_node.appendChild(DanhSachHocSinhElement);
		List<HOCSINHDTO> lst = lophocdto.getDanhSachHocSinh();
		HOCSINHDAO hocsinhdao = new HOCSINHDAO();
		for (int i = 0; i < lst.size(); ++i)
		{
			hocsinhdao.createNode(lst.get(i));
			DanhSachHocSinhElement.appendChild(hocsinhdao.getNode());
		}
		
		setNode(_node);
		return _node;
	}
	public boolean ThemHocSinh(LOPHOCDTO lophocdto, HOCSINHDTO hocsinhdto)
	{
		boolean kq = true;
				
		Element LopHocNode = (Element) TimLopHoc(lophocdto);
		Node DanhSachElement = LopHocNode.getElementsByTagName("DanhSachHocSinh").item(0);
		// Khong tim thay
		if (DanhSachElement == null)
		{			
			DanhSachElement = doc.createElement("DanhSachHocSinh");
			LopHocNode.appendChild(DanhSachElement);
		}
		
		HOCSINHDAO hocsinhdao = new HOCSINHDAO();
		hocsinhdao.createNode(hocsinhdto);
		
		DanhSachElement.appendChild(hocsinhdao.getNode());
		DOMUtil.writeXmlToFile(TenFile, doc);
		// Them vao dto
		lophocdto.getDanhSachHocSinh().add(hocsinhdto);
		return kq;
	}
	public boolean XoaHocSinh(LOPHOCDTO lophocdto, HOCSINHDTO hocsinhdto)
	{
		boolean kq = true;
		
		Element LopNode = (Element) TimLopHoc(lophocdto);
		Node DanhSachElement = LopNode.getElementsByTagName("DanhSachHocSinh").item(0);
		// Khong tim thay
		if (DanhSachElement == null)					
			return false;
		// Tim hoc sinh
		HOCSINHDAO hocsinhdao = new HOCSINHDAO();
		Node HocSinhNode = (Node) hocsinhdao.TimHocSinh(hocsinhdto);
		if (HocSinhNode == null)
			return false;
		
		try
		{
			DanhSachElement.removeChild(HocSinhNode);
		}
		catch (DOMException DOMe)
		{
			if (DOMe.code == DOMException.NOT_FOUND_ERR)
				return false;
			
			System.out.println(DOMe);
			return false;
		}
		DOMUtil.writeXmlToFile(TenFile, doc);

		lophocdto.getDanhSachHocSinh().remove(hocsinhdto);
		return kq;
	}
	public boolean CapNhatLopHoc(LOPHOCDTO lophoc)
	{
		Element LopNode = (Element) TimLopHoc(lophoc);
		if (LopNode == null)
			return false;		
				
		try
		{
			// Cap nhat giao vien
			Node giaoviennode = LopNode.getElementsByTagName("GIAOVIEN").item(0);
			GIAOVIENDAO giaoviendao = new GIAOVIENDAO();
			Node NewNode = giaoviendao.createNode(lophoc.getGiaoVien());
			LopNode.replaceChild(NewNode, giaoviennode);
			
			// Cap nhat phong hoc
			Node phonghocnode = LopNode.getElementsByTagName("PhongHoc").item(0);
			NewNode = doc.createElement("PhongHoc");
			Node value = doc.createTextNode(lophoc.getPhongHoc());			
			NewNode.appendChild(value);			
			LopNode.replaceChild(NewNode, phonghocnode);
			
			// Cap nhat gio hoc
			DateFormat df = DateFormat.getTimeInstance(DateFormat.SHORT, new Locale("vi", "VN"));
			Node giohocnode = LopNode.getElementsByTagName("GioHoc").item(0);
			NewNode = doc.createElement("GioHoc");
			value = doc.createTextNode(df.format(lophoc.getGioHoc()));			
			NewNode.appendChild(value);			
			LopNode.replaceChild(NewNode, giohocnode);
			
			// Cap nhat ten lop			
			Node tenlopnode = LopNode.getElementsByTagName("TenLop").item(0);
			NewNode = doc.createElement("TenLop");
			value = doc.createTextNode(lophoc.getTenLop());			
			NewNode.appendChild(value);			
			LopNode.replaceChild(NewNode, tenlopnode);
		}
		catch (DOMException DOMe)
		{			
			return false;
		}		
		DOMUtil.writeXmlToFile(TenFile, doc);
		return true;
	}
	public boolean ChuyenLop(LOPHOCDTO lophoccu, LOPHOCDTO lophocmoi, HOCSINHDTO hocsinh)
	{
		if (XoaHocSinh(lophoccu, hocsinh) == false)
			return false;
		
		if (ThemHocSinh(lophocmoi, hocsinh) == false)
			return false;
		
		return true;
	}
	public Node TimLopHoc(LOPHOCDTO lophocdto)
	{
		Node _node = null;
		NodeList nodelist = doc.getElementsByTagName("LOP");
		
		int i = 0;
		while (i < nodelist.getLength())
		{
			Element LopHocElement = (Element) nodelist.item(i);
			Element MaLopHocElement = (Element) LopHocElement.getElementsByTagName("MaLop").item(0);
			Node FirstNode = MaLopHocElement.getFirstChild();
			String MaLopHoc = "";
			if (FirstNode != null)
				MaLopHoc = FirstNode.getNodeValue();
			
			if (MaLopHoc.compareToIgnoreCase(lophocdto.getMaLop()) == 0)
			{
				_node = LopHocElement;
				break;
			}
			++i;
		}
		
		setNode(_node);
		return _node;
	}

}
