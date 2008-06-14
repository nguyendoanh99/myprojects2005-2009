// Viet chuong trinh nhap (3x3) so tu 1 den (3x3) vao bang gom 3 hang va 3 cot
// sao cho tong tren cac hang cac cot va cac duong cheo deu bang nhau. Hinh
// vuong nhu vay goi la ma phuong cap 3.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 int n,a[21][21],i,j;
 cout<<"n=";
 cin>>n;
 for (i=0;i<n;i++)
  for (j=0;j<n;j++) a[i][j]=0;
 i=0;
 j=n/2;
 a[i][j]=1;
 for (int d=2;d<=n*n;d++)
 {
  j++;
  if (i==0)
  {
   if (j!=n) i=n-1;
   else
   {
    i++;
    j--;
   }
  }
  else i--;
  if (j==n) j=0;
  if (a[i][j]!=0)
  {
   i+=2;
   j--;
  }
  a[i][j]=d;
 }
 for (i=0;i<n;i++)
 {
  for (j=0;j<n;j++) cout<<setw(4)<<a[i][j];
  cout<<endl;
 }
 getch();
}