// stdafx.cpp : source file that includes just the standard includes
//	chuoi.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// Copy chuoi s vao d
char *strcpy(char *d,char *s)
{	
	char *t=d;
	while (*t++=*s++);	
	return d;
}
// Copy n ky tu tu chuoi s vao d
char *strncpy(char *d,char *s,int n)
{
	char *t=d;
	while ((n--)&&(*t++=*s++));
	*t=0;
	return d;
}
// Tinh chieu dai cua chuoi
int strlen(char *s)
{
	int n=0;
	while (*s++)
		n++;
	return n;
}
// Noi 1 ban sao cua chuoi s vao cuoi chuoi d
char *strcat(char *d,char *s)
{
	char *t=d;
	while (*t++);
	t--;
	while (*t++=*s++);
	return d;
}
// Noi 1 ban sao chua n ky tu cua chuoi s vao cuoi chuoi d
char *strncat(char *d,char *s,int n)
{
	char *t=d;
	while (*t++);
	t--;
	while ((n--)&&(*t++=*s++));
	return d;
}
// Chuyen chuoi thanh chu hoa
char *strupr(char *s)
{
	char *t=s;
	while (*t)
	{
		if (*t>='a' && *t<='z')
			*t-=32;
		t++;
	}
	return s;
}
// Chuyen chuoi thanh chu thuong
char *strlwr(char *s)
{
	char *t=s;
	while (*t)
	{
		if (*t>='A' && *t<='Z')
			*t+=32;
		t++;
	}
	return s;
}