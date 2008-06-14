#ifndef _STACK_H
#define _STACK_H

struct nodestack
{
	void *info;
	struct nodestack *pNext;
};
typedef struct nodestack NODESTACK;
struct stack
{
	NODESTACK *pHead;
	NODESTACK *pTail;
};
typedef struct stack STACK;

void addhead(STACK &,NODESTACK *);
void init(STACK &);
void push(STACK &,NODESTACK *);
void *pop(STACK &);
NODESTACK *getnode(void *);
int isEmpty(STACK);

#endif