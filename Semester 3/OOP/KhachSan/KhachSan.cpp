#include <iostream>
#include "KhachSan.h"
#include "LLoaiA.h"
#include "LLoaiB.h"
#include "LLoaiC.h"

KhachSan::~KhachSan()
{
	for (int i = 0; i < m_Phong.size(); ++i)
		delete m_Phong[i];
}
/*
void Nhap()
{
}
*/
int KhachSan::TinhTienPhong(int i)
{
	if (i >= 0 && i < m_Phong.size())
		return m_Phong[i]->TinhTien();

	return 0;
}
int KhachSan::TongTien()
{
	int kq = 0;
	for (int i = 0; i < m_Phong.size(); ++i)
		kq += m_Phong[i]->TinhTien();
	return kq;
}

int KhachSan::LuaChon()
{
	int iChon, iChon1;

	cout << "Khach san hien co " << m_Phong.size() << " phong duoc thue" << endl;
	cout << "1. Thue phong." << endl;
	cout << "2. Xem thong tin phong thue. " << endl;
	cout << "3. Tinh tien phong thue." << endl;
	cout << "4. Tinh tien cua tat ca cac phong thue." << endl;
	cout << "0. Thoat." << endl;
	cout << "----------> Chon : ";
	cin >> iChon;
	cout << endl;

	switch (iChon)
	{
	case 1:
		{
			cout << "Khach san co 3 loai phong." << endl;
			cout << "1. Phong loai A, don gia 80 USD/ngay." << endl;
			cout << "2. Phong loai B, don gia 60 USD/ngay." << endl;
			cout << "3. Phong loai C, don gia 40 USD/ngay." << endl;
			cout << "0. Thoat." << endl;
			cout << "--------> Chon : ";
			cin >> iChon1;
			
			if (iChon1 == 0 || iChon1 > 3)
				break;
			switch (iChon1)
			{
			case 1:
				m_Phong.push_back(new LLoaiA);
				break;
			case 2:
				m_Phong.push_back(new LLoaiB);
				break;
			case 3:
				m_Phong.push_back(new LLoaiC);
				break;
			}

			m_Phong[m_Phong.size() - 1]->Nhap();
			break;
		}
	case 2:
		cout << "Nhap phong muon xem : ";
		cin >> iChon1;

		if (iChon1 > 0 && iChon1 < m_Phong.size() + 1)
			cout << endl << m_Phong[iChon1 - 1]->Xuat() << endl;

		break;
	case 3:
		cout << "Nhap phong muon tinh tien: ";
		cin >> iChon1;

		if (iChon1 > 0 && iChon1 < m_Phong.size() + 1)
		{
			cout << endl << m_Phong[iChon1 - 1]->Xuat() << endl;
			cout << "----> So tien phai tra la : " << TinhTienPhong(iChon1 - 1) << " USD" << endl;
		}

		break;
	case 4:
		cout << Xuat() << endl;
		cout << "\t\t-----> Tong tien : " << TongTien() << " USD" << endl;
		break;
	}

	return iChon;
}

string KhachSan::Xuat()
{
	string kq = "So phong\tLoai phong\tSo ngay thue\tDich vu\t\tThanh tien";
	for (int i = 0; i < m_Phong.size(); ++i)
	{
		char s[10];
		string k = string(itoa(i + 1, s, 10)) + "." + "\t\t";
		
		switch (m_Phong[i]->LoaiPhong())
		{
		case LOAI_A:
			{
				LLoaiA *a = (LLoaiA*) m_Phong[i];
				k += " Loai A\t\t     " + string(itoa(m_Phong[i]->DocSoNgay(), s, 10))
					+ "\t\t " + string(itoa(a->DocDichVu(), s, 10)) 
					+" USD" + "\t\t " + string(itoa(m_Phong[i]->TinhTien(), s, 10)) + " USD";
				break;
			}
		case LOAI_B:
			k += " Loai B\t\t     " + string(itoa(m_Phong[i]->DocSoNgay(), s, 10))
					+ "\t\t " + "0 USD" + "\t\t " + string(itoa(m_Phong[i]->TinhTien(), s, 10)) + " USD";
			break;
		case LOAI_C:
			k += " Loai C\t\t     " + string(itoa(m_Phong[i]->DocSoNgay(), s, 10))
					+ "\t\t " + "0 USD" + "\t\t " + string(itoa(m_Phong[i]->TinhTien(), s, 10)) + " USD";
			break;
		}
		
		kq += "\n" + k;
	}

	return kq;
}