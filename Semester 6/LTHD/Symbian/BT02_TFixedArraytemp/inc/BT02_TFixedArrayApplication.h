/*
========================================================================
 Name        : BT02_TFixedArrayApplication.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT02_TFIXEDARRAYAPPLICATION_H
#define BT02_TFIXEDARRAYAPPLICATION_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknapp.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Constants]
const TUid KUidBT02_TFixedArrayApplication = { 0xE0A06F9B };
// ]]] end generated region [Generated Constants]

/**
 *
 * @class	CBT02_TFixedArrayApplication BT02_TFixedArrayApplication.h
 * @brief	A CAknApplication-derived class is required by the S60 application 
 *          framework. It is subclassed to create the application's document 
 *          object.
 */
class CBT02_TFixedArrayApplication : public CAknApplication
	{
private:
	TUid AppDllUid() const;
	CApaDocument* CreateDocumentL();
	
	};
			
#endif // BT02_TFIXEDARRAYAPPLICATION_H		
