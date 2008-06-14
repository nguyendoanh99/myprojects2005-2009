// stdafx.cpp : source file that includes just the standard includes
//	0512232_BTTuan6.pch will be the pre-compiled header
//	stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file

// STACK STACK STACK STACK STACK STACK STACK STACK STACK STACK STACK

int SIsEmpty(char *s,int t)
{
	if(t == 0)
		return 1;
	return 0;
}

int SIsFull(char *s,int n,int t)
{
	if(t >= n)
		return 1;
	return 0;
}

void push(char *s,int n,int &t,char x)
{
	if(t < n)
	{
		s[t] = x;
		t++;
	}
	else
		puts("Stack day");
}

char pop(char *s,int &t)
{
	char x;
	if(t > 0)
	{
		t--;
		x = s[t];
		return x;
		
	}
	else
	{
		puts("Stack rong");
		return NULL;
	}
}

int stack(char *x,int &t)
{

	int len=strlen(x);
	for(int i=0;i<len;i++)
		if(x[i] == '*')
			break;
	t = i;
	for(;i<len;i++)
	{
		if(x[i] != '*')
			push(x,len,t,x[i]);
		else
			if(pop(x,t) == NULL)
				return -1;
	}
	return 1;

}

// ****************************************************************

// QUEUE QUEUE QUEUE QUEUE QUEUE QUEUE QUEUE QUEUE QUEUE QUEUE QUEUE

void InitQueue(char *q,int n,int &f,int &r)
{
	f=r=0;
	for(int i=0;i<n;i++)
		q[i] = NULL;
}

char QIsEmpty(char *q,int f)
{
	return (q[f] == NULL);
}


char QIsFull(char *q,int r)
{
	return (q[r] != NULL);
}


char EnQueue(char *q,int n,int &r,char x)
{
	if(QIsFull(q,r))
		return -1;
	q[r] = x;
	r++;
	if(r == n)
		r = 0;
	return 1;
}


char DeQueue(char *q,int n,int &f)
{
	char x;
	if(QIsEmpty(q,f))
		return NULL;
	x = q[f];
	q[f] = NULL;
	f++;
	if(f == n)
		f = 0;
	return x;
}

int queue(char *x,char *q,int &f,int &r)
{

	
	int len=strlen(x);
	InitQueue(q,len,f,r);

	for(int i=0;i<len;i++)
	{
		if(x[i] != '*')
			EnQueue(q,len,r,x[i]);
		else
			if(DeQueue(q,len,f) == NULL)
				return -1;
	}
	return 1;

}

// ****************************************************************

int input_output(char *filename1,char *filename2)
{
	char *x;

	x=new char[255];
	int n;
	unsigned char k;

	FILE *fr=fopen(filename1,"rt");
	FILE *fw=fopen(filename2,"wt");
	if(fr == NULL || fw == NULL)
		return 0;

	fscanf(fr,"%d",&n);
	fscanf(fr,"%d",&k);

	fprintf(fw,"%d ",n);
	fprintf(fw,"%d\n",k);

	switch(k)
	{
	case 1:
		{

			for(int i=0;i<n;i++)
			{
				int t=0;
				fscanf(fr,"%s",x);
				if(stack(x,t) == -1)
				{
					fprintf(fw,"Khong hop le\n");
					continue;
				}
				for(int j=t-1;j>=0;j--)
					fprintf(fw,"%c",x[j]);
				fprintf(fw,"\n");
				//output(x,t);
				printf("\n");
			}
			break;
		}
	case 2:
		{
			
			for(int i=0;i<n;i++)
			{
				
				char *q;
				int f=0,r=0;
				q=new char[255];
				
				fscanf(fr,"%s",x);
				int k= queue(x,q,f,r);
				if(k == -1)
				{
					fprintf(fw,"Khong hop le\n");
					continue;
				}
				else
				{
					for(int i=f;i<r;i++)
						fprintf(fw,"%c",q[i]);
					fprintf(fw,"\n");
				}
			

			}
			break;
		}
	}

	fclose(fr);
	fclose(fw);

	return 1;
}
