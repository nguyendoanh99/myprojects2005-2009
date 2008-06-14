// Viet chuong trinh
// - Nhap cac so nguyen vao mang 20 phan tu.
// - Xax dinh day doan con tang dai nhat.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 const int n=10;
 int a[n];
 int d=0,dd=0;
 for (int i=0;i<n;i++)
 {
  cout<<"a["<<i<<"]=";
  cin>>a[i];
 }
 for (i=0;i<n;i++)
 {
  int j=i;
  while (a[j+1]-a[j]==1)
  {
   j++;
   if (j>n-1)
   {
    j=n-1;
    break;
   }
  }
  if (j-i>dd)
  {
   dd=j-i;
   d=i;
  }
 }
 cout<<"Day doan con tang dai nhat la\n";
 for (i=d;i<=d+dd;i++)
 cout<<a[i]<<"  ";
 getch();
}