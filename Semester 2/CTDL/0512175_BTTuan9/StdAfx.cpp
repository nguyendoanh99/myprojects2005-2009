// stdafx.cpp : source file that includes just the standard includes
//	0512175_BTTuan9.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
int ktcp(int n)
{
	for (int i=0;i<=n;i++)
		if (i*i==n)
			return 1;
		else
			if (i*i>n)
				return 0;
	return 0;
}

int input(char *filename,AVLTREE &T,int &x)
{
	FILE *fp=fopen(filename,"rt");
	if (!fp)
		return 0;
	int n;
	init(T);
	fscanf(fp,"%d",&n);
	int t;
	for (int i=0;i<n;i++)
	{
		fscanf(fp,"%d",&t);
		insertNode(T,t);
	}
	fscanf(fp,"%d",&x);
	fclose(fp);
	return 1;
}
// -1	:	khong du bo nho
// 0	:	da co
// 1	:	thanh cong
// 2	:	chieu cao cay tang
int insertNode(AVLTREE &T,int x)
{
	int res;
	if (T)
	{
		if (T->info==x)
			return 0;
		if (T->info>x)
		{
			res=insertNode(T->pLeft,x);
			if (res<2)
				return res;
			switch (T->balFactor)
			{
			case RH:
				T->balFactor=EH;
				return 1;
			case EH:
				T->balFactor=LH;
				return 2;
			case LH:
				balanceLeft(T);
				return 1;
			}
		}
		else
		{
			res=insertNode(T->pRight,x);
			if (res<2)
				return res;
			switch (T->balFactor)
			{
			case LH:
				T->balFactor=EH;
				return 1;
			case EH:
				T->balFactor=RH;
				return 2;
			case RH:
				balanceRight(T);
				return 1;
			}
		}
	}
	T=new AVLNODE;
	if (T==NULL)
		return -1;
	T->balFactor=EH;
	T->info=x;
	T->pLeft=T->pRight=NULL;
	return 2;
}
int delNode(AVLTREE &T,int x)
{
	if (T==NULL)
		return 0;
	int res;
	if (T->info>x)
	{
		res=delNode(T->pLeft,x);
		if (res<2)
			return res;
		switch (T->balFactor)
		{
		case LH:
			T->balFactor=EH;
			return 2;
		case EH:
			T->balFactor=RH;
			return 1;
		case RH:
			return balanceRight(T);
		}
	}
		
	if (T->info<x)
	{
		res=delNode(T->pRight,x);
		if (res<2)
			return res;
		switch (T->balFactor)
		{
		case RH:
			T->balFactor=EH;
			return 2;
		case EH:
			T->balFactor=LH;
			return 1;
		case LH:
			return balanceLeft(T);
		}
	}
	else
	{
		AVLNODE *p=T;
		if (T->pLeft==NULL)
		{
			T=T->pRight;
			res=2;
		}
		else
			if (T->pRight==NULL)
			{
				T=T->pLeft;
				res=2;
			}
			else
			{				
				res=searchStandFor(p,T->pRight);
				if (res<2)
					return res;
				switch (T->balFactor)
				{
				case RH:
					T->balFactor=EH;
					return 2;
				case EH:
					T->balFactor=LH;
					return 1;
				case LH:
					return balanceLeft(T);
				}
			}
		delete p;
		return res;
	}
}
int searchStandFor(AVLTREE &p,AVLTREE &q)
{
	int res;
	if (q->pLeft)
	{
		res=searchStandFor(p,q->pLeft);
		if (res<2)
			return res;
		switch (q->balFactor)
		{
		case LH:
			q->balFactor=EH;
			return 2;
		case EH:
			q->balFactor=RH;
			return 1;
		case RH:
			return balanceRight(q);
		}
	}
	else
	{
		p->info=q->info;
		p=q;
		q=q->pRight;
		return 2;
	}
}
void rotateLL(AVLTREE &T)
{
	AVLNODE *T1=T->pLeft;
	T->pLeft=T1->pRight;
	T1->pRight=T;
	switch (T1->balFactor)
	{
	case LH:
		T1->balFactor=EH;
		T->balFactor=EH;
		break;
	case EH:
		T1->balFactor=RH;
		T->balFactor=LH;
		break;
	}
	T=T1;
}
void rotateRR(AVLTREE &T)
{
	AVLNODE *T1=T->pRight;
	T->pRight=T1->pLeft;
	T1->pLeft=T;
	switch (T1->balFactor)
	{
	case RH:
		T1->balFactor=EH;
		T->balFactor=EH;
		break;
	case EH:
		T1->balFactor=LH;
		T->balFactor=RH;
		break;
	}
	T=T1;
}
void rotateLR(AVLTREE &T)
{
	AVLNODE *T1=T->pLeft;
	AVLNODE *T2=T1->pRight;
	T->pLeft=T2->pRight;
	T2->pRight=T;
	T1->pRight=T2->pLeft;
	T2->pLeft=T1;
	switch (T2->balFactor)
	{
	case EH:
		T1->balFactor=EH;
		T->balFactor=EH;
		break;
	case LH:
		T1->balFactor=EH;
		T->balFactor=RH;
		break;
	case RH:
		T1->balFactor=LH;
		T->balFactor=EH;
		break;
	}
	T2->balFactor=EH;
	T=T2;
}
void rotateRL(AVLTREE &T)
{
	AVLNODE *T1=T->pRight;
	AVLNODE *T2=T1->pLeft;
	T->pRight=T2->pLeft;
	T2->pLeft=T;
	T1->pLeft=T2->pRight;
	T2->pRight=T1;
	switch (T2->balFactor)
	{
	case EH:
		T1->balFactor=EH;
		T->balFactor=EH;
		break;
	case RH:
		T1->balFactor=EH;
		T->balFactor=LH;
		break;
	case LH:
		T1->balFactor=RH;
		T->balFactor=EH;
		break;
	}
	T2->balFactor=EH;
	T=T2;
}
int balanceLeft(AVLTREE &T)
{
	AVLNODE *T1=T->pLeft;
	switch (T1->balFactor)
	{
	case LH:
		rotateLL(T);
		return 2;
	case EH:
		rotateLL(T);
		return 1;
	case RH:
		rotateLR(T);
		return 2;
	}
	return 0;
}
int balanceRight(AVLTREE &T)
{
	AVLNODE *T1=T->pRight;
	switch (T1->balFactor)
	{
	case RH:
		rotateRR(T);
		return 2;
	case EH:
		rotateRR(T);
		return 1;
	case LH:
		rotateRL(T);
		return 2;
	}
	return 0;
}
void init(AVLTREE &T)
{
	T=NULL;
}
void NLR(AVLTREE T,FILE *fp)
{
	if (T)
	{
		fprintf(fp,"%d ",T->info);
		NLR(T->pLeft,fp);
		NLR(T->pRight,fp);
	}
}
void LNR(AVLTREE T,FILE *fp)
{
	if (T)
	{
		LNR(T->pLeft,fp);
		fprintf(fp,"%d ",T->info);
		LNR(T->pRight,fp);
	}
}
void LRN(AVLTREE T,FILE *fp)
{
	if (T)
	{
		LRN(T->pLeft,fp);		
		LRN(T->pRight,fp);
		fprintf(fp,"%d ",T->info);
	}	
}
int tim(AVLTREE T,int x)
{
	AVLNODE *p=T;
	int dem=0;
	while (p)
	{		
		if (p->info>x)
			p=p->pLeft;
		else
			if (p->info<x)
				p=p->pRight;
			else
				return dem;
		dem++;
	}
	return -1;
}
void XoaChinhPhuong(AVLTREE &T)
{
	if (T)
	{
		XoaChinhPhuong(T->pLeft);
		XoaChinhPhuong(T->pRight);
		if (ktcp(T->info))
			delNode(T,T->info);
	}
}
void output(char *filename,AVLTREE T,int x)
{
	FILE *fp=fopen(filename,"wt");
	fprintf(fp,"%d\n",x);
	NLR(T,fp);
	fprintf(fp,"\n");
	LNR(T,fp);
	fprintf(fp,"\n");
	LRN(T,fp);
	fprintf(fp,"\n");
	fclose(fp);
}