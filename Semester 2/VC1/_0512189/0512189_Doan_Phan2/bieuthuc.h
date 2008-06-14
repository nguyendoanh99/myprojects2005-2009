#ifndef _BIEUTHUC_
#define _BIEUTHUC_


void init(BIEUTHUC &);
BT* getnode(char*);
void addhead(BIEUTHUC &,NODE*);
void addtail(BIEUTHUC &,NODE*);

int input(BIEUTHUC&);
int output(BIEUTHUC);
void process(BIEUTHUC&);
void tinhtoan(BT*);
#endif
