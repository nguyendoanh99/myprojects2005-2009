#include "CXML2DBF.h"
#include <string.h>
#include <afx.h>
#include "stdlib.h"
CXML2DBF::CXML2DBF(char *filename)
{
	char str[1000];
	m_File.open(filename, ios::in | ios::nocreate);
	if (m_File.fail())
	{
		cout << "Khong mo duoc file " << filename << " de doc";
		exit(1);
	}

	m_File.getline(str, 1000); // Doc <DBF>
	
	// ********************** Lay du lieu cua HEADER *********************
	m_File.getline(str, 1000); // Doc <HEADER>
	
	// Doc <FileType>
	m_File.getline(str, 1000); 
	LayDuLieu(str, "FileType", str);
	char *temp;
	m_Header.ucFileType = (unsigned char) strtoul(str, &temp, 16);

	// Doc <LastUpdate>
	m_File.getline(str, 1000); 
	LayDuLieu(str, "LastUpdate", str);
	str[2] = 0;
	str[5] = 0;
	m_Header.LastUpdate.cDay = atoi(str);
	m_Header.LastUpdate.cMonth = atoi(str + 3);
	m_Header.LastUpdate.cYear = atoi(str + 6);

	// Doc <NumRecord>
	m_File.getline(str, 1000);
	LayDuLieu(str, "NumRecord", str);
	m_Header.ulNumRec = strtoul(str, &temp, 10);

	// Doc <FirstRecord>
	m_File.getline(str, 1000);
	LayDuLieu(str, "FirstRecord", str);
	m_Header.usPos = (unsigned short) strtoul(str, &temp, 10);

	// Doc <LenRecord>
	m_File.getline(str, 1000);
	LayDuLieu(str, "LenRecord", str);
	m_Header.usLenRec = (unsigned short) strtoul(str, &temp, 10);

	// Doc <Reserved>
	m_File.getline(str, 1000);
	LayDuLieu(str, "Reserved", str);
	int len = strlen(str);
	str[len + 3] = 0;
	for (int i = 0; i < sizeof(m_Header.arrReserved); ++i)
	{
		strncpy(str + len + 1, &str[i * 2], 2);
		m_Header.arrReserved[i] = (unsigned char) strtoul(str + len + 1, &temp, 16);
	}

	// Doc <Flag>
	m_File.getline(str, 1000); 
	LayDuLieu(str, "Flag", str);
	m_Header.ucFlag = (unsigned char) strtoul(str, &temp, 16);

	// Doc <CodePageMark>
	m_File.getline(str, 1000); 
	LayDuLieu(str, "CodePageMark", str);
	m_Header.ucCodePageMark = (unsigned char) strtoul(str, &temp, 16);

	// Doc <Reserved_>
	m_File.getline(str, 1000);
	LayDuLieu(str, "Reserved_", str);
	len = strlen(str);
	str[len + 3] = 0;
	for (i = 0; i < sizeof(m_Header.arrReserved_); ++i)
	{
		strncpy(str + len + 1, &str[i * 2], 2);
		m_Header.arrReserved_[i] = (unsigned char) strtoul(str + len + 1, &temp, 16);
	}

	m_File.getline(str, 1000); // Doc </HEADER>

	// ********************** Lay du lieu cua FIELDS *********************
	m_File.getline(str, 1000); // Doc <FIELDS>
	
	// Doc <NumField>
	m_File.getline(str, 1000); 
	LayDuLieu(str, "NumField", str);
	m_ucNumField = (unsigned char) strtoul(str, &temp, 10);
	m_Field = new FIELD[m_ucNumField];

	// Doc cac <FIELD>
	for (i = 0; i < m_ucNumField; ++i)
	{
		m_File.getline(str, 1000); // Doc <FIELD No="i">

		// Doc <Name>
		m_File.getline(str, 1000); 
		memset(m_Field[i].strName, 0, sizeof(m_Field[i].strName));
		LayDuLieu(str, "Name", m_Field[i].strName);
		
		// Doc <Type>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "Type", str);
		m_Field[i].cType = str[0];

		// Doc <Displacement>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "Displacement", str);
		len = strlen(str);
		str[len + 3] = 0;
		for (int j = 0; j < sizeof(m_Field[i].arrDisplacement); ++j)
		{
			strncpy(str + len + 1, &str[j * 2], 2);
			m_Field[i].arrDisplacement[j] = (unsigned char) strtoul(str + len + 1, &temp, 16);
		}

		// Doc <Length>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "Length", str);
		m_Field[i].ucLength = (unsigned char) strtoul(str, &temp, 10);
		
		// Doc <NumDecimal>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "NumDecimal", str);
		m_Field[i].ucDecimal = (unsigned char) strtoul(str, &temp, 10);

		// Doc <Flag>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "Flag", str);
		m_Field[i].ucFlag = (unsigned char) strtoul(str, &temp, 16);
		
		// Doc <NextValue>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "NextValue", str);
		int iTemp = strtoul(str, &temp, 10);
		for (char d = 0; d < 4; ++d)
		{
			m_Field[i].arrNext[d] = (char) (0x000000ff & iTemp);
			iTemp >>= 8;
		}
		

		// Doc <StepValue>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "StepValue", str);
		m_Field[i].cStep = (char) strtoul(str, &temp, 10);

		// Doc <Reserved>
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "Reserved", str);
		len = strlen(str);
		str[len + 3] = 0;
		for (j = 0; j < sizeof(m_Field[i].arrReserved); ++j)
		{
			strncpy(str + len + 1, &str[j * 2], 2);
			m_Field[i].arrReserved[j] = (unsigned char) strtoul(str + len + 1, &temp, 16);
		}

		m_File.getline(str, 1000); // Doc </FIELD>
	}

	m_File.getline(str, 1000); // Doc </FIELDS>

	// Phan 263 byte
	if (m_Header.usPos % 2 == 0)
	{
		m_File.getline(str, 1000); 		
		LayDuLieu(str, "BackLink", str);
		len = strlen(str);
		str[len + 3] = 0;
		for (int j = 0; j < sizeof(m_arrBackLink); ++j)
		{
			strncpy(str + len + 1, &str[j * 2], 2);
			m_arrBackLink[j] = (char) strtoul(str + len + 1, &temp, 16);
		}
	}
}

CXML2DBF::~CXML2DBF()
{
}

int CXML2DBF::WriteDBF(char *filename)
{
	ofstream f;
	char str[1000];
	f.open(filename, ios::out | ios::binary);

	if (f.fail())
		return 0;
	
	// Ghi HEADER
	f.write((char *) (&m_Header), SIZEHEADER);

	// Ghi FIELDS
	for (unsigned char j = 0; j < m_ucNumField; ++j)
		f.write((char *) (&m_Field[j]), SIZEFIELD);

	// Phan 263 byte
	if (m_Header.usPos % 2 == 0)
	{
		f.write(m_arrBackLink, sizeof(m_arrBackLink));
	}

	// Ket thuc HEADER
	f.put((char) 0x0D);

	// ********************** Doc, Ghi du lieu cua RECORDS *********************
	m_File.getline(str, 1000); // Doc <RECORDS>

	for (unsigned int i = 0; i < m_Header.ulNumRec; ++i)
	{	
		m_File.getline(str, 1000); // Doc <RECORD No="i + 1">

		// Doc <Flag>
		m_File.getline(str, 1000);
		LayDuLieu(str, "Flag", str);
		f.write(str + 1, 1);

		for (unsigned char j = 0; j < m_ucNumField; ++j)
		{
			m_File.getline(str, 1000);
			LayDuLieu(str, m_Field[j].strName, str);
			switch (m_Field[j].cType)
			{
			case 'B':
				{
					char *t;
					double d = strtod(str, &t);
					f.write((char*) (&d), m_Field[j].ucLength);
					continue;
				}
			case 'I':
				{					
					int d = atoi(str);
					f.write((char*) (&d), m_Field[j].ucLength);
					continue;
				}
			case 'D':				
				// Chinh lai du lieu cho dung dinh dang cua DBF				
				strncpy(str + 11, str + 1, 5);
				strncpy(str + 1, str + 7, 4); // Nam
				strncpy(str + 5, str + 14, 2); // Thang 
				strncpy(str + 7, str + 11, 2); // Ngay				
				break;
			}

			f.write(str + 1, m_Field[j].ucLength);
		}		

		m_File.getline(str, 1000); // Doc </RECORD>
	}

	m_File.getline(str, 1000); // Doc </RECORDS>
	m_File.getline(str, 1000);
	// Co ky tu ket thuc file
	if (strstr(str, "<OEM>"))
	{
		char *temp;
		LayDuLieu(str, "EOM", str);
		m_cOEM = (char) strtoul(str, &temp, 16);
		f.put(m_cOEM);

		m_File.getline(str, 1000); // Doc </DBF>
	}
	return 1;
}

int CXML2DBF::LayDuLieu(char *s, char *element, char *kq)
{
	CString t(strchr(s, '>') + 1);
	char temp[300];
	sprintf(temp, "</%s>", element);

	t = t.Mid(0, t.ReverseFind('>') - strlen(element) - 2);
	t.Replace("&apos;", "'");
	t.Replace("&amp;", "&");
	t.Replace("&gt;", ">");
	t.Replace("&lt;", "<");
	t.Replace("&quot;", "\"");
	t.TrimLeft();
	t.TrimRight();
	strcpy(kq, t.GetBuffer(t.GetLength() + 1));
	
	return 1;
}