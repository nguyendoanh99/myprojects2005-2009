/*
========================================================================
 Name        : HelloCarbide3rdGUIContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef HELLOCARBIDE3RDGUICONTAINERVIEW_H
#define HELLOCARBIDE3RDGUICONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CHelloCarbide3rdGUIContainer;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for HelloCarbide3rdGUIContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CHelloCarbide3rdGUIContainerView HelloCarbide3rdGUIContainerView.h
 */
class CHelloCarbide3rdGUIContainerView : public CAknView
	{
public:
	// constructors and destructor
	CHelloCarbide3rdGUIContainerView();
	static CHelloCarbide3rdGUIContainerView* NewL();
	static CHelloCarbide3rdGUIContainerView* NewLC();        
	void ConstructL();
	virtual ~CHelloCarbide3rdGUIContainerView();

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
	TBool HandleTest1MenuItemSelectedL( TInt aCommand );
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CHelloCarbide3rdGUIContainer* iHelloCarbide3rdGUIContainer;
	// ]]] end generated region [Generated Instance Variables]
	
	};

#endif // HELLOCARBIDE3RDGUICONTAINERVIEW_H			
