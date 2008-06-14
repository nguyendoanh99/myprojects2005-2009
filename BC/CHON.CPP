// Viet CT nhap 2 so nguyen M,N
// Hay tim cach thay cac dau ? trong bieu thuc boi cac phep toan +,-,*,DIV,
// MOD sao cho gia tri bieu thuc nhan duoc dung bang N.
// ((((M?M)?M)?M)?M)?M
#include <iostream.h>
#include <conio.h>

void Tim(int,int,int&,int&,int []);
int KQ(int,int,int);
void Xuat(int[],int,int);

void main()
{
 int m,n,kq,d=0;
 int a[5];

 clrscr();
 cout<<"m,n = ";
 cin>>m>>n;
 kq=m;
 Tim(m,n,kq,d,a);
 getch();
}

void Tim(int m,int n,int& kq,int& d,int a[])
{
 int t;

 for (int i=1;i<=5;i++)
 {
  t=kq;
  kq=KQ(i,m,kq);
  a[d++]=i;
  if (kq==n && d==5) Xuat(a,m,n);
  else
   if (d<5) Tim(m,n,kq,d,a);
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
  case 5:k=kq%m;break;
 }
 return k;
}

void Xuat(int a[],int m,int n)
{
 cout<<"(((("<<m;
 for (int i=0;i<5;i++)
 {
  switch (a[i])
  {
   case 1:cout<<" + ";break;
   case 2:cout<<" - ";break;
   case 3:cout<<" * ";break;
   case 4:cout<<" DIV ";break;
   case 5:cout<<" MOD ";break;
  }
  if (i<4) cout<<m<<")";
  else cout<<m;
 }
 cout<<"="<<n<<endl;
}
