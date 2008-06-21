/*
========================================================================
 Name        : HelloCarbide3rdGUIContainerView.cpp
 Author      : 
 Copyright   : Your copyright notice
 Description : 
========================================================================
*/
// [[[ begin generated region: do not modify [Generated System Includes]
#include <aknviewappui.h>
#include <eikmenub.h>
#include <avkon.hrh>
#include <akncontext.h>
#include <akntitle.h>
#include <stringloader.h>
#include <barsread.h>
#include <eikbtgpc.h>
#include <HelloCarbide3rdGUI.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "HelloCarbide3rdGUI.hrh"
#include "HelloCarbide3rdGUIContainerView.h"
#include "HelloCarbide3rdGUIContainer.hrh"
#include "HelloCarbide3rdGUIContainer.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]
#include <aknnotewrappers.h> 
/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CHelloCarbide3rdGUIContainerView::CHelloCarbide3rdGUIContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iHelloCarbide3rdGUIContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CHelloCarbide3rdGUIContainerView::~CHelloCarbide3rdGUIContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iHelloCarbide3rdGUIContainer;
	iHelloCarbide3rdGUIContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CHelloCarbide3rdGUIContainerView
 */
CHelloCarbide3rdGUIContainerView* CHelloCarbide3rdGUIContainerView::NewL()
	{
	CHelloCarbide3rdGUIContainerView* self = CHelloCarbide3rdGUIContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CHelloCarbide3rdGUIContainerView
 */
CHelloCarbide3rdGUIContainerView* CHelloCarbide3rdGUIContainerView::NewLC()
	{
	CHelloCarbide3rdGUIContainerView* self = new ( ELeave ) CHelloCarbide3rdGUIContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CHelloCarbide3rdGUIContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_HELLO_CARBIDE3RDGUICONTAINER_HELLO_CARBIDE3RDGUICONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CHelloCarbide3rdGUIContainerView::Id() const
	{
	return TUid::Uid( EHelloCarbide3rdGUIContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CHelloCarbide3rdGUIContainerView::HandleCommandL( TInt aCommand )
	{   
	// [[[ begin generated region: do not modify [Generated Code]
	TBool commandHandled = EFalse;
	switch ( aCommand )
		{	// code to dispatch to the AknView's menu and CBA commands is generated here
		case EHelloCarbide3rdGUIContainerViewTest1MenuItemCommand:
			commandHandled = HandleTest1MenuItemSelectedL( aCommand );
			break;
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
void CHelloCarbide3rdGUIContainerView::DoActivateL(
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
	
	if ( iHelloCarbide3rdGUIContainer == NULL )
		{
		iHelloCarbide3rdGUIContainer = CHelloCarbide3rdGUIContainer::NewL( ClientRect(), NULL, this );
		iHelloCarbide3rdGUIContainer->SetMopParent( this );
		AppUi()->AddToStackL( *this, iHelloCarbide3rdGUIContainer );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CHelloCarbide3rdGUIContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iHelloCarbide3rdGUIContainer != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iHelloCarbide3rdGUIContainer );
		delete iHelloCarbide3rdGUIContainer;
		iHelloCarbide3rdGUIContainer = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CHelloCarbide3rdGUIContainerView::SetupStatusPaneL()
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
		iEikonEnv->CreateResourceReaderLC( reader, R_HELLO_CARBIDE3RDGUICONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CHelloCarbide3rdGUIContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CHelloCarbide3rdGUIContainerView::HandleStatusPaneSizeChange()
	{
	CAknView::HandleStatusPaneSizeChange();
	
	// this may fail, but we're not able to propagate exceptions here
	TInt result;
	TRAP( result, SetupStatusPaneL() ); 
	}
	
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CHelloCarbide3rdGUIContainerView::HandleTest1MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
    note->SetTimeout( CAknNoteDialog::ELongTimeout  );
    TBuf<0x100> buf;
    TInt errorCode = 100;
    buf.Format( _L("HandleLoginL( %i )"), errorCode );
    note->ExecuteLD( buf );

	return ETrue;
	}
				
