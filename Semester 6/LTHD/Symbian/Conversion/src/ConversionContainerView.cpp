/*
========================================================================
 Name        : ConversionContainerView.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated System Includes]
#include <aknviewappui.h>
#include <eikmenub.h>
#include <avkon.hrh>
#include <barsread.h>
#include <stringloader.h>
#include <eiklabel.h>
#include <eikenv.h>
#include <gdi.h>
#include <eikedwin.h>
#include <eikfpne.h>
#include <eikmfne.h>
#include <akncontext.h>
#include <akntitle.h>
#include <eikbtgpc.h>
#include <aknlistquerydialog.h>
#include <akniconarray.h>
#include <Conversion.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "Conversion.hrh"
#include "ConversionContainerView.h"
#include "ConversionContainer.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CConversionContainerView::CConversionContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iConversionContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CConversionContainerView::~CConversionContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iConversionContainer;
	iConversionContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CConversionContainerView
 */
CConversionContainerView* CConversionContainerView::NewL()
	{
	CConversionContainerView* self = CConversionContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CConversionContainerView
 */
CConversionContainerView* CConversionContainerView::NewLC()
	{
	CConversionContainerView* self = new ( ELeave ) CConversionContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CConversionContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_CONVERSION_CONTAINER_CONVERSION_CONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CConversionContainerView::Id() const
	{
	return TUid::Uid( EConversionContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CConversionContainerView::HandleCommandL( TInt aCommand )
	{   
	// [[[ begin generated region: do not modify [Generated Code]
	TBool commandHandled = EFalse;
	switch ( aCommand )
		{	// code to dispatch to the AknView's menu and CBA commands is generated here
		default:
			break;
		}
	
		
	if ( !commandHandled ) 
		{
	
		if ( aCommand == EAknSoftkeyExit )
			{
			AppUi()->HandleCommandL( EEikCmdExit );
			}
	
		}
	// ]]] end generated region [Generated Code]
	
	}

/**
 *	Handles user actions during activation of the view, 
 *	such as initializing the content.
 */
void CConversionContainerView::DoActivateL(
		const TVwsViewId& /*aPrevViewId*/,
		TUid /*aCustomMessageId*/,
		const TDesC8& /*aCustomMessage*/ )
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	SetupStatusPaneL();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( EFalse );
		}
	
	if ( iConversionContainer == NULL )
		{
		iConversionContainer = CConversionContainer::NewL( ClientRect(), NULL, this );
		iConversionContainer->SetMopParent( this );
		AppUi()->AddToStackL( *this, iConversionContainer );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CConversionContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iConversionContainer != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iConversionContainer );
		delete iConversionContainer;
		iConversionContainer = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CConversionContainerView::SetupStatusPaneL()
	{
	// reset the context pane
	TUid contextPaneUid = TUid::Uid( EEikStatusPaneUidContext );
	CEikStatusPaneBase::TPaneCapabilities subPaneContext = 
		StatusPane()->PaneCapabilities( contextPaneUid );
	if ( subPaneContext.IsPresent() && subPaneContext.IsAppOwned() )
		{
		CAknContextPane* context = static_cast< CAknContextPane* > ( 
			StatusPane()->ControlL( contextPaneUid ) );
		context->SetPictureToDefaultL();
		}
	
	// setup the title pane
	TUid titlePaneUid = TUid::Uid( EEikStatusPaneUidTitle );
	CEikStatusPaneBase::TPaneCapabilities subPaneTitle = 
		StatusPane()->PaneCapabilities( titlePaneUid );
	if ( subPaneTitle.IsPresent() && subPaneTitle.IsAppOwned() )
		{
		CAknTitlePane* title = static_cast< CAknTitlePane* >( 
			StatusPane()->ControlL( titlePaneUid ) );
		TResourceReader reader;
		iEikonEnv->CreateResourceReaderLC( reader, R_CONVERSION_CONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CConversionContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CConversionContainerView::HandleStatusPaneSizeChange()
	{
	CAknView::HandleStatusPaneSizeChange();
	
	// this may fail, but we're not able to propagate exceptions here
	TInt result;
	TRAP( result, SetupStatusPaneL() ); 
	}
	
// [[[ begin generated function: do not modify
/**
 *	Create a list box item with the given column values.
 */
void CConversionContainerView::CreateListQuery1ItemL( 
		TDes& aBuffer, 
		
		const TDesC& aMainText )
	{
	_LIT ( KStringHeader, "%S" );

	aBuffer.Format( KStringHeader(), &aMainText );
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
/**
 *	Add an item to the list by reading the text items from resource
 *	and setting a single image property (if available) from an index
 *	in the list box's icon array.
 *	@param aResourceId id of an ARRAY resource containing the textual
 *	items in the columns
 *	
 */
void CConversionContainerView::CreateListQuery1ResourceArrayItemL( 
		TDes& aBuffer, 
		TInt aResourceId )
	{
	CDesCArray* array = CCoeEnv::Static()->ReadDesCArrayResourceL( aResourceId );
	CleanupStack::PushL( array );
	CreateListQuery1ItemL( aBuffer, ( *array ) [ 0 ] );
	CleanupStack::PopAndDestroy( array );
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
/**
 * Initialize contents of the popup item list.  This constructs the array
 *	and pushes it on the cleanup stack.
 *	@return item array, never null
 */
CDesCArray* CConversionContainerView::InitializeListQuery1LC()
	{
	const int KNumItems = 2;
	CDesCArray* itemArray = new ( ELeave ) CDesCArrayFlat( KNumItems ? KNumItems : 1 );
	CleanupStack::PushL( itemArray );
	
	// This is intended to be large enough, but if you get 
	// a USER 11 panic, consider reducing string sizes.
	TBuf< 512 > des;
	CreateListQuery1ResourceArrayItemL(
			des, R_CONVERSION_CONTAINER_LISTBOX_ITEM1 );
	itemArray->AppendL( des );
	CreateListQuery1ResourceArrayItemL(
			des, R_CONVERSION_CONTAINER_LISTBOX_ITEM2 );
	itemArray->AppendL( des );
	return itemArray;
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
/**
 *	Set up the list query's icon array.  If any icons are used, allocates an
 *	icon array, and places it on the cleanup stack. 
 *	@return icon array, or NULL
 */
CArrayPtr< CGulIcon >* CConversionContainerView::SetupListQuery1IconsLC()
	{
	CArrayPtr< CGulIcon >* icons = NULL;
	return icons;
	}
	
// ]]] end generated function

// [[[ begin generated function: do not modify
/**
 * Show the popup list query dialog for listQuery1.
 * <p>
 * You may override the designer-specified items or icons, though generally
 * both should be overridden together.
 * @param aOverrideText optional override text
 * @param aOverrideItemArray if not NULL, the array of formatted list items to display (passes ownership)
 * @param aOverrideIconArray if not NULL, the array of icons to display (passes ownership)
 * @return selected index (>=0) or -1 for Cancel
 */
TInt CConversionContainerView::RunListQuery1L( 
		const TDesC* aOverrideText,
		CDesCArray* aOverrideItemArray,
		CArrayPtr< CGulIcon >* aOverrideIconArray )
	{
	TInt index = 0;
	CAknListQueryDialog* queryDialog = NULL;
	queryDialog = new ( ELeave ) CAknListQueryDialog( &index );	
	CleanupStack::PushL( queryDialog );
	
	queryDialog->PrepareLC( R_CONVERSION_CONTAINER_LIST_QUERY1 );
	if ( aOverrideText != NULL )
		{
		queryDialog->SetPromptL( *aOverrideText );
		}
		
	// initialize list items
	CDesCArray* itemArray = NULL;
	
	if ( aOverrideItemArray != NULL ) 
		{
		CleanupStack::PushL( aOverrideItemArray );
		itemArray = aOverrideItemArray;
		}
	else
		{
		itemArray = InitializeListQuery1LC();
		}
		
	queryDialog->SetItemTextArray( itemArray );
	queryDialog->SetOwnershipType( ELbmOwnsItemArray );
	CleanupStack::Pop( itemArray );
	
	// initialize list icons
	CArrayPtr< CGulIcon >* iconArray = NULL;
	
	if ( aOverrideIconArray != NULL )
		{
		CleanupStack::PushL( aOverrideIconArray );
		iconArray = aOverrideIconArray;
		}
	else
		{
		iconArray = SetupListQuery1IconsLC();
		}
		
	if ( iconArray != NULL ) 
		{
		queryDialog->SetIconArrayL( iconArray );	// passes ownership
		CleanupStack::Pop( iconArray );
		}
	
	// run dialog
	TInt result = queryDialog->RunLD();
	
	// clean up
	CleanupStack::Pop( queryDialog );
	
	return result == 0 ? -1 : index;
	}
	
// ]]] end generated function

