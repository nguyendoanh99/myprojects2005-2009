/*
========================================================================
 Name        : BT01_DescriptorsDocument.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "BT01_DescriptorsDocument.h"
#include "BT01_DescriptorsAppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CBT01_DescriptorsDocument::CBT01_DescriptorsDocument( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CBT01_DescriptorsDocument::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CBT01_DescriptorsDocument, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CBT01_DescriptorsDocument
 */
CBT01_DescriptorsDocument* CBT01_DescriptorsDocument::NewL( CEikApplication& aApp )
	{
	CBT01_DescriptorsDocument* self = new ( ELeave ) CBT01_DescriptorsDocument( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CBT01_DescriptorsDocument::CreateAppUiL()
	{
	return new ( ELeave ) CBT01_DescriptorsAppUi;
	}
				
