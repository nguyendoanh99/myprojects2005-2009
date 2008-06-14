#ifndef _BIGINT_H
#define _BIGINT_H
#define MAX 1000
#include "stack.h"

enum so_sanh
{
	LON_HON,
	NHO_HON,
	BANG_NHAU,
	__NULL
};
typedef enum so_sanh SO_SANH;
// Khai bao cau truc du lieu
struct node
{	
	char digit;
	struct node *pNext;
	struct node *pPrev;
};
typedef struct node NODE;
struct bigint
{
	// -1 : so am
	// 1  : so duong
	char dau;
	NODE *pHead;
	NODE *pTail;
};
typedef struct bigint BIGINT;
// Khai bao ham
void init(BIGINT&);
NODE *getnode(int);
void addhead(BIGINT &,NODE *);
void addtail(BIGINT &,NODE *);
int isEmpty(BIGINT);
int xuat(BIGINT);
BIGINT createBIGINT(char *);
BIGINT createBIGINT(BIGINT);
BIGINT createBIGINT(int);
void deleteBIGINT(BIGINT &);
void xoa0(BIGINT &); // Xoa cac so 0 vo nghia
int kiemtra0(BIGINT); // Kiem tra xem so dang xet co bang 0 hay khong
int convert(BIGINT);

BIGINT tong(BIGINT ,BIGINT);
BIGINT hieu(BIGINT ,BIGINT);
BIGINT tich(BIGINT ,BIGINT);
int thuong(BIGINT,BIGINT,BIGINT&,BIGINT&);
BIGINT pow(BIGINT,BIGINT);
BIGINT giaithua(BIGINT);
BIGINT pow(BIGINT,int);
BIGINT giaithua(int);
BIGINT operator+(BIGINT ,BIGINT);
BIGINT operator-(BIGINT ,BIGINT);
BIGINT operator*(BIGINT ,BIGINT);
BIGINT operator/(BIGINT ,BIGINT);
BIGINT operator%(BIGINT ,BIGINT);
I_NODE *tinhbieuthuc(STACK &);
STACK Trung_to_hau_to(char *);

int length(BIGINT);
SO_SANH sosanh(BIGINT ,BIGINT);// 1:">"	0:"="	-1:"<"
SO_SANH ssanh(BIGINT ,BIGINT); // 1:">"	0:"="	-1:"<"
int uutien(char); // Lay do uu tien cua toan tu

#endif