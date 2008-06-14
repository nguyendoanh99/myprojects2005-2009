#include <iostream.h>
#include <string.h>

char *bd[9]={
	"0134",
	"012",
	"1234",
	"036",
	"13457",
	"258",
	"3467",
	"678",
	"4578"};
short b[9]={0};
char s[10]="330222212";
char s1[]= "000000000";

void biendoi(char [],int );
int generate();
void xuat(short []);
void tim();

void main()
{
	tim();
}

void tim()
{	int t=generate();
	while (!t)
	{
		t=generate();		
	}
	if (t)
		xuat(b);
}

void xuat(short a[])
{
	for (int i=0;i<9;i++)
		cout<<a[i]<<" ";
	cout<<endl;
}
int generate()
{
	if (strcmp(s,s1)==0)
		return 1;
	int i=8;
	while (i>=0 && b[i]==3)
	{
		biendoi(s,i);
		b[i]=0;
		--i;
	}
	if (i>0)
	{
		biendoi(s,i);
		++b[i];
		return 0;
	}
	else
		return 1;
}
void biendoi(char s[],int n)
{
	for (int i=0;i<strlen(bd[n]);++i)
	{
		int j=bd[n][i]-'0';
		s[j]++;
		if (s[j]=='4')
			s[j]='0';
	}
}