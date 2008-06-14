// Cho so nguyen N (2<=N<=1000000000). Tim so nguyen duong a nho nhat sao cho a^a chia het cho N.

#include <iostream.h>
#include <conio.h>
#include <stdio.h>

struct tsnt
	{
	 int so;
	 int mu;
	};
typedef tsnt M[10];

int Pt(long,M);
long Timso(long);

void main()
{
 long n;
 M t;
 int d;
 FILE *f;

 clrscr();
/* f=fopen("C:\\TSNT.OUT","wt");
 for (int i=1000;i<10000;i++)
 {
  d=Pt(i,t);
  fprintf(f,"%d = ",i);
  for (int j=0;j<=d;j++) fprintf(f,"%d^%d*",t[j].so,t[j].mu);
  fprintf(f,"\n");
 }
 fclose(f);*/
 cout<<"n=";
 cin>>n;
 cout<<"a="<<Timso(n);
 getch();
}
// Phan tich n ra tich cac thua so nguyen to
int Pt(long n,M tso)
{
 long i=2;
 int d=0;

 while (n!=1)
 {
  if (n%i==0)
  {
   tso[d].so=i;
   tso[d].mu=1;
   n=n/i;
   while (n%i==0)
   {
    tso[d].mu++;
    n=n/i;
   }
   d++;
  }
  i++;
 }
 return d-1;
}

long Timso(long n)
{
 M t1,t2;
 int d1=Pt(n,t1),d2,j1,j2,j;
 int k;
 long s=1;

 for (j=0;j<=d1;j++) s*=t1[j].so;
 for (long i=s;;i++)
 {
  d2=Pt(i,t2);
  if (d2>=d1)
  {
   for (j=0;j<=d2;j++) t2[j].mu*=i;
   j2=0;
   k=1;
   j1=0;
   while (j1<=d1 && k)
   {
    while ((j2<=d2)&&(t2[j2].so<t1[j1].so)) j2++;
    if (j2<=d2)
    {
     if (t2[j2].so>t1[j1].so) k=0;
     else k=t2[j2].mu>=t1[j1].mu?1:0;
    }
    else k=0;
    j1++;
   }
   if (k) return i;
  }
 }
}