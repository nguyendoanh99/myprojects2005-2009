package DTO;
import java.util.Date;


public class HOCSINHDTO
{
	//private
	private	String m_strMaHocSinh;
	private String m_strHoTen;
	private Date m_dateNamSinh;
	private String m_strDiaChi;
	private String m_strDienThoai;
	private KETQUAHOCTAPDTO m_KQHT;
 
	public boolean equals(Object obj)
	{
		HOCSINHDTO hocsinhdto = (HOCSINHDTO) obj;
		
		if (m_strMaHocSinh.compareTo(hocsinhdto.m_strMaHocSinh) != 0)
			return false;
		
		if (m_strHoTen.compareTo(hocsinhdto.m_strHoTen) != 0)
			return false;
		
		if (m_dateNamSinh.equals(hocsinhdto.m_dateNamSinh) == false)
			return false;
		
		if (m_strDiaChi.compareTo(hocsinhdto.m_strDiaChi) != 0)
			return false;
		
		if (m_strDienThoai.compareTo(hocsinhdto.m_strDienThoai) != 0)
			return false;
		
		if (!m_KQHT.equals(hocsinhdto.m_KQHT))
			return false;
		
		return true;
	}
	public HOCSINHDTO() {
		// TODO Auto-generated constructor stub
		m_strMaHocSinh = "";
		m_strHoTen = "";
		m_dateNamSinh = new Date();
		m_strDiaChi = "";
		m_strDienThoai = "";
		m_KQHT = new KETQUAHOCTAPDTO();		
	}
	// MaHocSinh
	public String getMaHocSinh()
	{
		return m_strMaHocSinh;
	}
	public void setMaHocSinh(String value)
	{
		m_strMaHocSinh = value;
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
	// NamSinh
	public Date getNamSinh()
	{
		return m_dateNamSinh;
	}
	public void setNamSinh(Date value)
	{
		m_dateNamSinh = value;
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
	// Ket qua hoc tap
	public KETQUAHOCTAPDTO getKQHT()
	{
		return m_KQHT;
	}
	public void setKQHT(KETQUAHOCTAPDTO value)
	{
		m_KQHT = value;
	}
	
	public String toString()
	{
		String kq = "";
		kq += "[" + getMaHocSinh() + "] ";
		kq += getHoTen();
		/*
		kq += "Mã HS: " + getMaHocSinh();
		kq += "; Họ tên: " + getHoTen();
		kq += "; Năm sinh: " + getNamSinh();
		kq += "; Địa chỉ: " + getDiaChi();
		kq += "; Điện thoại: " + getDienThoai();
		kq += "; KQHT: " + getKQHT();
		*/
		return kq;
	}
}
