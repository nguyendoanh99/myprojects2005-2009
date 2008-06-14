// Ho ten: NGUYEN DANG KHOA
// MSSV: 0512175
// Lop: C1
// Ca thuc hanh: ca 2 chieu thu 6
#define CHIEU_DAI_MAC_DINH 1000 // chieu dai mac dinh cua chuoi khi nhap tu ban phim

#include "CMyString.h"
#include <string.h>
#include <stdlib.h>

char* CMyString::LayChuoi(int iBatDau, int iDoDai) const
{
	char *strKQ;
	// Neu iBatDau nam ngoai pham vi hoat dong cua chuoi thi ket qua tra ve la chuoi rong
	if (iBatDau < 0 || iBatDau > m_iDoDai - 1 || iDoDai <= 0)
	{
		strKQ = new char[1];
		strKQ[0] = 0;		
	}
	else
	{
		// Tai vi tri iBatDau, neu so ky can lay nhieu hon so ky tu trong chuoi
		// thi lay chuoi tu iBatDau den het chuoi
		if (iDoDai + iBatDau > m_iDoDai)
			iDoDai = m_iDoDai - iBatDau;
		
		strKQ = new char[iDoDai + 1];
		// Neu con du bo nho thi thuc hien
		if (strKQ)
		{
			for (int i = iBatDau; i < iBatDau + iDoDai; ++i)
				strKQ[i - iBatDau] = m_str[i];
			strKQ[iDoDai] = 0;
		}		
	}

	return strKQ;
}

void CMyString::TaoChuoiRong()
{
	m_iDoDai = 0;
	m_str = new char[1];
	m_str[0] = 0;
}

CMyString::CMyString(char *str, int)
{
	m_iDoDai = strlen(str);
	m_str = str;
}

CMyString::CMyString()
{
	TaoChuoiRong();
}

CMyString::CMyString(const CMyString &P)
{
	m_iDoDai = P.m_iDoDai;
	m_str = new char[m_iDoDai + 1];	
	// Neu khong con du bo nho de cap phat thi tao chuoi rong
	// nguoc lai thuc hien viec sao chep 2 chuoi
	if (m_str)
		strcpy(m_str, P.m_str);	
	else
		TaoChuoiRong();
}

CMyString::CMyString(char *str)
{
	// Neu str la chuoi thi thuc hien tao chuoi tu str
	// nguoc lai tao chuoi rong
	if (str)
	{
		m_iDoDai = strlen(str);
		m_str = new char[m_iDoDai + 1];	
		// Neu khong con du bo nho de cap phat thi tao chuoi rong
		// nguoc lai thuc hien sao chep 2 chuoi
		if (m_str)
			strcpy(m_str, str);
		else
			TaoChuoiRong();
	}
	else
		TaoChuoiRong();
}

CMyString::CMyString(char c, int n)
{
	if (n >= 0)
	{
		m_iDoDai = n;
		m_str = new char[n + 1];
		// Neu khong con du bo nho de cap phat thi tao chuoi rong
		// nguoc lai thuc hien viec tao chuoi gom n ky tu c giong nhau
		if (m_str)
		{
			m_str[n] = 0;
			strset(m_str, c);
		}
		else
			TaoChuoiRong();
	}
	else
		TaoChuoiRong();
}

CMyString::~CMyString()
{
	delete m_str;	
}

bool CMyString::operator==(const CMyString& P) const
{
	return (strcmp(m_str, P.m_str) == 0);
}

bool CMyString::operator==(char *str) const
{
	// Neu str la 1 chuoi thi kiem tra
	if (str)
		return (strcmp(m_str, str) == 0);	

	return false;
}

bool CMyString::operator>(const CMyString &P) const
{
	return (strcmp(m_str, P.m_str) > 0);
}

bool CMyString::operator>(char *str) const
{
	// Neu str la 1 chuoi thi kiem tra
	if (str)
		return (strcmp(m_str, str) > 0);

	return false;
}

bool CMyString::operator>=(const CMyString &P) const
{	
	return ( strcmp(m_str, P.m_str) >= 0);
}

bool CMyString::operator>=(char *str) const
{
	// Neu str la 1 chuoi thi kiem tra
	if (str)
		return (strcmp(m_str, str) >= 0);

	return false;
}
bool CMyString::operator<(const CMyString &P) const
{
	return (strcmp(m_str, P.m_str) < 0);
}

bool CMyString::operator<(char *str) const
{
	// Neu str la 1 chuoi thi kiem tra
	if (str)
		return (strcmp(m_str, str) < 0);

	return false;
}

bool CMyString::operator<=(const CMyString &P) const
{
	return (strcmp(m_str, P.m_str) <= 0);
}

bool CMyString::operator<=(char *str) const
{
	// Neu str la 1 chuoi thi kiem tra
	if (str)
		return (strcmp(m_str, str) <= 0);

	return false;
}

CMyString CMyString::operator+(const CMyString& P) const
{
	char *strKQ = new char[m_iDoDai + P.m_iDoDai + 1];
	// Neu khong con du bo nho de cap phat thi thoat ra 
	// nguoc lai thuc hien phep cong 2 chuoi
	if (strKQ)
	{
		strcpy(strKQ, m_str);
		strcat(strKQ, P.m_str);		
	}
	
	return CMyString(strKQ, 1);
}

CMyString CMyString::operator+(char *str) const
{	
	int iLen;
	// Kiem tra xem str co phai la 1 chuoi khong
	if (str)
		iLen = strlen(str);
	else
		iLen = 0;

	char *strKQ = new char[m_iDoDai + iLen + 1];
	// Neu khong con du bo nho de cap phat thi thoat
	// nguoc lai thuc hien phep cong 2 chuoi
	if (strKQ)
	{
		strcpy(strKQ, m_str);
		// Neu str dung la 1 chuoi thi thuc hien ham noi 2 chuoi lai
		if (str)
			strcat(strKQ, str);
	}

	return CMyString(strKQ, 1);
}

CMyString& CMyString::operator+=(const CMyString& P)
{
	m_iDoDai += P.m_iDoDai;
	char *strKQ = new char[m_iDoDai + 1];
	// Neu khong con du bo nho de cap phat thi thoat
	// nguoc lai thuc hien phep cong don chuoi P vao chuoi m_str
	if (strKQ)
	{
		strcpy(strKQ, m_str);
		strcat(strKQ, P.m_str);
		delete m_str;
		m_str = strKQ;
	}

	return *this;
}

CMyString& CMyString::operator+=(char *str)
{
	// Neu str dung la 1 chuoi thi moi thuc hien viec cong chuoi
	if (str)
	{
		m_iDoDai += strlen(str);
		char *strKQ = new char[m_iDoDai + 1];
		// Neu khong con du bo nho de cap phat thi thoat
		// nguoc lai thuc hien phep cong don chuoi str vao chuoi m_str
		if (strKQ)
		{
			strcpy(strKQ, m_str);
			strcat(strKQ, str);
			delete m_str;
			m_str = strKQ;
		}
	}

	return *this;
}

char CMyString::operator[](int iViTri)
{
	// Neu iViTri nam ngoai gioi han cua mang thi 
	// dua iViTri ve gia tri bien gan nhat so voi iViTri ban dau
	iViTri = __max(iViTri, 0);
	iViTri = __min(iViTri, m_iDoDai - 1);

	return  m_str[iViTri];
}

CMyString& CMyString::operator=(const CMyString& P)
{
	// Ngan chan phep gan voi P chinh la doi tuong goi ham
	if (m_str != P.m_str)
	{
		if (P.m_iDoDai > m_iDoDai)
		{	
			char *strKQ = new char[P.m_iDoDai + 1];
			// Neu khong con du bo nho de cap phat thi thoat
			// nguoc lai thuc hien phep gan chuoi
			if (strKQ)
			{
				delete m_str;			
				m_str = strKQ;
			}
			else
				return *this;
		}
		
		m_iDoDai = P.m_iDoDai;
		strcpy(m_str, P.m_str);
	}

	return *this;	
}

CMyString& CMyString::operator=(char *str)
{
	// Neu st la 1 chuoi thi thuc hien
	if (str)
	{
		int iLen = strlen(str);
		if (iLen > m_iDoDai)
		{
			char *strKQ = new char[iLen + 1];
			// Neu khong con du bo nho de cap phat thi thoat
			// nguoc lai thuc hien phep gan chuoi
			if (strKQ)
			{
				delete m_str;			
				m_str = strKQ;
			}
			else
				return *this;
		}
		
		m_iDoDai = iLen;
		strcpy(m_str, str);
	}
	
	return *this;
}

int CMyString::GetLength() const
{
	return m_iDoDai;
}

bool CMyString::IsEmpty() const
{
	return m_iDoDai == 0;
}

void CMyString::Empty()
{
	if (m_iDoDai > 0)
		delete m_str;

	TaoChuoiRong();
}

char CMyString::GetAt(int iViTri) const
{
	// Neu iViTri nam ngoai gioi han cua mang thi 
	// dua iViTri ve gia tri bien gan nhat so voi iViTri ban dau
	iViTri = __max(iViTri, 0);
	iViTri = __min(iViTri, m_iDoDai - 1);

	return m_str[iViTri];
}

bool CMyString::SetAt(int iViTri, char c)
{
	if (iViTri >= 0 && iViTri < m_iDoDai)
	{
		m_str[iViTri] = c;
		return true;
	}

	return true;
}

int CMyString::Compare(const CMyString& P) const
{
	return Compare(P.m_str);
}

int CMyString::Compare(char *str) const
{
	// Neu str la chuoi thi thuc hien phep so sanh	
	if (str)
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

int CMyString::CompareNoCase(const CMyString& P) const
{
	return CompareNoCase(P.m_str);	
}

int CMyString::CompareNoCase(char *str) const
{
	// Neu str la chuoi thi thuc hien phep so sanh	
	if (str)
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

CMyString CMyString::Mid(int iBatDau, int iDoDai) const
{	
	return CMyString(LayChuoi(iBatDau, iDoDai), 1);
}

CMyString CMyString::Left(int iDoDai) const
{
	return CMyString(LayChuoi(0, iDoDai), 1);	
}

CMyString CMyString::Right(int iDoDai) const
{
	// Neu so ky tu can lay nhieu hon so ky tu ma chuoi dang co thi lay tat ca cac
	// ky tu co trong chuoi
	if (iDoDai > m_iDoDai)
		return CMyString(LayChuoi(0,iDoDai), 1);

	return CMyString(LayChuoi(m_iDoDai - iDoDai, iDoDai), 1);
}

CMyString& CMyString::MakeUpper()
{
	strupr(m_str);
	return *this;
}

CMyString& CMyString::MakeLower()
{
	strlwr(m_str);
	return *this;
}

CMyString& CMyString::TrimLeft()
{
	// Tim vi tri dau tien ma tai do ky khac khoang trang tinh tu trai qua phai
	for (int i = 0; i < m_iDoDai &&  m_str[i] == ' '; ++i);
	
	// Di chuyen cac ky tu tu vi tri i ve dau chuoi
	if (i != 0)
	{
		if (i != m_iDoDai)		
		{		
			for (int j = i; j <= m_iDoDai; ++j)
				m_str[j - i] = m_str[j];		

			m_iDoDai = m_iDoDai - i;
		}
		else // Neu chuoi toan la khoang trang thi xoa chuoi va tao chuoi rong
		{
			delete m_str;
			TaoChuoiRong();
		}
	}	

	return *this;
}

CMyString& CMyString::TrimRight()
{
	// Tim ky tu dau tien khac khoang trang tinh tu phai qua trai
	for (int i = m_iDoDai - 1; i >= 0 && m_str[i] == ' '; --i);
	// Neu toan bo chuoi la khoang trang thi tao chuoi rong
	if (i < 0)
	{
		delete m_str;
		TaoChuoiRong();
	}
	else
	{
		m_str[i + 1] = 0;
		m_iDoDai = i;
	}

	return *this;
}

int CMyString::Find(const CMyString& P) const
{
	return Find(P.m_str);
}

int CMyString::Find(char *str) const
{
	// Neu str la chuoi thi thuc hien tim kiem
	if (str)
	{
		char *p = strstr(m_str, str);
		if (p)
			return (p - m_str) / sizeof(char);
	}

	return -1;
}

int CMyString::Find(char c) const
{
	char *p = strchr(m_str, c);
	if (p)
		return (p - m_str) / sizeof(char);

	return -1;
}

int CMyString::ReverseFind(const CMyString& P) const
{
	return ReverseFind(P.m_str);
}

int CMyString::ReverseFind(char *str) const
{	
	// Neu str la chuoi thi thuc hien tim kiem
	if (str)
	{
		char *p = strstr(m_str, str);
		char *q = NULL;
		
		while (p)
		{	
			q = p;
			++p;
			p = strstr(p, str);

		}

		if (q)
			return (q - m_str) / sizeof(char);
	}

	return -1;
}

int CMyString::ReverseFind(char c) const
{
	char *p = strrchr(m_str, c);
	if (p)
		return (p - m_str) / sizeof(char);

	return -1;
}

ostream& operator<<(ostream& os, const CMyString &P)
{
	os << P.m_str;
	return os;
}

istream& operator>>(istream& is, CMyString& P)
{
	char str[CHIEU_DAI_MAC_DINH];
	is.getline(str, CHIEU_DAI_MAC_DINH);

	P = str;
	return is;
}