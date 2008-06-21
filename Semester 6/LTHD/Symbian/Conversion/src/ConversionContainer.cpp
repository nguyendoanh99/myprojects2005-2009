/*
========================================================================
 Name        : ConversionContainer.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated System Includes]
#include <barsread.h>
#include <stringloader.h>
#include <eiklabel.h>
#include <eikenv.h>
#include <gdi.h>
#include <eikedwin.h>
#include <eikfpne.h>
#include <eikmfne.h>
#include <aknviewappui.h>
#include <eikappui.h>
#include <avkon.hrh>
#include <Conversion.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "ConversionContainer.h"
#include "ConversionContainerView.h"
#include "Conversion.hrh"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * First phase of Symbian two-phase construction. Should not 
 * contain any code that could leave.
 */
CConversionContainer::CConversionContainer()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iLabel1 = NULL;
	iLabel2 = NULL;
	iLabel3 = NULL;
	iLabel4 = NULL;
	iLabel5 = NULL;
	iEdit1 = NULL;
	iFixedPointEditor1 = NULL;
	iEdit2 = NULL;
	iFixedPointEditor2 = NULL;
	iTimeEditor1 = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * Destroy child controls.
 */
CConversionContainer::~CConversionContainer()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iLabel1;
	iLabel1 = NULL;
	delete iLabel2;
	iLabel2 = NULL;
	delete iLabel3;
	iLabel3 = NULL;
	delete iLabel4;
	iLabel4 = NULL;
	delete iLabel5;
	iLabel5 = NULL;
	delete iEdit1;
	iEdit1 = NULL;
	delete iFixedPointEditor1;
	iFixedPointEditor1 = NULL;
	delete iEdit2;
	iEdit2 = NULL;
	delete iFixedPointEditor2;
	iFixedPointEditor2 = NULL;
	delete iTimeEditor1;
	iTimeEditor1 = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
				
/**
 * Construct the control (first phase).
 *  Creates an instance and initializes it.
 *  Instance is not left on cleanup stack.
 * @param aRect bounding rectangle
 * @param aParent owning parent, or NULL
 * @param aCommandObserver command observer
 * @return initialized instance of CConversionContainer
 */
CConversionContainer* CConversionContainer::NewL( 
		const TRect& aRect, 
		const CCoeControl* aParent, 
		MEikCommandObserver* aCommandObserver )
	{
	CConversionContainer* self = CConversionContainer::NewLC( 
			aRect, 
			aParent, 
			aCommandObserver );
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Construct the control (first phase).
 *  Creates an instance and initializes it.
 *  Instance is left on cleanup stack.
 * @param aRect The rectangle for this window
 * @param aParent owning parent, or NULL
 * @param aCommandObserver command observer
 * @return new instance of CConversionContainer
 */
CConversionContainer* CConversionContainer::NewLC( 
		const TRect& aRect, 
		const CCoeControl* aParent, 
		MEikCommandObserver* aCommandObserver )
	{
	CConversionContainer* self = new ( ELeave ) CConversionContainer();
	CleanupStack::PushL( self );
	self->ConstructL( aRect, aParent, aCommandObserver );
	return self;
	}
			
/**
 * Construct the control (second phase).
 *  Creates a window to contain the controls and activates it.
 * @param aRect bounding rectangle
 * @param aCommandObserver command observer
 * @param aParent owning parent, or NULL
 */ 
void CConversionContainer::ConstructL( 
		const TRect& aRect, 
		const CCoeControl* aParent, 
		MEikCommandObserver* aCommandObserver )
	{
	if ( aParent == NULL )
	    {
		CreateWindowL();
	    }
	else
	    {
	    SetContainerWindowL( *aParent );
	    }
	iFocusControl = NULL;
	iCommandObserver = aCommandObserver;
	InitializeControlsL();
	SetRect( aRect );
	ActivateL();
	// [[[ begin generated region: do not modify [Post-ActivateL initializations]
	// ]]] end generated region [Post-ActivateL initializations]
	
	}
			
/**
* Return the number of controls in the container (override)
* @return count
*/
TInt CConversionContainer::CountComponentControls() const
	{
	return ( int ) ELastControl;
	}
				
/**
* Get the control with the given index (override)
* @param aIndex Control index [0...n) (limited by #CountComponentControls)
* @return Pointer to control
*/
CCoeControl* CConversionContainer::ComponentControl( TInt aIndex ) const
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	switch ( aIndex )
		{
		case ELabel1:
			return iLabel1;
		case ELabel2:
			return iLabel2;
		case ELabel3:
			return iLabel3;
		case ELabel4:
			return iLabel4;
		case ELabel5:
			return iLabel5;
		case EEdit1:
			return iEdit1;
		case EFixedPointEditor1:
			return iFixedPointEditor1;
		case EEdit2:
			return iEdit2;
		case EFixedPointEditor2:
			return iFixedPointEditor2;
		case ETimeEditor1:
			return iTimeEditor1;
		}
	// ]]] end generated region [Generated Contents]
	
	// handle any user controls here...
	
	return NULL;
	}
				
/**
 *	Handle resizing of the container. This implementation will lay out
 *  full-sized controls like list boxes for any screen size, and will layout
 *  labels, editors, etc. to the size they were given in the UI designer.
 *  This code will need to be modified to adjust arbitrary controls to
 *  any screen size.
 */				
void CConversionContainer::SizeChanged()
	{
	CCoeControl::SizeChanged();
	LayoutControls();
	// [[[ begin generated region: do not modify [Generated Contents]
			
	// ]]] end generated region [Generated Contents]
	
	}
				
// [[[ begin generated function: do not modify
/**
 * Layout components as specified in the UI Designer
 */
void CConversionContainer::LayoutControls()
	{
	iLabel1->SetExtent( TPoint( 6, 7 ), TSize( 71, 17 ) );
	iLabel2->SetExtent( TPoint( 7, 38 ), TSize( 71, 17 ) );
	iLabel3->SetExtent( TPoint( 8, 72 ), TSize( 71, 17 ) );
	iLabel4->SetExtent( TPoint( 8, 96 ), TSize( 71, 17 ) );
	iLabel5->SetExtent( TPoint( 6, 119 ), TSize( 71, 17 ) );
	iEdit1->SetExtent( TPoint( 85, 10 ), TSize( 50, 15 ) );
	iFixedPointEditor1->SetExtent( TPoint( 84, 38 ), TSize( 27, 17 ) );
	iEdit2->SetExtent( TPoint( 84, 72 ), TSize( 50, 15 ) );
	iFixedPointEditor2->SetExtent( TPoint( 84, 93 ), TSize( 27, 17 ) );
	iTimeEditor1->SetExtent( TPoint( 83, 122 ), TSize( 79, 17 ) );
	}
// ]]] end generated function

/**
 *	Handle key events.
 */				
TKeyResponse CConversionContainer::OfferKeyEventL( 
		const TKeyEvent& aKeyEvent, 
		TEventCode aType )
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	
	// ]]] end generated region [Generated Contents]
	
	if ( iFocusControl != NULL
		&& iFocusControl->OfferKeyEventL( aKeyEvent, aType ) == EKeyWasConsumed )
		{
		return EKeyWasConsumed;
		}
	return CCoeControl::OfferKeyEventL( aKeyEvent, aType );
	}
				
// [[[ begin generated function: do not modify
/**
 *	Initialize each control upon creation.
 */				
void CConversionContainer::InitializeControlsL()
	{
	iLabel1 = new ( ELeave ) CEikLabel;
	iLabel1->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_LABEL1 );
		iLabel1->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
	iLabel2 = new ( ELeave ) CEikLabel;
	iLabel2->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_LABEL2 );
		iLabel2->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
	iLabel3 = new ( ELeave ) CEikLabel;
	iLabel3->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_LABEL3 );
		iLabel3->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
	iLabel4 = new ( ELeave ) CEikLabel;
	iLabel4->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_LABEL4 );
		iLabel4->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
	iLabel5 = new ( ELeave ) CEikLabel;
	iLabel5->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_LABEL5 );
		iLabel5->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
	iEdit1 = new ( ELeave ) CEikEdwin;
	iEdit1->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_EDIT1 );
		iEdit1->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
		{
		HBufC* text = StringLoader::LoadLC( R_CONVERSION_CONTAINER_EDIT1_2 );
		iEdit1->SetTextL( text );
		CleanupStack::PopAndDestroy( text );
		}
	iFixedPointEditor1 = new ( ELeave ) CEikFixedPointEditor;
	iFixedPointEditor1->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_FIXED_POINT_EDITOR1 );
		iFixedPointEditor1->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
		{
		TInt value = 0;
		iFixedPointEditor1->SetValueL( &value );
		}
	iEdit2 = new ( ELeave ) CEikEdwin;
	iEdit2->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_EDIT2 );
		iEdit2->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
		{
		HBufC* text = StringLoader::LoadLC( R_CONVERSION_CONTAINER_EDIT2_2 );
		iEdit2->SetTextL( text );
		CleanupStack::PopAndDestroy( text );
		}
	iFixedPointEditor2 = new ( ELeave ) CEikFixedPointEditor;
	iFixedPointEditor2->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_FIXED_POINT_EDITOR2 );
		iFixedPointEditor2->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
		{
		TInt value = 0;
		iFixedPointEditor2->SetValueL( &value );
		}
	iTimeEditor1 = new ( ELeave ) CEikTimeEditor;
	iTimeEditor1->SetContainerWindowL( *this );
		{
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_TIME_EDITOR1 );
		iTimeEditor1->ConstructFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
	iTimeEditor1->SetTime( TTime( TDateTime( 0, EJanuary, 0, 0, 0, 0, 0 ) ) );
	
	iEdit1->SetFocus( ETrue );
	iFocusControl = iEdit1;
	
	}
// ]]] end generated function

/** 
 * Handle global resource changes, such as scalable UI or skin events (override)
 */
void CConversionContainer::HandleResourceChange( TInt aType )
	{
	CCoeControl::HandleResourceChange( aType );
	SetRect( iAvkonViewAppUi->View( TUid::Uid( EConversionContainerViewId ) )->ClientRect() );
	// [[[ begin generated region: do not modify [Generated Contents]
	// ]]] end generated region [Generated Contents]
	
	}
				
/**
 *	Draw container contents.
 */				
void CConversionContainer::Draw( const TRect& aRect ) const
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CWindowGc& gc = SystemGc();
	gc.Clear( aRect );
	
	// ]]] end generated region [Generated Contents]
	
	}
				
