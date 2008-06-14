#ifndef _LLOAIPHONG_
#define _LLOAIPHONG_

#define GIA_A 80
#define GIA_B 60
#define GIA_C 40
#define MUC_GIAM 10
#define SO_NGAY_GIAM 5
#define LOAI_A 1
#define LOAI_B 2
#define LOAI_C 3
#include <string>

using namespace std;

class LLoaiPhong
{
private:
	int m_iSoNgay;
	
public:
	virtual ~LLoaiPhong();
	LLoaiPhong(int = 1);
	
	int DocSoNgay();
	int GanSoNgay(int);
	virtual int TinhTien() = 0;
	virtual void Nhap();
	virtual string Xuat();
	virtual int LoaiPhong() = 0;
};

#endif