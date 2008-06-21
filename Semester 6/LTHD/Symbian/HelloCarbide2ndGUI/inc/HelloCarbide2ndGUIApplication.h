/*
========================================================================
 Name        : HelloCarbide2ndGUIApplication.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE2NDGUIAPPLICATION_H
#define HELLOCARBIDE2NDGUIAPPLICATION_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknapp.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Constants]
const TUid KUidHelloCarbide2ndGUIApplication = { 0x0B10718E };
// ]]] end generated region [Generated Constants]

/**
 *
 * @class	CHelloCarbide2ndGUIApplication HelloCarbide2ndGUIApplication.h
 * @brief	A CAknApplication-derived class is required by the S60 application 
 *          framework. It is subclassed to create the application's document 
 *          object.
 */
class CHelloCarbide2ndGUIApplication : public CAknApplication
	{
private:
	TUid AppDllUid() const;
	CApaDocument* CreateDocumentL();
	
	};
			
#endif // HELLOCARBIDE2NDGUIAPPLICATION_H		
