/*
========================================================================
 Name        : BaiTap1Document.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated User Includes]
#include "BaiTap1Document.h"
#include "BaiTap1AppUi.h"
// ]]] end generated region [Generated User Includes]

/**
 * @brief Constructs the document class for the application.
 * @param anApplication the application instance
 */
CBaiTap1Document::CBaiTap1Document( CEikApplication& anApplication )
	: CAknDocument( anApplication )
	{
	}

/**
 * @brief Completes the second phase of Symbian object construction. 
 * Put initialization code that could leave here.  
 */ 
void CBaiTap1Document::ConstructL()
	{
	}
	
/**
 * Symbian OS two-phase constructor.
 *
 * Creates an instance of CBaiTap1Document, constructs it, and
 * returns it.
 *
 * @param aApp the application instance
 * @return the new CBaiTap1Document
 */
CBaiTap1Document* CBaiTap1Document::NewL( CEikApplication& aApp )
	{
	CBaiTap1Document* self = new ( ELeave ) CBaiTap1Document( aApp );
	CleanupStack::PushL( self );
	self->ConstructL();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * @brief Creates the application UI object for this document.
 * @return the new instance
 */	
CEikAppUi* CBaiTap1Document::CreateAppUiL()
	{
	return new ( ELeave ) CBaiTap1AppUi;
	}
				
