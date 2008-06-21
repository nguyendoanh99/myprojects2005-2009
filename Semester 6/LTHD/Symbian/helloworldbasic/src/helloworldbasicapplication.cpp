/* Copyright (c) 2004, Nokia. All rights reserved */


// INCLUDE FILES
#include "HelloWorldBasicDocument.h"
#include "HelloWorldBasicApplication.h"

// ============================ MEMBER FUNCTIONS ===============================

// UID for the application;
// this should correspond to the uid defined in the mmp file
const TUid KUidHelloWorldBasicApp = { 0x10005B91 };

// -----------------------------------------------------------------------------
// CHelloWorldBasicApplication::CreateDocumentL()
// Creates CApaDocument object
// -----------------------------------------------------------------------------
//
CApaDocument* CHelloWorldBasicApplication::CreateDocumentL()
    {
    // Create an HelloWorldBasic document, and return a pointer to it
    return (static_cast<CApaDocument*>
                    ( CHelloWorldBasicDocument::NewL( *this ) ) );
    }

// -----------------------------------------------------------------------------
// CHelloWorldBasicApplication::AppDllUid()
// Returns application UID
// -----------------------------------------------------------------------------
//
TUid CHelloWorldBasicApplication::AppDllUid() const
    {
    // Return the UID for the HelloWorldBasic application
    return KUidHelloWorldBasicApp;
    }

// End of File