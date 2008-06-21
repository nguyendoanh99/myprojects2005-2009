/*
========================================================================
 Name        : ConversionApplication.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef CONVERSIONAPPLICATION_H
#define CONVERSIONAPPLICATION_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknapp.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Constants]
const TUid KUidConversionApplication = { 0xE5ED59CD };
// ]]] end generated region [Generated Constants]

/**
 *
 * @class	CConversionApplication ConversionApplication.h
 * @brief	A CAknApplication-derived class is required by the S60 application 
 *          framework. It is subclassed to create the application's document 
 *          object.
 */
class CConversionApplication : public CAknApplication
	{
private:
	TUid AppDllUid() const;
	CApaDocument* CreateDocumentL();
	
	};
			
#endif // CONVERSIONAPPLICATION_H		
