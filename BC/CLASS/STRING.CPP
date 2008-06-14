#include <conio.h>
#include <iostream.h>
#include <stdio.h>

class String
	{
	  friend int length(const String&); // Tra ve chieu dai cua chuoi
	  friend String operator+(const String&,const String&); // Cong chuoi
	  friend void Ucase(String&); // Chuyen chuoi in thuong sang chuoi in hoa
	  friend void Lcase(String&); // Chuyen chuoi in hoa sang chuoi in thuong
	  friend String copy(const String&,int,int); // Sao chep chuoi
	  friend void del(String&,int,int); // Xoa chuoi
	  friend ostream& operator<<(ostream &,const String&); // Xuat chuoi
	  friend istream& operator>>(istream &,String&); // Nhap chuoi
	  friend int Find(const String&,const String&); // Tim chuoi con
	  friend int operator==(const String&,const String&); // So sanh 2 chuoi
	  friend int StrSS(const String&,const String&); // So sanh 2 chuoi
	  char Uchar(int)const; // Chuyen ki tu thuong sang ki tu hoa
	  char Lchar(int)const; // Chuyen ki tu hoa sang ki tu thuong
	  char* s;
	  int max,l;
	 public:
	  String(int=255);       	    // constructor
	  String(int=255,char);  	    // constructor
	  String(int=255,char*); 	    // constructor
	  String(const String&); 	    // copy constructor
	  String(char*); 		    // Chuyen kieu char* sang kieu String
	  String(char); 		    // Chuyen kieu char sang kieu String
	  String &operator=(const String&); // Phep gan
	  String &operator+=(const String&);// Cong va gan chuoi
	  operator char*() const;	    // Chuyen kieu String sang kieu char*
	  char &operator[](int i) const{return s[i-1];}// Tra ve ky tu thu i cua chuoi
	  ~String() {delete [] s;};	    // destructor
	};

void main()
{
 clrscr();
 String g(10,"aBc"),s(4,"AB"),d(3,"asdadsdfdhd");
 String f=g;
 String k(10,"123");
 g+="123456";
 g+='4';

 cin>>f;
 cout<<endl<<f<<endl;
 cout<<Find(f,k)<<"\n";
 cout<<g<<"\n";
 Ucase(g);
 cout<<g<<"\n";
 Lcase(g);
 cout<<g<<"\n";
 del(g,13,1);
 cout<<g<<"\n";
 getch();
}
// constructor
String::String(int m)
{
 max=m;
 l=0;
 s=new char[m];
}
// constructor
String::String(int m,char c)
{
 max=m;
 l=1;
 s=new char[max];
 s[0]=c;
}
// constructor
String::String(int m,char* c)
{
 max=m;
 l=0;
 s=new char[max];
 while (*c && l<max) s[l++]=*c++;
}
// copy constructor
String::String(const String& c)
{
 char *t=c.s;
 int m;

 max=c.max;
 l=0;
 s=new char[max];
 m=c.l>max?max:c.l;
 while (l<m) s[l++]=*t++;
}
// Phep gan
String &String::operator=(const String& c)
{
 char *t=c.s;
 int m;

 l=0;
 m=c.l>max?max:c.l;
 while (l<m) s[l++]=*t++;
 return *this;
}
// Cong va gan chuoi
String &String::operator+=(const String& c)
{
 char *t=c.s;
 int m=c.l+l>max?max:c.l+l;

 while (l<m)s[l++]=*t++;
 return *this;
}
// Chuyen kieu char* sang kieu String
String::String(char* c)
{
 char *t=c;

 max=0;
 while (*t++) max++;
 s=new char[max];
 l=0;
 while (*c) s[l++]=*c++;
}
// Chuyen kieu char sang kieu String
String::String(char c)
{

 max=1;
 s=new char[max];
 l=1;
 s[0]=c;
}
// Tra ve chieu dai cua chuoi
int length(const String& c)
{
 return c.l;
}
// Cong chuoi
String operator+(const String& s1,const String& s2)
{
 int m=length(s1)+length(s2);

 m=m>255?m:255;

 String s(m);
 char *c1=s1.s,*c2=s2.s;

 while (s.l<s1.l) s.s[s.l++]=*c1++;
 while (s.l<s1.l+s2.l) s.s[s.l++]=*c2++;
 return s;
}
// Chuyen chuoi in thuong sang chuoi in hoa
void Ucase(String &c)
{
 int i=0;

 while (i<c.l)
 {
  c.s[i]=c.Uchar(i);
  i++;
 }
}
// Chuyen chuoi in hoa sang chuoi in thuong
void Lcase(String &c)
{
 int i=0;

 while (i<c.l)
 {
  c.s[i]=c.Lchar(i);
  i++;
 }
}
// Sao chep n ki tu tu vi tri v cua chuoi c
String copy(const String &c,int v,int n)
{
 int m=n,i=--v;

 m=m>c.l-v?c.l-v:m;

 String s(m);

 m+=i;
 while (i<m) s.s[s.l++]=c.s[i++];
 return s;
}
// Xoa n ki tu tu vi tri v cua chuoi c
void del(String& c,int v,int n)
{
 int i=--v+n;
 i=i<0?0:i;
 while (i<c.l) c.s[v++]=c.s[i++];
 c.l-=c.l>v+n?n:c.l-v;
 c.l=c.l>0?c.l:0;
}
// Xuat chuoi
ostream& operator<<(ostream &os,const String& c)
{
 return os<<(char*)c;
}
// Nhap chuoi
istream& operator>>(istream &is,String &c)
{
 char t;
 c="";
 do
 {
  t=getche();
  if (t!=13) c+=t;
 }
 while (t!=13);
 return is;
}
// Chuyen kieu String sang kieu char*
String::operator char*() const
{
 char *t=s;
 t[l]=0;
 return t;
}
// Tim chuoi con c2 trong chuoi me c1
int Find(const String &c1,const String &c2)
{
 int i=0;
 while (i<c1.l-c2.l)
  if (copy(c1,++i,c2.l)==c2) return i;
 return 0;
}
// So sanh 2 chuoi
int operator==(const String &c1,const String &c2)
{
 return !StrSS(c1,c2);
}
// So sanh 2 chuoi
int StrSS(const String &c1,const String &c2)
{
 int i=0;

 if (c1.l>c2.l) return 1;
 if (c1.l<c2.l) return -1;
 while (i<c1.l)
 {
  if (c1.Uchar(i)>c2.Uchar(i)) return 1;
  if (c1.Uchar(i)<c2.Uchar(i)) return -1;
  if (c1.s[i]<c2.s[i]) return 1;
  if (c1.s[i]>c2.s[i]) return -1;
  i++;
 }
 return 0;
}
// Chuyen ki tu thuong sang ki tu hoa
char String::Uchar(int i)const
{
 return (s[i]>='a' && s[i]<='z')?s[i]-32:s[i];
}
// Chuyen ki tu hoa sang ki tu thuong
char String::Lchar(int i)const
{
 return (s[i]>='A' && s[i]<='Z')?s[i]+32:s[i];
}