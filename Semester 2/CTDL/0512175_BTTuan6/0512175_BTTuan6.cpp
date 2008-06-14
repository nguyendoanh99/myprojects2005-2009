// 0512175_BTTuan6.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stack.h"
#include "queue.h"
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char* argv[])
{
	// Doc file
	FILE *fp1=fopen(argv[1],"rt");
	if (!fp1)
	{
		printf("Khong mo duoc file");
		return 1;
	}
	int n;
	int k;			
	char (*s)[256];
	fscanf(fp1,"%d %d ",&n,&k);	
	s=new char[n][256];
	for (int i=0;i<n;i++)
		fgets(s[i],256,fp1);
	fclose(fp1);	
	// Ghi file
	FILE *fp2=fopen(argv[2],"wt");
	if (!fp2)
	{
		printf("Khong tao duoc file");
		return 1;
	}
	STACK st;
	QUEUE q;		
	fprintf(fp2,"%d %d\n",n,k);
	for (i=0;i<n;i++)
	{		
		init(st);
		init(q);
		char *s1=s[i];
		for (;*s1!=10 && *s1!=0;s1++)
			if (*s1=='*')			
				switch (k)
				{
				case 1:
					delete pop(st);
					break;
				case 2:
					delete deQueue(q);
					break;
				}
			else
			{
				char *c=new char;
				*c=*s1;
				if (k==1)				
				{
				
					NODESTACK *p=getnode(c);
					push(st,p);
				}
				else				
				{
					NODEQUEUE *p=_getnode(c);
					enQueue(q,p);				
				}	
			}
		while (!isEmpty(st))
		{
			char *c;
			c=(char*) pop(st);
			fprintf(fp2,"%c",*c);
			
		}
		while (!isEmpty(q))
		{
			char *c;
			c=(char*) deQueue(q);
			fprintf(fp2,"%c",*c);					
		}
		fprintf(fp2,"\n");		
	}	
	fclose(fp2);
	return 0;
}
