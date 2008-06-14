#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 int a,b,c,d,max;
 cout<<"So lon nhat cua 2 so.\nNhap vao 2 so: ";
 cin>>a>>b;
 max=a;
 if (a<b) max=b;
 cout<<"So lon nhat la "<<max<<"\n";
 cout<<"So lon nhat cua 3 so.\nNhap vao 3 so: ";
 cin>>a>>b>>c;
 max=a;
 if (max<b) max=b;
 if (max<c) max=c;
 cout<<"So lon nhat la "<<max<<"\n";
 cout<<"So lon nhat cua 4 so.\nNhap vao 4 so: ";
 cin>>a>>b>>c>>d;
 max=a;
 if (max<b) max=b;
 if (max<c) max=c;
 if (max<d) max=d;
 cout<<"So lon nhat la "<<max<<"\n";
 return 0;
}