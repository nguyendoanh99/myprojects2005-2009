/*
========================================================================
 Name        : HelloCarbide2ndGUIDocument.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "HelloCarbide2ndGUIDocument.h"
#include "HelloCarbide2ndGUIAppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CHelloCarbide2ndGUIDocument::CHelloCarbide2ndGUIDocument( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CHelloCarbide2ndGUIDocument::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CHelloCarbide2ndGUIDocument, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CHelloCarbide2ndGUIDocument
 */
CHelloCarbide2ndGUIDocument* CHelloCarbide2ndGUIDocument::NewL( CEikApplication& aApp )
	{
	CHelloCarbide2ndGUIDocument* self = new ( ELeave ) CHelloCarbide2ndGUIDocument( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CHelloCarbide2ndGUIDocument::CreateAppUiL()
	{
	return new ( ELeave ) CHelloCarbide2ndGUIAppUi;
	}
				
