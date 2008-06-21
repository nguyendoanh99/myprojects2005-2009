/*
========================================================================
 Name        : BT01_DescriptorsContainerView.cpp
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
#include <BT01_Descriptors.rsg>
// ]]] end generated region [Generated System Includes]

// [[[ begin generated region: do not modify [Generated User Includes]
#include "BT01_Descriptors.hrh"
#include "BT01_DescriptorsContainerView.h"
#include "BT01_DescriptorsContainer.hrh"
#include "BT01_DescriptorsContainer.h"
// ]]] end generated region [Generated User Includes]

// [[[ begin generated region: do not modify [Generated Constants]
// ]]] end generated region [Generated Constants]
#include <aknnotewrappers.h> 
/**
 * First phase of Symbian two-phase construction. Should not contain any
 * code that could leave.
 */
CBT01_DescriptorsContainerView::CBT01_DescriptorsContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	iBT01_DescriptorsContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}
/** 
 * The view's destructor removes the container from the control
 * stack and destroys it.
 */
CBT01_DescriptorsContainerView::~CBT01_DescriptorsContainerView()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	delete iBT01_DescriptorsContainer;
	iBT01_DescriptorsContainer = NULL;
	// ]]] end generated region [Generated Contents]
	
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance then calls the second-phase constructor
 * without leaving the instance on the cleanup stack.
 * @return new instance of CBT01_DescriptorsContainerView
 */
CBT01_DescriptorsContainerView* CBT01_DescriptorsContainerView::NewL()
	{
	CBT01_DescriptorsContainerView* self = CBT01_DescriptorsContainerView::NewLC();
	CleanupStack::Pop( self );
	return self;
	}

/**
 * Symbian two-phase constructor.
 * This creates an instance, pushes it on the cleanup stack,
 * then calls the second-phase constructor.
 * @return new instance of CBT01_DescriptorsContainerView
 */
CBT01_DescriptorsContainerView* CBT01_DescriptorsContainerView::NewLC()
	{
	CBT01_DescriptorsContainerView* self = new ( ELeave ) CBT01_DescriptorsContainerView();
	CleanupStack::PushL( self );
	self->ConstructL();
	return self;
	}


/**
 * Second-phase constructor for view.  
 * Initialize contents from resource.
 */ 
void CBT01_DescriptorsContainerView::ConstructL()
	{
	// [[[ begin generated region: do not modify [Generated Code]
	BaseConstructL( R_BT01_DESCRIPTORS_CONTAINER_BT01_DESCRIPTORS_CONTAINER_VIEW );
	// ]]] end generated region [Generated Code]
	
	// add your own initialization code here
	}
	
/**
 * @return The UID for this view
 */
TUid CBT01_DescriptorsContainerView::Id() const
	{
	return TUid::Uid( EBT01_DescriptorsContainerViewId );
	}

/**
 * Handle a command for this view (override)
 * @param aCommand command id to be handled
 */
void CBT01_DescriptorsContainerView::HandleCommandL( TInt aCommand )
	{   
	// [[[ begin generated region: do not modify [Generated Code]
	TBool commandHandled = EFalse;
	switch ( aCommand )
		{	// code to dispatch to the AknView's menu and CBA commands is generated here
		case EBT01_DescriptorsContainerViewExample_1MenuItemCommand:
			commandHandled = HandleExample_1MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_2MenuItemCommand:
			commandHandled = HandleExample_2MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_3MenuItemCommand:
			commandHandled = HandleExample_3MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_4MenuItemCommand:
			commandHandled = HandleExample_4MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_5MenuItemCommand:
			commandHandled = HandleExample_5MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_6MenuItemCommand:
			commandHandled = HandleExample_6MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_7MenuItemCommand:
			commandHandled = HandleExample_7MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_8MenuItemCommand:
			commandHandled = HandleExample_8MenuItemSelectedL( aCommand );
			break;
		case EBT01_DescriptorsContainerViewExample_9MenuItemCommand:
			commandHandled = HandleExample_9MenuItemSelectedL( aCommand );
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
void CBT01_DescriptorsContainerView::DoActivateL(
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
	
	if ( iBT01_DescriptorsContainer == NULL )
		{
		iBT01_DescriptorsContainer = CBT01_DescriptorsContainer::NewL( ClientRect(), NULL, this );
		iBT01_DescriptorsContainer->SetMopParent( this );
		AppUi()->AddToStackL( *this, iBT01_DescriptorsContainer );
		} 
	// ]]] end generated region [Generated Contents]
	
	}

/**
 */
void CBT01_DescriptorsContainerView::DoDeactivate()
	{
	// [[[ begin generated region: do not modify [Generated Contents]
	CleanupStatusPane();
	
	CEikButtonGroupContainer* cba = AppUi()->Cba();
	if ( cba != NULL ) 
		{
		cba->MakeVisible( ETrue );
		cba->DrawDeferred();
		}
	
	if ( iBT01_DescriptorsContainer != NULL )
		{
		AppUi()->RemoveFromViewStack( *this, iBT01_DescriptorsContainer );
		delete iBT01_DescriptorsContainer;
		iBT01_DescriptorsContainer = NULL;
		}
	// ]]] end generated region [Generated Contents]
	
	}

// [[[ begin generated function: do not modify
void CBT01_DescriptorsContainerView::SetupStatusPaneL()
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
		iEikonEnv->CreateResourceReaderLC( reader, R_BT01_DESCRIPTORS_CONTAINER_TITLE_RESOURCE );
		title->SetFromResourceL( reader );
		CleanupStack::PopAndDestroy(); // reader internal state
		}
				
	}
// ]]] end generated function

// [[[ begin generated function: do not modify
void CBT01_DescriptorsContainerView::CleanupStatusPane()
	{
	}
// ]]] end generated function

/** 
 * Handle status pane size change for this view (override)
 */
void CBT01_DescriptorsContainerView::HandleStatusPaneSizeChange()
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
TBool CBT01_DescriptorsContainerView::HandleExample_1MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	// Getting TPtrC from TBufC or TBuf
	_LIT(KText, "Example 1");
	TBufC<10> Buf(KText);
//	TBuf<10> Buf(KText);
	TPtrC Ptr(Buf);
	TPtrC Ptr1;
	Ptr1.Set(Buf);	
	
//	XuatChuoi(Buf);
//	XuatChuoi(Ptr);

	TBufC<0x100> temp(_L("Buf: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(Buf);
	chuoi.Append(_L("\nPtr: "));
	chuoi.Append(Ptr);
	chuoi.Append(_L("\nPtr1: "));
	chuoi.Append(Ptr1);
	XuatChuoi(chuoi);
	
	return ETrue;
	}
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_2MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	TText* text = _S("Example 2\n");
	TPtrC ptr(text);
	TPtrC ptr1;
	ptr1.Set(text);
	TPtrC ptr2(text, 5);
	
//	XuatChuoi(ptr);
//	XuatChuoi(ptr1);
//	XuatChuoi(ptr2);
	
	TBufC<0x100> temp(_L("ptr: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(ptr);
	chuoi.Append(_L("\nptr1: "));
	chuoi.Append(ptr1);
	chuoi.Append(_L("\nptr2: "));
	chuoi.Append(ptr2);
	XuatChuoi(chuoi);	

	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_3MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	TText* text = _S("Example 3\n");
	TPtrC ptr(text);
	TPtrC p1(ptr);
	TPtrC p2;
	p2.Set(ptr);
	
//	XuatChuoi(p2);
	
	TBufC<0x100> temp(_L("ptr: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(ptr);
	chuoi.Append(_L("\np1: "));
	chuoi.Append(p1);
	chuoi.Append(_L("\np2: "));
	chuoi.Append(p2);
	XuatChuoi(chuoi);
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_4MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	
	_LIT(KText, "Example 4");
	TBufC<10> Buf(KText);
	TPtrC Ptr1(Buf);
	TText* Text1 = (TText*)Ptr1.Ptr();
	
	TPtrC chuoi1;
	chuoi1.Set(Text1);
//	XuatChuoi(chuoi);
	TBufC<0x100> temp(_L("Buf: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(Buf);
	chuoi.Append(_L("\nPtr1: "));
	chuoi.Append(Ptr1);
	chuoi.Append(_L("\nText1: "));
	chuoi.Append(chuoi1);
	XuatChuoi(chuoi);
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_5MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler

	_LIT(KText, "Example 5");
	TBufC<10> buf(KText);
	TBufC<10> buf2;
	buf2 = KText;
	TBufC<10> buf3(buf2);
	
//	XuatChuoi(buf3);
	TBufC<0x100> temp(_L("buf: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(buf);
	chuoi.Append(_L("\nbuf2: "));
	chuoi.Append(buf2);
	chuoi.Append(_L("\nbuf3: "));
	chuoi.Append(buf3);
	XuatChuoi(chuoi);
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_6MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	_LIT(KText, "Example 6");
	_LIT(KText1, "6Example");
	
	TBufC<10> Buf1(KText);
	TBufC<10> Buf2(KText1);
	
	Buf2 = Buf1;
	
	TBufC<10> Buf3;
	Buf3 = Buf1;
	
//	XuatChuoi(Buf3);
	TBufC<0x100> temp(_L("Buf1: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(Buf1);
	chuoi.Append(_L("\nBuf2: "));
	chuoi.Append(Buf2);
	chuoi.Append(_L("\nBuf3: "));
	chuoi.Append(Buf3);
	XuatChuoi(chuoi);
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_7MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	_LIT(KText, "Example 7");
	_LIT(KXtraText, "New:");
	TBufC<10> Buf1 (KText);
	TPtr Pointer = Buf1.Des();
	Pointer.Delete(Pointer.Length() - 4, 4);
	
	TInt Len = Pointer.Length();
	
	Pointer.Append(KXtraText);
	Len = Pointer.Length();
	 
	_LIT(NewText, "New1");
	_LIT(NewText1, "New2");
	
//	Pointer.Copy(Buf2);
	Pointer.Copy(NewText1);
	
//	XuatChuoi(Buf1);
	TBufC<0x100> temp(_L("Buf1: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(Buf1);
	chuoi.Append(_L("\nPointer: "));
	chuoi.Append(Pointer);
	XuatChuoi(chuoi);
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_8MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	HBufC* Buf = HBufC::NewL(15);
	CleanupStack::PushL(Buf);
	_LIT(KText, "Example 8");
	TBufC<10> CBuf;
	CBuf = KText;
	HBufC* Buf1 = CBuf.AllocL();
	CleanupStack::PushL(Buf1);
	TInt BufSize = Buf->Size();
	TInt BufLength = Buf->Length();
	
	_LIT(KText1, "Text1");
	*Buf1 = KText1;
	
	TPtr Pointer = Buf1->Des();
	Pointer.Delete(Pointer.Length() - 2, 2);
	_LIT(KNew, "New:");
	Pointer.Append(KNew);
		
//	XuatChuoi(Pointer);
	TBufC<0x100> temp(_L("Pointer: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(Pointer);
	XuatChuoi(chuoi);
	CleanupStack::PopAndDestroy();
	CleanupStack::PopAndDestroy();
	return ETrue;
	}
				
/** 
 * Handle the selected event.
 * @param aCommand the command id invoked
 * @return ETrue if the command was handled, EFalse if not
 */
TBool CBT01_DescriptorsContainerView::HandleExample_9MenuItemSelectedL( TInt aCommand )
	{
	// TODO: implement selected event handler
	
	_LIT(KText, "Example10"); 
	TBufC<10> NBuf ( KText ); 
	TPtr Pointer = NBuf.Des(); 
	         
	TPtr Pointer2 ( Pointer ); 
	         
	TText* Text = _S("Test Second"); 
	TPtr Pointer3 ( Text ,11, 12); 
	         
	_LIT(K1, "Text1"); 
	_LIT(K2, "Text2");          
	Pointer2 = K1;
	Pointer.Copy(K2); 

	Pointer2.SetLength(2); 
	Pointer2.Zero(); 
	
//	XuatChuoi(NBuf);
	TBufC<0x100> temp(_L("NBuf: "));
	TPtr chuoi = temp.Des();
	chuoi.Append(NBuf);
	chuoi.Append(_L("\nPointer: "));
	chuoi.Append(Pointer);
	chuoi.Append(_L("\nPointer2: "));
	chuoi.Append(Pointer2);
	chuoi.Append(_L("\nPointer3: "));
	chuoi.Append(Pointer3);
	XuatChuoi(chuoi);
	return ETrue;
	}
				
