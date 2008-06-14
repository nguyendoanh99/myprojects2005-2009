#include "CDBF2XML.h"
#include <iostream.h>
#include <iomanip.h>
#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>

CDBF2XML::CDBF2XML(char *filename)
{
	m_File.open(filename, ios::binary | ios::in | ios::nocreate);
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

CDBF2XML::~CDBF2XML()
{
}

int CDBF2XML::WriteXML(char *filename)
{	
	char arrData[300];
	char cFlag;
	ofstream f;
	f.open(filename);

	if (f.fail())
		return 0;

	f << "<DBF>\n";
	
	// Phan header
	f << "\t<HEADER>\n";
	f << "\t\t<FileType>0x" << hex << setw(2) << setfill('0') << (int) m_Header.ucFileType << "</FileType>\n";
	
	f << "\t\t<LastUpdate>" 
		<< dec << setw(2) << (int) m_Header.LastUpdate.cDay << "/" 
		<< setw(2) << (int) m_Header.LastUpdate.cMonth << "/"
		<< setw(2) << (int) m_Header.LastUpdate.cYear 
		<<"</LastUpdate>\n";

	f << "\t\t<NumRecord>" << m_Header.ulNumRec << "</NumRecord>\n";
	f << "\t\t<FirstRecord>" << m_Header.usPos << "</FirstRecord>\n";
	f << "\t\t<LenRecord>" << m_Header.usLenRec << "</LenRecord>\n";

	f << "\t\t<Reserved>" << hex;
	// Xuat theo kieu hex
	for (int d = 0; d < sizeof(m_Header.arrReserved); ++d)
		f << setw(2) << (int) m_Header.arrReserved[d];
	f << "</Reserved>\n";

	f << "\t\t<Flag>0x"<< setw(2) << (int) m_Header.ucFlag << "</Flag>\n";
	f << "\t\t<CodePageMark>0x" << setw(2) << (int) m_Header.ucCodePageMark << "</CodePageMark>\n";
	f << "\t\t<Reserved_>";
	// Xuat theo kieu hex
	for (d = 0; d < sizeof(m_Header.arrReserved_); ++d)
		f << setw(2) << (int) m_Header.arrReserved_[d];
	f << "</Reserved_>\n";

	f << "\t</HEADER>\n";

	// Phan mo ta field
	f << "\t<FIELDS>\n";
	f << "\t\t<NumField>" << dec << (int) m_ucNumField << "</NumField>\n";
	for (d = 0; d < m_ucNumField; ++d)
	{
		f << "\t\t<FIELD No=\"" << dec << (d + 1) << "\">\n";

		f << "\t\t\t<Name>" << m_Field[d].strName << "</Name>\n";
		f << "\t\t\t<Type>" << m_Field[d].cType << "</Type>\n";
		
		f << "\t\t\t<Displacement>" << hex;
		for (int i = 0; i < 4; ++i)
			f << hex << setw(2) << (int) m_Field[d].arrDisplacement[i];
		f << "</Displacement>\n";

		f << "\t\t\t<Length>" << dec << (int) m_Field[d].ucLength << "</Length>\n";
		f << "\t\t\t<NumDecimal>" << (int) m_Field[d].ucDecimal << "</NumDecimal>\n";
		f << "\t\t\t<Flag>0x" << hex << setw(2) << (int) m_Field[d].ucFlag << "</Flag>\n";

		// Chuyen so he 16 --> he 10
		int iNext = 0;
		for (int j = 3; j >= 0; --j)
		{
			iNext <<= 8;
			iNext |= (m_Field[d].arrNext[j] & 0x000000ff);
		}

		f << "\t\t\t<NextValue>" << dec << iNext << "</NextValue>\n";
		f << "\t\t\t<StepValue>" << (int) m_Field[d].cStep << "</StepValue>\n";

		f << "\t\t\t<Reserved>" << hex;
		// Xuat theo kieu hex
		for (i = 0; i < 8; ++i)
			f << setw(2) << (int) m_Field[d].arrReserved[i];
		f << "</Reserved>\n";

		f << "\t\t</FIELD>\n" << dec;
	}
	f << "\t</FIELDS>\n";

	// Phan 263 byte
	if (m_Header.usPos % 2 == 0)
	{
		f << "\t<BACKLINK>" << hex;
		// Xuat theo kieu hex
		for (int d = 0; d < sizeof(m_arrBackLink); ++d)
			f << setw(2) << (int) m_arrBackLink[d];
		f << "</BACKLINK>\n" << dec;
	}


	// Phan du lieu
	f << "\t<RECORDS>\n";
	
	f << setiosflags(ios::showpoint | ios::fixed);
	for (unsigned int i = 0; i < m_Header.ulNumRec; ++i)
	{	
		f << "\t\t<RECORD No=\"" << (i + 1) << "\">\n";		

		// Doc Flag		
		m_File.read(&cFlag, 1);		
		f << "\t\t\t<Flag>\"" << cFlag << "\"</Flag>\n";
		
		for (int j = 0; j < m_ucNumField; ++j)
		{	

			f << "\t\t\t<" << m_Field[j].strName << "> ";

			switch (m_Field[j].cType)
			{			
			case 'B':
				{
					double temp;
					m_File.read((char*) (&temp), m_Field[j].ucLength);					
					f << setprecision(m_Field[j].ucDecimal) << temp;
					break;
				}
			case 'I':
				{
					int temp;
					m_File.read((char*) (&temp), m_Field[j].ucLength);
					f << temp;
					break;
				}				
			case 'D':
				m_File.read(arrData, m_Field[j].ucLength);
				f << "&quot;" << arrData[6] << arrData[7] << "/"; // Ngay
				f << arrData[4] << arrData[5] << "/"; // Thang
				f << arrData[0] << arrData[1] << arrData[2] << arrData[3] << "&quot;"; // Nam
				break;
			default:
				m_File.read(arrData + 1, m_Field[j].ucLength);
				arrData[0] = '\"';			
				arrData[m_Field[j].ucLength + 1] = '\"';
				arrData[m_Field[j].ucLength + 2] = '\0';
				for (int i = 0; i < strlen(arrData); ++i)
				{
					switch (arrData[i])
					{
					case '&':
						f << "&amp;";
						break;
					case '<':
						f << "&lt;";
						break;
					case '>':
						f << "&gt;";
						break;
					case '\"':
						f << "&quot;";
						break;
					case '\'':
						f << "&apos;";
						break;
					default:
						f << arrData[i];				
						break;
					}							
				}			
			}			
			
			f << "</" << m_Field[j].strName << ">\n";
		}
		f << "\t\t</RECORD>\n";
	}
	f << "\t</RECORDS>\n";

	if (m_File.read(&m_cOEM, 1) == 0)
		m_cOEM = 0;
	else
	{
		f << "\t<OEM>0x" << hex << setw(2) << (int) m_cOEM << "</OEM>\n";
	}

	f << "</DBF>";

	return 1;
}