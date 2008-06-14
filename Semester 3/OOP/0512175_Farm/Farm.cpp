#include <iostream.h>
#include "Farm.h"
#include "Cow.h"
#include "Sheep.h"
#include "Goat.h"

int Farm::Count(int iType)
{
	return m_arrCount[iType];
}

void Farm::MakeNoise()
{
	for (int i = 0; i < m_arrAnimals.size(); ++i)
		cout << m_arrAnimals[i]->Talk() << endl;
}

int Farm::GetTotalGrass()
{
	int kq = 0;
	for (int i = 0; i < m_arrAnimals.size(); ++i)
		kq += m_arrAnimals[i]->Eat();

	return kq;
}

int Farm::GetTotalMilk()
{
	int kq = 0;
	for (int i = 0; i < m_arrAnimals.size(); ++i)
		kq += m_arrAnimals[i]->GiveMilk();

	return kq;
}

void Farm::Reproduce()
{
	int len = m_arrAnimals.size();
	for (int i = 0; i < len; ++i)
	{
		vector<Animal *> temp = m_arrAnimals[i]->GiveBirth();

		int iType = m_arrAnimals[i]->GetType();
		// Tim vi tri xuat hien cua con vat m_arrAnimals[i] 
		// trong m_arrObject
		int index = 0;
		while (iType != m_arrObjects[index]->GetType())
			++index;
		
		m_arrCount[index] += temp.size();

		for (int j = 0; j < temp.size(); ++j)		
			m_arrAnimals.push_back(temp[j]);		
	}
}

Farm::~Farm()
{
	for (int i = 0; i < m_arrAnimals.size(); ++i)
		delete m_arrAnimals[i];

	for (i = 0; i < m_arrObjects.size(); ++i)
		delete m_arrObjects[i];

	m_arrAnimals.clear();
	m_arrObjects.clear();
}

void Farm::Init(int iSoLuong[])
{	
	// Khoi tao lai bien dem
	m_arrCount.clear();
	for (int i = 0; i < m_arrObjects.size(); ++i)
		m_arrCount.push_back(0);

	// Xoa cac doi tuong cu
	for (i = 0; i < m_arrAnimals.size(); ++i)
		delete m_arrAnimals[i];

	m_arrAnimals.clear();
	// Them iSoLuong[i] gia suc loai "i" vao nong trai
	for (i = 0; i < m_arrObjects.size(); ++i)
		Add(i, iSoLuong[i]);
}

Farm::Farm()
{
	// Tao mau doi tuong
	m_arrObjects.clear();
	
	m_arrObjects.push_back(new Cow);	
	m_arrObjects.push_back(new Sheep);
	m_arrObjects.push_back(new Goat);

	int *iSoLuong = new int[m_arrObjects.size()];
	for (int i = 0; i < m_arrObjects.size(); ++i)
		iSoLuong[i] = 0;

	Init(iSoLuong);
	delete []iSoLuong;
}

void Farm::Add(int iType,int n)
{
	for (int i = 0; i < n; ++i)
	{
		++m_arrCount[iType];
		m_arrAnimals.push_back(m_arrObjects[iType]->CreateObject());
	}
}

int Farm::LuaChon()
{
	int chon;
	int n;

	cout << "So gia suc co trong nong trai: " << endl;
	for (int i = 0; i < m_arrObjects.size(); ++i)
		cout << "\t" << Count(i) << " con " << m_arrObjects[i]->GetName();
	cout << endl;

	cout << "1. Khoi tao so luong gia suc trong nong trai." << endl;
	cout << "2. Tieng keu cua gia suc trong nong trai." << endl;
	cout << "3. So gia suc sau mot lua sinh." << endl;
	cout << "4. Tong so kg co da tieu thu sau mot lan an." << endl;
	cout << "5. Tong so lit sua nhan duoc sau mot lan cho sua cua tat ca gia suc." << endl;
	
	for (i = 0; i < m_arrObjects.size(); ++i)
		cout << i + 6 << ". Them " << m_arrObjects[i]->GetName() << " vao nong trai." << endl;

	cout << "0. Thoat" << endl;
	cout << " ---->    Chon : ";
	cin >> chon;
	switch (chon)
	{
	case 1:
		{
			int *iSoLuong = new int[m_arrObjects.size()];
			for (i = 0; i < m_arrObjects.size(); ++i)
			{
				cout << "Nhap so luong " << m_arrObjects[i]->GetName() <<" : ";
				cin >> iSoLuong[i];
			}

			Init(iSoLuong);

			delete []iSoLuong;
			break;
		}
	case 2:
		MakeNoise();
		break;
	case 3:
		Reproduce();
		cout << "Sau mot lua sinh, nong trai co:" << endl;
		for (i = 0; i < m_arrObjects.size(); ++i)
			cout << "\t" << Count(i) << " con " << m_arrObjects[i]->GetName() << endl;

		break;
	case 4:
		cout << "Tong so kg co da tieu thu sau mot lan an la: " << GetTotalGrass() << endl;
		break;
	case 5:
		cout << "Tong so lit sua nhan duoc: " << GetTotalMilk() << endl;
		break;
	default:		
		if (chon - 6 >= 0 && chon - 6 < m_arrObjects.size())
		{		
			cout << "Ban muon them may con " << m_arrObjects[chon - 6]->GetName() << " vao nong trai: ";
			cin >> n;

			Add(chon - 6, n);
		}
		break;
	}

	cout << endl;
	cout << "--------------------------------------------------------------" << endl << endl;

	return chon;
}