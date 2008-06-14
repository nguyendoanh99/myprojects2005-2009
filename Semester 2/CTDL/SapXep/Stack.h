#ifndef STACK_H
#define STACK_H

struct kdl
{
	int l,r;
};
typedef struct kdl KDL;

// Dinh nghia Stack theo cau truc mang
struct stack
{
	KDL a[100];
	int n;
};
typedef struct stack STACK;
// Cac thao tac tren Stack
KDL pop(STACK &);
void push(STACK&,KDL);
void init(STACK&);
int isEmpty(STACK);

#endif // #ifndef
