// AreaFillingDoc.h : interface of the CAreaFillingDoc class
//


#pragma once


class CAreaFillingDoc : public CDocument
{
protected: // create from serialization only
	CAreaFillingDoc();
	DECLARE_DYNCREATE(CAreaFillingDoc)

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
	virtual ~CAreaFillingDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


