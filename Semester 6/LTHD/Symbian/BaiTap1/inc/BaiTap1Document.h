/*
========================================================================
 Name        : BaiTap1Document.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BAITAP1DOCUMENT_H
#define BAITAP1DOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CBaiTap1Document BaiTap1Document.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CBaiTap1Document : public CAknDocument
	{
public: 
	// constructor
	static CBaiTap1Document* NewL( CEikApplication& aApp );

private: 
	// constructors
	CBaiTap1Document( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // BAITAP1DOCUMENT_H
