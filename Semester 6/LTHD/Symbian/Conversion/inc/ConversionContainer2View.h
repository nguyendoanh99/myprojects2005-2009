/*
========================================================================
 Name        : ConversionContainer2View.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef CONVERSIONCONTAINER2VIEW_H
#define CONVERSIONCONTAINER2VIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CConversionContainer2;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for ConversionContainer2View. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CConversionContainer2View ConversionContainer2View.h
 */
class CConversionContainer2View : public CAknView
	{
public:
	// constructors and destructor
	CConversionContainer2View();
	static CConversionContainer2View* NewL();
	static CConversionContainer2View* NewLC();        
	void ConstructL();
	virtual ~CConversionContainer2View();

public:
	// from base class CAknView
	TUid Id() const;
	void HandleCommandL( TInt aCommand );

protected:
	// from base class CAknView
	void DoActivateL(
		const TVwsViewId& aPrevViewId,
		TUid aCustomMessageId,
		const TDesC8& aCustomMessage );
	void DoDeactivate();
	void HandleStatusPaneSizeChange();
	
private:
	void SetupStatusPaneL();
	void CleanupStatusPane();
	// [[[ begin generated region: do not modify [Generated Methods]
public: 
	// ]]] end generated region [Generated Methods]
	
	
	// [[[ begin [Overridden Methods]
protected: 
	// ]]] end [Overridden Methods]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CConversionContainer2* iConversionContainer2;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // CONVERSIONCONTAINER2VIEW_H			
