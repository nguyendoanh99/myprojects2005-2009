#ifndef STACK_DSLK_H
#define STACK_DSLK_H

struct kdl
{
	int l,r;
};
typedef struct kdl KDL;
// Dinh nghia Stack theo danh sach lien ket don
struct node
{		
	KDL info;
	struct node *pNext;
};
typedef struct node NODE;
struct stack
{
  	NODE *pHead;
	NODE *pTail;
};
typedef struct stack STACK;
// Cac thao tac tren Stack
KDL pop(STACK &);
void push(STACK&,KDL);
void init(STACK&);
int isEmpty(STACK);
// Cac thao tac tren NODE
NODE *getnode(KDL);

#endif	// #ifndef