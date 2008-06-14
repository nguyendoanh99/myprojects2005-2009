// Cap nhat 8/4/2007, 15:30
#ifndef _CDOTHIMTK
#define _CDOTHIMTK

#include <iostream.h>
// Chua kiem tra khi dung toan tu new (neu khong cap phat duoc thi bao loi)
class CDoThiMTK
{	
private:	
	int m_iSoDinh; // So dinh cua do thi
	int **m_arrDinh;	// Bieu dien do thi bang ma tran ke. Bat dau tu dinh 1
						// Dung kieu int vi dung cho do thi co trong so

	int TaoDoThi(int n, int **A);
	void ThuHoi(); // Thu hoi vung nho ma m_arrDinh tro toi

public:
	CDoThiMTK();
	CDoThiMTK(int n, int **A);
	
	CDoThiMTK(const CDoThiMTK&);
	virtual ~CDoThiMTK();

	CDoThiMTK& operator = (const CDoThiMTK&);
	
	int Tao(int n, int **A); // Tao du lieu moi cho do thi

	virtual int Input(char *); // Doc do thi thong qua file
	virtual int Output(char *) const; // Ghi do thi vao file

	int LaySoDinh() const; // Cho biet so dinh cua do thi
	int LayCanhNoi(int i, int j) const; // Cho biet trong so giua dinh i va dinh j, 
										// neu giua 2 dinh khong co canh noi thi tra ve 0
	friend ostream& operator << (ostream &, const CDoThiMTK&);	
};

#endif