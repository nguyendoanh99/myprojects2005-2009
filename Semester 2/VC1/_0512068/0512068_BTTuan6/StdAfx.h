// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__7DFA8F08_2879_44D3_9DE3_515B31AC0263__INCLUDED_)
#define AFX_STDAFX_H__7DFA8F08_2879_44D3_9DE3_515B31AC0263__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


// TODO: reference additional headers your program requires here
#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <iostream.h>
#include <string.h>
#include <ctype.h>

struct node_st
{
	char info;
	struct node_st *pNext;
};
typedef struct node_st NODE_ST;

struct stack
{
	NODE_ST *pHead;
	NODE_ST *pTail;
	int so_node;
};
typedef struct stack STACK;

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__7DFA8F08_2879_44D3_9DE3_515B31AC0263__INCLUDED_)
