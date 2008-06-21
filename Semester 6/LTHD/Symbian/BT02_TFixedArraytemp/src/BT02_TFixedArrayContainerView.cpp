/*
========================================================================
 Name        : BT02_TFixedArrayContainerView.cpp
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
#include <BT02_TFixedArray.rsg>

// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "BT02_TFixedArray.hrh"
#include "BT02_TFixedArrayContainerView.h"
#include "BT02_TFixedArrayContainer.hrh"
#include "BT02_TFixedArrayContainer.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]
#include "TDiem.h"
/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CBT02_TFixedArrayContainerView::CBT02_TFixedArrayContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iBT02_TFixedArrayContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CBT02_TFixedArrayContainerView::~CBT02_TFixedArrayContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iBT02_TFixedArrayContainer;
	iBT02_TFixedArrayContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CBT02_TFixedArrayContainerView
 */
CBT02_TFixedArrayContainerView* CBT02_TFixedArrayContainerView::NewL()
	{
	CBT02_TFixedArrayContainerView* self = CBT02_TFixedArrayContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CBT02_TFixedArrayContainerView
 */
CBT02_TFixedArrayContainerView* CBT02_TFixedArrayContainerView::NewLC()
	{
	CBT02_TFixedArrayContainerView* self = new ( ELeave ) CBT02_TFixedArrayContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CBT02_TFixedArrayContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_BT02_TFIXED_ARRAY_CONTAINER_BT02_TFIXED_ARRAY_CONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CBT02_TFixedArrayContainerView::Id() const
	{
	return TUid::Uid( EBT02_TFixedArrayContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CBT02_TFixedArrayContainerView::HandleCommandL( TInt aCommand )
	{   
	// [[[ begin generated region: do not modify [Generated Code]
	TBool commandHandled = EFalse;
	switch ( aCommand )
		{	// code to dispatch to the AknView's menu and CBA commands is generated here
		case EBT02_TFixedArrayContainerViewKtao_Sap_xepMenuItemCommand:
			commandHandled = HandleKtao_Sap_xepMenuItemSelectedL( aCommand );
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
void CBT02_TFixedArrayContainerView::DoActivateL(
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
	
	if ( iBT02_TFixedArrayContainer == NULL )
		{
		iBT02_TFixedArrayContainer = CBT02_TFixedArrayContainer::NewL( ClientRect(), NULL, this );
		iBT02_TFixedArrayContainer->SetMopParent( this );
		AppUi()->AddToStackL( *this, iBT02_TFixedArrayContainer );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CBT02_TFixedArrayContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iBT02_TFixedArrayContainer != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iBT02_TFixedArrayContainer );
		delete iBT02_TFixedArrayContainer;
		iBT02_TFixedArrayContainer = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CBT02_TFixedArrayContainerView::SetupStatusPaneL()
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
		iEikonEnv->CreateResourceReaderLC( reader, R_BT02_TFIXED_ARRAY_CONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CBT02_TFixedArrayContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CBT02_TFixedArrayContainerView::HandleStatusPaneSizeChange()
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
TBool CBT02_TFixedArrayContainerView::HandleKtao_Sap_xepMenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	
	TFixedArray<TDiem, 10> MangDiem;
	MangDiem[0].Gan(9, 1);
	MangDiem[1].Gan(8, 2);
	MangDiem[2].Gan(7, 3);
	MangDiem[3].Gan(6, 4);
	MangDiem[4].Gan(5, 5);
	MangDiem[5].Gan(4, 6);
	MangDiem[6].Gan(3, 7);
	MangDiem[7].Gan(2, 8);
	MangDiem[8].Gan(1, 9);
	MangDiem[9].Gan(0, 10);
	
	for (int i = 0; i < 10; i++)
	{	
		for (int j = i + 1; j < 10; j++)
			if (MangDiem[i].DiemX() < MangDiem[j].DiemX())
			{
				TDiem temp;
				temp.Gan(MangDiem[i].DiemX(), MangDiem[i].DiemY());
				MangDiem[i].Gan(MangDiem[j].DiemX(), MangDiem[j].DiemY());
				MangDiem[j].Gan(temp.DiemX(), temp.DiemY());
			}
	}
		
	return ETrue;
	
	}
				
