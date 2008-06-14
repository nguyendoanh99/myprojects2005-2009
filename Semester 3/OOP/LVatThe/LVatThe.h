#ifndef _VAT_THE_
#define _VAT_THE_

#include "LHCN.h"

class LVatThe
{
private:
	LHCN *m_pBoPhan;
	LHCN m_Khung;
	int m_iSoBoPhan;
	void TaoKhung();
public:
	LVatThe();
	LVatThe(const LVatThe &);
	LVatThe(LHCN *, int);
	~LVatThe();

	LVatThe& operator =(const LVatThe&);
	void DichTrai(int = 1);
	void DichPhai(int = 1);
	void DichLen(int = 1);
	void DichXuong(int = 1);

	void In() const;
	void Xoa() const;
};

#endif