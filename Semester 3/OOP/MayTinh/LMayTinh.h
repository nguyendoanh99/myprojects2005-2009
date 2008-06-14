#ifndef _LMAYTINH_
#define _LMAYTINH_

#include "LPhepTinh.h"
#include <iostream.h>
#include <vector>

class LMayTinh
{
private:
	std::vector<LPhepTinh *> m_DoiTuong;
	LPhepTinh* m_pt;
public:
	LMayTinh();
	~LMayTinh();
	
	void KhoiTao(float, float, int);
	float KetQua() const;
	int Nhap();
	friend ostream& operator<<(ostream&, const LMayTinh&);
};

#endif