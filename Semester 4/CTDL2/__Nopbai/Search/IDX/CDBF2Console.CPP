#include "CDBF2Console.h"
#include <iostream>
#include <iomanip>
#include <string>
using namespace std;
CDBF2Console::CDBF2Console(char *filename)
{
	m_strField = 0;
	m_strKey = 0;
	m_File.open(filename, ios_base::binary);
	if (m_File.fail())
	{
		cout << "Khong mo duoc file " << filename << " de doc" << endl;
		exit(1);
	}
	// Doc Header tu file
	m_File.read((char*) (&m_Header), SIZEHEADER);
	
	// Tinh so field
	if (m_Header.usPos % 2 == 0)
		m_ucNumField = (m_Header.usPos - SIZEHEADER - 263 - 1) / SIZEFIELD;	// - 1:	 byte ket thuc cua Header
	else
		m_ucNumField = (m_Header.usPos - SIZEHEADER - 1) / SIZEFIELD;	// - 1:	 byte ket thuc cua Header
									
	m_Field = new FIELD[m_ucNumField];

	// Doc cac Field Subrecords Structure tu file	
	for (int i = 0; i < m_ucNumField; ++i)
		m_File.read((char*) (&m_Field[i]), SIZEFIELD);
	
	// Doc Header record terminator
	char temp;
	m_File.read(&temp, 1);

	// Doc 263 byte neu duoc
	if (m_Header.usPos % 2 == 0)
		m_File.read(m_arrBackLink, 263);
}

CDBF2Console::~CDBF2Console()
{
	if (m_strField)
	{
		delete m_strField;
		m_strField = 0;
	}

	if (m_strKey)
	{
		delete m_strKey;
		m_strKey = 0;
	}
}
// Xuat noi dung cua record thu PosRec ra console
void CDBF2Console::WriteConsole(int PosRec)
{	
	char arrData[300];
	char cFlag;
	// Phan du lieu
	PosRec--;
	
	m_File.seekg((m_Header.usPos + PosRec * m_Header.usLenRec) - m_File.tellg(), ios_base::cur);	

	cout << setiosflags(ios::showpoint | ios::fixed);
	cout << "<RECORD No=\"" << (PosRec + 1) << "\">\n";		

	// Doc Flag		
	m_File.read(&cFlag, 1);		
	cout << "\t<DeleteFlag>\"" << cFlag << "\"\n";
	
	for (int j = 0; j < m_ucNumField; ++j)
	{	

		cout << "\t<" << m_Field[j].strName << "> ";

		switch (m_Field[j].cType)
		{			
		case 'B':
			{
				double temp;
				m_File.read((char*) (&temp), m_Field[j].ucLength);					
				cout << setprecision(m_Field[j].ucDecimal) << temp;
				break;
			}
		case 'I':
			{
				int temp;
				m_File.read((char*) (&temp), m_Field[j].ucLength);
				cout << temp;
				break;
			}				
		case 'D':
			m_File.read(arrData, m_Field[j].ucLength);
			cout << arrData[6] << arrData[7] << "/"; // Ngay
			cout << arrData[4] << arrData[5] << "/"; // Thang
			cout << arrData[0] << arrData[1] << arrData[2] << arrData[3]; // Nam
			break;
		default:
			m_File.read(arrData, m_Field[j].ucLength);
			arrData[m_Field[j].ucLength] = '\0';
			cout << arrData;
		}			
					
		cout << endl;
	}
	cout << "</RECORD>\n";
	
}

int CDBF2Console::SearchField(char *Field)
{
	for (int d = 0; d < m_ucNumField; ++d)
		if (strnicmp(m_Field[d].strName, Field, strlen(Field)) == 0)
			return d;
	
	return -1;
}

long CDBF2Console::Find(char *Field,char *key)
{
	m_iIndex = -1;
	if (m_strKey)
		delete m_strKey;

	m_strKey = new char[strlen(key) + 1];
	strcpy(m_strKey, key);

	if (m_strField)
		delete m_strField;

	m_strField = new char[strlen(key) + 1];
	strcpy(m_strField, key);
	
	
	// Khong co ten field tuong ung
	if (m_SField = SearchField(Field) == -1)	
	{
		m_iIndex = -1;
		return -1;
	}
	
	m_iIndex = 0;
	return FindNext();
}

long CDBF2Console::FindNext()
{
	if (m_iIndex == -1)
		return -1;

	char arrData[300];
	char cFlag;
	bool bTimThay = false;

	m_File.seekg((m_Header.usPos + m_iIndex * m_Header.usLenRec) - m_File.tellg(), ios_base::cur);	

	for (unsigned int i = m_iIndex; i < m_Header.ulNumRec; ++i)
	{
		// Doc Flag		
		m_File.read(&cFlag, 1);		
		
		for (int j = 0; j < m_ucNumField; ++j)
		{	
			switch (m_Field[j].cType)
			{			
			case 'B': // Sai
				{
					double temp;
					m_File.read((char*) (&temp), m_Field[j].ucLength);					
					break;
				}
			case 'I': // Sai
				{
					int temp;
					m_File.read((char*) (&temp), m_Field[j].ucLength);
					break;
				}				
			case 'D':
				m_File.read(arrData, m_Field[j].ucLength);
				break;
			default:
				m_File.read(arrData, m_Field[j].ucLength);
				arrData[m_Field[j].ucLength] = '\0';
			}			
						
			if (m_SField == j && strncmp(arrData, m_strKey, strlen(m_strKey)) == 0)
				bTimThay = true;
		}

		if (bTimThay == true)
		{
			m_iIndex = i + 1;
			return m_iIndex;
		}
	}

	return -1;
}