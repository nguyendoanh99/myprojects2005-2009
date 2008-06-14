#include <iostream.h>
#include <conio.h>

int a[150][150];

void Ackermann(int,int);

void main()
{
 int m,n;

 clrscr();
 cout<<"m,n=";
 cin>>m>>n;
 Ackermann(m,n);
 cout<<a[m][n];
 getch();
}

void Ackermann(int m,int n)
{
 if (!a[m][n])
 {
  if (m==0) a[m][n]=1;
  else
   if (n==0)
    if (m==1) a[m][n]=2;
    else a[m][n]=m+2;
   else
   {
    Ackermann(m-1,n);
    Ackermann(a[m-1][n],n-1);
    a[m][n]=a[a[m-1][n]][n-1];
   }
 }
}