// PolygonDoc.h : interface of the CPolygonDoc class
//


#pragma once


class CPolygonDoc : public CDocument
{
protected: // create from serialization only
	CPolygonDoc();
	DECLARE_DYNCREATE(CPolygonDoc)

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
	virtual ~CPolygonDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


