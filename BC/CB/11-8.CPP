// Lai xuat gui tien tiet kiem khong ki han la 0,7%. Voi so tien la A,tinh
// tong tien co duoc sau khi gui n thang.(a,n nhap tu ban phim)
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 int a,n;
 float t;
 cout<<"Nhap so tien gui = ";
 cin>>a;
 t=a;
 cout<<"Nhap so thang gui = ";
 cin>>n;
 for (int i=1; i<=n;i++) t+=0.7*t/100.0;
 cout<<"So tien sau khi gui "<<n<<" thang la "<<setprecision(2)<<t;
 getch();
}