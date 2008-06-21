/*
========================================================================
 Name        : HelloCarbide2ndGUIContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE2NDGUICONTAINERVIEW_H
#define HELLOCARBIDE2NDGUICONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CHelloCarbide2ndGUIContainer;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for HelloCarbide2ndGUIContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CHelloCarbide2ndGUIContainerView HelloCarbide2ndGUIContainerView.h
 */
class CHelloCarbide2ndGUIContainerView : public CAknView
	{
public:
	// constructors and destructor
	CHelloCarbide2ndGUIContainerView();
	static CHelloCarbide2ndGUIContainerView* NewL();
	static CHelloCarbide2ndGUIContainerView* NewLC();        
	void ConstructL();
	virtual ~CHelloCarbide2ndGUIContainerView();

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
	CHelloCarbide2ndGUIContainer* iHelloCarbide2ndGUIContainer;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // HELLOCARBIDE2NDGUICONTAINERVIEW_H			
