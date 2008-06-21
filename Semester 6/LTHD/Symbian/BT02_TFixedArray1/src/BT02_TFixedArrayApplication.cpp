/*
========================================================================
 Name        : BT02_TFixedArrayApplication.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated System Includes]
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated Includes]
#include "BT02_TFixedArrayApplication.h"
#include "BT02_TFixedArrayDocument.h"
#ifdef EKA2
#include <eikstart.h>
#endif
// ]]] end generated region [Generated Includes]

/**
 * @brief Returns the application's UID (override from CApaApplication::AppDllUid())
 * @return UID for this application (KUidBT02_TFixedArrayApplication)
 */
TUid CBT02_TFixedArrayApplication::AppDllUid() const
	{
	return KUidBT02_TFixedArrayApplication;
	}

/**
 * @brief Creates the application's document (override from CApaApplication::CreateDocumentL())
 * @return Pointer to the created document object (CBT02_TFixedArrayDocument)
 */
CApaDocument* CBT02_TFixedArrayApplication::CreateDocumentL()
	{
	return CBT02_TFixedArrayDocument::NewL( *this );
	}

#ifdef EKA2

/**
 *	@brief Called by the application framework to construct the application object
 *  @return The application (CBT02_TFixedArrayApplication)
 */	
LOCAL_C CApaApplication* NewApplication()
	{
	return new CBT02_TFixedArrayApplication;
	}

/**
* @brief This standard export is the entry point for all Series 60 applications
* @return error code
 */	
GLDEF_C TInt E32Main()
	{
	return EikStart::RunApplication( NewApplication );
	}
	
#else 	// Series 60 2.x main DLL program code

/**
* @brief This standard export constructs the application object.
* @return The application (CBT02_TFixedArrayApplication)
*/
EXPORT_C CApaApplication* NewApplication()
	{
	return new CBT02_TFixedArrayApplication;
	}

/**
* @brief This standard export is the entry point for all Series 60 applications
* @return error code
*/
GLDEF_C TInt E32Dll(TDllReason /*reason*/)
	{
	return KErrNone;
	}

#endif // EKA2
