#include <iostream.h>
#include <conio.h>
main()
{
 clrscr();
 int a,b,c;
 cout<<"Nhap vao 2 so a, b= ";
 cin>>a>>b;
 c=a+b;
 cout<<"Tong "<<a<<" va "<<b<<" = "<<c<<"\n";
 if (c%3==0) cout<<"Tong do chia het cho 3\n";
 else cout<<"Tong do khong chia het cho 3\n";
 if (c%2==0) cout<<"Tong do chia het cho 2\n";
 else cout<<"Tong do khong chia het cho 2\n";
 if ((a+b)%6==0) cout<<"Tong do chia het cho 6\n";
 else cout<<"Tong do khong chia het cho 6\n";
 cout<<"Tich "<<a<<" va "<<b<<" = "<<a*b<<"\n";
 if ((a*b)%5==0) cout<<"Tich do chia het cho 5\n";
 else cout<<"Tich do khong chia het cho 5\n";
 return 0;
}