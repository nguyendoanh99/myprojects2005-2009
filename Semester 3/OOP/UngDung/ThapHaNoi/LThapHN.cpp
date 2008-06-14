#include "LThapHN.h"
#include "iostream.h"
#include <conio.h>

#define tgCho 100 // Thoi gian cho de thuc hien 1 buoc dich dia
bool Dung = false;

void LThapHN::MacDinh()
{
	m_arrCotX[0] = 20;
	m_arrCotX[1] = 40;
	m_arrCotX[2] = 60;	
}

LThapHN::LThapHN(int iSoDia)
{
	m_iSoDia = iSoDia;
	MacDinh();
	// Xay dung bien duoi cua ThapHN
	m_iDong = ((25 - (m_iSoDia + 3)) / 2) + (m_iSoDia + 3);
	
	m_Dia = new LHCNDac[m_iSoDia];

	for (int i = m_iSoDia - 1; i >= 0; --i)
	{
		int j = (m_iSoDia - i - 1);
		// Tao Dia thu i voi toa do va kich thuoc cho truoc
		m_Dia[i] = LHCNDac(m_arrCotX[0] - m_iSoDia + 1 + j, m_iDong - j, i * 2 + 1, 1, 15 - i);	
		// Dua cac dia vao cot 0
		m_Cot[0].Push(m_Dia + i);
	}	
}

LThapHN::~LThapHN()
{
	delete m_Dia;
}

void LThapHN::DoiDia(int iCot1, int iCot2)
{	
	// Neu nhan phim ESC thi dung chuong trinh
	if (Dung || (kbhit() && getch() == 27))
	{
		Dung = true;
		return;
	}

	LHCNDac* p = (LHCNDac*) m_Cot[iCot1].Pop();
	// Minh hoa cach di chuyen dia tu iCot1 sang iCot2
	// Di chuyen dia o iCot1 di len
	while (p->DocY() > m_iDong - m_iSoDia - 2)
	{
		Sleep(tgCho);
		p->Xoa();
		p->DichLen();
		p->In();
	}
	// Neu nhan phim ESC thi dung chuong trinh
	if (Dung || (kbhit() && getch() == 27))
	{
		Dung = true;
		return;
	}

	// Di chuyen dia o iCot1 di ngang qua ben cot iCot2
	int i = abs(m_arrCotX[iCot1] - m_arrCotX[iCot2]);
	
	while (i)
	{
		Sleep(tgCho / 3);
		p->Xoa();
		if (m_arrCotX[iCot1] < m_arrCotX[iCot2])
			p->DichPhai();
		else
			p->DichTrai();
		p->In();
		--i;
	}

	// Neu nhan phim ESC thi dung chuong trinh
	if (Dung || (kbhit() && getch() == 27))
	{
		Dung = true;
		return;
	}

	// Di chuyen dia do di xuong cot iCot2 den vi tri thich hop	
	int iDich = m_iDong;
	
	if (!m_Cot[iCot2].IsEmpty())	
	{
		LHCNDac* q = (LHCNDac*) m_Cot[iCot2].GetInfo();
		iDich = q->DocY() - 1;
	}
	
	while (p->DocY() < iDich)
	{
		Sleep(tgCho);
		p->Xoa();
		p->DichXuong();
		p->In();
	}
	// Dua dia o cot iCot1 sang cot iCot2 (Stack)
	m_Cot[iCot2].Push(p);
}

void LThapHN::ChuyenDia(int iN, int iCot1, int iCot2)
{	
	if (iN == 0)
		return;
	// Dieu kien dung cua chuong trinh	
	if (Dung)
		return;

	ChuyenDia(iN - 1, iCot1, 3 - iCot1 - iCot2);
	// Dieu kien dung cua chuong trinh
	if (Dung)
		return;

	DoiDia(iCot1, iCot2);
	// Dieu kien dung cua chuong trinh
	if (Dung)
		return;

	ChuyenDia(iN - 1, 3 - iCot1 - iCot2, iCot2);
}

void LThapHN::ThucHien()
{
	for (int j = 0; j < 3; ++j)
	{
		gotoxy(m_arrCotX[j], m_iDong + 1);
		cout << "T" <<endl;
	}
	
	for (int i = 0; i < m_iSoDia; ++i)
		m_Dia[i].In();

	getch();

	ChuyenDia(m_iSoDia, 0, 2);
}