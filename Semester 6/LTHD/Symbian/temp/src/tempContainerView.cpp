/*
========================================================================
 Name        : tempContainerView.cpp
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
#include <temp.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "temp.hrh"
#include "tempContainerView.h"
#include "tempContainer.hrh"
#include "tempContainer.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]
#include <aknnotewrappers.h> 
#include "TDiem.h"
#include "CDuongTron.h"
/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CtempContainerView::CtempContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iTempContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CtempContainerView::~CtempContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iTempContainer;
	iTempContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CtempContainerView
 */
CtempContainerView* CtempContainerView::NewL()
	{
	CtempContainerView* self = CtempContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CtempContainerView
 */
CtempContainerView* CtempContainerView::NewLC()
	{
	CtempContainerView* self = new ( ELeave ) CtempContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CtempContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_TEMP_CONTAINER_TEMP_CONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CtempContainerView::Id() const
	{
	return TUid::Uid( ETempContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CtempContainerView::HandleCommandL( TInt aCommand )
	{   
	// [[[ begin generated region: do not modify [Generated Code]
	TBool commandHandled = EFalse;
	switch ( aCommand )
		{	// code to dispatch to the AknView's menu and CBA commands is generated here
		case ETempContainerView_10_TDiemMenuItemCommand:
			commandHandled = Handle_10_TDiemMenuItemSelectedL( aCommand );
			break;
		case ETempContainerView_10_CDuongTronMenuItemCommand:
			commandHandled = Handle_10_CDuongTronMenuItemSelectedL( aCommand );
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
void CtempContainerView::DoActivateL(
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
	
	if ( iTempContainer == NULL )
		{
		iTempContainer = CTempContainer::NewL( ClientRect(), NULL, this );
		iTempContainer->SetMopParent( this );
		AppUi()->AddToStackL( *this, iTempContainer );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CtempContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iTempContainer != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iTempContainer );
		delete iTempContainer;
		iTempContainer = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CtempContainerView::SetupStatusPaneL()
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
		iEikonEnv->CreateResourceReaderLC( reader, R_TEMP_CONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CtempContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CtempContainerView::HandleStatusPaneSizeChange()
	{
	CAknView::HandleStatusPaneSizeChange();
	
	// this may fail, but we're not able to propagate exceptions here
	TInt result;
	TRAP( result, SetupStatusPaneL() ); 
	}
void XuatChuoi(const TDesC &  aPrompt )
	{
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
	note->SetTimeout( CAknNoteDialog::ELongTimeout  );
	note->ExecuteLD( aPrompt );
	}
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CtempContainerView::Handle_10_TDiemMenuItemSelectedL( TInt aCommand )
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
	
	for (TInt i = 0; i < 10; i++)
	{	
		for (TInt j = i + 1; j < 10; j++)
			if (MangDiem[i].DiemX() > MangDiem[j].DiemX())
			{
				TDiem temp;
				temp.Gan(MangDiem[i].DiemX(), MangDiem[i].DiemY());
				MangDiem[i].Gan(MangDiem[j].DiemX(), MangDiem[j].DiemY());
				MangDiem[j].Gan(temp.DiemX(), temp.DiemY());
			}
	}
	TBuf<100> buf;   
    
	TBufC<0x100> temp(_L("Mang sau khi sap xep: \n"));
	TPtr chuoi = temp.Des();
	for (int k = 0; k < 10; ++k)
		{
		buf.Format( _L("TDiem(%d, %d)\n"), MangDiem[k].DiemX(), MangDiem[k].DiemY());
		chuoi.Append(buf);
		}
	XuatChuoi(chuoi);
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CtempContainerView::Handle_10_CDuongTronMenuItemSelectedL( TInt aCommand )
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
	
	TFixedArray<CDuongTron*, 10> MangDuongTron;
	CDuongTron* ptr = NULL;
	for (TInt ix = 0; ix < 10; ++ix)
		{
		ptr = CDuongTron::NewL(MangDiem[ix], ix + 1);
		MangDuongTron.At(ix) = ptr;
		}

	for (TInt i = 0; i < 10; i++)
	{	
		for (TInt j = i + 1; j < 10; j++)
			if (MangDuongTron[i]->LayBanKinh() < MangDuongTron[j]->LayBanKinh())
			{
				CDuongTron* temp = MangDuongTron[i];
				MangDuongTron[i] = MangDuongTron[j];
				MangDuongTron[j] = temp;
			}
	}
	
	TBuf<100> buf;   
    
	TBufC<0x100> temp(_L("Mang sau khi sap xep: \n"));
	TPtr chuoi = temp.Des();
	for (int k = 0; k < 10; ++k)
		{
		TDiem* temp = MangDuongTron[k]->LayTam();
		buf.Format( _L("((%d, %d), %d)\n"), temp->DiemX(), temp->DiemY(), MangDuongTron[k]->LayBanKinh());
		chuoi.Append(buf);
		}
	XuatChuoi(chuoi);

	// Now delete all the CTest objects
	MangDuongTron.DeleteAll();
	MangDuongTron.Reset();

	return ETrue;
	}
				
