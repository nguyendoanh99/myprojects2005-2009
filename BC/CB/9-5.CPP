#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 int sl;
 unsigned long k=90000;
 cout<<"Gia dinh co bao nhieu con em hoc tai truong = ";
 cin>>sl;
 if (sl==1) cout<<"So tien gia dinh phai nop la: "<<k;
 else cout<<"So tien gia dinh phai nop la: "<<(k-k/10.0)*sl;
 cout<<"d";
 return 0;
}