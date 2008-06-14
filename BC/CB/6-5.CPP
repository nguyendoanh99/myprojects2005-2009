#include <iostream.h>
#include <conio.h>
#include <stdlib.h>
main()
{
 clrscr();
 randomize();
 int x,y,z,tl;
 x=random(1000);
 y=random(1000);
 z=random(1000);
 cout<<"\t\tLam toan cong va tru\n";
 cout<<"\t\t"<<x<<"+"<<y<<"-"<<z<<"=";
 cin>>tl;
 cout<<"\t\t";
 if (tl==x+y-z) cout<<"Hoan ho! Ban lam dung roi.\n";
 else cout<<"Tiec qua, ban lam sai roi.\n";
 x=random(1000);
 y=random(1000);
 z=random(1000);
 cout<<"\t\tLam toan cong va tru\n";
 cout<<"\t\t"<<x<<"+"<<y<<"*"<<z<<"=";
 cin>>tl;
 cout<<"\t\t";
 if (tl==x+y*z) cout<<"Hoan ho! Ban lam dung roi.\n";
 else cout<<"Tiec qua, ban lam sai roi.\n";
 return 0;
}