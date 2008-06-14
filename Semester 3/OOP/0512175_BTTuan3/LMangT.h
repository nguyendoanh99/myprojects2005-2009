#ifndef _MANG_T_
#define _MANG_T_

#include <string.h>
#include <stdlib.h>
#include <iostream.h>

template <class T>
class LMangT
{
private:
	T *m_pPhanTu;
	int m_iChieuDai;

	void QuickSort(int l, int r)
	{
		int i = l;
		int j = r;
		T tam = m_pPhanTu[(i + j) / 2];
		do
		{			
			
			while (m_pPhanTu[i] < tam)
				++i;
			while (tam < m_pPhanTu[j])
				--j;
			if (i <= j)
			{
				T t = m_pPhanTu[i];
				m_pPhanTu[i] = m_pPhanTu[j];
				m_pPhanTu[j] = t;
				++i;
				--j;
			}
		} while (i < j);

		if (i < r)
			QuickSort(i, r);

		if (l < j)
			QuickSort(l, j);
	}

public:
	
	LMangT(int iChieuDai = 1)
	{
		m_iChieuDai = __max(iChieuDai, 1);
		m_pPhanTu = new T[m_iChieuDai];
	}
	
	LMangT(const LMangT& P)
	{	
		m_iChieuDai = P.m_iChieuDai;
		m_pPhanTu = new T[m_iChieuDai];
		
		memcpy(m_pPhanTu, P.m_pPhanTu, m_iChieuDai * sizeof(T));
	}

	virtual ~LMangT()
	{
		if (m_pPhanTu)
			delete []m_pPhanTu;
		m_pPhanTu = NULL;
	}

	int LayChieuDai()
	{
		return m_iChieuDai;
	}

	T& LayPhanTu(int iViTri)
	{
		// Neu iViTri < 0 hay iViTri > m_iChieuDai - 1 thi dua iViTri ve gia tri 
		// co nghia gan voi no nhat
		iViTri = __max(iViTri, 0);
		iViTri = __min(iViTri, m_iChieuDai - 1);

		return m_pPhanTu[iViTri];
	}

	T& operator[](int iViTri)
	{		
		return LayPhanTu(iViTri);
	}
	
	LMangT& operator=(const LMangT& P)
	{
		// Xoa cac o nho ma doi tuong goi ham dang chiem giu	
		if (m_pPhanTu)
			delete []m_pPhanTu;

		m_iChieuDai = P.m_iChieuDai;
		m_pPhanTu = new T[m_iChieuDai];
	
		memcpy(m_pPhanTu, P.m_pPhanTu, m_iChieuDai * sizeof(T));
		return *this;
	}

	friend ostream& operator<<(ostream& os, const LMangT& P)
	{
		for (int i = 0; i < P.m_iChieuDai; ++i)
			os << P.m_pPhanTu[i] << " ";
		return os;
	}

	friend istream& operator>>(istream& is, LMangT& P)
	{
		// Nhap chieu dai cua mang
		do
		{
			cout << "Nhap so phan tu cua mang (n > 0): ";
			is >> P.m_iChieuDai;
		} while (P.m_iChieuDai <= 0);		
		// Khoi tao lai mang moi
		if (P.m_pPhanTu)
			delete []P.m_pPhanTu;		
		P.m_pPhanTu = new T[P.m_iChieuDai];
		// Nhap cac phan tu cua mang
		for (int i = 0; i < P.m_iChieuDai; ++i)
		{
			cout << "Nhap phan tu thu " << i << ": ";
			is >> P.m_pPhanTu[i];
		}
		
		return is;
	}
	// Tim phan tu t trong mang
	// Neu co thi tra ve vi tri tim thay dau tien
	// Neu khong thi tra ve -1
	int Tim(T t)
	{
		for (int i = 0; i < m_iChieuDai; ++i)
			if (m_pPhanTu[i] == t)
				return i;
		return -1;
	}
	// Sap xep tang dan 
	// Thuat toan QuickSort
	void SapXep()
	{
		QuickSort(0, m_iChieuDai - 1);
	}
};

#endif
