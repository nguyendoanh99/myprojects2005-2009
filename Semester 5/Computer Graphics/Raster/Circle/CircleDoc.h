// CircleDoc.h : interface of the CCircleDoc class
//


#pragma once


class CCircleDoc : public CDocument
{
protected: // create from serialization only
	CCircleDoc();
	DECLARE_DYNCREATE(CCircleDoc)

// Attributes
public:

// Operations
public:

// Overrides
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CCircleDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


