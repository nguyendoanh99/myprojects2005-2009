#ifndef _STACK_H
#define _STACK_H
// Liet ke cac kieu cua NODESTACK
enum loai_node
{
	_BIGINT,
	_CHAR,
	_NULL,
	_BOOL
};
typedef enum loai_node LOAI_NODE;
// Thong tin cua NODESTACK
struct i_node
{
	LOAI_NODE loai;
	void *pInfo;
};
typedef struct i_node I_NODE;
struct nodestack
{
	I_NODE info;
	struct nodestack *pNext;
};
typedef struct nodestack NODESTACK;
struct stack
{
	NODESTACK *pHead;
	NODESTACK *pTail;
};
typedef struct stack STACK;

void addtail(STACK &,NODESTACK *);
void addhead(STACK &,NODESTACK *);
void addafter(STACK &,NODESTACK *,NODESTACK *);
void init(STACK &);
void push(STACK &,NODESTACK *);
I_NODE pop(STACK &);
I_NODE top(STACK);
NODESTACK *getnode(I_NODE);
int isEmpty(STACK);
void Empty(STACK &);
void delafter(STACK &,NODESTACK *);
void xuat(STACK );
void xuat(I_NODE*);

#endif