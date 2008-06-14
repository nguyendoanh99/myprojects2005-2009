#ifndef _L_HINH_CHU_NHAT_H_
#define	_L_HINH_CHU_NHAT_H_

class LHinhChuNhat
{
private:
	int mX;		// 1 <= mX <= 79 - mNgang
	int mY;		// 1 <= mY <= 23 - mDoc
	int mNgang; // 1 <= mNgang <= 78
	int mDoc;	// 1 <= mDoc <= 22
	int mMau;	// 0 <= mMau <= 15

public:	
	// KhoiDong(mX, mY, mNgang, mDoc, mMau);
	void KhoiDong(int = 1, int = 1, int = 1, int = 1, int = 15);
	void KhoiDong(const LHinhChuNhat&);

	int DocX();
	int DocY();
	int DocNgang();
	int DocDoc();
	int DocMau();
	
	void GanX(int);
	void GanY(int);
	void GanXY(int, int);
	void GanNgang(int);
	void GanDoc(int);
	void GanMau(int);
	void GanNgangDoc(int, int);

	void DichTrai(int = 1);
	void DichPhai(int = 1);
	void DichLen(int = 1);
	void DichXuong(int = 1);
	void In();
	void Xoa();
};

#endif