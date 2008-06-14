// Cap nhat 8/4/2007, 15:30
#ifndef _CBANDODAO
#define _CBANDODAO

#include "COLuoi.h"
// Chua kiem tra khi dung toan tu new (neu khong cap phat duoc thi bao loi)
class CBanDoDao: public COLuoi
{
private:
	int m_iSoDao;

	void Try(int i, int j, int &iNhan); // Ham de qui de xac dinh mot dao bat dau tu vi tri (i, j)
	void TimDao();
	void KhoiTao();
	void PhucHoi(); // Sau khi tim duoc cac dao thi mang da thay doi, nen can phai phuc hoi trang thai cu cho mang
	
public:
	CBanDoDao();
	CBanDoDao(int m, int n, int **);
	CBanDoDao(const CBanDoDao&);
	CBanDoDao(const COLuoi&);
	CBanDoDao& operator = (const CBanDoDao&);
	virtual ~CBanDoDao();

	int Input(char *);
	int Output(char *) const;
	int SoDao(); // Cho biet co bao nhieu dao

	friend ostream& operator <<(ostream &os, const CBanDoDao&);
};

#endif