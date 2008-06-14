package DTO;
import java.util.*;


/**
 * 
 */

/**
 * @author DangKhoa
 *
 */
public class LOPHOCDTO {
	private String m_strMaLop;
	private String m_strTenLop;
	private GIAOVIENDTO m_giaovien;
	private String m_strPhongHoc;
	private Date m_dateGioHoc;
	private List<HOCSINHDTO> m_arrHocSinh;
	/**
	 * 
	 */
	public LOPHOCDTO() {
		// TODO Auto-generated constructor stub
		m_strMaLop = "";
		m_strTenLop = "";
		m_giaovien = new GIAOVIENDTO();
		m_strPhongHoc = "";
		m_dateGioHoc = new Date();
		m_arrHocSinh = new ArrayList<HOCSINHDTO>();		
	}
	public boolean equals(Object obj)
	{
		LOPHOCDTO lophoc = (LOPHOCDTO) obj;
		if (m_strMaLop.equals(lophoc.m_strMaLop) == false)
			return false;
		
		if (m_strTenLop.equals(lophoc.m_strTenLop) == false)
			return false;
		
		if (m_strPhongHoc.equals(lophoc.m_strPhongHoc) == false)
			return false;
		
		if (m_dateGioHoc.equals(lophoc.m_dateGioHoc) == false)
			return false;
		
		if (m_giaovien.equals(lophoc.m_giaovien) == false)
			return false;
		
		if (m_arrHocSinh.equals(lophoc.m_arrHocSinh) == false)
			return false;
		
		return true;
	}
	// TenLop
	public String getTenLop()
	{
		return m_strTenLop;
	}
	public void setTenLop(String value)
	{
		m_strTenLop = value;
	}
	// MaLop
	public String getMaLop()
	{
		return m_strMaLop;
	}
	public void setMaLop(String value)
	{
		m_strMaLop = value;
	}
	// GiaoVien
	public GIAOVIENDTO getGiaoVien()
	{
		return m_giaovien;
	}
	public void setGiaoVien(GIAOVIENDTO value)
	{
		m_giaovien = value;
	}
	// PhongHoc
	public String getPhongHoc()
	{
		return m_strPhongHoc;
	}
	public void setPhongHoc(String value)
	{
		m_strPhongHoc = value;
	}
	// GioHoc
	public Date getGioHoc()
	{
		return m_dateGioHoc;
	}
	public void setGioHoc(Date value)
	{
		m_dateGioHoc = value;
	}
	// DanhSachHocSinh
	public List<HOCSINHDTO> getDanhSachHocSinh()
	{
		return m_arrHocSinh;
	}
	public void setDanhSachHocSinh(List<HOCSINHDTO> value)
	{
		m_arrHocSinh = value;
	}
	public String toString()
	{
		
		String kq = "";
		kq += "[" + getMaLop() + "] ";
		kq += getTenLop();
		
		/*
		kq += "Mã lớp: " + getMaLop();
		kq += "; Tên lớp: " + getTenLop();
		kq += "; Giáo viên: " + getGiaoVien();
		kq += "; Phòng học: " + getPhongHoc();
		kq += "; Giờ học: " + getGioHoc();
		kq += "; Danh sách học sanh: (";
		List<HOCSINHDTO> lst = getDanhSachHocSinh();
		for (int i = 0; i < lst.size() - 1; ++i)
		{
			kq += lst.get(i);
			if (i < lst.size() - 1)
				kq += ", ";
		}
		kq += ")";
		*/
		return kq;
	}
}
