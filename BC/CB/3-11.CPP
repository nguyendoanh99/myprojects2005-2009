// Viet chuong trinh nhap vao 20 so (luu vao mang), sau do:
//	a) In ra cac so do voi chi so cua no.
//	b) In ra cac so do theo chi so giam dan.
//	c) In ra cac so la so chan.
//	d) In ra trung binh cong cua cac so do.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int a[20];
 for (int i=0;i<20;i++)
 {
  cout<<"a["<<i<<"]=";
  cin>>a[i];
 }
 cout<<"Cac so do voi chi so cua no:\n";
 for (i=0;i<20;i++)
  cout<<"a["<<i<<"]="<<a[i]<<"\n";
 getch();
 clrscr();
 cout<<"Cac so do theo chi so giam dan:\n";
 for (i=20;i>0;i--)
  cout<<"a["<<i<<"]="<<a[i]<<"\n";
 getch();
 clrscr();
 cout<<"Cac so la so chan:\n";
 for (i=0;i<20;i++)
  if (a[i]%2==0) cout<<a[i]<<" ";
 getch();
 clrscr();
 int t=0;
 for (i=0;i<20;i++) t+=a[i];
 cout<<"\nTrung binh cong cua cac so do = "<<t/20.0;
 getch();
}