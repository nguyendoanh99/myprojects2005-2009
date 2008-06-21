/*
========================================================================
 Name        : HelloCarbide3rdGUIApplication.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated System Includes]
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated Includes]
#include "HelloCarbide3rdGUIApplication.h"
#include "HelloCarbide3rdGUIDocument.h"
#ifdef EKA2
#include <eikstart.h>
#endif
// ]]] end generated region [Generated Includes]

/**
 * @brief Returns the application's UID (override from CApaApplication::AppDllUid())
 * @return UID for this application (KUidHelloCarbide3rdGUIApplication)
 */
TUid CHelloCarbide3rdGUIApplication::AppDllUid() const
	{
	return KUidHelloCarbide3rdGUIApplication;
	}

/**
 * @brief Creates the application's document (override from CApaApplication::CreateDocumentL())
 * @return Pointer to the created document object (CHelloCarbide3rdGUIDocument)
 */
CApaDocument* CHelloCarbide3rdGUIApplication::CreateDocumentL()
	{
	return CHelloCarbide3rdGUIDocument::NewL( *this );
	}

#ifdef EKA2

/**
 *	@brief Called by the application framework to construct the application object
 *  @return The application (CHelloCarbide3rdGUIApplication)
 */	
LOCAL_C CApaApplication* NewApplication()
	{
	return new CHelloCarbide3rdGUIApplication;
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
* @return The application (CHelloCarbide3rdGUIApplication)
*/
EXPORT_C CApaApplication* NewApplication()
	{
	return new CHelloCarbide3rdGUIApplication;
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
