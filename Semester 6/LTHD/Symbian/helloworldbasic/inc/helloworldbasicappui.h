/* Copyright (c) 2004, Nokia. All rights reserved */


#ifndef __HELLOWORLDBASICAPPUI_H__
#define __HELLOWORLDBASICAPPUI_H__

// INCLUDES
#include <aknappui.h>


// FORWARD DECLARATIONS
class CHelloWorldBasicAppView;


// CLASS DECLARATION
/**
* CHelloWorldBasicAppUi application UI class.
* Interacts with the user through the UI and request message processing
* from the handler class
*/
class CHelloWorldBasicAppUi : public CAknAppUi
    {
    public: // Constructors and destructor

        /**
        * ConstructL.
        * 2nd phase constructor.
        */
        void ConstructL();

        /**
        * CHelloWorldBasicAppUi.
        * C++ default constructor. This needs to be public due to
        * the way the framework constructs the AppUi
        */
        CHelloWorldBasicAppUi();

        /**
        * ~CHelloWorldBasicAppUi.
        * Virtual Destructor.
        */
        virtual ~CHelloWorldBasicAppUi();

    public:  // Functions from base classes

        /**
        * From CEikAppUi, HandleCommandL.
        * Takes care of command handling.
        * @param aCommand Command to be handled.
        */
        void HandleCommandL( TInt aCommand );

    private: // Data

        /**
        * The application view
        * Owned by CHelloWorldBasicAppUi
        */
        CHelloWorldBasicAppView* iAppView;
    };

#endif // __HELLOWORLDBASICAPPUI_H__

// End of File