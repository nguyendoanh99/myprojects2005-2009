// stdafx.cpp : source file that includes just the standard includes
//	0512175_DoAn.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "BigInt.h"
#include <stdio.h>
#include <string.h>
void Phan1()
{
	BIGINT a,b,c,n;
	char s[MAX];
	int k;
	init(c);
	init(a);
	init(b);
	printf("\nCho biet toan tu(1 - cong, 2 - tru, 3 - nhan, 4 - so sanh, 5 - luy thua, 6 - giai thua, 0 - ket thuc):");
	scanf("%d",&k);
	while (k!=0)
	{	
		switch (k)
		{
		case 1:
		case 2:
		case 3:
		case 4:
			fflush(stdin);
			printf("\nNhap so thu nhat:");
			gets(s);
			a=createBIGINT(s);

			fflush(stdin);
			printf("Nhap so thu hai:");
			gets(s);
			b=createBIGINT(s);
			break;
		case 5:
			fflush(stdin);
			printf("\nNhap so x:");
			gets(s);
			a=createBIGINT(s);
			printf("Nhap so n:");
			gets(s);
			n=createBIGINT(s);			
			break;
		case 6:
			printf("Nhap so n:");
			gets(s);
			n=createBIGINT(s);			
			break;
		default:
			printf("\nCho biet toan tu(1 - cong, 2 - tru, 3 - nhan, 4 - so sanh, 5 - luy thua, 6 - giai thua, 0 - ket thuc):");
			scanf("%d",&k);
			continue;
		}
		printf("\nKet qua: \n");
		int kq;
		if (!isEmpty(a))
			xuat(a);
		switch (k)
		{
		case 1:
			c=a+b;
			printf(" + ");
			break;
		case 2:
			c=a-b;
			printf(" - ");
			break;
		case 3:
			c=a*b;
			printf(" * ");
			break;
		case 4:			
			kq=sosanh(a,b);
			switch(kq)
			{
			case NHO_HON:
				printf(" < ");
				break;
			case LON_HON:
				printf(" > ");
				break;
			case BANG_NHAU:
				printf(" = ");
				break;
			}
			break;
		case 5:
			printf("^%d",n);
			c=pow(a,n);
			
			break;
		case 6:
			printf("%d!",n);
			c=giaithua(n);			
			break;
		}
		if (!isEmpty(b))
		{
			xuat(b);
			deleteBIGINT(b);
		}
		if (k!=4)
		{
			printf(" = ");
			xuat(c);
			deleteBIGINT(c);
		}
		printf("\n");
		if (!isEmpty(a))
			deleteBIGINT(a);				
		printf("\nCho biet toan tu(1 - cong, 2 - tru, 3 - nhan, 4 - so sanh, 5 - luy thua, 6 - giai thua, 0 - ket thuc):");
		scanf("%d",&k);
	}
}
void Phan2(char *filename)
{
	FILE *fp=fopen(filename,"rt");
	if (!fp)
	{
		printf("Khong mo duoc file");
		return;
	}
	char s[2001];
	while (1)
	{
		if (fgets(s,2001,fp)==NULL)
			break;
		int t=strlen(s)-1;
		if (s[t]==10)
			s[t]=0;		
		STACK c=Trung_to_hau_to(s);
		I_NODE *kq=tinhbieuthuc(c);
		// Xuat bieu thuc 		
		if (kq && kq->loai==_BIGINT)		
			printf("%s = ",s);
		else
			printf("%s : ",s);
		// Xuat ket qua
		xuat(kq);
		printf("\n\n");

		if (kq && kq->loai==_BIGINT)
		{
			BIGINT temp=*((BIGINT*) kq->pInfo);
			deleteBIGINT(temp);
		}
//		if (feof(fp))
//			break;
	}
	fclose(fp);
}
