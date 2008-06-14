// Cai tien chuong trinh bai 19 sao cho ki tu de to, chieu ngang, chieu doc
// duoc chon tu ban phim.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 char c;
 int n,d;
 cout<<"Ban nhap vao ki tu to : ";
 cin>>c;
 cout<<"Chieu ngang = ";
 cin>>n;
 cout<<"Chieu doc = ";
 cin>>d;
 for (int i=1;i<=d;i++)
 {
  for (int j=1;j<=n;j++) cout<<c;
  cout<<"\n";
 }
 getch();
}