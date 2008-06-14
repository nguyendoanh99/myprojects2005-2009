// Liet ke tat ca cac hoan vi cua 1 tap gom n phan tu.
#include <iostream.h>
#include <conio.h>
int n;
int a[10];
void Xuat()
{
 for (int i=0;i<n;i++) cout<<a[i]<<" ";
 cout<<endl;
}
void doicho(int& a,int& b)
{
 int d=a;
 a=b;
 b=d;
}
void Try(int m)
{
 if (m==0) Xuat();
 else
 {
  for (int i=m;i>=0;i--)
  {
   doicho(a[i],a[m]);
   Try(m-1);
   doicho(a[i],a[m]);
  }
 }
}
void main()
{
 clrscr();
 cout<<"n=";
 cin>>n;
 for (int i=0;i<n;i++) a[i]=i+1;
 Try(n-1);
 getch();
}