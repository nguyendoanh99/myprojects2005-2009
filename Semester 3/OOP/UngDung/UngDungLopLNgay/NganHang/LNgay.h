#ifndef _LNgay_
#define _LNgay_

class LNgay
{
private:
	int mNgay;
	int mThang;
	int mNam;		
	int SoSanh(const LNgay& a);	
public:	
	void KhoiDong(int=1,int=1,int=2006);
	void KhoiDong(const LNgay&);

	int LaNamNhuan();
	int TuDauNam();
	long TuDauCN();
	long KhoangCach(LNgay &);
	int LaThu();
	LNgay NgayTL(unsigned);
	LNgay NgayQK(unsigned);

	void GanNgay(int);
	void GanThang(int);
	void GanNam(int);
	void Nhap();

	int DocNgay();
	int DocThang();
	int DocNam();
	void In();

};
#endif