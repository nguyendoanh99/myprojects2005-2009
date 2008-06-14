// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__C5961F08_258D_4F21_95AF_E38A9E49FDDD__INCLUDED_)
#define AFX_STDAFX_H__C5961F08_258D_4F21_95AF_E38A9E49FDDD__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
typedef int (*pf) (int,int); // con tro toi ham so sanh
int input(char *,int **,int *,int *,int *);
int output(char *,int [],int);
int lonhon(int,int);
int nhohon(int,int);
void hv(int *,int *);
void SelectionSort(int [],int ,int);
void InsertionSort(int [],int ,int);
void InterchangeSort(int [],int ,int);
void BubbleSort(int [],int ,int);
void ShakerSort(int [],int ,int);
//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__C5961F08_258D_4F21_95AF_E38A9E49FDDD__INCLUDED_)
