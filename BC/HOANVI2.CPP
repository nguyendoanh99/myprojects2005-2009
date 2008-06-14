// Liet ke tat ca cac hoan vi cua 1 tap gom n phan tu.
#include <iostream.h>
#include <conio.h>
int a[10],b[10];
int n;
void xuat()
{
 for (int i=0;i<n;i++) cout<<a[i]<<" ";
 cout<<endl;
}
void Try(int i)
{
 if (i==n) xuat();
 else
 {
  for (int j=0;j<n;j++)
   if (b[j]==1)
   {
    a[i]=j+1;
    b[j]=0;
    Try(i+1);
    b[j]=1;
   }
 }
}
void main()
{
 clrscr();
 cout<<"n=";
 cin>>n;
 for (int i=0;i<n;i++) b[i]=1;
 Try(0);
 getch();
}