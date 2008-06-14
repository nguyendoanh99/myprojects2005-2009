// Viet ham de qui de tinh luy thua x^n

#include <iostream.h>
#include <conio.h>

int luythua(int,int);

void main()
{
 int x,n;

 clrscr();
 cout<<"x,n=";
 cin>>x>>n;
 cout<<luythua(x,n);
 getch();
}
// Luy thua cua x^n
int luythua(int x,int n)
{
 if (n==0) return 1;
 if (n==1) return x;
 return luythua(x,n-1)*x;
}