// Chuyen bieu thuc tu trung to sang hau to roi tinh toan

#include <iostream.h>
#include <conio.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>

struct ct
	{
	 char so;
	 ct *tiep;
	};
struct ct1
	{
	 ct *so;
	 ct1 *tiep;
	};
char ut[15]="(+-*/0123456789";
void Chentruoc(ct *&,char); // Chen 1 phan tu moi vao dau danh sach lien ket
void Chensau(ct *&,char);   // Chen 1 phan tu moi vao cuoi danh sach lien ket
void Them(ct1 *&,ct *);     // Them 1 phan tu vao cuoi danh sach lien ket (kieu ct1)
char Lay(ct *&);	    // Lay 1 phan tu ra khoi Stack
ct1 *Xuly(char *);	    // Chuyen trung to sang hau to
void Tinh(ct1 *&);	    // Tinh ket qua bieu thuc o dang hau to
void Xuat(ct *);	    // Xuat ket qua cua danh sach lien ket (kieu ct) ra man hinh
void Xuat1(ct1 *);          // Xuat ket qua cua danh sach lien ket (kieu ct1) ra man hinh
char Dk(char,ct *&);
char gt(char);              // Tra ve 1 so ung voi muc uu tien cua toan tu
ct *Tong(ct *,ct *);	    // Tong hai so
ct *Hieu(ct *,ct *);        // Hieu hai so
ct *Tich(ct *,ct *);        // Tich hai so
ct *Thuong(ct *,ct *,ct *&);// Thuong cua 2 so lay nguyen va du
void Dao(ct *&);	    // Dao vi tri cac thanh phan cua danh sach lien ket
char Sosanh(ct *,ct *);	    // So sanh 2 so (-1:so1<so2; 0:so1=so2; 1:so1>so2)
void Xoa0(ct *&);	    // Cat bo cac so 0 o dau danh sach lien ket
void XoaCT(ct *&);          // Xoa 1 danh sach lien ket
// Chuong trinh chinh
void main()
{
 char *s;
 ct1 *hauto;

 clrscr();
 cout<<"Nhap vao 1 bieu thuc"<<endl;
 cin>>s;
 hauto=Xuly(s);
 Xuat1(hauto);cout<<endl;
 Tinh(hauto);
// cout<<endl;
// Xuat1(hauto);
 getch();
}
// Chen 1 phan tu moi vao dau danh sach lien ket
void Chentruoc(ct *&dt,char a)
{
 ct *tam=new ct;

 tam->so=a;
 if (!dt) tam->tiep=0;
 else tam->tiep=dt;
 dt=tam;
}
// Chen 1 phan tu moi vao cuoi danh sach lien ket
void Chensau(ct *&dt,char a)
{
 ct *tam=new ct;

 tam->so=a;
 tam->tiep=0;
 if (!dt) dt=tam;
 else
 {
  ct *ht=dt;

  while (ht->tiep) ht=ht->tiep;
  ht->tiep=tam;
 }
}
// Them 1 phan tu vao cuoi danh sach lien ket (kieu ct1)
void Them(ct1 *&dt,ct *so)
{
 ct1 *tam=new ct1;

 tam->so=so;
 tam->tiep=0;
 if (dt)
 {
  ct1 *ht=dt;

  while (ht->tiep) ht=ht->tiep;
  ht->tiep=tam;
 }
 else dt=tam;
}
// Lay 1 phan tu ra khoi Stack
char Lay(ct *&Stack)
{
 char t=Stack->so;
 ct *tam=Stack;

 Stack=Stack->tiep;
 delete(tam);
 return t;
}
// Chuyen trung to sang hau to
ct1 *Xuly(char *s)
{
 ct1 *hauto=0;
 ct *tam=0,*Stack=0;
 char g,t1[255]="(";

 strcat(t1,s);
 strcat(t1,")");
 s=t1;
 for (int i=0;i<strlen(s);i++)
 {
  g=gt(s[i]);
  if ((g>4 && g<=15) || (g>=1 && g<=2 && gt(s[i-1])<=4))
  {
   if (g>4 || (g==2 && (!tam || gt(tam->so)>4))) Chensau(tam,s[i]);
  }
  else
  {
   if (tam) Them(hauto,tam);
   if (g<=4)
   {
    if (ut[g]!='(' && Stack && ut[Stack->so]!='(' && Stack->so>=g)
    {
     while (Stack && ut[Stack->so]!='(' && Stack->so>=g)
     {
      tam=0;
      Chensau(tam,ut[Lay(Stack)]);
      Them(hauto,tam);
     }
    }
    Chentruoc(Stack,g);
   }
   else
    if (s[i]==')')
    {
     while (ut[Stack->so]!='(')
     {
      tam=0;
      Chensau(tam,ut[Lay(Stack)]);
      Them(hauto,tam);
     }
     Lay(Stack);
    }
   tam=0;
  }
 }
 if (tam) Them(hauto,tam);
 while (Stack)
 {
  tam=0;
  Chensau(tam,ut[Lay(Stack)]);
  Them(hauto,tam);
 }
 return hauto;
}
// Tinh ket qua bieu thuc o dang hau to
void Tinh(ct1 *&hauto)
{
 ct1 *s1=hauto,*s2=s1->tiep,*s3=s2->tiep,*tam;
 ct *kq;
 char t;

 do
 {
  t=s3->so->so;
  if ((gt(t)<=4) && !s3->so->tiep)
  {
   switch (t)
   {
    case '+':
     kq=Tong(s1->so,s2->so);
     break;
    case '-':
     kq=Hieu(s1->so,s2->so);
     break;
    case '*':
     kq=Tich(s1->so,s2->so);
     break;
    case '/':
     ct *du=0;
     kq=Thuong(s1->so,s2->so,du);
     if (!kq)
     {
      cout<<"Phep chia co loi !!!";exit(1);
     }
     XoaCT(du);
     break;
   }
   if (s3->tiep)
   {
    if (hauto!=s1)
    {
     tam=hauto;
     while (tam->tiep!=s1) tam=tam->tiep;
     tam->tiep=s2->tiep;
    }
    else hauto=s3;
   }
   else hauto=s3;
   XoaCT(s1->so);
   XoaCT(s2->so);
   XoaCT(s3->so);
   delete(s1);
   delete(s2);
   s3->so=kq;
   if (s3->tiep)
   {
    s1=hauto;
    s2=s1->tiep;
    s3=s2->tiep;
   }
   cout<<endl;
   Xuat1(hauto);
  }
  else
  {
   s1=s2;
   s2=s3;
   s3=s3->tiep;
  }
 }
 while (hauto->tiep);
}
// Xuat ket qua cua danh sach lien ket ra man hinh
void Xuat(ct *dt)
{
 ct *ht=dt;

 while (ht)
 {
  cout<<ht->so;
  ht=ht->tiep;
 }
}
// Xuat ket qua cua danh sach lien ket (kieu ct1) ra man hinh
void Xuat1(ct1 *dt)
{
 ct1 *ht=dt;

 while (ht)
 {
  Xuat(ht->so);
  cout<<" ";
  ht=ht->tiep;
 }
}
//
char Dk(char a,ct *&so)
{
 if (a>=10)
 {
  Chentruoc(so,(a-10)+48);
  return 1;
 }
 else
 {
  Chentruoc(so,a+48);
  return 0;
 }
}
// Tra ve 1 so ung voi muc uu tien cua toan tu
char gt(char c)
{
 for (int i=0;i<=strlen(ut);i++)
  if (c==ut[i]) return i;
 return i;
}
//Tong hai so
ct *Tong(ct *so1,ct *so2)
{
 ct *ht1,*ht2,*so=0;
 char a,b,nho=0,k1=so1->so=='-',k2=so2->so=='-';

 if ((k1 && k2) || (!k1 && !k2))
 {
  char k=0;

  if (k1)
  {
   so1=so1->tiep;
   so2=so2->tiep;
   k=1;
  }
  Dao(so1);
  Dao(so2);
  ht1=so1;
  ht2=so2;
  while (ht1)
  {
   a=ht1->so-48;
   ht1=ht1->tiep;
   if (ht2)
   {
    b=ht2->so-48;
    ht2=ht2->tiep;
   }
   else b=0;
   nho=Dk(a+b+nho,so);
  }
  while (ht2)
  {
   nho=Dk(ht2->so-48+nho,so);
   ht2=ht2->tiep;
  }
  if (nho) Chentruoc(so,nho+48);
  if (k) Chentruoc(so,'-');
  Dao(so1);
  Dao(so2);
 }
 else
 {
  if (k1)
  {
   so1=so1->tiep;
   so=Hieu(so2,so1);
  }
  else
  {
   so2=so2->tiep;
   so=Hieu(so1,so2);
  }
 }
 return so;
}
// Hieu 2 so
ct *Hieu(ct *so1,ct *so2)
{
 ct *ht1,*ht2,*so=0;
 char a,b,nho=0,k,k1=so1->so=='-',k2=so2->so=='-';

 if ((k1 && k2) || (!k1 && !k2))
 {
  if (k1)
  {
   ct *t;

   so1=so1->tiep;
   so2=so2->tiep;
   t=so1;
   so1=so2;
   so2=t;
  }
  k=Sosanh(so1,so2);
  Dao(so1);
  Dao(so2);
  if (k==-1)
  {
   ht1=so2;
   ht2=so1;
  }
  else
  {
   ht1=so1;
   ht2=so2;
  }
  while (ht1)
  {
   a=ht1->so-48;
   ht1=ht1->tiep;
   if (ht2)
   {
    b=ht2->so-48;
    ht2=ht2->tiep;
   }
   else b=0;
   if (a+nho-b>=0)
   {
    Chentruoc(so,(a+nho-b)+48);
    nho=0;
   }
   else
   {
    Chentruoc(so,(10+a+nho-b)+48);
    nho=-1;
   }
  }
  Xoa0(so);
  if (k==-1) Chentruoc(so,'-');
  Dao(so1);
  Dao(so2);
 }
 else
 {
  char k=0;
  if (k1)
  {
   so1=so1->tiep;
   k=1;
  }
  else so2=so2->tiep;
  so=Tong(so1,so2);
  if (k) Chentruoc(so,'-');
 }
 return so;
}
// Tich 2 so
ct *Tich(ct *so1,ct *so2)
{
 ct *so=0,*ht1,*ht2,*t=0,*tam;
 char m=0,nho=0,a,b,k=0,k1=so1->so=='-',k2=so2->so=='-';

 if (k1 && k2)
 {
  so1=so1->tiep;
  so2=so2->tiep;
 }
 else
  if (k1)
  {
   so1=so1->tiep;
   k=1;
  }
  else
   if (k2)
   {
    so2=so2->tiep;
    k=1;
   }
 Chentruoc(so,'0');
 Dao(so1);
 Dao(so2);
 ht2=so2;
 while (ht2)
 {
  a=ht2->so-48;
  ht1=so1;
  while (ht1)
  {
   b=ht1->so-48;
   if (a*b+nho>=10)
   {
    Chentruoc(t,((a*b+nho)%10)+48);
    nho=(a*b+nho)/10;
   }
   else
   {
    Chentruoc(t,(a*b+nho)+48);
    nho=0;
   }
   ht1=ht1->tiep;
  }
  if (nho)
  {
   Chentruoc(t,nho+48);
   nho=0;
  }
  for (int i=1;i<=m;i++) Chensau(t,'0');
  tam=Tong(so,t);
  XoaCT(so);
  XoaCT(t);
  so=tam;
  ht2=ht2->tiep;
  m++;
 }
 Dao(so1);
 Dao(so2);
 Xoa0(so);
 if (k && so->so>0) Chentruoc(so,'-');
 return so;
}
// Thuong cua 2 so lay nguyen va du
ct *Thuong(ct *so1,ct *so2,ct *&du)
{
 ct *ht1,*so=0,*t=0,*tam=0,*t2=0;
 char ss,m,i,k1=so1->so=='-',k2=so2->so=='-';

 Chensau(tam,'0');
 if (Sosanh(so2,tam))
 {
  if (k1) so1=so1->tiep;
  if (k2) so2=so2->tiep;
  delete tam;
  tam=0;
  ht1=so1;
  while (ht1)
  {
   Chensau(du,ht1->so);
   ss=Sosanh(du,so2);
   if (ss==-1) Chensau(so,'0');
   else
   {
    m=(du->so-48)/(so2->so-48);
    if (m==0) m=9;
    i=m;
    Chensau(tam,i+48);
    t=Tich(so2,tam);
    while (Sosanh(du,t)==-1)
    {
     i--;
     XoaCT(tam);
     XoaCT(t);
     Chensau(tam,i+48);
     t=Tich(so2,tam);
    }
    XoaCT(tam);
    Chensau(so,i+48);
    t2=Hieu(du,t);
    XoaCT(du);
    du=t2;
   }
   ht1=ht1->tiep;
  }
  Xoa0(so);
  Xoa0(du);
  if (((!k1 && k2) || (k1 && !k2)) && so->so>0) Chentruoc(so,'-');
  if (k1 && du->so>0) Chentruoc(du,'-');
 }
 return so;
}
// Dao vi tri cac thanh phan cua danh sach lien ket
void Dao(ct *&dt)
{
 ct *p1,*p2;

 p1=dt;
 dt=0;
 while (p1)
 {
  p2=p1->tiep;
  p1->tiep=dt;
  dt=p1;
  p1=p2;
 }
}
// So sanh 2 so (-1:so1<so2; 0:so1=so2; 1:so1>so2)
char Sosanh(ct *so1,ct *so2)
{
 ct *ht1,*ht2;
 char d1=0,d2=0;
 char m;

 ht1=so1;
 ht2=so2;
 if (so1->so=='-' && so2->so!='-') m=-1;
 else
  if (so1->so!='-' && so2->so=='-') m=1;
  else
  {
   while (ht1)
   {
    d1++;
    ht1=ht1->tiep;
   }
   while (ht2)
   {
    d2++;
    ht2=ht2->tiep;
   }
   if (d1>d2) m=1;
   else
    if (d1<d2) m=-1;
    else
    {
     ht1=so1;
     ht2=so2;
     while (ht1->tiep && ht1->so==ht2->so)
     {
      ht1=ht1->tiep;
      ht2=ht2->tiep;
     }
     if (ht1->so>ht2->so) m=1;
     else
      if (ht1->so<ht2->so) m=-1;
      else m=0;
    }
   if (m==1 && so1->so=='-') m=-1;
   else
    if (m==-1 && so1->so=='-') m=1;
  }
 return m;
}
// Cat bo cac so 0 o dau danh sach lien ket
void Xoa0(ct *&dt)
{
 ct *ht=dt;

 if (dt->so!='-')
 {
  while (ht->tiep && ht->so=='0')
  {
   ht=ht->tiep;
   delete dt;
   dt=ht;
  }
 }
 else
 {
  ct *p=ht,*nho;

  ht=ht->tiep;
  while (ht->tiep && ht->so=='0')
  {
   p->tiep=ht->tiep;
   nho=ht;
   delete nho;
   ht=ht->tiep;
  }
 }
}
// Xoa 1 danh sach lien ket
void XoaCT(ct *&dt)
{
 ct *ht=dt;

 while (ht)
 {
  ht=ht->tiep;
  delete dt;
  dt=ht;
 }
}