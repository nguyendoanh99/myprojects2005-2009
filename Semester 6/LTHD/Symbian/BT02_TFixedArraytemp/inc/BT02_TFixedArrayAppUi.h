/*
========================================================================
 Name        : BT02_TFixedArrayAppUi.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT02_TFIXEDARRAYAPPUI_H
#define BT02_TFIXEDARRAYAPPUI_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknviewappui.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CBT02_TFixedArrayContainerView;
// ]]] end generated region [Generated Forward Declarations]

/**
 * @class	CBT02_TFixedArrayAppUi BT02_TFixedArrayAppUi.h
 * @brief The AppUi class handles application-wide aspects of the user interface, including
 *        view management and the default menu, control pane, and status pane.
 */
class CBT02_TFixedArrayAppUi : public CAknViewAppUi
	{
public: 
	// constructor and destructor
	CBT02_TFixedArrayAppUi();
	virtual ~CBT02_TFixedArrayAppUi();
	void ConstructL();

public:
	// from CCoeAppUi
	TKeyResponse HandleKeyEventL(
				const TKeyEvent& aKeyEvent,
				TEventCode aType );

	// from CEikAppUi
	void HandleCommandL( TInt aCommand );
	void HandleResourceChangeL( TInt aType );

	// from CAknAppUi
	void HandleViewDeactivation( 
			const TVwsViewId& aViewIdToBeDeactivated, 
			const TVwsViewId& aNewlyActivatedViewId );

private:
	void InitializeContainersL();
	// [[[ begin generated region: do not modify [Generated Methods]
public: 
	// ]]] end generated region [Generated Methods]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CBT02_TFixedArrayContainerView* iBT02_TFixedArrayContainerView;
	// ]]] end generated region [Generated Instance Variables]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
	};

#endif // BT02_TFIXEDARRAYAPPUI_H			
