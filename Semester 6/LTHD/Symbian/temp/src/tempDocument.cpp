/*
========================================================================
 Name        : tempDocument.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "tempDocument.h"
#include "tempAppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CtempDocument::CtempDocument( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CtempDocument::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CtempDocument, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CtempDocument
 */
CtempDocument* CtempDocument::NewL( CEikApplication& aApp )
	{
	CtempDocument* self = new ( ELeave ) CtempDocument( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CtempDocument::CreateAppUiL()
	{
	return new ( ELeave ) CtempAppUi;
	}
				
