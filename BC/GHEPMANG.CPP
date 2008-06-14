// Viet CT nhap 2 mang 10 so nguyen:
// - Ghep lai thanh 1 mang.
// - Sap xep theo thu tu tang dan.

#include <iostream.h>
#include <conio.h>

const int n=10;

void Nhap(int [],char);
void Ghep(int [],int [],int []);
void Xuat(int,int []);
void Sapxep(int,int []);

void main()
{
 clrscr();
 int a[n],b[n],c[n*2];
 Nhap(a,'a');
 Nhap(b,'b');
 Ghep(a,b,c);
 Sapxep(20,c);
 Xuat(10,a);
 Xuat(10,b);
 Xuat(20,c);
 getch();
}

void Nhap(int a[],char c)
{
 for (int i=0;i<n;i++)
 {
  cout<<c<<"["<<i<<"]=";
  cin>>a[i];
 }
}

void Ghep(int a[],int b[],int c[])
{
 for (int i=0;i<n;i++) c[i]=a[i];
 for (i=0;i<n;i++) c[i+10]=b[i];
}

void Xuat(int n,int a[])
{
 for (int i=0;i<n;i++) cout<<a[i]<<" ";
 cout<<endl;
}

void Sapxep(int n,int a[])
{
 for (int i=0;i<n;i++)
  for (int j=i+1;j<n;j++)
   if (a[i]>a[j])
   {
    int c=a[i];
    a[i]=a[j];
    a[j]=c;
   }
}
