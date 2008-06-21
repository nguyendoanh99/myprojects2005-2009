/*
========================================================================
 Name        : ConversionContainerView.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef CONVERSIONCONTAINERVIEW_H
#define CONVERSIONCONTAINERVIEW_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <aknview.h>
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class CConversionContainer;
// ]]] end generated region [Generated Forward Declarations]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * Avkon view class for ConversionContainerView. It is register with the view server
 * by the AppUi. It owns the container control.
 * @class	CConversionContainerView ConversionContainerView.h
 */
class CConversionContainerView : public CAknView
	{
public:
	// constructors and destructor
	CConversionContainerView();
	static CConversionContainerView* NewL();
	static CConversionContainerView* NewLC();        
	void ConstructL();
	virtual ~CConversionContainerView();

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
	static void CreateListQuery1ItemL( 
			TDes& aBuffer,
			
			const TDesC& aMainText );
	static void CreateListQuery1ResourceArrayItemL( 
			TDes& aBuffer, 
			TInt aResourceId );
	static CDesCArray* InitializeListQuery1LC();
	static CArrayPtr< CGulIcon >* SetupListQuery1IconsLC();
	static TInt RunListQuery1L( 
			const TDesC* aOverrideText = NULL, 
			CDesCArray* aOverrideItemArray = NULL,
			CArrayPtr< CGulIcon >* aOverrideIconArray = NULL );
	// ]]] end generated region [Generated Methods]
	
	
	// [[[ begin [Overridden Methods]
protected: 
	// ]]] end [Overridden Methods]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CConversionContainer* iConversionContainer;
	// ]]] end generated region [Generated Instance Variables]
	
	enum TListQuery1Images
		{
		// [[[ begin generated region: do not modify [Generated Enums]
		EListQuery1FirstUserImageIndex
		
		// ]]] end generated region [Generated Enums]
		
		};
	};

#endif // CONVERSIONCONTAINERVIEW_H			
