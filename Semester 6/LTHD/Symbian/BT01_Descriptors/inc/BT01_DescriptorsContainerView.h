/*
========================================================================
 Name        : BT01_DescriptorsContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT01_DESCRIPTORSCONTAINERVIEW_H
#define BT01_DESCRIPTORSCONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CBT01_DescriptorsContainer;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for BT01_DescriptorsContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CBT01_DescriptorsContainerView BT01_DescriptorsContainerView.h
 */
class CBT01_DescriptorsContainerView : public CAknView
	{
public:
	// constructors and destructor
	CBT01_DescriptorsContainerView();
	static CBT01_DescriptorsContainerView* NewL();
	static CBT01_DescriptorsContainerView* NewLC();        
	void ConstructL();
	virtual ~CBT01_DescriptorsContainerView();

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
	TBool HandleExample_1MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_2MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_3MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_4MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_5MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_6MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_7MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_8MenuItemSelectedL( TInt aCommand );
	TBool HandleExample_9MenuItemSelectedL( TInt aCommand );
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CBT01_DescriptorsContainer* iBT01_DescriptorsContainer;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // BT01_DESCRIPTORSCONTAINERVIEW_H			
