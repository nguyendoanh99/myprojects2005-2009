// 0512186_BTTuan6.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>

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
	LIST l;
	fprintf(fp2,"%d %d\n",n,k);
	for (i=0;i<n;i++)
	{		
		init(l);
		char *s1=s[i];
		for (;*s1!=10 && *s1!=0;s1++)
			if (*s1=='*')			
				switch (k)
				{
				case 1:
					pop(l);
					break;
				case 2:
					deQueue(l);
					break;
				}
			else
			{
				NODE *p=getnode(*s1);
				if (k==1)									
					push(l,p);		
				else				
					enQueue(l,p);
			}
		while (!isEmpty(l))
		{
			char c;
			switch (k)
			{
			case 1:
				c=pop(l);
				break;
			case 2:
				c=deQueue(l);
				break;
			}			
			fprintf(fp2,"%c",c);			
		}		
		fprintf(fp2,"\n");		
	}	
	fclose(fp2);
	return 0;
}
