// Cap nhat 8/4/2007, 15:30
#ifndef _COLUOI
#define _COLUOI

#include <iostream.h>
// Chua kiem tra khi dung toan tu new (neu khong cap phat duoc thi bao loi)
class COLuoi
{
protected:
	int m_iDong; // So dong
	int m_iCot; // So cot
	int **m_arrDinh; // Bat dau tu dong 1, cot 1 tro di
					 // Dung kieu int de dung cho nhung lop con co nhu cau thay doi mang

	void KhoiTao(int m, int n, int **); // Khoi tao cac tham so 
	void ThuHoi(); // Thu hoi vung nho da cap phat cho m_arrDinh
public:
	COLuoi();
	COLuoi(int m, int n, int **A);
	COLuoi(const COLuoi&);
	virtual ~COLuoi();
	COLuoi& operator = (const COLuoi&);

	virtual int Input(char *);
	virtual int Output(char *) const;
	
	int LaySoDong(); // Lay so dong cua O luoi
	int LaySoCot(); // Lay so cot cua O luoi
	int GiaTriO(int i, int j); // Cho biet gia tri tai o (i, j)

	friend ostream& operator << (ostream&, const COLuoi&);		
};

#endif