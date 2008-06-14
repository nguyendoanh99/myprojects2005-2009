// Tao 1 hang doi
// Kiem tra tinh rong cua hang doi
// Them 1 phan tu vao hang doi
// Loai bo phan tu trong hang doi
// Duyet hang doi

#include <iostream.h>
#include <conio.h>
#include <stdlib.h>

struct Hangdoi
	{
	 int so;
	 Hangdoi *tiep;
	};

void Tao(Hangdoi *&,Hangdoi *&);
int Rong(Hangdoi *);
void Them(Hangdoi *&,Hangdoi *&,int);
int Lay(Hangdoi *&,Hangdoi *&);
void Duyet(Hangdoi *);

void main()
{
 Hangdoi *St=0,*Ht;

 clrscr();
 randomize();
 Tao(St,Ht);
 cout<<"Truoc khi lay 1 phan tu\n";
 cout<<"Duyet Hang doi \n";
 Duyet(St);
 cout<<"\nKiem tra tinh rong cua Hang doi = "<<Rong(St)<<"\n\n";
 cout<<"Sau khi lay 1 phan tu "<<Lay(St,Ht)<<"\n";
 cout<<"Duyet Hang doi \n";
 Duyet(St);
 cout<<"\nKiem tra tinh rong cua Hang doi = "<<Rong(St);
 getch();
}
// Tao mot hang doi
void Tao(Hangdoi *&St,Hangdoi *&Ht)
{
 int s,f;

 St=0;
 cout<<"Ban muon tao bao nhieu phan tu vao Hang doi ? ";
 cin>>s;
 for (int i=1;i<=s;i++)
 {
  f=random(100);
  cout<<f<<" ";
  Them(St,Ht,f);
 }
 cout<<endl;
}
// Kiem tra tinh rong cua hang doi
int Rong(Hangdoi *St)
{
 return (St!=0);
}
// Them phan tu vao hang doi
void Them(Hangdoi *&St,Hangdoi *&Ht,int so)
{
 Hangdoi *tam=new Hangdoi;

 tam->so=so;
 tam->tiep=0;
 if (!St) St=tam;
 else Ht->tiep=tam;
 Ht=tam;
}
// Loai bo phan tu trong hang doi
int Lay(Hangdoi *&St,Hangdoi *&Ht)
{
 Hangdoi *tam;
 int so;

 if (St)
 {
  if (St==Ht)
  {
   so=St->so;
   delete St;
   St=Ht=0;
  }
  else
  {
   so=Ht->so;
   tam=St;
   while (tam->tiep!=Ht) tam=tam->tiep;
   delete Ht;
   Ht=tam;
   Ht->tiep=0;
  }
  return so;
 }
 else return 0;
}
// Duyet phan tu trong hang doi
void Duyet(Hangdoi *St)
{
 Hangdoi *tam=St;

 while (tam)
 {
  cout<<tam->so<<" ";
  tam=tam->tiep;
 }
}