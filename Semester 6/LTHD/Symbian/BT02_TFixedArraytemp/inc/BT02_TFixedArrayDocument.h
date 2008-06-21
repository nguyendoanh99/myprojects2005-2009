/*
========================================================================
 Name        : BT02_TFixedArrayDocument.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT02_TFIXEDARRAYDOCUMENT_H
#define BT02_TFIXEDARRAYDOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CBT02_TFixedArrayDocument BT02_TFixedArrayDocument.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CBT02_TFixedArrayDocument : public CAknDocument
	{
public: 
	// constructor
	static CBT02_TFixedArrayDocument* NewL( CEikApplication& aApp );

private: 
	// constructors
	CBT02_TFixedArrayDocument( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // BT02_TFIXEDARRAYDOCUMENT_H
