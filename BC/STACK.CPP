// Tao mot stack
// Kiem tra tinh rong cua stack
// Them phan tu vao stack
// Loai bo phan tu trong stack
// Duyet phan tu trong stack

#include <iostream.h>
#include <conio.h>
#include <stdlib.h>

struct Stack
	{
	 int so;
	 Stack *tiep;
	};

void Tao(Stack *&);
int Rong(Stack *);
void Them(Stack *&,int);
int Lay(Stack *&);
void Duyet(Stack *);

void main()
{
 Stack *Hd;

 randomize();
 clrscr();
 Tao(Hd);
 cout<<"Truoc khi lay phan tu\n";
 cout<<"Duyet stack\n";
 Duyet(Hd);
 cout<<"\nKiem tra tinh rong cua stack = "<<Rong(Hd)<<"\n\n";
 cout<<"Sau khi lay phan tu:"<<Lay(Hd)<<"\n";
 cout<<"Duyet stack\n";
 Duyet(Hd);
 cout<<"\nKiem tra tinh rong cua stack = "<<Rong(Hd)<<"\n\n";
 getch();
}
// Tao 1 Stack
void Tao(Stack *&Hd)
{
 int s,f;

 Hd=0;
 cout<<"Ban muon tao bao nhieu phan tu vao stack ? ";
 cin>>s;
 for (int i=1;i<=s;i++)
 {
  f=random(100);
  cout<<f<<" ";
  Them(Hd,f);
 }
 cout<<"\n";
}
// Kiem tra tinh rong cua Stack
int Rong(Stack *Hd)
{
 return (Hd!=0);
}
// Them 1 phan tu vao Stack
void Them(Stack *&Hd,int so)
{
 Stack *tam=new Stack;

 tam->so=so;
 if (!Hd)
 {
  tam->tiep=0;
  Hd=tam;
 }
 else
 {
  tam->tiep=Hd;
  Hd=tam;
 }
}
// Loai bo phan tu trong Stack
int Lay(Stack *&Hd)
{
 int so;
 Stack *tam;

 if (Hd)
 {
  so=Hd->so;
  if (!Hd->tiep)
  {
   delete Hd;
   Hd=0;
  }
  else
  {
   tam=Hd;
   Hd=Hd->tiep;
   delete tam;
  }
  return so;
 }
 return 0;
}
// Duyet Stack
void Duyet(Stack *Hd)
{
 while (Hd)
 {
  cout<<Hd->so<<" ";
  Hd=Hd->tiep;
 }
}