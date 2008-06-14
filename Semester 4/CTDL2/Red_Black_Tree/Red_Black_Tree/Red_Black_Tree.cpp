#include <iostream>

typedef enum mau
{BLACK, 
RED} MAU;
typedef struct node
{
	int key;
	node *pLeft;
	node *pRight;
	node *pParent;
	int iMau;
} NODE;
typedef NODE* TREE;

void Insert_Node(TREE, NODE*);
void Insert_FixUp(TREE, NODE*);
void Right_Rotate(TREE, NODE*);
void Left_Rotate(TREE, NODE*);

void main()
{
}

void Insert_Node(TREE T, NODE* x)
{
	NODE *temp = T;

	while (temp != 0)
	{
		if (temp->key > x->key)
			temp = temp->pLeft;
		else
			temp = temp->pRight;
	}

	x->iMau = RED;
	x->pLeft = 0;
	x->pRight = 0;
	x->pParent = temp;

	Insert_FixUp(T, x);
}

void Insert_FixUp(TREE T, NODE *x)
{
	if (
}

void Right_Rotate(TREE T, NODE *x)
{
	NODE *y = x->pLeft;
	x->pLeft = y->pRight;
	
	if (y->pRight != 0)
		y->pRight->pParent = x;

	y->pRight = x;
	y->pParent = x->pParent;

	if (x == T)
		T = y;
	else
		if (x == x->pParent->pLeft)
			x->pParent->pLeft = y;
		else
			x->pParent->pRight = y;

	x->pParent = y;
}

void Left_Rotate(TREE T, NODE *x)
{
	NODE *y = x->pRight;
	x->pRight = y->pLeft;
	
	if (y->pLeft != 0)
		y->pLeft->pParent = x;
	
	y->pLeft = x;
	y->pParent = x->pParent;

	if (x == T)
		T = y;
	else
		if (x == x->pParent->pLeft)
			x->pParent->pLeft = y;
		else
			x->pParent->pRight = y;

	x->pParent = y;
}