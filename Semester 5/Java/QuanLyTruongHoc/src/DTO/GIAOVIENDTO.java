package DTO;
/**
 * @author DangKhoa
 *
 */
public class GIAOVIENDTO {
	private String m_strMaGiaoVien;
	private String m_strHoTen;
	private String m_strTenTat;
	private String m_strDiaChi;
	private String m_strDienThoai;
		
	/**
	 * 
	 */
	public GIAOVIENDTO() {
		// TODO Auto-generated constructor stub
		m_strMaGiaoVien = "";
		m_strHoTen = "";
		m_strTenTat = "";
		m_strDiaChi = "";
		m_strDienThoai = "";
	}
	public boolean equals(Object obj)
	{
		GIAOVIENDTO gv = (GIAOVIENDTO) obj;
		if (m_strMaGiaoVien.compareTo(gv.m_strMaGiaoVien) != 0)
			return false;
		
		if (m_strHoTen.compareTo(gv.m_strHoTen) != 0)
			return false;
		
		if (m_strTenTat.compareTo(gv.m_strTenTat) != 0)
			return false;
		
		if (m_strDiaChi.compareTo(gv.m_strDiaChi) != 0)
			return false;
		
		if (m_strDienThoai.compareTo(gv.m_strDienThoai) != 0)
			return false;
		
		return true;
	}
	// MaGiaoVien
	public String getMaGiaoVien()
	{
		return m_strMaGiaoVien;
	}
	public void setMaGiaoVien(String value)
	{
		m_strMaGiaoVien = value;
	}
	// HoTen
	public String getHoTen()
	{
		return m_strHoTen;
	}
	public void setHoTen(String value)
	{
		m_strHoTen = value;
	}
	// TenTat
	public String getTenTat()
	{
		return m_strTenTat;
	}
	public void setTenTat(String value)
	{
		m_strTenTat = value;
	}
	// DiaChi
	public String getDiaChi()
	{
		return m_strDiaChi;
	}
	public void setDiaChi(String value)
	{
		m_strDiaChi = value;
	}
	// DienThoai
	public String getDienThoai()
	{
		return m_strDienThoai;
	}
	public void setDienThoai(String value)
	{
		m_strDienThoai = value;
	}
	public String toString()
	{
		String kq = "";
		kq += "Mã GV: " + getMaGiaoVien();
		kq += "; Họ tên: " + getHoTen();
		kq += "; Tên tắt: " + getTenTat();
		kq += "; Địa chỉ: " + getDiaChi();
		kq += "; Điện thoại: " + getDienThoai();
		return kq;
	}
}
