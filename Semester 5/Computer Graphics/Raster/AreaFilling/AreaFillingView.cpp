// AreaFillingView.cpp : implementation of the CAreaFillingView class
//

#include "stdafx.h"
#include "AreaFilling.h"

#include "AreaFillingDoc.h"
#include "AreaFillingView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAreaFillingView

IMPLEMENT_DYNCREATE(CAreaFillingView, CView)

BEGIN_MESSAGE_MAP(CAreaFillingView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CAreaFillingView construction/destruction

CAreaFillingView::CAreaFillingView()
{
	// TODO: add construction code here

}

CAreaFillingView::~CAreaFillingView()
{
}

BOOL CAreaFillingView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CAreaFillingView drawing

void CAreaFillingView::OnDraw(CDC* pDC)
{
	CAreaFillingDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
//	ReadFileStar5("Star5.inp", pDC);
//	ReadFileScanLineTriangle("ScanLineTriangle.inp", pDC);
	ReadFileStar5WithFilling("Star5WithFilling.inp", pDC);
}


// CAreaFillingView printing

BOOL CAreaFillingView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CAreaFillingView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CAreaFillingView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CAreaFillingView diagnostics

#ifdef _DEBUG
void CAreaFillingView::AssertValid() const
{
	CView::AssertValid();
}

void CAreaFillingView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CAreaFillingDoc* CAreaFillingView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CAreaFillingDoc)));
	return (CAreaFillingDoc*)m_pDocument;
}
#endif //_DEBUG


// CAreaFillingView message handlers
