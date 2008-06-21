/*
========================================================================
 Name        : tempDocument.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef TEMPDOCUMENT_H
#define TEMPDOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CtempDocument tempDocument.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CtempDocument : public CAknDocument
	{
public: 
	// constructor
	static CtempDocument* NewL( CEikApplication& aApp );

private: 
	// constructors
	CtempDocument( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // TEMPDOCUMENT_H
