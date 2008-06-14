// Viet chuong trinh nhap vao 10 so luu vao 1 mang. In ra so lon nhat, be nhat
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a[10];
 for (int i=1;i<=10;i++)
 {
  cout<<"a["<<i-1<<"]=";
  cin>>a[i-1];
 }
 int min=a[0],max=a[0];
 for (i=1;i<10;i++)
  if (max<a[i]) max=a[i];
  else
   if (min>a[i]) min=a[i];
 cout<<"Max = "<<max<<"\tMin = "<<min;
 getch();
}