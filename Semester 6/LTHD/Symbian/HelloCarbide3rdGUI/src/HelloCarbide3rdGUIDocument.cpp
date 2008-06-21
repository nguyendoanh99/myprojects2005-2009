/*
========================================================================
 Name        : HelloCarbide3rdGUIDocument.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "HelloCarbide3rdGUIDocument.h"
#include "HelloCarbide3rdGUIAppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CHelloCarbide3rdGUIDocument::CHelloCarbide3rdGUIDocument( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CHelloCarbide3rdGUIDocument::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CHelloCarbide3rdGUIDocument, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CHelloCarbide3rdGUIDocument
 */
CHelloCarbide3rdGUIDocument* CHelloCarbide3rdGUIDocument::NewL( CEikApplication& aApp )
	{
	CHelloCarbide3rdGUIDocument* self = new ( ELeave ) CHelloCarbide3rdGUIDocument( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CHelloCarbide3rdGUIDocument::CreateAppUiL()
	{
	return new ( ELeave ) CHelloCarbide3rdGUIAppUi;
	}
				
