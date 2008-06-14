// Ho ten: NGUYEN DANG KHOA
// MSSV: 0512175
// Lop: C1
// Ca thuc hanh: ca 2 chieu thu 6
#ifndef _CMYSTRING_H_
#define _CMYSTRING_H_

#include <iostream.h>

class CMyString
{
private:
	int m_iDoDai; // Chieu dai cua chuoi
	char *m_str; // Con tro chua dia chi cua chuoi

	
	CMyString(char *str, int); // Ham tao cho phep m_str dung chung vung nho ma str dang giu 
	void TaoChuoiRong();	
	char *LayChuoi(int, int) const;
public:
	CMyString();
	CMyString(const CMyString&);
	CMyString(char *);	
	CMyString(char, int = 1);
	virtual ~CMyString();

	bool operator==(const CMyString&) const;
	bool operator==(char *) const;
	bool operator>(const CMyString &) const;
	bool operator>(char *) const;
	bool operator>=(const CMyString &) const;
	bool operator>=(char *) const;
	bool operator<(const CMyString &) const;
	bool operator<(char *) const;
	bool operator<=(const CMyString &) const;
	bool operator<=(char *) const;
	CMyString operator+(const CMyString&) const;
	CMyString operator+(char *) const;
	CMyString& operator+=(const CMyString&);
	CMyString& operator+=(char *);
	char operator[](int);
	CMyString& operator=(const CMyString&);
	CMyString& operator=(char *);

	int GetLength() const;
	bool IsEmpty() const;
	void Empty();
	char GetAt(int) const;
	bool SetAt(int, char); // Neu gan ky tu thanh cong thi tra ve true, nguoc lai tra ve false

	int Compare(const CMyString&) const;
	int Compare(char *) const;
	int CompareNoCase(const CMyString&) const;
	int CompareNoCase(char *) const;

	CMyString Mid(int, int) const;
	CMyString Left(int) const;
	CMyString Right(int) const;

	CMyString& MakeUpper();
	CMyString& MakeLower();
	CMyString& TrimLeft();
	CMyString& TrimRight();

	int Find(const CMyString&) const;
	int Find(char *) const;
	int Find(char) const;
	int ReverseFind(const CMyString&) const;
	int ReverseFind(char *) const;
	int ReverseFind(char) const;

	friend ostream& operator<<(ostream&, const CMyString &);
	friend istream& operator>>(istream&, CMyString&);
};

#endif