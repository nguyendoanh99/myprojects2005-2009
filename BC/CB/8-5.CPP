#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 float f,c;
 int tl;
 cout<<"F=9/5C+32\n";
 cout<<"Ban muon tinh do nao?(0:F; 1:C) ";
 cin>>tl;
 if (tl==0)
 {
  cout<<"C=";
  cin>>c;
  cout<<"F="<<9/5.0*c+32<<"\n";
 }
 else
 {
  cout<<"F=";
  cin>>f;
  cout<<"C="<<(f-32)*5/9.0;
 }
 return 0;
}