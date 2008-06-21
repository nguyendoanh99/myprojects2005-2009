/*
========================================================================
 Name        : BT02_TFixedArrayDocument.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "BT02_TFixedArrayDocument.h"
#include "BT02_TFixedArrayAppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CBT02_TFixedArrayDocument::CBT02_TFixedArrayDocument( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CBT02_TFixedArrayDocument::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CBT02_TFixedArrayDocument, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CBT02_TFixedArrayDocument
 */
CBT02_TFixedArrayDocument* CBT02_TFixedArrayDocument::NewL( CEikApplication& aApp )
	{
	CBT02_TFixedArrayDocument* self = new ( ELeave ) CBT02_TFixedArrayDocument( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CBT02_TFixedArrayDocument::CreateAppUiL()
	{
	return new ( ELeave ) CBT02_TFixedArrayAppUi;
	}
				
