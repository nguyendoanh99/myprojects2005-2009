package DTO;
/**
 * 
 */
import java.util.*;
/**
 * @author DangKhoa
 *
 */
public class TRUONGDTO {
	private List<KHOIDTO> m_arrKhoi;
	/**
	 * 
	 */
	public TRUONGDTO() {
		// TODO Auto-generated constructor stub
		m_arrKhoi = new ArrayList<KHOIDTO>();
	}
	// DanhSachKhoi
	public List<KHOIDTO> getDanhSachKhoiHoc()
	{
		return m_arrKhoi;
	}
	public void setDanhSachKhoiHoc(List<KHOIDTO> value)
	{
		m_arrKhoi = value;
	}
	public String toString()
	{
		String kq = "";
		List<KHOIDTO> lst = getDanhSachKhoiHoc();
		for (int i = 0; i < lst.size() - 1; ++i)
		{
			kq += lst.get(i);
			if (i < lst.size() - 1)
				kq += ", ";
		}
		return kq;
	}
}
