/*
========================================================================
 Name        : BT01_DescriptorsDocument.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT01_DESCRIPTORSDOCUMENT_H
#define BT01_DESCRIPTORSDOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CBT01_DescriptorsDocument BT01_DescriptorsDocument.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CBT01_DescriptorsDocument : public CAknDocument
	{
public: 
	// constructor
	static CBT01_DescriptorsDocument* NewL( CEikApplication& aApp );

private: 
	// constructors
	CBT01_DescriptorsDocument( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // BT01_DESCRIPTORSDOCUMENT_H
