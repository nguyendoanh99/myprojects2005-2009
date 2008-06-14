#ifndef _LIST_H
#define _LIST_H

void init(LIST &);
NODE *getnode(int);
void addtail(LIST &,NODE*);
void delnode(LIST &,NODE *);

#endif