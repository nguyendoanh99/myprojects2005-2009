/*
========================================================================
 Name        : tempContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef TEMPCONTAINERVIEW_H
#define TEMPCONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CTempContainer;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for tempContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CtempContainerView tempContainerView.h
 */
class CtempContainerView : public CAknView
	{
public:
	// constructors and destructor
	CtempContainerView();
	static CtempContainerView* NewL();
	static CtempContainerView* NewLC();        
	void ConstructL();
	virtual ~CtempContainerView();

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
	TBool Handle_10_TDiemMenuItemSelectedL( TInt aCommand );
	TBool Handle_10_CDuongTronMenuItemSelectedL( TInt aCommand );
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CTempContainer* iTempContainer;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // TEMPCONTAINERVIEW_H			
