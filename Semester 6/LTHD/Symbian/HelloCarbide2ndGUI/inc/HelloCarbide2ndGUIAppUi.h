/*
========================================================================
 Name        : HelloCarbide2ndGUIAppUi.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE2NDGUIAPPUI_H
#define HELLOCARBIDE2NDGUIAPPUI_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknviewappui.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CHelloCarbide2ndGUIContainerView;
// ]]] end generated region [Generated Forward Declarations]

/**
 * @class	CHelloCarbide2ndGUIAppUi HelloCarbide2ndGUIAppUi.h
 * @brief The AppUi class handles application-wide aspects of the user interface, including
 *        view management and the default menu, control pane, and status pane.
 */
class CHelloCarbide2ndGUIAppUi : public CAknViewAppUi
	{
public: 
	// constructor and destructor
	CHelloCarbide2ndGUIAppUi();
	virtual ~CHelloCarbide2ndGUIAppUi();
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
	CHelloCarbide2ndGUIContainerView* iHelloCarbide2ndGUIContainerView;
	// ]]] end generated region [Generated Instance Variables]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
	};

#endif // HELLOCARBIDE2NDGUIAPPUI_H			
