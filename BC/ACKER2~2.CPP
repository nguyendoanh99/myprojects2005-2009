#include <iostream.h>
#include <conio.h>

int A(int,int);

void main()
{
 clrscr();
 cout<<A(4,2);
 getch();
}

int A(int m,int n)
{
 if (m==0) return 1;
 if (n==0)
  if (m==1) return 2;
  else return m+2;
 return A(A(m-1,n),n-1);
}