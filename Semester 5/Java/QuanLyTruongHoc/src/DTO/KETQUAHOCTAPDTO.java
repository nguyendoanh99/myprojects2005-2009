package DTO;
import java.util.*;
public class KETQUAHOCTAPDTO {
	private List<Float> m_Diem;	
	private float m_fDTB;
	
	public boolean equals(Object obj)
	{
		KETQUAHOCTAPDTO kqht = (KETQUAHOCTAPDTO) obj;
		if (m_Diem.equals(kqht.m_Diem) == false)
			return false;
		
		if (m_fDTB != kqht.m_fDTB)
			return false;
		
		return true;
	}
	public KETQUAHOCTAPDTO() 
	{
		// TODO Auto-generated constructor stub
		m_Diem = new ArrayList<Float>();
		m_Diem.add(0f); // Toan
		m_Diem.add(0f); // Ly
		m_Diem.add(0f); // Hoa
		m_fDTB = 0;
	}
	// DTB
	public float getDTB()
	{
		return m_fDTB;
	}
	public boolean setDTB(float value)
	{
		if (0 > value || value > 10)
			return false;
		
		m_fDTB = value;
		return true;
	}
	public void TinhDTB()
	{
		float dtb = 0;
		int size = m_Diem.size();
		for (int i = 0; i < size; ++i)
			dtb += m_Diem.get(i);
		
		if (size == 0)
			size = 1;
		
		dtb /= size;
		m_fDTB = dtb;
	}
	// Toan
	public float getToan()
	{
		return m_Diem.get(0);
	}
	public boolean setToan(float value)
	{
		if (0 > value || value > 10)
			return false;
		
		m_Diem.set(0, value);
		return true;
	}
	// Ly
	public float getLy()
	{
		return m_Diem.get(1);
	}
	public boolean setLy(float value)
	{
		if (0 > value || value > 10)
			return false;
		
		m_Diem.set(1, value);
		return true;
	}
	// Hoa
	public float getHoa()
	{
		return m_Diem.get(2);
	}
	public boolean setHoa(float value)
	{
		if (0 > value || value > 10)
			return false;
		
		m_Diem.set(2, value);
		return true;
	}
	public String toString()
	{
		String kq = "";
		kq += "Toán " + String.valueOf(getToan());
		kq += ", Lý " + String.valueOf(getLy());
		kq += ", Hóa " + String.valueOf(getHoa());
		kq += ", DTB " + String.valueOf(getDTB());
		return kq;
	}
}
