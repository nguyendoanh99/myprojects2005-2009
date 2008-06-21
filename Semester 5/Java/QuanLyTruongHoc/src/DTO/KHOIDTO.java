package DTO;
/**
 * 
 */
import java.util.*;

/**
 * @author DangKhoa
 *
 */
public class KHOIDTO {
	private String m_strMaKhoi;
	private String m_strTenKhoi;
	private List<LOPHOCDTO> m_arrLopHoc;
	/**
	 * 
	 */
	public KHOIDTO() {
		// TODO Auto-generated constructor stub
		m_strMaKhoi = "";
		m_strTenKhoi = "";
		m_arrLopHoc = new ArrayList<LOPHOCDTO>();
	}
	public boolean equals(Object obj)
	{
		KHOIDTO khoi = (KHOIDTO) obj;
		if (m_strMaKhoi.compareTo(khoi.m_strMaKhoi) != 0)
			return false;
		
		if (m_strTenKhoi.compareTo(khoi.m_strTenKhoi) != 0)
			return false;
		
		if (m_arrLopHoc.equals(khoi.m_arrLopHoc) == false)
			return false;
		
		return true;
	}
	//	 TenKhoi
	public String getTenKhoi()
	{
		return m_strTenKhoi;
	}
	public void setTenKhoi(String value)
	{
		m_strTenKhoi = value;
	}
	// MaKhoi
	public String getMaKhoi()
	{
		return m_strMaKhoi;
	}
	public void setMaKhoi(String value)
	{
		m_strMaKhoi = value;
	}
	// DanhSachLopHoc
	public List<LOPHOCDTO> getDanhSachLopHoc()
	{
		return m_arrLopHoc;
	}
	public void setDanhSachLopHoc(List<LOPHOCDTO> value)
	{
		m_arrLopHoc = value;
	}
	public String toString()
	{
		String kq = "";
		kq += "Mã khối: " + getMaKhoi();
		kq += "; Tên khối: " + getTenKhoi();
		kq += "; Danh sách lớp học: (";
		List<LOPHOCDTO> lst = getDanhSachLopHoc();
		for (int i = 0; i < lst.size(); ++i)
		{
			kq += lst.get(i);
			if (i < lst.size() - 1)
				kq += ", ";
		}
		kq += ")";
		return kq;
	}
}