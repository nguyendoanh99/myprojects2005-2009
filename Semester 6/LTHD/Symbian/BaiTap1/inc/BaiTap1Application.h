/*
========================================================================
 Name        : BaiTap1Application.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BAITAP1APPLICATION_H
#define BAITAP1APPLICATION_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknapp.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Constants]
const TUid KUidBaiTap1Application = { 0xE8BC2C9B };
// ]]] end generated region [Generated Constants]

/**
 *
 * @class	CBaiTap1Application BaiTap1Application.h
 * @brief	A CAknApplication-derived class is required by the S60 application 
 *          framework. It is subclassed to create the application's document 
 *          object.
 */
class CBaiTap1Application : public CAknApplication
	{
private:
	TUid AppDllUid() const;
	CApaDocument* CreateDocumentL();
	
	};
			
#endif // BAITAP1APPLICATION_H		
