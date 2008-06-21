/*
========================================================================
 Name        : BT02_TFixedArrayContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT02_TFIXEDARRAYCONTAINERVIEW_H
#define BT02_TFIXEDARRAYCONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CBT02_TFixedArrayContainer;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for BT02_TFixedArrayContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CBT02_TFixedArrayContainerView BT02_TFixedArrayContainerView.h
 */
class CBT02_TFixedArrayContainerView : public CAknView
	{
public:
	// constructors and destructor
	CBT02_TFixedArrayContainerView();
	static CBT02_TFixedArrayContainerView* NewL();
	static CBT02_TFixedArrayContainerView* NewLC();        
	void ConstructL();
	virtual ~CBT02_TFixedArrayContainerView();

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
	TBool Handle_10_doi_tuong_TDiemMenuItemSelectedL( TInt aCommand );
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CBT02_TFixedArrayContainer* iBT02_TFixedArrayContainer;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // BT02_TFIXEDARRAYCONTAINERVIEW_H			
