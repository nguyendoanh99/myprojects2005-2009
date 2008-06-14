// CircleDoc.cpp : implementation of the CCircleDoc class
//

#include "stdafx.h"
#include "Circle.h"

#include "CircleDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCircleDoc

IMPLEMENT_DYNCREATE(CCircleDoc, CDocument)

BEGIN_MESSAGE_MAP(CCircleDoc, CDocument)
END_MESSAGE_MAP()


// CCircleDoc construction/destruction

CCircleDoc::CCircleDoc()
{
	// TODO: add one-time construction code here

}

CCircleDoc::~CCircleDoc()
{
}

BOOL CCircleDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CCircleDoc serialization

void CCircleDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}


// CCircleDoc diagnostics

#ifdef _DEBUG
void CCircleDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CCircleDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CCircleDoc commands
