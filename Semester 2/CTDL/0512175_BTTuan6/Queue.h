#ifndef _QUEUE_H
#define _QUEUE_H

struct nodequeue
{
	void *info;	
	struct nodequeue *pNext;
};
typedef struct nodequeue NODEQUEUE;
struct queue
{
	NODEQUEUE *pHead;
	NODEQUEUE *pTail;
};
typedef struct queue QUEUE;

void addtail(QUEUE &,NODEQUEUE *);
void init(QUEUE &);
void enQueue(QUEUE &,NODEQUEUE *);
void *deQueue(QUEUE &);
NODEQUEUE *_getnode(void *);
int isEmpty(QUEUE);

#endif