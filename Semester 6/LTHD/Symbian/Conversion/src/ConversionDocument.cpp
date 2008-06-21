/*
========================================================================
 Name        : ConversionDocument.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "ConversionDocument.h"
#include "ConversionAppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CConversionDocument::CConversionDocument( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CConversionDocument::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CConversionDocument, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CConversionDocument
 */
CConversionDocument* CConversionDocument::NewL( CEikApplication& aApp )
	{
	CConversionDocument* self = new ( ELeave ) CConversionDocument( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CConversionDocument::CreateAppUiL()
	{
	return new ( ELeave ) CConversionAppUi;
	}
				
