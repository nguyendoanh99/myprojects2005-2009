// Thuc thi ham Ackermann de qui:
// a(0,n)=1
// a(1,0)=2
// a(m,0)=m+2 if m>1
// a(m,n)=a(a(m-1,n),n-1) if m>0 va n>0

#include <iostream.h>
#include <conio.h>
#include <stdio.h>

struct ngang
	{
	 unsigned long n;
	 unsigned long so;
	 ngang *ng;
	};
struct doc
	{
	 unsigned long m;
	 ngang *ng;
	 doc *d;
	} *DL=0;
FILE *f;

void Chen_ngang_t(doc *&,ngang *,unsigned long,unsigned long);
doc *Chen_doc_t(doc *&,doc *,unsigned long);
void Chen_mn(doc *&,unsigned long,unsigned long,unsigned long);
unsigned long Tim(doc *&,unsigned long,unsigned long);
unsigned long A(unsigned long,unsigned long);

void main()
{
 unsigned long m,n;

 clrscr();
 f=fopen("C:\\AA.OUT","wt");
 cout<<"m,n=";
 cin>>m>>n;
 cout<<A(m,n);
 fclose(f);
 getch();
}
// Chen vao truoc ht 1 phan tu (DSLK co kieu ngang) n la chi so ngang cua mang, so la gia tri
void Chen_ngang_t(doc *&dt,ngang *ht,unsigned long n,unsigned long so)
{
 ngang *tam=new ngang;

 tam->n=n;
 tam->so=so;
 if (!dt->ng)
 {
  tam->ng=0;
  dt->ng=tam;
 }
 else
  if (ht==dt->ng)
  {
   tam->ng=dt->ng;
   dt->ng=tam;
  }
  else
  {
   ngang *t=dt->ng;

   while (t->ng!=ht) t=t->ng;
   tam->ng=ht;
   t->ng=tam;
  }
}
// Chen vao truoc ht 1 phan tu (DSLK co kieu doc) m la chi so doc cua mang
// Ham tra ve la 1 con tro co kieu ngang
doc *Chen_doc_t(doc *&dt,doc *ht,unsigned long m)
{
 doc *tam=new doc;

 tam->m=m;
 tam->ng=0;
 if (!dt)
 {
  tam->d=0;
  dt=tam;
 }
 else
  if (dt==ht)
  {
   tam->d=dt;
   dt=tam;
  }
  else
  {
   doc *t=dt;

   while (t->d!=ht) t=t->d;
   tam->d=ht;
   t->d=tam;
  }
 return tam;
}
// Chen vao DSLK dt (kieu doc) 1 phan tu co chi so m,n va co gia tri la so
void Chen_mn(doc *&dt,unsigned long m,unsigned long n,unsigned long so)
{
 doc *ht,*ht_n;
 ngang *ht1;

 if (!dt)
 {
  Chen_ngang_t(Chen_doc_t(dt,ht,m),ht1,n,so);
 }
 else
 {
  ht=dt;
  while (ht->m<m && ht) ht=ht->d;
  if (!ht || ht->m>m) ht_n=Chen_doc_t(dt,ht,m);
  else ht_n=ht;
  if (!ht_n) Chen_ngang_t(ht_n,ht1,n,so);
  else
  {
   ht1=ht_n->ng;
   while (ht1->n<n && ht1) ht1=ht1->ng;
   if (!ht1 || ht1->n>n) Chen_ngang_t(ht_n,ht1,n,so);
  }
 }
}
// Tim ket qua thong qua chi so m,n
unsigned long Tim(doc *&dt,unsigned long m,unsigned long n)
{
 doc *ht;
 ngang *ht1,*tam;
 unsigned long a;

 if (!dt) return 0;
 else
 {
  ht=dt;
  while (ht->m<m && ht) ht=ht->d;
  if (!ht || ht->m>m) return 0;
  ht1=ht->ng;
  while (ht1->n<n && ht1)
  {
   tam=ht1;
   ht1=ht1->ng;
  }
  if (!ht1 || ht1->n>n) return 0;
  if (ht1!=ht->ng) tam->ng=ht1->ng;
  else ht->ng=ht1->ng;
  a=ht1->so;
  delete ht1;
  return a;
 }
}
// a(0,n)=1
// a(1,0)=2
// a(m,0)=m+2 if m>1
// a(m,n)=a(a(m-1,n),n-1) if m>0 va n>0
unsigned long A(unsigned long m,unsigned long n)
{
 if (m==0) return 1;
 if (n==0)
  if (m==1) return 2;
  else
  {
//     cout<<"A["<<m<<","<<n<<"]="<<m+2<<endl;
//   fprintf(f,"A[%lu,%lu]=%lu\n",m,n,m+2);
   return m+2;
  }
 unsigned long t=Tim(DL,m,n);

 if (!t)
 {
  fprintf(f,"D A[%lu,%lu]=A[A[%lu,%lu],%lu]\n",m,n,m-1,n,n-1);
  unsigned long so=A(A(m-1,n),n-1);

  Chen_mn(DL,m,n,so);
  return so;
 }
// cout<<"A["<<m<<","<<n<<"]="<<t<<endl;
// fprintf(f,"Ma A[%lu,%lu]=%lu\n",m,n,t);
 return t;
}