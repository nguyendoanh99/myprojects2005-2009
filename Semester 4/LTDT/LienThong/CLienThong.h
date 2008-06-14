// Cap nhat 8/4/2007, 15:30

#ifndef _CLIENTHONG
#define _CLIENTHONG

#include "CDoThiMTK.h"
// Chua kiem tra khi dung toan tu new (neu khong cap phat duoc thi bao loi)
class CLienThong: public CDoThiMTK
{
private:
	int *m_arrNhanDinh; // arrNhanDinh[i] la nhan cua dinh i
	int m_iSoTPLT; // So thanh phan lien thong cua do thi

	void Visit(int iDinh, int iNhan); // Thu tuc de qui de tham tat ca cac dinh co nhan iNhan xuat phat tu dinh iDinh
	void XacDinhTPLT(); // Xac dinh thanh phan lien thong cua do thi
	void KhoiTao(int n); // Khoi tao cac tham so ban dau
	void KhoiTao_XacDinh(int n); // Khoi tao cac tham so ban dau va tim thanh phan lien thong
	void ThuHoi();
public:
	CLienThong();
	CLienThong(int n, int **A);
	CLienThong(const CDoThiMTK&);
	CLienThong(const CLienThong&);
	virtual ~CLienThong();

	CLienThong& operator=(const CLienThong&);
	CLienThong& operator=(const CDoThiMTK&);

	int SoTPLT() const; // So thanh phan lien thong cua do thi
	bool LaDoThiLT() const; // Kiem tra do thi co lien thong hay khong
	int TPLT(int t, int *&pKQ) const; // tra ve tong so dinh thuoc thanh phan lien thong thu t, pKQ nhan ve cac dinh
	int Output(char *) const;
	int Input(char *);

	friend ostream& operator <<(ostream&, const CLienThong&);
};

#endif