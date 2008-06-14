// in ra tat ca cac truong hop
// 1?2?3?4?5?6?7?8?9=10

#include <iostream.h>
#include <conio.h>

int s=0;

void Tim(int&,int&,int []);
int KQ(int,int,int);
void Xuat(int[]);

void main()
{
 int kq=1,d=0;
 int a[8];
 clrscr();
 Tim(kq,d,a);
 cout<<s;
 getch();
}

void Tim(int& kq,int& d,int a[])
{
 int t;

 for (int i=1;i<=4;i++)
 {
  t=kq;
  kq=KQ(i,d+2,kq);
  a[d++]=i;
  if (kq==10 && d==8) Xuat(a);
  else
   if (d<8) Tim(kq,d,a);
  a[--d]=0;
  kq=t;
 }
}

int KQ(int t,int m,int kq)
{
 int k;

 switch (t)
 {
  case 1:k=kq+m;break;
  case 2:k=kq-m;break;
  case 3:k=kq*m;break;
  case 4:k=kq/m;break;
 }
 return k;
}

void Xuat(int a[])
{
 cout<<"1";
 for (int i=0;i<8;i++)
 {
  switch (a[i])
  {
   case 1:cout<<" + ";break;
   case 2:cout<<" - ";break;
   case 3:cout<<" * ";break;
   case 4:cout<<" / ";break;
  }
  cout<<i+2;
 }
 cout<<"=10"<<endl;
 s++;
}