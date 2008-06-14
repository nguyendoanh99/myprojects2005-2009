// Viet chuong trinh in ra 10 dong, moi dong co 1 dau *.
// Dong 1 in 50 khoang trang roi moi in ki tu *.
// Dong 2 in 49 khoang trang roi moi in ki tu *...
// Dong 9 in 42 khoang trang roi moi in ki tu *.
// Dong 10 in 41 khoang trang roi moi in ki tu *.
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 for (int i=1;i<=10;i++) cout<<setw(51-i)<<"*"<<endl;
 getch();
}