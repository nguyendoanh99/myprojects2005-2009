import java.io.*;

class JMyString
{
	private char[] m_str;

	private JMyString LayChuoi(int iBatDau, int iDoDai)
	{
		JMyString strKQ;
		// Neu iBatDau nam ngoai pham vi hoat dong cua chuoi thi ket qua tra ve la chuoi rong
		if ((iBatDau < 0) || (iBatDau > (m_str.length - 1)) || (iDoDai <= 0))
			strKQ = new JMyString();
		else
		{
			// Tai vi tri iBatDau, neu so ky can lay nhieu hon so ky tu trong chuoi
			// thi lay chuoi tu iBatDau den het chuoi
			if (iDoDai + iBatDau > m_str.length)
				iDoDai = m_str.length - iBatDau;
			
			strKQ = new JMyString(' ', iDoDai);			
			// Neu con du bo nho thi thuc hien
			if (strKQ.m_str != null)
			{
				for (int i = iBatDau; i < iBatDau + iDoDai; ++i)
					strKQ.m_str[i - iBatDau] = m_str[i];				
			}		
		}
	
		return strKQ;
	}
	// Chuyen ky tu c thanh chu hoa
	public static char Upcase(char c)
	{
		if ('a' <= c && c <= 'z')
			c -= 32;
		return c;
	}
	// Chuyen ky tu c thanh chu thuong
	public static char Lowcase(char c)
	{
		if ('A' <= c && c <= 'Z')
			c += 32;
		return c;
	}
	// Sao chep src vao des
	public static char[] strcpy(char[] des, char[] src)
	{		
		for (int i = 0; i < src.length; ++i)
			des[i] = src[i];
		
		return des;
	}
	// Dien day mang bang ky tu c
	public static char[] strset(char[] des, char c)
	{
		for (int i = 0; i < des.length; ++i)
			des[i] = c;
		
		return des;
	}	
	// So sanh 2 mang ky tu s1 va s2 co phan biet chu hoa thuong. Gia tri tra ve:
	// 1 : s1 > s2
	// -1: s1 < s2
	// 0 : s1 = s2
	public static int strcmp(char []s1, char[]s2)		
	{
		int min = (s1.length > s2.length) ? s2.length : s1.length;
		
		for (int i = 0; i < min; ++i)
		{
			if (s1[i] > s2[i])
				return 1;			
			
			if (s1[i] < s2[i])
				return -1;			
		}
		
		if (s1.length > s2.length)
			return 1;
		
		if (s1.length < s2.length)
			return -1;
		
		return 0;		
	}
	// So sanh 2 mang ky tu s1 va s2 khong phan biet chu hoa thuong. Gia tri tra ve:
	// 1 : s1 > s2
	// -1: s1 < s2
	// 0 : s1 = s2
	public static int stricmp(char []s1, char []s2)		
	{
		int min = (s1.length > s2.length) ? s2.length : s1.length;
		
		for (int i = 0; i < min; ++i)
		{
			if (Lowcase(s1[i]) > Lowcase(s2[i]))
				return 1;			
			
			if (Lowcase(s1[i]) < Lowcase(s2[i]))
				return -1;			
		}
		
		if (s1.length > s2.length)
			return 1;
		
		if (s1.length < s2.length)
			return -1;
		
		return 0;		
	}
	// Chuyen mang ky tu s thanh mang ky tu hoa
	public static char[] strupr(char []s)
	{
		for (int i = 0; i < s.length; ++i)
			s[i] = Upcase(s[i]);
		return s;
	}
	// Chuyen mang ky tu s thanh mang ky tu thuong
	public static char[] strlwr(char []s)
	{
		for (int i = 0; i < s.length; ++i)
			s[i] = Lowcase(s[i]);
		return s;
	}
	// Tim s trong src bat dau tu vi tri iBatDau trong src (tim tu trai sang phai). Ket qua tra ve:
	// i : i la vi tri tim thay dau tien
	// -1: neu khong tim thay s trong src
	public static int strstr(char []src, char []s, int iBatDau)
	{
		if (src.length == 0 || s.length == 0)
			return -1;
		for (int i = iBatDau; i <= src.length - s.length; ++i)
		{
			boolean flag = true;
			for (int j = 0; j < s.length; ++j)
				if (src[i + j] != s[j])
				{
					flag = false;
					break;
				}
			
			if (flag == true)
				return i;
		}
	
		return -1;
	}
	// Tim c trong src bat dau tu vi tri iBatDau trong src (tim tu trai sang phai). Ket qua tra ve:
	// i : i la vi tri tim thay dau tien
	// -1: neu khong tim thay s trong src
	public static int strchr(char []src, char c, int iBatDau)
	{
		char []k = {c};
		return strstr(src, k, iBatDau);
	}
	// Tim s trong src bat dau tu vi tri iBatDau trong src (tim tu phai sang trai). Ket qua tra ve:
	// i : i la vi tri tim thay cuoi cung
	// -1: neu khong tim thay s trong src
	public static int strrstr(char []src, char []s, int iBatDau)
	{
		if (src.length == 0 || s.length == 0)
			return -1;
		
		for (int i = Math.min(iBatDau, src.length - s.length); i >= 0; --i)
		{
			boolean flag = true;
			for (int j = 0; j < s.length; ++j)
				if (src[i + j] != s[j])
				{
					flag = false;
					break;
				}
			
			if (flag == true)
				return i;
		}
	
		return -1;
	}
	// Tim c trong src bat dau tu vi tri iBatDau trong src (tim tu phai sang trai). Ket qua tra ve:
	// i : i la vi tri tim thay cuoi cung
	// -1: neu khong tim thay s trong src
	public static int strrchr(char []src, char c, int iBatDau)
	{
		char []k = {c};
		return strrstr(src, k, iBatDau);
	}
	// Chen mang src vao mang des tai vi tri iBatDau
	private char[] strcat(char []des, char []src, int iBatDau)
	{
		for (int i = 0; i < src.length; ++i)
			des[iBatDau + i] = src[i];
		return des;
	}
	public JMyString()
	{		
		m_str = new char[0];
	}
	public JMyString(JMyString P)
	{		
		m_str = new char[P.m_str.length];	
		// Neu khong con du bo nho de cap phat thi tao chuoi rong
		// nguoc lai thuc hien viec sao chep 2 chuoi
		if (m_str != null)
			strcpy(m_str, P.m_str);
		else
			m_str = new char[0];
	}	
	public JMyString(char[] str)
	{
		m_str = new char[str.length];	
		// Neu khong con du bo nho de cap phat thi tao chuoi rong
		// nguoc lai thuc hien sao chep 2 chuoi
		if (m_str != null)
			strcpy(m_str, str);
		else
			m_str = new char[0];
	}
		
	public JMyString(String str)
	{
		m_str = new char[str.length()];	
		// Neu khong con du bo nho de cap phat thi tao chuoi rong
		// nguoc lai thuc hien sao chep 2 chuoi
		if (m_str != null)			
		{
			for (int i = 0; i < m_str.length; ++i)
				m_str[i] = str.charAt(i);
		}
		else
			m_str = new char[0];
	}
	public JMyString(char c, int n)
	{
		if (n > 0)
		{			
			m_str = new char[n];
			// Neu khong con du bo nho de cap phat thi tao chuoi rong
			// nguoc lai thuc hien viec tao chuoi gom n ky tu c giong nhau
			if (m_str != null)							
				strset(m_str, c);				
			else
				m_str = new char[0];
		}		
		else
			m_str = new char[0];
	}
	
	public String toString()
	{
		String kq = new String();
		for (int i = 0; i < m_str.length; ++i)			
			kq = kq + m_str[i];
		return kq;
	}
	// Cong chuoi
	public JMyString Concat(String Q)
	{
		JMyString P = new JMyString(Q);
		return Concat(P);
	}
	public JMyString Concat(JMyString P)
	{
		JMyString strKQ = new JMyString(' ', m_str.length + P.m_str.length);
		// Neu khong con du bo nho de cap phat thi thoat ra 
		// nguoc lai thuc hien phep cong 2 chuoi
		if (strKQ != null)
		{
			strcpy(strKQ.m_str, m_str);
			strcat(strKQ.m_str, P.m_str, m_str.length);
		}
		
		return strKQ;
	}	
	public JMyString Concat(char []str)
	{	
		int iLen;
		// Kiem tra xem str co phai la 1 chuoi khong
		if (str != null)
			iLen = str.length;
		else
			iLen = 0;
	
		JMyString strKQ = new JMyString(' ', m_str.length + str.length);
		// Neu khong con du bo nho de cap phat thi thoat
		// nguoc lai thuc hien phep cong 2 chuoi
		if (strKQ != null)
		{
			strcpy(strKQ.m_str, m_str);
			// Neu str dung la 1 chuoi thi thuc hien ham noi 2 chuoi lai
			if (str != null)
				strcat(strKQ.m_str, str, m_str.length);
		}
	
		return strKQ;
	}
	public JMyString Concat(char c)
	{
		char s[] = {c};
		return Concat(s);
	}
	// Cac ham so sanh chuoi
	// Cac ham so sanh bang
	public boolean EqualTo(String Q)
	{
		JMyString P = new JMyString(Q);
		return EqualTo(P);
	}
	public boolean EqualTo(JMyString P)
	{
		return (strcmp(m_str, P.m_str) == 0);
	}	
	public boolean EqualTo(char []str)
	{
		// Neu str la 1 chuoi thi kiem tra
		if (str != null)
			return (strcmp(m_str, str) == 0);	
	
		return false;
	}
	// Cac ham so sanh lon hon
	public boolean GreaterThan(String Q)
	{
		JMyString P = new JMyString(Q);
		return GreaterThan(P);
	}
	public boolean GreaterThan(JMyString P)
	{
		return (strcmp(m_str, P.m_str) > 0);
	}	
	public boolean GreaterThan(char []str)
	{
		// Neu str la 1 chuoi thi kiem tra
		if (str != null)
			return (strcmp(m_str, str) > 0);
	
		return false;
	}
	// Cac ham so sanh lon hon hoac bang
	public boolean GreaterEqualTo(String Q)
	{
		JMyString P = new JMyString(Q);
		return GreaterEqualTo(P);
	}
	public boolean GreaterEqualTo(JMyString P)
	{	
		return (strcmp(m_str, P.m_str) >= 0);
	}	
	public boolean GreaterEqualTo(char []str)
	{
		// Neu str la 1 chuoi thi kiem tra
		if (str != null)
			return (strcmp(m_str, str) >= 0);
	
		return false;
	}
	// Cac ham so sanh nho hon
	public boolean LessThan(String Q)
	{
		JMyString P = new JMyString(Q);
		return LessThan(P);
	}
	public boolean LessThan(JMyString P)
	{
		return (strcmp(m_str, P.m_str) < 0);
	}	
	public boolean LessThan(char []str)
	{
		// Neu str la 1 chuoi thi kiem tra
		if (str != null)
			return (strcmp(m_str, str) < 0);
	
		return false;
	}
	// Cac ham so sanh nho hon hoac bang 
	public boolean LessEqualTo(String Q)
	{
		JMyString P = new JMyString(Q);
		return LessEqualTo(P);
	}
	boolean LessEqualTo(JMyString P)
	{
		return (strcmp(m_str, P.m_str) <= 0);
	}	
	boolean LessEqualTo(char []str)
	{
		// Neu str la 1 chuoi thi kiem tra
		if (str != null)
			return (strcmp(m_str, str) <= 0);
	
		return false;
	}
	
	public int GetLength()
	{
		return m_str.length;
	}
	public boolean IsEmpty()
	{
		return m_str.length == 0;
	}
	public void Empty()
	{
		m_str = new char[0];
	}	
	public char GetAt(int iViTri)
	{
		// Neu iViTri nam ngoai gioi han cua mang thi 
		// dua iViTri ve gia tri bien gan nhat so voi iViTri ban dau		
		iViTri = Math.max(iViTri, 0);
		iViTri = Math.min(iViTri, m_str.length - 1);
	
		return m_str[iViTri];
	}
	// Neu gan ky tu thanh cong thi tra ve true, nguoc lai tra ve false
	public boolean SetAt(int iViTri, char c)
	{
		if (iViTri >= 0 && iViTri < m_str.length)
		{
			m_str[iViTri] = c;
			return true;
		}
	
		return true;
	}

	public int Compare(JMyString P)
	{
		return Compare(P.m_str);
	}
	
	public int Compare(char[] str)
	{
		// Neu str la chuoi thi thuc hien phep so sanh	
		if (str != null)
		{
			int i = strcmp(m_str, str);
			if (i > 0)
				return 1;
			if (i < 0)
				return -1;
			return 0;
		}	
	
		return 1;
	}
	public int Compare(String P)
	{
		JMyString s = new JMyString(P);
		return Compare(s.m_str);
	}
	public int CompareNoCase(JMyString P)
	{
		return CompareNoCase(P.m_str);
	}
	public int CompareNoCase(char []str)
	{
		// Neu str la chuoi thi thuc hien phep so sanh	
		if (str != null)
		{
			int i = stricmp(m_str, str);
			if (i > 0)
				return 1;
			if (i < 0)
				return -1;
			return 0;
		}
	
		return 1;
	}
	public int CompareNoCase(String P)
	{
		JMyString s = new JMyString(P);
		return CompareNoCase(s.m_str);
	}
	
	public JMyString Mid(int iBatDau, int iDoDai)
	{
		return LayChuoi(iBatDau, iDoDai);
	}
	public JMyString Left(int iDoDai)
	{
		return LayChuoi(0, iDoDai);
	}
	public JMyString Right(int iDoDai)
	{
		// Neu so ky tu can lay nhieu hon so ky tu ma chuoi dang co thi lay tat ca cac
		// ky tu co trong chuoi
		if (iDoDai > m_str.length)
			return LayChuoi(0,iDoDai);
	
		return LayChuoi(m_str.length - iDoDai, iDoDai);
	}

	public JMyString MakeUpper()		
	{
		strupr(m_str);
		return this;
	}
	public JMyString MakeLower()
	{
		strlwr(m_str);
		return this;
	}
	public JMyString TrimLeft()
	{
		char []kq;
		// Tim vi tri dau tien ma tai do ky khac khoang trang tinh tu trai qua phai
		int i;
		for (i = 0; i < m_str.length &&  m_str[i] == ' '; ++i);
		
		// Di chuyen cac ky tu tu vi tri i ve dau chuoi
		if (i != 0)
		{
			if (i != m_str.length)
			{		
				kq = new char[m_str.length - i + 1];
				for (int j = i; j < m_str.length; ++j)
					kq[j - i] = m_str[j];		
				m_str = kq;

			}
			// Neu chuoi toan la khoang trang thi xoa chuoi va tao chuoi rong
			else 
				m_str = new char[0];			
		}	
	
		return this;
	}
	public JMyString TrimRight()
	{
		// Tim ky tu dau tien khac khoang trang tinh tu phai qua trai
		int i;
		for (i = m_str.length - 1; i >= 0 && m_str[i] == ' '; --i);
		// Neu toan bo chuoi la khoang trang thi tao chuoi rong
		if (i < 0)
			m_str = new char[0];
		else
			// Neu co khoang trang o cuoi chuoi thi cat bo
			if (i != m_str.length)
			{
				char []kq =new char[i + 1];
				
				for (int j = 0; j <= i; ++j)
					kq[j] = m_str[j];
				
				m_str = kq;
			}
	
		return this;
	}

	public int Find(String Q)
	{
		JMyString P = new JMyString(Q);
		return strstr(m_str, P.m_str, 0);
	}
	public int Find(JMyString P)
	{		
		return strstr(m_str, P.m_str, 0);
	}
	public int Find(char []str)
	{
		// Neu str la chuoi thi thuc hien tim kiem
		if (str != null)		
			return strstr(m_str, str, 0);		
		return -1;
	}	
	public int Find(char c)
	{
		return strchr(m_str, c, 0);		
	}

	public int ReverseFind(String Q)
	{
		JMyString P = new JMyString(Q);
		return strrstr(m_str, P.m_str, m_str.length);
	}	
	public int ReverseFind(JMyString P)
	{
		return strrstr(m_str, P.m_str, m_str.length);
	}
	public int ReverseFind(char []str)
	{
		// Neu str la chuoi thi thuc hien tim kiem
		if (str != null)
			return strrstr(m_str, str, m_str.length);
		return -1;
	}	
	public int ReverseFind(char c)
	{
		return strrchr(m_str, c, m_str.length);
	}
	
	public static void main(String[] args) throws IOException
	{
		JMyString strDS[] = {new JMyString("Sai"), new JMyString("Dung")};
		JMyString a = new JMyString();
		JMyString b = new JMyString("Toi la");
		JMyString c = new JMyString(b); // c(b)
		JMyString d = new JMyString('K', 10);
		String e = new String();
		JMyString f;
		char []str = {'M','S','S','V',':',' ','0','5','1','2','1','7','5'};
		
		// Nhap chuoi e		
		System.out.print("Nhap chuoi e: ");
		byte []buff = new byte [255];
		int len = System.in.read(buff, 0, 255);
		for (int i = 0; i < len - 1; ++i)
			e += (char) buff[i];
		
		
		// Xuat cac chuoi ra man hinh
		System.out.println();
		System.out.println("a(\"" + a + "\")");
		System.out.println("b(\"" + b + "\")");
		System.out.println("c(\"" + c + "\")");
		System.out.println("d(\"" + d + "\")");
		System.out.println("e(\"" + e + "\")");
		System.out.print("Mang ky tu str = \"");
		for (int i = 0; i < str.length; ++i)
			System.out.print(str[i]);
		System.out.println("\"\n");
		
		// Thuc hien cac toan tu so sanh
		System.out.println("Cac phep so sanh co phan biet hoa thuong" );
		System.out.println("c == b : " + strDS[c.EqualTo(b) ? 1 : 0]);
		System.out.println("a == str : " + strDS[a.EqualTo(str) ? 1 : 0]);
		System.out.println("b > c : " + strDS[b.GreaterThan(c) ? 1 : 0]);
		System.out.println("b > str : " + strDS[b.GreaterThan(str) ? 1 : 0]);
		System.out.println("b >= c : " + strDS[b.GreaterEqualTo(c) ? 1 : 0]);
		System.out.println("b >= str : " + strDS[b.GreaterEqualTo(str) ? 1 : 0]);
		System.out.println("b < a : " + strDS[b.LessThan(a) ? 1 : 0]);
		System.out.println("b < str : " + strDS[b.LessThan(str) ? 1 : 0]);
		System.out.println("b <= a : " + strDS[b.LessEqualTo(a) ? 1 : 0]);
		System.out.println("b <= str : " + strDS[b.LessEqualTo(str) ? 1 : 0]);
		System.out.println();
		
		// Thuc hien cac phep cong chuoi
		f = b.Concat(" ").Concat(e).Concat(" ").Concat(str);
		System.out.println("f = (b + \" \" + e + \" \" + str) : (\"" + f + "\")");
			
		// Lay chieu dai cua chuoi, kiem tra chuoi rong
		System.out.println("Chieu dai cua chuoi d la " + d.GetLength());
		d.Empty();
		System.out.println("Sau khi dung lenh d.Empty().\nd la chuoi rong: " + strDS[d.IsEmpty() == true ? 1 : 0]);
		System.out.println();
		// Dung ham de so sanh 2 chuoi
		JMyString ss[] = {new JMyString("=="), new JMyString(">"), new JMyString("<")};
		JMyString s1 = new JMyString("   Nguyen Dang Khoa ");
		JMyString s2 = new JMyString("   nguyen dang khoa ");	
		System.out.println("So sanh 2 chuoi s1 va s2");
		
		int kq = s1.Compare(s2);
		kq = (kq >= 0 ? kq : 2);
		System.out.println("Co phan biet hoa thuong : s1(\"" + s1 + "\") " 
			+ ss[kq] + " s2(\"" + s2 + "\")");
	
		kq = s1.CompareNoCase(s2);
		kq = (kq >= 0 ? kq : 2);
		System.out.println("Khong phan biet hoa thuong : s1(\"" + s1 + "\") " 
			+ ss[kq] + " s2(\"" + s2 + "\")");
		System.out.println();
	
		// Doi chuoi thanh chu hoa, chu thuong
		System.out.println("Chuoi s1 sau khi doi sang chu thuong : s1(\"" + s1.MakeLower() + "\")");
		System.out.println("Chuoi s2 sau khi doi sang chu hoa : s2(\"" + s2.MakeUpper() + "\")");
		System.out.println();
	
		// Xoa cac khoang trang o dau, cuoi chuoi
		System.out.println("Chuoi s1 sau khi cat bo cac ky tu trang dau chuoi: s1(\"" + s1.TrimLeft() + "\")");
		System.out.println("Chuoi s2 sau khi cat bo cac ky tu trang cuoi chuoi: s2(\"" + s2.TrimRight() + "\")");
		System.out.println();
		
		// Lay chuoi con trong 1 chuoi
		System.out.println("Lay 6 ky tu tu s1 bat dau tu vi tri 2 = \"" + s1.Mid(2,6) + "\"");
		System.out.println("Lay 7 ky tu dau tien cua s1 = \"" + s1.Left(7) + "\"");
		System.out.println("Lay 7 ky tu cuoi cung cua s1 = \"" + s1.Right(7) + "\"");
		System.out.println();
	
		// Tim chuoi con trong 1 chuoi
		System.out.println("Vi tri xuat hien dau tien cua chuoi \"ng\" trong chuoi s1 la " + s1.Find("ng"));
		System.out.println("Vi tri xuat hien cuoi cung cua chuoi \"ng\" trong chuoi s1 la " + s1.ReverseFind("ng"));
	}
}