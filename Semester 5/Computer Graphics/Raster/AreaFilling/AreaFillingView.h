// AreaFillingView.h : interface of the CAreaFillingView class
//


#pragma once


class CAreaFillingView : public CView
{
protected: // create from serialization only
	CAreaFillingView();
	DECLARE_DYNCREATE(CAreaFillingView)

// Attributes
public:
	CAreaFillingDoc* GetDocument() const;

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
	virtual ~CAreaFillingView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in AreaFillingView.cpp
inline CAreaFillingDoc* CAreaFillingView::GetDocument() const
   { return reinterpret_cast<CAreaFillingDoc*>(m_pDocument); }
#endif

