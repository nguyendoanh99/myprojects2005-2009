#ifndef _LNgay_
#define _LNgay_

class LNgay
{
private:
	int mNgay;
	int mThang;
	int mNam;	
	int ktNamNhuan(int Nam)
	{
		return (Nam%400==0)||((Nam%4==0)&&(Nam%100!=0));
	}
	int SoSanh(const LNgay& a)
	{
		if (mNam>a.mNam)
			return 1;
		if (mNam<a.mNam)
			return -1;
		if (mThang>a.mThang)
			return 1;
		if (mThang<a.mThang)
			return -1;
		if (mNgay>a.mNgay)
			return 1;
		if (mNgay<a.mNgay)
			return -1;
		return 0;
	}
public:
	void KhoiDong(int=1,int=1,int=2006);
	void KhoiDong(const LNgay&);
	int TuDauNam();
	long TuDauCN();
	long KhoangCach(LNgay &);
	int LaThu();
	LNgay NgayTL(unsigned);
	LNgay NgayQK(unsigned);
	void GanNgay(int);
	void GanThang(int);
	void GanNam(int);
	int DocNgay();
	int DocThang();
	int DocNam();
	void In();
};
#endif