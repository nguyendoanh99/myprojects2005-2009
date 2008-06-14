// stdafx.cpp : source file that includes just the standard includes
//	0512189_Doan_Phan2.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <math.h>
#include "bigint.h"
#include <ctype.h>
#include <string.h>

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

BIGINT tinhbieuthuc(char *s)
{
	BIGINT *temp=new BIGINT;
	BIGINT so[2];
	char dau='+';	
	so[0]=CreateBigint("0");
	init(*temp);
	char *c;
	while (*s!=0 &&*s!=10)
	{
		if (isdigit(*s))
		{
			NODE *p=getnode(*s-'0');
			addtail(*temp,p);
		}
		else
		{			
			if (temp->pHead)
			{
				temp->sign=1;
				so[1]=*temp;				
				temp=new BIGINT;
				init(*temp);
			}
			if (*s==' ')
			{
				s++;
				continue;
			}
			switch (dau)
			{			
			case '+':
				*temp=cong(so[0],so[1]);				
				break;
			case '-':
				*temp=tru(so[0],so[1]);				
				break;			
			}
			so[0]=*temp;
			temp=new BIGINT;
			init(*temp);
			dau=*s;
		}
		s++;
	}
	// So nam o cuoi chuoi
	if (temp->pHead)
	{
		temp->sign=1;
		so[1]=*temp;				
		temp=new BIGINT;
		init(*temp);
	}
	switch (dau)
	{			
	case '+':
		*temp=cong(so[0],so[1]);				
		break;
	case '-':
		*temp=tru(so[0],so[1]);				
		break;			
	}
	return *temp;
}
void Phan2()
{
	char filename[256];	
	fflush(stdin);
	printf("Nhap ten file muon thuc hien:");
	gets(filename);
	FILE *fp=fopen(filename,"rt");
	if (!fp)
	{
		printf("Khong mo duoc file");
		return;
	}
	char s[2001];
	while (1)
	{
		fgets(s,2001,fp);
		int t=strlen(s)-1;
		if (s[t]==10)
			s[t]=0;
		printf("%s = ",s);
		BIGINT c=tinhbieuthuc(s);
		xuat(c);
		printf("\n");		
		if (feof(fp))
			break;
	}
	fclose(fp);
}