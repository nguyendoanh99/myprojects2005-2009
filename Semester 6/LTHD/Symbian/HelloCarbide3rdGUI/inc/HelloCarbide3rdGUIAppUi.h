/*
========================================================================
 Name        : HelloCarbide3rdGUIAppUi.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE3RDGUIAPPUI_H
#define HELLOCARBIDE3RDGUIAPPUI_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknviewappui.h>
// ]]] end generated region [Generated Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CHelloCarbide3rdGUIContainerView;
// ]]] end generated region [Generated Forward Declarations]

/**
 * @class	CHelloCarbide3rdGUIAppUi HelloCarbide3rdGUIAppUi.h
 * @brief The AppUi class handles application-wide aspects of the user interface, including
 *        view management and the default menu, control pane, and status pane.
 */
class CHelloCarbide3rdGUIAppUi : public CAknViewAppUi
	{
public: 
	// constructor and destructor
	CHelloCarbide3rdGUIAppUi();
	virtual ~CHelloCarbide3rdGUIAppUi();
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
	CHelloCarbide3rdGUIContainerView* iHelloCarbide3rdGUIContainerView;
	// ]]] end generated region [Generated Instance Variables]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
	};

#endif // HELLOCARBIDE3RDGUIAPPUI_H			
