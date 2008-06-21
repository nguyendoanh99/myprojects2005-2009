/*
========================================================================
 Name        : HelloCarbide3rdGUIDocument.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE3RDGUIDOCUMENT_H
#define HELLOCARBIDE3RDGUIDOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CHelloCarbide3rdGUIDocument HelloCarbide3rdGUIDocument.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CHelloCarbide3rdGUIDocument : public CAknDocument
	{
public: 
	// constructor
	static CHelloCarbide3rdGUIDocument* NewL( CEikApplication& aApp );

private: 
	// constructors
	CHelloCarbide3rdGUIDocument( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // HELLOCARBIDE3RDGUIDOCUMENT_H
