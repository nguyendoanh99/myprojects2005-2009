// Viet ham de qui in ra tong n phan tu dau tien cua mang

#include <iostream.h>
#include <conio.h>
#include <stdlib.h>
#include <iomanip.h>

int Tong(int,int []);

void main()
{
 int a[20],n;

 clrscr();
 randomize();
 for (int i=0;i<20;i++) a[i]=random(100);
 for (i=0;i<20;i++) cout<<setw(3)<<a[i];
 cout<<"\nn=";
 cin>>n;
 cout<<Tong(n-1,a);
 getch();
}

int Tong(int n,int a[])
{
 if (n>=0) return a[n]+Tong(n-1,a);
 else return 0;
}
