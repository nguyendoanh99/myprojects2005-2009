#ifndef _LLIST_
#define _LLIST_

struct Node
{
	void *m_info;
	Node *m_pNext;
};

Node* GetNode(void *);

class LList
{
private:
	Node *m_pHead;
	Node *m_pTail;
	int m_iSoNode;
	void TaoListRong();
public:
	LList();
	LList(const LList&);
	virtual ~LList();

	LList& operator =(const LList&);
	LList& AddHead(Node *);
	LList& AddHead(void *);
	LList& AddTail(Node *);
	LList& AddTail(void *);
	LList& DelNode(Node *);
	LList& Empty();

	void SetNode(int, void*);

	Node* GetNode(int) const;
	bool IsEmpty() const;
};

#endif