/*
========================================================================
 Name        : BT01_DescriptorsApplication.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated System Includes]
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated Includes]
#include "BT01_DescriptorsApplication.h"
#include "BT01_DescriptorsDocument.h"
#ifdef EKA2
#include <eikstart.h>
#endif
// ]]] end generated region [Generated Includes]

/**
 * @brief Returns the application's UID (override from CApaApplication::AppDllUid())
 * @return UID for this application (KUidBT01_DescriptorsApplication)
 */
TUid CBT01_DescriptorsApplication::AppDllUid() const
	{
	return KUidBT01_DescriptorsApplication;
	}

/**
 * @brief Creates the application's document (override from CApaApplication::CreateDocumentL())
 * @return Pointer to the created document object (CBT01_DescriptorsDocument)
 */
CApaDocument* CBT01_DescriptorsApplication::CreateDocumentL()
	{
	return CBT01_DescriptorsDocument::NewL( *this );
	}

#ifdef EKA2

/**
 *	@brief Called by the application framework to construct the application object
 *  @return The application (CBT01_DescriptorsApplication)
 */	
LOCAL_C CApaApplication* NewApplication()
	{
	return new CBT01_DescriptorsApplication;
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
* @return The application (CBT01_DescriptorsApplication)
*/
EXPORT_C CApaApplication* NewApplication()
	{
	return new CBT01_DescriptorsApplication;
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
