#ifndef _PHEPTINH_
#define _PHEPTINH_

class LPhepTinh
{
protected:
	float m_fSoHang1;
	float m_fSoHang2;
public:
	LPhepTinh(float, float);
	LPhepTinh();
	virtual ~LPhepTinh();

	virtual float TinhToan() = 0;
	virtual LPhepTinh* TaoDoiTuong(float, float) = 0;
	virtual char* TenDoiTuong() = 0;
};

#endif