#ifndef _THAP_HA_NOI_
#define _THAP_HA_NOI_

#include "LStack.h"
#include "LHCNDac.h"

class LThapHN
{
private:
	int m_iSoDia;	// So dia can chuyen tu cot[0] sang cot[2] trong ThapHN
	LStack m_Cot[3]; // m_Cot[i] cho biet tai Cot[i] co may dia
	int m_arrCotX[3]; // Toa do x cua 3 cot
	int m_iDong; // Bien duoi cua Thap Ha Noi
	LHCNDac *m_Dia; // Mang chua kich thuoc cac dia
	
	void ChuyenDia(int iN, int iCot1, int iCot2); // Ham de qui de tim cach chuyen iN dia tu iCot1 sang iCot2
	void MacDinh(); // Tao cac toa do mac dinh de dat dia
	void DoiDia(int iCot1, int iCot2); // Mo ta cach di chuyen dia tren cung cua cot 1 sang cot 2
public:	
	LThapHN(int);
	virtual ~LThapHN();

	LThapHN& GanSoDia(int); // Thay doi so dia hien co
	void ThucHien();	// Thuc hien viec chuyen dia
};

#endif