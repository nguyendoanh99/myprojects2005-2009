/*
========================================================================
 Name        : BT01_DescriptorsApplication.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT01_DESCRIPTORSAPPLICATION_H
#define BT01_DESCRIPTORSAPPLICATION_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknapp.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Constants]
const TUid KUidBT01_DescriptorsApplication = { 0xED383BA3 };
// ]]] end generated region [Generated Constants]

/**
 *
 * @class	CBT01_DescriptorsApplication BT01_DescriptorsApplication.h
 * @brief	A CAknApplication-derived class is required by the S60 application 
 *          framework. It is subclassed to create the application's document 
 *          object.
 */
class CBT01_DescriptorsApplication : public CAknApplication
	{
private:
	TUid AppDllUid() const;
	CApaDocument* CreateDocumentL();
	
	};
			
#endif // BT01_DESCRIPTORSAPPLICATION_H		
