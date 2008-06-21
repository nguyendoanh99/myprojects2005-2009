/*
========================================================================
 Name        : HelloCarbide2ndGUIContainerView.cpp
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
#include <HelloCarbide2ndGUI.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "HelloCarbide2ndGUI.hrh"
#include "HelloCarbide2ndGUIContainerView.h"
#include "HelloCarbide2ndGUIContainer.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]

/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CHelloCarbide2ndGUIContainerView::CHelloCarbide2ndGUIContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iHelloCarbide2ndGUIContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CHelloCarbide2ndGUIContainerView::~CHelloCarbide2ndGUIContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iHelloCarbide2ndGUIContainer;
	iHelloCarbide2ndGUIContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CHelloCarbide2ndGUIContainerView
 */
CHelloCarbide2ndGUIContainerView* CHelloCarbide2ndGUIContainerView::NewL()
	{
	CHelloCarbide2ndGUIContainerView* self = CHelloCarbide2ndGUIContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CHelloCarbide2ndGUIContainerView
 */
CHelloCarbide2ndGUIContainerView* CHelloCarbide2ndGUIContainerView::NewLC()
	{
	CHelloCarbide2ndGUIContainerView* self = new ( ELeave ) CHelloCarbide2ndGUIContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CHelloCarbide2ndGUIContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_HELLO_CARBIDE2NDGUICONTAINER_HELLO_CARBIDE2NDGUICONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CHelloCarbide2ndGUIContainerView::Id() const
	{
	return TUid::Uid( EHelloCarbide2ndGUIContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CHelloCarbide2ndGUIContainerView::HandleCommandL( TInt aCommand )
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
void CHelloCarbide2ndGUIContainerView::DoActivateL(
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
	
	if ( iHelloCarbide2ndGUIContainer == NULL )
		{
		iHelloCarbide2ndGUIContainer = CHelloCarbide2ndGUIContainer::NewL( ClientRect(), NULL, this );
		iHelloCarbide2ndGUIContainer->SetMopParent( this );
		AppUi()->AddToStackL( *this, iHelloCarbide2ndGUIContainer );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CHelloCarbide2ndGUIContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iHelloCarbide2ndGUIContainer != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iHelloCarbide2ndGUIContainer );
		delete iHelloCarbide2ndGUIContainer;
		iHelloCarbide2ndGUIContainer = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CHelloCarbide2ndGUIContainerView::SetupStatusPaneL()
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
		iEikonEnv->CreateResourceReaderLC( reader, R_HELLO_CARBIDE2NDGUICONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CHelloCarbide2ndGUIContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CHelloCarbide2ndGUIContainerView::HandleStatusPaneSizeChange()
	{
	CAknView::HandleStatusPaneSizeChange();
	
	// this may fail, but we're not able to propagate exceptions here
	TInt result;
	TRAP( result, SetupStatusPaneL() ); 
	}
	
