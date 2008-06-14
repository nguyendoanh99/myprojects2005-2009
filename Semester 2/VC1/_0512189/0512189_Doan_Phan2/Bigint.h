#ifndef _BIGINT_
#define _BIGINT_


void init(BIGINT &);
NODE* getnode(int);
void addhead(BIGINT &,NODE*);
void addtail(BIGINT &,NODE*);

BIGINT CreateBigint(char*);	//tao 1 so BIGINT tu 1 chuoi
BIGINT CreateBigint(BIGINT);//tao 1 so BIGINT giong BIGINT tham so

void xoa0(BIGINT &); // Xoa cac so 0 vo nghia dung dau 1 so
int kiemtra0(BIGINT);//Kiem tra 1 so co = 0 ko ?

BIGINT cong(BIGINT,BIGINT);
BIGINT tru(BIGINT,BIGINT);
BIGINT operator+(BIGINT,BIGINT);
BIGINT operator-(BIGINT,BIGINT);
void xuat(BIGINT);
int ss(BIGINT,BIGINT);	//So sanh tri tuyet doi cua hai so
int sosanh(BIGINT,BIGINT);
void hoanvi(BIGINT &,BIGINT &);



#endif
