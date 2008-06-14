#include <iostream.h>
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>

const char *tf="C:\\HV.INP";
int a[10],b[10];
int n,m,d,k=0;

void Try(int);
void Input();

void main()
{
 clrscr();
 Input();
 for (int i=0;i<n;i++) b[i]=1;
 d=0;
 Try(0);
 getch();
}

void Input()
{
 FILE *f;

 f=fopen(tf,"rt");
 fscanf(f,"%d %d",n,m);
 fclose(f);
}

void Try(int i)
{
 if (i==n)
 {
  d+=n;
  if (d>=m)
  {
   if (d==m) cout<<char (a[n-1]+64);
   else cout<<char (a[(m%n)-1]+64);
   k=1;
   exit(1);
  }
 }
 else
 {
  if (k) exit(1);
  for (int j=0;j<n;j++)
  {
   if (k) exit(1);
   if (b[j]==1)
   {
    a[i]=j+1;
    b[j]=0;
    Try(i+1);
    b[j]=1;
   }
  }
 }
}