// Duyet do thi (DSLK) bang phuong phap duyet theo chieu sau

#include <iostream.h>
#include <conio.h>
#include <stdio.h>

const char *tf="C:\\DSLK.INP";

struct ct
	{
	 int so;
	 ct *tiep;
	};

void Them(ct *&,ct *&,int); 	 // Them 1 phan tu vao DSLK
void Input(const char *,ct *[],int &); // Doc du lieu tu file

void main()
{
 ct *a[7];
 int n;
 clrscr();
 Input(tf,a,n);
 getch();
}
// Them 1 phan tu vao DSLK
void Them(ct *&dt,ct *&ht,int a)
{
 ct *tam=new ct;

 tam->tiep=0;
 tam->so=a;
 if (dt) ht->tiep=tam;
 else dt=tam;
 ht=tam;
}
// Doc du lieu tu file
void Input(const char *s,ct *a[],int &n)
{
 FILE *f;
 ct *ht;
 int x;

 f=fopen(s,"rt");
 fscanf(f,"%d",&n);
 for (int i=0;i<n;i++)
 {
  a[i]=0;
  ht=a[i];
  while (1)
  {
   fscanf(f,"%d",&x);
   if (x==0) break;
   Them(a[i],ht,x);
  }
 }
 fclose(f);
}