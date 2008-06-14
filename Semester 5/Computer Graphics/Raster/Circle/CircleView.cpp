// CircleView.cpp : implementation of the CCircleView class
//

#include "stdafx.h"
#include "Circle.h"

#include "CircleDoc.h"
#include "CircleView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCircleView

IMPLEMENT_DYNCREATE(CCircleView, CView)

BEGIN_MESSAGE_MAP(CCircleView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CCircleView construction/destruction

CCircleView::CCircleView()
{
	// TODO: add construction code here

}

CCircleView::~CCircleView()
{
}

BOOL CCircleView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CCircleView drawing

void CCircleView::OnDraw(CDC* pDC)
{
	CCircleDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
	ReadFileCircle("Circle.inp", pDC);
}


// CCircleView printing

BOOL CCircleView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CCircleView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CCircleView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CCircleView diagnostics

#ifdef _DEBUG
void CCircleView::AssertValid() const
{
	CView::AssertValid();
}

void CCircleView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CCircleDoc* CCircleView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CCircleDoc)));
	return (CCircleDoc*)m_pDocument;
}
#endif //_DEBUG


// CCircleView message handlers
