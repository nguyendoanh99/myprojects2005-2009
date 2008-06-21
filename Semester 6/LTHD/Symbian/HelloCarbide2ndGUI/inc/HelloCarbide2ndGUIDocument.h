/*
========================================================================
 Name        : HelloCarbide2ndGUIDocument.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE2NDGUIDOCUMENT_H
#define HELLOCARBIDE2NDGUIDOCUMENT_H

#include <akndoc.h>
		
class CEikAppUi;

/**
* @class	CHelloCarbide2ndGUIDocument HelloCarbide2ndGUIDocument.h
* @brief	A CAknDocument-derived class is required by the S60 application 
*           framework. It is responsible for creating the AppUi object. 
*/
class CHelloCarbide2ndGUIDocument : public CAknDocument
	{
public: 
	// constructor
	static CHelloCarbide2ndGUIDocument* NewL( CEikApplication& aApp );

private: 
	// constructors
	CHelloCarbide2ndGUIDocument( CEikApplication& aApp );
	void ConstructL();
	
public: 
	// from base class CEikDocument
	CEikAppUi* CreateAppUiL();
	};
#endif // HELLOCARBIDE2NDGUIDOCUMENT_H
