// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__B2240095_2ACD_4FAA_83D8_7C82A09F90AC__INCLUDED_)
#define AFX_STDAFX_H__B2240095_2ACD_4FAA_83D8_7C82A09F90AC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
struct sv
{
	char MSSV[11];
	char hoten[41];
	char diachi[51];
	float dtb;
};
typedef struct sv SV;
int timtuyentinh(SV [],int ,char []);
int timnhiphan(SV [],int ,char []);

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__B2240095_2ACD_4FAA_83D8_7C82A09F90AC__INCLUDED_)
