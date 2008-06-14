// Viet chuong trinh in ra 10 dong moi dong co 1 dau *, dong thu nhat thut
// vao 0 cot, dong 2 thut vao 1 cot, dong 3 thut vao 2 cot...
#include <iostream.h>
#include <conio.h>
#include <iomanip.h>
void main()
{
 clrscr();
 for (int i=1;i<=10;i++) cout<<setw(i)<<"*"<<endl;
 getch();
}