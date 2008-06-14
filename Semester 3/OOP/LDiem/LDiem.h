#ifndef _LDIEM_H_
#define _LDIEM_H_

#include <windows.h>
class LDiem
{
private:
	int mX;
	int mY;
	int mMau;
	unsigned char mKyTu;
	
public:
	LDiem(unsigned char = 'A', int x = 1, int y = 1, int mau = 0);
	LDiem(const LDiem&);

	void GanX(int);
	void GanY(int);
	void GanXY(int x, int y);
	void GanMau(int);
	void GanKyTu(unsigned char);

	int DocX() const;
	int DocY() const;
	int DocMau() const;
	unsigned char DocKyTu() const;
	void In() const;
	void Xoa() const;

	void DichTrai(int = 1);
	void DichPhai(int = 1);
	void DichLen(int = 1);
	void DichXuong(int = 1);
};

void gotoxy(short x, short y);
void SetColor(WORD color);

#endif