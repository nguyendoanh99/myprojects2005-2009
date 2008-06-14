// Tinh giai thua cua n.
#include <iostream.h>
#include <conio.h>
void main()
{
 clrscr();
 int n;
 cout<<"n=";
 cin>>n;
 int gt=1;
 for (int i=2;i<=n;i++) gt*=i;
 cout<<"Giai thua cua "<<n<<" = "<<gt;
 getch();
}