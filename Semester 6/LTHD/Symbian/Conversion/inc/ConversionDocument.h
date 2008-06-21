/*
========================================================================
 Name        : ConversionDocument.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef CONVERSIONDOCUMENT_H
#define CONVERSIONDOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CConversionDocument ConversionDocument.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CConversionDocument : public CAknDocument
	{
public: 
	// constructor
	static CConversionDocument* NewL( CEikApplication& aApp );

private: 
	// constructors
	CConversionDocument( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // CONVERSIONDOCUMENT_H
