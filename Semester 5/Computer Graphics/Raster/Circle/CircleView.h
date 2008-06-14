// CircleView.h : interface of the CCircleView class
//


#pragma once


class CCircleView : public CView
{
protected: // create from serialization only
	CCircleView();
	DECLARE_DYNCREATE(CCircleView)

// Attributes
public:
	CCircleDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CCircleView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in CircleView.cpp
inline CCircleDoc* CCircleView::GetDocument() const
   { return reinterpret_cast<CCircleDoc*>(m_pDocument); }
#endif

