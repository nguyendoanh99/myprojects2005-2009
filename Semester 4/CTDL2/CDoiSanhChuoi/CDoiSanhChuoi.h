// Cap nhat 8/4/2007, 15:55
#ifndef _CDOISANHCHUOI
#define _CDOISANHCHUOI

class CDoiSanhChuoi
{
protected:
	char *m_strT;
	char *m_strP;
public:
	CDoiSanhChuoi();
	CDoiSanhChuoi(char *T, char *P);
	CDoiSanhChuoi(const CDoiSanhChuoi&);
	CDoiSanhChuoi& operator = (const CDoiSanhChuoi&);
	virtual ~CDoiSanhChuoi();	

	virtual int ViTriTimThay(int iBatDau = 0) = 0; // Tra ve vi tri tim thay dau tien cua chuoi P trong chuoi T
													// Khong tim thay tra ve -1, vi tri bat dau tim kiem trong 
													// chuoi T la iBatDau
	char *LayT();
	char *LayP();
	void GanT(char *T);
	virtual void GanP(char *P);
};

#endif
