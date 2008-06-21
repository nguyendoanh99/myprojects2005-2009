/*
========================================================================
 Name        : BT01_DescriptorsAppUi.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef BT01_DESCRIPTORSAPPUI_H
#define BT01_DESCRIPTORSAPPUI_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknviewappui.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CBT01_DescriptorsContainerView;
// ]]] end generated region [Generated Forward Declarations]

/**
 * @class	CBT01_DescriptorsAppUi BT01_DescriptorsAppUi.h
 * @brief The AppUi class handles application-wide aspects of the user interface, including
 *        view management and the default menu, control pane, and status pane.
 */
class CBT01_DescriptorsAppUi : public CAknViewAppUi
	{
public: 
	// constructor and destructor
	CBT01_DescriptorsAppUi();
	virtual ~CBT01_DescriptorsAppUi();
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
	CBT01_DescriptorsContainerView* iBT01_DescriptorsContainerView;
	// ]]] end generated region [Generated Instance Variables]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
	};

#endif // BT01_DESCRIPTORSAPPUI_H			
