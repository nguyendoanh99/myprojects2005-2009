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
	int m_iLength; 
	void TaoListRong();
public:
	LList();
	LList(const LList&);
	virtual ~LList();

	LList& operator =(const LList&);
	LList& AddHead(Node *); // Them 1 node vao dau List
	LList& AddHead(void *info); // Them info vao dau List
	LList& AddTail(Node *); // Them 1 node vao cuoi List
	LList& AddTail(void *info); // Them info vao cuoi List
	LList& DelNode(int); // Xoa 1 node ra khoi List tai vi tri cho truoc
	LList& DelHead(); // Xoa node nam o dau List
	LList& DelTail(); // Xoa node nam o cuoi List
	LList& Empty(); // Lam rong List

	bool SetNode(int, void*); // Ghi thong tin vao node tai vi tri cho truoc

	void* GetNode(int) const; // Lay thong tin cua mot node tai vi tri cho truoc
	bool IsEmpty() const; // Kiem tra List co rong hay khong
	int GetLength() const; // Cho biet so node hien co trong List
};

#endif