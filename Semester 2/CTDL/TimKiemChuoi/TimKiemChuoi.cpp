// TimKiemChuoi.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <string.h>

void preKMP(char [],int,int[]);
void KMP_Search(char[],int,char [],int);
int main(int argc, char* argv[])
{
	char T[]="1010100111";
	char P[]="1010101010";
	int M=strlen(T);
	int N=strlen(P);
	printf("T=\"%s\"	length=%d\n",T,M);
	printf("P=\"%s\"	length=%d\n",P,N);
	KMP_Search(T,M,P,N);
	getch();
	return 0;

}
void preKMP(char P[],int M,int kmpNext[])
{
	int i=0;
	int j=-1;
	kmpNext[0]=-1;
	while (i<M)
	{
		while ((j>-1)&&(P[i]!=P[j]))
			j=kmpNext[j];
		i++;
		j++;
		if (P[i]==P[j])
			kmpNext[i]=kmpNext[j];
		else
			kmpNext[i]=j;
	}
}
void KMP_Search(char T[],int N,char P[],int M)
{
	int kmpNext[100];
	preKMP(P,M,kmpNext);
	int i=0;
	int j=0;
	while (j<N)
	{
		while (i>-1 && P[i]!=T[j])
			i=kmpNext[i];
		i++;
		j++;
		if (i>=M)
		{
			printf("%4d ",j-i);
			i=kmpNext[i];
		}
	}
}