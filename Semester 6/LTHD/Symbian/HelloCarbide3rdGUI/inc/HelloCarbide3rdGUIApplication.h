/*
========================================================================
 Name        : HelloCarbide3rdGUIApplication.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE3RDGUIAPPLICATION_H
#define HELLOCARBIDE3RDGUIAPPLICATION_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknapp.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Constants]
const TUid KUidHelloCarbide3rdGUIApplication = { 0xE05FA9E8 };
// ]]] end generated region [Generated Constants]

/**
 *
 * @class	CHelloCarbide3rdGUIApplication HelloCarbide3rdGUIApplication.h
 * @brief	A CAknApplication-derived class is required by the S60 application 
 *          framework. It is subclassed to create the application's document 
 *          object.
 */
class CHelloCarbide3rdGUIApplication : public CAknApplication
	{
private:
	TUid AppDllUid() const;
	CApaDocument* CreateDocumentL();
	
	};
			
#endif // HELLOCARBIDE3RDGUIAPPLICATION_H		
