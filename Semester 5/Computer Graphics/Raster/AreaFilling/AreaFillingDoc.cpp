// AreaFillingDoc.cpp : implementation of the CAreaFillingDoc class
//

#include "stdafx.h"
#include "AreaFilling.h"

#include "AreaFillingDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAreaFillingDoc

IMPLEMENT_DYNCREATE(CAreaFillingDoc, CDocument)

BEGIN_MESSAGE_MAP(CAreaFillingDoc, CDocument)
END_MESSAGE_MAP()


// CAreaFillingDoc construction/destruction

CAreaFillingDoc::CAreaFillingDoc()
{
	// TODO: add one-time construction code here

}

CAreaFillingDoc::~CAreaFillingDoc()
{
}

BOOL CAreaFillingDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CAreaFillingDoc serialization

void CAreaFillingDoc::Serialize(CArchive& ar)
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


// CAreaFillingDoc diagnostics

#ifdef _DEBUG
void CAreaFillingDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CAreaFillingDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CAreaFillingDoc commands
