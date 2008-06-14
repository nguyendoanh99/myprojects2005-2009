#ifndef _CDBF_H_
#define _CDBF_H_
#define SIZEHEADER 32
#define SIZEFIELD 32
class CDBF
{
protected:
	struct HEADER
	{		
		unsigned char ucFileType;
		struct 
		{
			unsigned char cYear;
			unsigned char cMonth;
			unsigned char cDay;
		} LastUpdate;
		unsigned long ulNumRec;
		unsigned short usPos;
		unsigned short usLenRec;
		unsigned char arrReserved[16];
		unsigned char ucFlag;
		unsigned char ucCodePageMark;
		char arrReserved_[2];
	} m_Header;

	unsigned char m_ucNumField;

	struct FIELD
	{		
		char strName[11];
		char cType;
		char arrDisplacement[4];		
		unsigned char ucLength;		
		unsigned char ucDecimal;	
		unsigned char ucFlag;
		char arrNext[4];
		char cStep;
		char arrReserved[8];		
	} *m_Field;

	char m_arrBackLink[263];
	char m_cOEM;
public:
	CDBF();
	virtual ~CDBF();
};

#endif