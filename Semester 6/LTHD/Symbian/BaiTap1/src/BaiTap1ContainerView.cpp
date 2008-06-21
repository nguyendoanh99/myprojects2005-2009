/*
========================================================================
 Name        : BaiTap1ContainerView.cpp
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
#include <BaiTap1.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "BaiTap1.hrh"
#include "BaiTap1ContainerView.h"
#include "BaiTap1Container.hrh"
#include "BaiTap1Container.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]
#include <aknnotewrappers.h> 
#include "TDiem.h"
#include "CDuongTron.h"
#include "CTamGiac.h"
/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CBaiTap1ContainerView::CBaiTap1ContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iBaiTap1Container = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CBaiTap1ContainerView::~CBaiTap1ContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iBaiTap1Container;
	iBaiTap1Container = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CBaiTap1ContainerView
 */
CBaiTap1ContainerView* CBaiTap1ContainerView::NewL()
	{
	CBaiTap1ContainerView* self = CBaiTap1ContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CBaiTap1ContainerView
 */
CBaiTap1ContainerView* CBaiTap1ContainerView::NewLC()
	{
	CBaiTap1ContainerView* self = new ( ELeave ) CBaiTap1ContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CBaiTap1ContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_BAI_TAP1_CONTAINER_BAI_TAP1_CONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CBaiTap1ContainerView::Id() const
	{
	return TUid::Uid( EBaiTap1ContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CBaiTap1ContainerView::HandleCommandL( TInt aCommand )
	{   
	// [[[ begin generated region: do not modify [Generated Code]
	TBool commandHandled = EFalse;
	switch ( aCommand )
		{	// code to dispatch to the AknView's menu and CBA commands is generated here
		case EBaiTap1ContainerViewTinh_khoang_cachMenuItemCommand:
			commandHandled = HandleTinh_khoang_cachMenuItemSelectedL( aCommand );
			break;
		case EBaiTap1ContainerViewChu_vi_dien_tich_HCNMenuItemCommand:
			commandHandled = HandleChu_vi_dien_tich_HCNMenuItemSelectedL( aCommand );
			break;
		case EBaiTap1ContainerViewChu_vi_dien_tich_duong_tronMenuItemCommand:
			commandHandled = HandleChu_vi_dien_tich_duong_tronMenuItemSelectedL( aCommand );
			break;
		case EBaiTap1ContainerViewTao_doi_tuong_tam_giacMenuItemCommand:
			commandHandled = HandleTao_doi_tuong_tam_giacMenuItemSelectedL( aCommand );
			break;
		case EBaiTap1ContainerViewTao_doi_tuong_duong_tronMenuItemCommand:
			commandHandled = HandleTao_doi_tuong_duong_tronMenuItemSelectedL( aCommand );
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
void CBaiTap1ContainerView::DoActivateL(
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
	
	if ( iBaiTap1Container == NULL )
		{
		iBaiTap1Container = CBaiTap1Container::NewL( ClientRect(), NULL, this );
		iBaiTap1Container->SetMopParent( this );
		AppUi()->AddToStackL( *this, iBaiTap1Container );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CBaiTap1ContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iBaiTap1Container != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iBaiTap1Container );
		delete iBaiTap1Container;
		iBaiTap1Container = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CBaiTap1ContainerView::SetupStatusPaneL()
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
		iEikonEnv->CreateResourceReaderLC( reader, R_BAI_TAP1_CONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CBaiTap1ContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CBaiTap1ContainerView::HandleStatusPaneSizeChange()
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
TBool CBaiTap1ContainerView::HandleTinh_khoang_cachMenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
    note->SetTimeout( CAknNoteDialog::ELongTimeout  );
    TBuf<0x100> buf;
    
    TDiem A(1, 1);
    TDiem B(4, 5);

    TReal errorCode = A.KhoangCach(B);;

    buf.Format( _L("Khoang cach tu A(1, 1) den B(4, 5) la %.2f"), errorCode );
    note->ExecuteLD( buf );

	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBaiTap1ContainerView::HandleChu_vi_dien_tich_HCNMenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
    note->SetTimeout( CAknNoteDialog::ELongTimeout  );
    TBuf<0x100> buf;
    
    TDiem A(0, 3);
    TDiem B(4, 0);
    TDiem C(0, 0);
    CTamGiac* tg = CTamGiac::NewLC(A, B, C);
    buf.Format( _L("Tam giac ((0, 3), (4,0), (0,0)) co\nChu vi %.2f\nDien tich %.2f"), tg->ChuVi(), tg->DienTich());
    CleanupStack::PopAndDestroy();
    note->ExecuteLD( buf );

	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBaiTap1ContainerView::HandleChu_vi_dien_tich_duong_tronMenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
    note->SetTimeout( CAknNoteDialog::ELongTimeout  );
    TBuf<0x100> buf;
    
    TDiem C(0, 0);
    CDuongTron* dt = CDuongTron::NewLC(C, 3);
    buf.Format( _L("Duong tron ((0,0), 3) co \nChu vi %.2f\nDien tich %.2f"), dt->ChuVi(), dt->DienTich());
    CleanupStack::PopAndDestroy();
    note->ExecuteLD( buf );
	return ETrue;
	}
void testTamGiacL() {
	TDiem A(1, 2);
	TDiem B(2, 3);
	TDiem C(4, 5);
	CTamGiac* myExample = CTamGiac::NewLC(A, B, C);
	myExample->TaoLoiL();
	CleanupStack::PopAndDestroy();
}				

/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBaiTap1ContainerView::HandleTao_doi_tuong_tam_giacMenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	TRAPD(error, testTamGiacL());
	// Do some error code
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
    note->SetTimeout( CAknNoteDialog::ELongTimeout  );
    TBuf<0x100> buf;

	if(error != KErrNone) {
		buf.Format( _L("Loi tai ham TaoLoiL"));
	}
	else
	{
		buf.Format( _L("Thuc thi thanh cong"));
	}
    note->ExecuteLD( buf );
	return ETrue;
	}
void doTestDuongTronL() {
	TDiem A(0, 0);
	CDuongTron* myExample = CDuongTron::NewLC(A, 4);
	myExample->TaoLoiL();
	CleanupStack::PopAndDestroy();
}		/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBaiTap1ContainerView::HandleTao_doi_tuong_duong_tronMenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	TRAPD(error, doTestDuongTronL());
	// Do some error code
	CAknInformationNote* note = new (ELeave) CAknInformationNote( EFalse );
    note->SetTimeout( CAknNoteDialog::ELongTimeout  );
    TBuf<0x100> buf;

	if(error != KErrNone) {
		buf.Format( _L("Loi tai ham TaoLoiL"));
	}
	else
	{
		buf.Format( _L("Thuc thi thanh cong"));
	}
    note->ExecuteLD( buf );
	return ETrue;
	}
				
