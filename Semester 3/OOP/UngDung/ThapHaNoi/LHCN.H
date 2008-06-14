//#ifndef _L_HINH_CHU_NHAT_H_
//#define	_L_HINH_CHU_NHAT_H_

#include "LDiem.h"

class LHCN
{
private:
	LDiem mGoc;
	int mRong; // 1 <= mRong <= 78
	int mDai;	// 1 <= mDai <= 22

public:	
	
	LHCN(int iX = 1, int iY = 1, int iRong = 1, int iDai = 1, int mMau = 15);
	LHCN(const LDiem& , int iRong = 1, int iDai = 1);
	LHCN(const LDiem& Diem1, const LDiem& Diem2);
	LHCN(const LHCN&);

	int DocX() const;
	int DocY() const;
	int DocRong() const;
	int DocDai() const;
	int DocMau() const;
	LDiem DocGoc() const;
	void In() const;
	void Xoa() const;
	
	void GanX(int);
	void GanY(int);
	void GanXY(int iX, int iY);
	void GanRong(int);
	void GanDai(int);	
	void GanGoc(const LDiem&);
	void GanMau(int);

	void DichTrai(int = 1);
	void DichPhai(int = 1);
	void DichLen(int = 1);
	void DichXuong(int = 1);	
};

//#endif