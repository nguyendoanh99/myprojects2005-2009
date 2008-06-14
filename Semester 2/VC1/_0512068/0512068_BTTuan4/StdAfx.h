// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__5F1DD0D7_3EBC_4B53_BDDB_3D194681DBE9__INCLUDED_)
#define AFX_STDAFX_H__5F1DD0D7_3EBC_4B53_BDDB_3D194681DBE9__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <process.h>

void docfile(FILE *f,int n,int *a,int &x,int &k);
void ghifile(int *a,int n,char *ten);
void in_ktra(int n,int *a,int x,int k);
void Insau_sapxep(int *a,int n);
void hoanvi(int &a,int &b);

// CAC PHUONG PHAP SAP XEP
void Shift_giam(int *a,int l,int r);
void Shift_tang(int *a,int l,int r);
void Createheap(int *a,int n,int k);
void Heapsort(int *a,int n,int k);

void ShellSort_tang(int *a,int n,int h[],int nh);
void ShellSort_giam(int *a,int n,int h[],int nh);

void MergeSort_tang(int *a,int n);
void MergeSort_giam(int *a,int n);

void Quicksort_tang(int *a,int l,int r);
void Quicksort_giam(int *a,int l,int r);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__5F1DD0D7_3EBC_4B53_BDDB_3D194681DBE9__INCLUDED_)
