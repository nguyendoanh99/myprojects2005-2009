/*
========================================================================
 Name        : ConversionContainer.h
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
#ifndef CONVERSIONCONTAINER_H
#define CONVERSIONCONTAINER_H

// [[[ begin generated region: do not modify [Generated Includes]
#include <coecntrl.h>		
// ]]] end generated region [Generated Includes]


// [[[ begin [Event Handler Includes]
// ]]] end [Event Handler Includes]

// [[[ begin generated region: do not modify [Generated Forward Declarations]
class MEikCommandObserver;		
class CEikLabel;
class CEikEdwin;
class CEikFixedPointEditor;
class CEikTimeEditor;
// ]]] end generated region [Generated Forward Declarations]

/**
 * Container class for ConversionContainer
 * 
 * @class	CConversionContainer ConversionContainer.h
 */
class CConversionContainer : public CCoeControl
	{
public:
	// constructors and destructor
	CConversionContainer();
	static CConversionContainer* NewL( 
		const TRect& aRect, 
		const CCoeControl* aParent, 
		MEikCommandObserver* aCommandObserver );
	static CConversionContainer* NewLC( 
		const TRect& aRect, 
		const CCoeControl* aParent, 
		MEikCommandObserver* aCommandObserver );
	void ConstructL( 
		const TRect& aRect, 
		const CCoeControl* aParent, 
		MEikCommandObserver* aCommandObserver );
	virtual ~CConversionContainer();

public:
	// from base class CCoeControl
	TInt CountComponentControls() const;
	CCoeControl* ComponentControl( TInt aIndex ) const;
	TKeyResponse OfferKeyEventL( 
			const TKeyEvent& aKeyEvent, 
			TEventCode aType );
	void HandleResourceChange( TInt aType );
	
protected:
	// from base class CCoeControl
	void SizeChanged();

private:
	// from base class CCoeControl
	void Draw( const TRect& aRect ) const;

private:
	void InitializeControlsL();
	void LayoutControls();
	CCoeControl* iFocusControl;
	MEikCommandObserver* iCommandObserver;
	// [[[ begin generated region: do not modify [Generated Methods]
public: 
	// ]]] end generated region [Generated Methods]
	
	// [[[ begin generated region: do not modify [Generated Type Declarations]
public: 
	// ]]] end generated region [Generated Type Declarations]
	
	// [[[ begin generated region: do not modify [Generated Instance Variables]
private: 
	CEikLabel* iLabel1;
	CEikLabel* iLabel2;
	CEikLabel* iLabel3;
	CEikLabel* iLabel4;
	CEikLabel* iLabel5;
	CEikEdwin* iEdit1;
	CEikFixedPointEditor* iFixedPointEditor1;
	CEikEdwin* iEdit2;
	CEikFixedPointEditor* iFixedPointEditor2;
	CEikTimeEditor* iTimeEditor1;
	// ]]] end generated region [Generated Instance Variables]
	
	
	// [[[ begin [Overridden Methods]
protected: 
	// ]]] end [Overridden Methods]
	
	
	// [[[ begin [User Handlers]
protected: 
	// ]]] end [User Handlers]
	
public: 
	enum TControls
		{
		// [[[ begin generated region: do not modify [Generated Contents]
		ELabel1,
		ELabel2,
		ELabel3,
		ELabel4,
		ELabel5,
		EEdit1,
		EFixedPointEditor1,
		EEdit2,
		EFixedPointEditor2,
		ETimeEditor1,
		
		// ]]] end generated region [Generated Contents]
		
		// add any user-defined entries here...
		
		ELastControl
		};
	};
				
#endif // CONVERSIONCONTAINER_H
