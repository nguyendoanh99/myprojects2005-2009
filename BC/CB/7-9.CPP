// Cho biet cac so nao trong khoang tu 20 den 200.
// a) Chia chan cho 3.    	b) Chia chan cho 4.
// c) Chia chan cho 5.		c) Chia chan cho 6.
// 		e) Chia chan cho 4 va 5.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 cout<<"Cac so chia chan cho 3 trong khoang tu 20 den 200 la:\n";
 int i=20;
 do
 {
  if (i%3==0) cout<<setw(4)<<i;
  i++;
 }
 while (i<=200);
 getch();
 clrscr();
 cout<<"Cac so chia chan cho 4 trong khoang tu 20 den 200 la:\n";
 i=20;
 do
 {
  if (i%4==0) cout<<setw(4)<<i;
  i++;
 }
 while (i<=200);
 getch();
 clrscr();
 cout<<"Cac so chia chan cho 5 trong khoang tu 20 den 200 la:\n";
 i=20;
 do
 {
  if (i%5==0) cout<<setw(4)<<i;
  i++;
 }
 while (i<=200);
 getch();
 clrscr();
 cout<<"Cac so chia chan cho 6 trong khoang tu 20 den 200 la:\n";
 i=20;
 do
 {
  if (i%6==0) cout<<setw(4)<<i;
  i++;
 }
 while (i<=200);
 getch();
 clrscr();
 cout<<"Cac so chia chan cho 4 va 5 trong khoang tu 20 den 200 la:\n";
 i=20;
 do
 {
  if (i%4==0 && i%5==0) cout<<setw(4)<<i;
  i++;
 }
 while (i<=200);
 getch();
}