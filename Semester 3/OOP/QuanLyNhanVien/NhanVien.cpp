#include "NhanVien.h"

using namespace std;
char* NhanVien::DocTen() const
{
	return strdup(m_strTen);
}

void NhanVien::GanTen(char *s)
{	
	strcpy(m_strTen, s);
}

NhanVien::NhanVien(char *s)
{
	GanTen(s);
}

NhanVien::~NhanVien()
{
}

string NhanVien::InBCC() const 
{
	return string("\tBANG CHAM CONG\n") + string("Ten NV: ") + string(m_strTen);
}