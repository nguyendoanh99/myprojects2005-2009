//Phan tich 1 so nguyen to>5 thanh tong 3 so nguyen to.
#include <iostream.h>
#include <conio.h>
#include <math.h>

int a,b[3],d,l[10],m;
int nt(int);
void Try(int);
int kt(int);

void main()
{
 clrscr();
 cout<<"a=";
 cin>>a;
 d=0;
 m=0;
 Try(a);
 getch();
}

int kt(int a)
{
 int k=0;
 for (int i=0;i<m;i++)
  if (l[i]==a)
  {
   k=1;
   break;
  }
 return k;
}

int nt(int a)
{
 int k=1;
 for (int i=2;i<=sqrt(a);i++)
  if (a%i==0)
  {
   k=0;
   break;
  }
 return k;
}

void Try(int a)
{
 if (d>2)
 {
  if (a==0)
  {
   if (kt(b[0]+b[1])==0 && kt(b[1]+b[2])==0)
   {
    for (int i=0;i<=2;i++) cout<<b[i]<<"+";
    cout<<endl;
    l[m++]=b[0]+b[1];
    l[m++]=b[1]+b[2];
   }
  }
 }
 else
 {
  for (int i=2;i<=a;i++)
   if (nt(i)==1)
   {
    b[d]=i;
    d++;
    Try(a-i);
    d--;
   }
 }
}