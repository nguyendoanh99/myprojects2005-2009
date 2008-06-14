#include <iostream.h>
#include <conio.h>
#include <math.h>
void inc(int &);
void dec(int &);

void main()
{
 clrscr();
 for (int i=1;i<=10;i++)
 {
  gotoxy(31-i,i);
  for (int j=1,m=i-1;j<=i*2-1;j++)
  {
   (j<=i)?inc(m):dec(m);
   cout<<m;
  }
 }
 getch();
}

void inc(int &i)
{
 i=++i%10;
}

void dec(int &i)
{
 i=abs(--i%10);
}