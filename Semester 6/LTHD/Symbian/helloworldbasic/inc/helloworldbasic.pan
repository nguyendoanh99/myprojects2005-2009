/* Copyright (c) 2004, Nokia. All rights reserved */


#ifndef __HELLOWORLDBASIC_PAN__
#define __HELLOWORLDBASIC_PAN__

/** HelloWorldBasic application panic codes */
enum THelloWorldBasicPanics
    {
    EHelloWorldBasicUi = 1
    // add further panics here
    };

inline void Panic(THelloWorldBasicPanics aReason)
    {
    _LIT(applicationName,"HelloWorldBasic");
    User::Panic(applicationName, aReason);
    }

#endif // __HELLOWORLDBASIC_PAN__
