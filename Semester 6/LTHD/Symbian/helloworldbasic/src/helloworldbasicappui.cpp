/* Copyright (c) 2004, Nokia. All rights reserved */

// INCLUDE FILES
#include <avkon.hrh>
#include <aknnotewrappers.h>
#include <stringloader.h>
#include <HelloWorldBasic.rsg>

#include "HelloWorldBasic.pan"
#include "HelloWorldBasicAppUi.h"
#include "HelloWorldBasicAppView.h"
#include "HelloWorldBasic.hrh"

// ============================ MEMBER FUNCTIONS ===============================


// -----------------------------------------------------------------------------
// CHelloWorldBasicAppUi::ConstructL()
// Symbian 2nd phase constructor can leave.
// -----------------------------------------------------------------------------
//
void CHelloWorldBasicAppUi::ConstructL()
    {
    // Initialise app UI with standard value.
    BaseConstructL();

    // Create view object
    iAppView = CHelloWorldBasicAppView::NewL( ClientRect() );
    }

// -----------------------------------------------------------------------------
// CHelloWorldBasicAppUi::CHelloWorldBasicAppUi()
// C++ default constructor can NOT contain any code, that might leave.
// -----------------------------------------------------------------------------
//
CHelloWorldBasicAppUi::CHelloWorldBasicAppUi()
    {
    // No implementation required
    }

// -----------------------------------------------------------------------------
// CHelloWorldBasicAppUi::~CHelloWorldBasicAppUi()
// Destructor.
// -----------------------------------------------------------------------------
//
CHelloWorldBasicAppUi::~CHelloWorldBasicAppUi()
    {
    if ( iAppView )
        {
        delete iAppView;
        iAppView = NULL;
        }
    }

// -----------------------------------------------------------------------------
// CHelloWorldBasicAppUi::HandleCommandL()
// Takes care of command handling.
// -----------------------------------------------------------------------------
//
void CHelloWorldBasicAppUi::HandleCommandL( TInt aCommand )
    {
    switch( aCommand )
        {
        case EEikCmdExit:
        case EAknSoftkeyExit:
            Exit();
            break;

        case EHelloWorldBasicCommand1:
            {
            // Load a string from the resource file and display it
            HBufC* textResource = StringLoader::LoadLC( R_HEWB_COMMAND1_TEXT );
            CAknInformationNote* informationNote;

            informationNote = new ( ELeave ) CAknInformationNote;

            // Show the information Note with
            // textResource loaded with StringLoader.
            informationNote->ExecuteLD( *textResource);

            // Pop HBuf from CleanUpStack and Destroy it.
            CleanupStack::PopAndDestroy( textResource );
            }
            break;

        default:
            Panic( EHelloWorldBasicUi );
            break;
        }
    }

// End of File